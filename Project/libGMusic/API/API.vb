Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.Encoding
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

Imports ProtoBuf
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports NAudio.Wave

Imports libGMusic.Auth
Imports libGMusic.Http
Imports libGMusic.Http.GoogleHttp
Imports libGMusic.Model
Imports libGMusic.Model.Uits


Namespace API
    Public Class API
        Private Enum HttpType
            NULL
            MUSIC_MANAGER
            WEB
        End Enum
        '==================================================
        Public WriteOnly Property SetSendEvent As Action(Of Long, Long, Integer, String)
            Set(value As Action(Of Long, Long, Integer, String))
                _SendEvent = value
            End Set
        End Property
        Public WriteOnly Property SetReceiveEvent As Action(Of Long, Long, Integer, String)
            Set(value As Action(Of Long, Long, Integer, String))
                _ReceiveEvent = value
            End Set
        End Property
        '==================================================
        Private _ReceiveEvent As Action(Of Long, Long, Integer, String)
        Private _SendEvent As Action(Of Long, Long, Integer, String)

        Private Auth As MasterAuth
        Private Http As GoogleHttp

        Private BaseUrl As String = "https://play.google.com/music/services/"
        Private AndroidBaseUrl As String = "https://android.clients.google.com/upsj/"
        Private Type As HttpType = HttpType.NULL
        '==================================================
        Sub New(MasterAuth As MasterAuth)
            Auth = MasterAuth
        End Sub
        Public Async Function AddTrack(FilePath As String, Optional Overwrite As Boolean = False) As Task(Of AddTracksResponse)
            Return Await AddTracks({FilePath}, Overwrite)
        End Function
        Public Async Function AddTracks(FilePath As IEnumerable(Of String), Optional Overwrite As Boolean = False) As Task(Of AddTracksResponse)
            SwitchToMMHttp()

            Dim Response As AddTracksResponse = New AddTracksResponse
            Response.response = New AddTracksResponse.Field

            Dim UploadResponse As RelatedToUploadResponse
            UploadResponse = Await UploadAuthorization()
            If UploadResponse.status = False Then
                Response.status = False
                Response.description = UploadResponse.description

                Return Response
            End If

            Await CancelExisitingJobs()

            UploadResponse = Await UpdateUploadState(UpdateUploadStateRequest.UploadState.START)
            If UploadResponse.status = False Then
                Response.status = False
                Response.description = UploadResponse.description

                Return Response
            End If

            Dim Request As List(Of AddTracksRequest) = New List(Of AddTracksRequest)
            Dim Item As AddTracksRequest
            For Each File As String In FilePath
                Item = New AddTracksRequest
                Item.filepath = File
                Item.metadata = GetTrackMetadata(File)
                Request.Add(Item)
            Next

            UploadResponse = Await UploadMetadata(Request.Select(Function(Func) Func.metadata))
            If UploadResponse.status = False Then
                Response.status = False
                Response.description = UploadResponse.description

                Return Response
            End If

            For Each Item In Request
                Item.sci = UploadResponse.response.metadata_response.signed_challenge_info.SingleOrDefault(Function(Func) Func.challenge_info.client_track_id = Item.metadata.client_id)
                If Item.sci Is Nothing Then
                    Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                    Failed.path = Item.filepath
                    Failed.description = "UploadMetadata Failed. - No Data"
                    Response.response.failed.Add(Failed)
                    Request.Remove(Item) : If Request.Count = 0 Then Return Response
                End If
            Next

            UploadResponse = Await UploadSample(Request)
            If UploadResponse.status = False Then
                Response.status = False
                Response.description = UploadResponse.description

                Return Response
            End If

            Dim Temp As String
            Dim AlbumArtResponse As UploadAlbumArtResponse
            For Each Item In Request
                Item.tsr = UploadResponse.response.sample_response.track_sample_response.SingleOrDefault(Function(Func) Func.client_track_id = Item.metadata.client_id)
                If Item.tsr Is Nothing Then
                    Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                    Failed.path = Item.filepath
                    Failed.description = "UploadSample Failed. - No Data"
                    Response.response.failed.Add(Failed)
                    Request.Remove(Item) : If Request.Count = 0 Then Return Response
                End If

                Temp = Path.GetTempFileName & ".png" '// 음.. 일단 포맷을 알 방법을 찾을 때 까지는 임시로 이렇게.. //
                Try
                    File.WriteAllBytes(Temp, GetAlbumArtData(Item.filepath))

                    AlbumArtResponse = Await UploadAlbumArt(Temp)
                    If AlbumArtResponse.status Then
                        If AlbumArtResponse.response.imageUrl IsNot Nothing Then
                            Item.tsr.album_art_url = AlbumArtResponse.response.imageUrl
                        End If
                    End If
                Catch ex As Exception
                End Try

                File.Delete(Temp)

                Select Case Item.tsr.response_code
                    Case TrackSampleResponse.ResponseCode.UPLOAD_REQUESTED
                        Item.session = Await GetUploadSession(Item, Request.IndexOf(Item), Request.Count)
                        If Item.session.status = False Then
                            Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                            Failed.path = Item.filepath
                            Failed.description = "GetUploadSession Failed. - No Data"
                            Response.response.failed.Add(Failed)
                            Request.Remove(Item) : If Request.Count = 0 Then Return Response
                        End If

                    Case TrackSampleResponse.ResponseCode.ALREADY_EXISTS
                        If Overwrite = False Then
                            Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                            Failed.path = Item.filepath
                            Failed.description = "UploadSample Failed. - " & Item.tsr.response_code.ToString & " / Overwrite = False"
                            Response.response.failed.Add(Failed)
                            Request.Remove(Item) : If Request.Count = 0 Then Return Response
                        Else
                            Item.retry = True
                        End If

                    Case Else
                        Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                        Failed.path = Item.filepath
                        Failed.description = "UploadSample Failed. - " & Item.tsr.response_code.ToString
                        Response.response.failed.Add(Failed)
                        Request.Remove(Item) : If Request.Count = 0 Then Return Response
                End Select
            Next

            Response.response.responses = Await UploadTrack(Request.Where(Function(Func) Func.retry = False))
            Request.RemoveAll(Function(Func) Func.retry = False)

            For Each FailedItem As UploadTrackResponse In Response.response.responses.Where(Function(Func) Func.status = False)
                Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                Failed.path = FailedItem.filePath
                Failed.description = Join(FailedItem.description.ToArray, "/")
                Response.response.failed.Add(Failed)
            Next


            If Request.Count > 0 Then
                Dim DeleteResponse As DeleteTrackResponse = Await DeleteTracks(Request.Select(Function(Func) Func.tsr.server_track_id), True)
                If DeleteResponse.status = False Then
                    For Each Item In Request
                        Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                        Failed.path = Item.filepath
                        Failed.description = "Overwrite Failed."
                        Response.response.failed.Add(Failed)
                    Next
                Else
                    Dim SecondaryResponse As AddTracksResponse = Await AddTracks(Request.Select(Function(Func) Func.filepath))
                    If SecondaryResponse.status = False Then
                        For Each Item In Request
                            Dim Failed As AddTracksResponse.Field.FailedField = New AddTracksResponse.Field.FailedField
                            Failed.path = Item.filepath
                            Failed.description = Join(SecondaryResponse.description.ToArray, "/")
                            Response.response.failed.Add(Failed)
                        Next
                    Else
                        Response.response.failed.AddRange(SecondaryResponse.response.failed)
                        Response.response.responses.AddRange(SecondaryResponse.response.responses)
                    End If
                End If
            End If

            Await UpdateUploadState(UpdateUploadStateRequest.UploadState.STOPPED)

            Return Response
        End Function
        Public Async Function AddPlaylist(Name As String, Description As String, TrackId As IEnumerable(Of String)) As Task(Of AddPlaylistResponse)
            SwitchToWebHttp()

            Dim Request As AddPlaylistRequest = New AddPlaylistRequest
            Request.sessionId = Auth.SessionId
            Request.name = Name
            Request.description = Description
            For Each Id As String In TrackId
                Request.AddTrackField(Id)
            Next

            Dim Url As String = BaseUrl & GetParameter("createplaylist", Request)

            Dim Response As AddPlaylistResponse = New AddPlaylistResponse
            Try
                Response.response = Await Http.SendRequest(Of AddPlaylistResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function AddPlaylistContent(TrackId As String, PlaylistId As String) As Task(Of AddPlaylistContentsResponse)
            Return Await AddPlaylistContents({TrackId}, PlaylistId)
        End Function
        Public Async Function AddPlaylistContents(TrackId As IEnumerable(Of String), PlaylistId As String) As Task(Of AddPlaylistContentsResponse)
            SwitchToWebHttp()

            Dim Request As AddPlaylistContentsRequest = New AddPlaylistContentsRequest
            Request.sessionId = Auth.SessionId
            Request.songIds = TrackId
            Request.listId = PlaylistId

            Dim Url As String = BaseUrl & GetParameter("addtrackstoplaylist", Nothing) & "&format=jsarray"
            Dim Content As StringContent = New StringContent(Request.Build)

            Dim Response As AddPlaylistContentsResponse = New AddPlaylistContentsResponse
            Response.response = New AddPlaylistContentsResponse.Field
            Try
                Response.response.Build(JsonConvert.DeserializeObject(Await Http.SendRequest(HttpMethod.Post, Url, Content, GoogleHttp.ResultType.STRING_TYPE)))
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function DeleteTrack(TrackId As String, Permanently As Boolean) As Task(Of DeleteTrackResponse)
            Return Await DeleteTracks({TrackId}, Permanently)
        End Function
        Public Async Function DeleteTracks(TrackId As IEnumerable(Of String), Permanently As Boolean) As Task(Of DeleteTrackResponse)
            SwitchToWebHttp()

            Dim Request As DeleteTrackRequest = New DeleteTrackRequest
            Request.sessionId = Auth.SessionId
            Request.songIds = TrackId.ToArray

            Dim Url As String = BaseUrl & GetParameter("deletesong", Request)
            Dim Response As DeleteTrackResponse = New DeleteTrackResponse
            Try
                Response.response = Await Http.SendRequest(Of DeleteTrackResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
                If Permanently Then
                    Dim Metadata As TrackMetadataField
                    For Each Id As String In Response.response.deleteIds
                        Metadata = New TrackMetadataField
                        Metadata.id = Id
                        Metadata.permanentlyDelete = True

                        Await EditTrack(Metadata)
                    Next
                End If
            Catch ex As Exception
                ReportError(Response, ex)
            End Try


            Return Response
        End Function
        Public Async Function DeletePlaylist(PlaylistId As String) As Task(Of DeletePlaylistResponse)
            SwitchToWebHttp()
            Dim Request As DeletePlaylistRequest = New DeletePlaylistRequest
            Request.sessionId = Auth.SessionId
            Request.id = PlaylistId

            Dim Url As String = BaseUrl & GetParameter("deleteplaylist", Request)
            Dim Response As DeletePlaylistResponse = New DeletePlaylistResponse
            Try
                Response.response = Await Http.SendRequest(Of DeletePlaylistResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function DeletePlaylistContent(TrackId As String, EntryId As String, PlaylistId As String) As Task(Of DeletePlaylistContentsResponse)
            Return Await DeletePlaylistContents({TrackId}, {EntryId}, PlaylistId)
        End Function
        Public Async Function DeletePlaylistContent(TrackId As String, PlaylistId As String) As Task(Of DeletePlaylistContentsResponse)
            Return Await DeletePlaylistContents({TrackId}, PlaylistId)
        End Function
        Public Async Function DeletePlaylistContents(TrackId As IEnumerable(Of String), EntryId As IEnumerable(Of String), PlaylistId As String) As Task(Of DeletePlaylistContentsResponse)
            SwitchToWebHttp()

            Dim Request As DeletePlaylistContentsRequest = New DeletePlaylistContentsRequest
            Request.sessionId = Auth.SessionId
            Request.listId = PlaylistId
            Request.songIds = TrackId.ToArray
            Request.entryIds = EntryId.ToArray

            Dim Url As String = BaseUrl & GetParameter("deletesong", Request)
            Dim Response As DeletePlaylistContentsResponse = New DeletePlaylistContentsResponse
            Try
                Response.response = Await Http.SendRequest(Of DeletePlaylistContentsResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function DeletePlaylistContents(TrackId As IEnumerable(Of String), PlaylistId As String) As Task(Of DeletePlaylistContentsResponse)
            Dim EntryIds As List(Of String) = New List(Of String)

            Dim Contents As GetPlaylistContentsResponse = Await GetPlaylistContents(PlaylistId)
            For Each Id As String In TrackId
                Try
                    EntryIds.Add(Contents.response.track.Single(Function(Func) Func.id = Id).playlistEntryId)
                Catch ex As Exception
                    EntryIds.Add(String.Empty)
                End Try
            Next

            Return Await DeletePlaylistContents(TrackId, EntryIds, PlaylistId)
        End Function
        Public Async Function DeleteUserActionHistory() As Task(Of Boolean)
            SwitchToWebHttp()

            Dim Request As DeleteUserActionHistoryRequest = New DeleteUserActionHistoryRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("deleteuseractionhistory", Request)
            Try
                Await Http.SendRequest(HttpMethod.Post, Url, ResultType.NULL_TYPE)
                If Http.LastCode <> HttpStatusCode.OK Then Return False
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Async Function EditTrack(Metadata As TrackMetadataField) As Task(Of EditTrackResponse)
            Return Await EditTracks({Metadata})
        End Function
        Public Async Function EditTracks(Metadatas As IEnumerable(Of TrackMetadataField)) As Task(Of EditTrackResponse)
            SwitchToWebHttp()

            Dim Request As EditTrackRequest = New EditTrackRequest
            Request.sessionId = Auth.SessionId
            Request.track.AddRange(Metadatas)

            Dim Url As String = BaseUrl & GetParameter("modifytracks", Request)
            Dim Response As EditTrackResponse = New EditTrackResponse
            Try
                Response.response = Await Http.SendRequest(Of EditTrackResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function EditPlaylist(PlaylistId As String, Name As String, Description As String) As Task(Of EditPlaylistResponse)
            SwitchToWebHttp()

            Dim Request As EditPlaylistRequest = New EditPlaylistRequest
            Request.sessionId = Auth.SessionId
            Request.id = PlaylistId
            Request.name = Name
            Request.description = Description

            Dim Url As String = BaseUrl & GetParameter("editplaylist", Request)
            Dim Response As EditPlaylistResponse = New EditPlaylistResponse
            Try
                Response.response = Await Http.SendRequest(Of EditPlaylistResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function EditLabSettings(DesktopNotifications As Boolean, HTML5Audio As Boolean, ViewTrackComments As Boolean, ChromecastFireplaceVisualizer As Boolean) As Task(Of Boolean)
            SwitchToWebHttp()

            Dim Request As EditLabSettingsRequest = New EditLabSettingsRequest
            Request.sessionId = Auth.SessionId
            Request.labs = New EditLabSettingsRequest.LabsField
            Request.labs.dn = DesktopNotifications
            Request.labs.ha = HTML5Audio
            Request.labs.view_song_comments = ViewTrackComments
            Request.labs.fireplace_chromecast = ChromecastFireplaceVisualizer

            Dim Url As String = BaseUrl & GetParameter("modifylab", Request)
            Try
                Await Http.SendRequest(HttpMethod.Post, Url, ResultType.NULL_TYPE)
                If Http.LastCode <> HttpStatusCode.OK Then Return False
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Async Function FindTracks(Title As String) As Task(Of GetAllTracksResponse)
            Dim Tracks As GetAllTracksResponse = Await GetAllTracks()
            If Tracks.status = False Then Return Tracks

            Tracks.response.track = Tracks.response.track.Where(Function(Func) LCase(Func.title) = LCase(Title)).ToList

            Return Tracks
        End Function
        Public Async Function FindPlaylists(Name As String) As Task(Of GetAllPlaylistsResponse)
            Dim Playlists As GetAllPlaylistsResponse = Await GetAllPlaylists()
            If Playlists.status = False Then Return Playlists

            Playlists.response.playlist = Playlists.response.playlist.Where(Function(Func) LCase(Func.title) = LCase(Name)).ToArray

            Return Playlists
        End Function
        Public Async Function FetchQuerySuggestions(Keyword As String) As Task(Of FetchQuerySuggestionsResponse)
            SwitchToWebHttp()

            Dim Request As FetchQuerySuggestionsRequest = New FetchQuerySuggestionsRequest
            Request.sessionId = Auth.SessionId
            Request.query = Keyword

            Dim Url As String = BaseUrl & GetParameter("fetchquerysuggestions", Request)
            Dim Response As FetchQuerySuggestionsResponse = New FetchQuerySuggestionsResponse
            Try
                Response.response = Await Http.SendRequest(Of FetchQuerySuggestionsResponse.Field)(HttpMethod.Post, Url, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetAllTracks(Optional IncludeDeletedTracks As Boolean = False) As Task(Of GetAllTracksResponse)
            SwitchToWebHttp()

            Dim Request As GetAllTracksRequest = New GetAllTracksRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("streamingloadalltracks", Request) & "&format=jsarray"
            Dim Response As GetAllTracksResponse = New GetAllTracksResponse
            Dim JsonArray As JArray
            Try
                Dim Match As Match = New Regex("window.parent\['slat_process'\]\((?<tracks>.*?)\);\nwindow.parent\['slat_progress'\]", RegexOptions.Singleline).Match(Await Http.SendRequest(HttpMethod.Get, Url, GoogleHttp.ResultType.STRING_TYPE))
                Do Until Match.Success = False
                    JsonArray = JsonConvert.DeserializeObject(Match.Groups("tracks").Value)
                    For i As Integer = 0 To JsonArray.Item(0).Count - 1
                        Response.Build(JsonArray.Item(0).Item(i), IncludeDeletedTracks)
                    Next
                    Match = Match.NextMatch
                Loop
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetAllPlaylists() As Task(Of GetAllPlaylistsResponse)
            SwitchToWebHttp()

            Dim Request As GetAllPlaylistsRequest = New GetAllPlaylistsRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("loadplaylists", Request) & "&format=jsarray"
            Dim Response As GetAllPlaylistsResponse = New GetAllPlaylistsResponse
            Try
                Response.response = Await Http.SendRequest(Of GetAllPlaylistsResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetPlaylistContents(PlaylistId As String) As Task(Of GetPlaylistContentsResponse)
            SwitchToWebHttp()

            Dim Request As GetPlaylistContentsRequest = New GetPlaylistContentsRequest
            Request.sessionId = Auth.SessionId
            Request.id = PlaylistId

            Dim Url As String = BaseUrl & GetParameter("loaduserplaylist", Request)
            Dim Response As GetPlaylistContentsResponse = New GetPlaylistContentsResponse
            Try
                Response.response = Await Http.SendRequest(Of GetPlaylistContentsResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetAutoPlaylistContents(AutoPlaylistName As String) As Task(Of GetPlaylistContentsResponse)
            SwitchToWebHttp()

            Dim Request As GetPlaylistContentsRequest = New GetPlaylistContentsRequest
            Request.sessionId = Auth.SessionId
            Request.id = AutoPlaylistName

            Dim Url As String = BaseUrl & GetParameter("loadautoplaylist", Request)
            Dim Response As GetPlaylistContentsResponse = New GetPlaylistContentsResponse
            Try
                Response.response = Await Http.SendRequest(Of GetPlaylistContentsResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetDeletedTracks() As Task(Of GetPlaylistContentsResponse)
            Return Await GetAutoPlaylistContents("auto-playlist-trash")
        End Function
        Public Async Function GetPermanentlyDeletedTracks() As Task(Of GetAllTracksResponse)
            SwitchToWebHttp()

            Dim Tracks As GetAllTracksResponse = Await GetAllTracks(True)
            If Tracks.status = False Then Return Tracks

            Tracks.response.track = Tracks.response.track.Where(Function(Func) Func.deleted = True).ToList
            For Each Item As TrackMetadataField In GetDeletedTracks.Result.response.track
                Tracks.response.track.RemoveAll(Function(Func) Func.id = Item.id)
            Next

            Return Tracks
        End Function
        Public Async Function GetRandomTracks() As Task(Of Object)
            '## 확인하지 않음 ##
            SwitchToWebHttp()

            Dim Request As GetRandomTracksRequest = New GetRandomTracksRequest
            Request.sessionId = Auth.SessionId  '// 추가 요소 필요 //

            Dim Url As String = BaseUrl & GetParameter("radio/fetchradiofeed", Request)
            Dim Response As String
            Try
                Response = Await Http.SendRequest(HttpMethod.Post, Url, GoogleHttp.ResultType.STRING_TYPE)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End Function
        Public Async Function GetSuggestedMetadata(MatchedId() As String) As Task(Of GetSuggestedMetadataResponse)
            SwitchToWebHttp()

            Dim Request As GetSuggestedMetadataRequest = New GetSuggestedMetadataRequest
            Request.sessionId = Auth.SessionId
            Request.matchedId = MatchedId

            Dim Url As String = BaseUrl & GetParameter("fetchtracks", Request)
            Dim Response As GetSuggestedMetadataResponse = New GetSuggestedMetadataResponse
            Try
                Response.response = Await Http.SendRequest(Of GetSuggestedMetadataResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetStreamingUrl(TrackId As String, Optional StartPosition As Long = 0) As Task(Of GetStreamingUrlResponse)
            SwitchToWebHttp()

            Dim Url As String = "https://play.google.com/music/play" & GetParameter(String.Empty, Nothing) & "&songid=" & TrackId & "&start=" & StartPosition
            Dim Response As GetStreamingUrlResponse = New GetStreamingUrlResponse
            Try
                Response.response = Await Http.SendRequest(Of GetStreamingUrlResponse.Field)(HttpMethod.Get, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetDownloadUrl(TrackId As String) As Task(Of GetDownloadUrlResponse)
            SwitchToMMHttp()

            Dim Url As String = "https://music.google.com/music/export?version=2&songid=" & TrackId
            Dim Response As GetDownloadUrlResponse = New GetDownloadUrlResponse
            Try
                Response.response = Await Http.SendRequest(Of GetDownloadUrlResponse.Field)(HttpMethod.Get, Url, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetRegisteredDevices() As Task(Of IEnumerable(Of GetAllSettingsResponse.Field.SettingField.UploadDeviceField))
            Dim Settings As GetAllSettingsResponse = Await GetAllSettings()
            If Settings.status = False Then Return Nothing

            Return Settings.response.settings.uploadDevice
        End Function
        Public Async Function GetAllSettings() As Task(Of GetAllSettingsResponse)
            SwitchToWebHttp()

            Dim Request As GetAllSettingsRequest = New GetAllSettingsRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("fetchsettings", Request)
            Dim Response As GetAllSettingsResponse = New GetAllSettingsResponse
            Try
                Response.response = Await Http.SendRequest(Of GetAllSettingsResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetDismissedItems() As Task(Of GetDismissedItemsResponse)
            SwitchToWebHttp()

            Dim Request As GetDismissedItemsRequest = New GetDismissedItemsRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("getdismisseditems", Request)
            Dim Response As GetDismissedItemsResponse = New GetDismissedItemsResponse
            Try
                Response.response = Await Http.SendRequest(Of GetDismissedItemsResponse.Field)(HttpMethod.Post, Url, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetStatus() As Task(Of GetStatusResponse)
            SwitchToWebHttp()

            Dim Request As GetStatusRequest = New GetStatusRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("getstatus", Request)
            Dim Response As GetStatusResponse = New GetStatusResponse
            Try
                Response.response = Await Http.SendRequest(Of GetStatusResponse.Field)(HttpMethod.Post, Url, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetOffer() As Task(Of GetOfferResponse)
            SwitchToWebHttp()

            Dim Request As GetOfferRequest = New GetOfferRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("getoffers", Request)
            Dim Response As GetOfferResponse = New GetOfferResponse
            Try
                Response.response = Await Http.SendRequest(Of GetOfferResponse.Field)(HttpMethod.Post, Url, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function GetListenNowItems() As Task(Of GetListenNowItemsResponse)
            SwitchToWebHttp()

            Dim Request As GetListenNowItemsRequest = New GetListenNowItemsRequest
            Request.sessionId = Auth.SessionId

            Dim Url As String = BaseUrl & GetParameter("getfelistennowitems", Request)
            Dim Response As GetListenNowItemsResponse = New GetListenNowItemsResponse
            Try
                Response.response = Await Http.SendRequest(Of GetListenNowItemsResponse.Field)(HttpMethod.Post, Url, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function RestoreDeletedTrack(TrackId As String) As Task(Of RestoreDeletedTracksResponse)
            Return Await RestoreDeletedTracks({TrackId})
        End Function
        Public Async Function RestoreDeletedTracks(TrackId As IEnumerable(Of String)) As Task(Of RestoreDeletedTracksResponse)
            SwitchToWebHttp()

            Dim Request As RestoreDeletedTracksRequest = New RestoreDeletedTracksRequest
            Request.sessionId = Auth.SessionId
            Request.songIds = TrackId.ToArray

            Dim Url As String = BaseUrl & GetParameter("undeletesong", Request)
            Dim Response As RestoreDeletedTracksResponse = New RestoreDeletedTracksResponse
            Try
                Response.response = Await Http.SendRequest(Of RestoreDeletedTracksResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        Public Async Function RestorePermanentlyDeletedTracks(TrackId As String) As Task(Of Boolean)
            Return Await RestorePermanentlyDeletedTracks({TrackId})
        End Function
        Public Async Function RestorePermanentlyDeletedTracks(TrackId As IEnumerable(Of String)) As Task(Of Boolean)
            Dim Metadata As TrackMetadataField
            Dim Metadatas As List(Of TrackMetadataField) = New List(Of TrackMetadataField)
            For Each Id As String In TrackId
                Metadata = New TrackMetadataField
                Metadata.id = Id
                Metadata.permanentlyDelete = False
                Metadatas.Add(Metadata)
            Next

            Dim EditResponse As EditTrackResponse
            EditResponse = Await EditTracks(Metadatas)
            If EditResponse.status = False Then Return False

            Dim RestoreResponse As RestoreDeletedTracksResponse
            RestoreResponse = Await RestoreDeletedTracks(TrackId)
            If RestoreResponse.status = False Then Return False

            Return True
        End Function
        Public Async Function SearchStoreTracks(Keyword As String) As Task(Of SearchTracksResponse)
            SwitchToWebHttp()

            Dim Request As SearchTracksRequest = New SearchTracksRequest
            Request.sessionId = Auth.SessionId
            Request.query = Keyword

            Dim Url As String = BaseUrl & GetParameter("search", Request)
            Dim Response As SearchTracksResponse = New SearchTracksResponse
            Try
                Response.response = Await Http.SendRequest(Of SearchTracksResponse.Field)(HttpMethod.Post, Url, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
                Debug.WriteLine(ex.Message)
            End Try

            Return Response
        End Function
        Public Async Function SearchPlaylists(Keyword As String) As Task(Of GetAllPlaylistsResponse)
            Dim Playlists As GetAllPlaylistsResponse = Await GetAllPlaylists()
            If Playlists.status = False Then Return Playlists

            Dim FoundPlaylists As List(Of GetAllPlaylistsResponse.Field.PlaylistField) = New List(Of GetAllPlaylistsResponse.Field.PlaylistField)
            FoundPlaylists.AddRange(Playlists.response.playlist.Where(Function(Func) LCase(Func.title).Contains(LCase(Keyword))))
            FoundPlaylists.AddRange(Playlists.response.playlist.Where(Function(Func) LCase(Func.description).Contains(LCase(Keyword))))
            Playlists.response.playlist = FoundPlaylists.ToArray

            Return Playlists
        End Function
        Public Async Function UploadAlbumArt(FilePath As String) As Task(Of UploadAlbumArtResponse)
            SwitchToWebHttp()

            Dim Request As UploadAlbumArtRequest = New UploadAlbumArtRequest
            Request.sessionId = Auth.SessionId

            Dim Content As MultipartFormDataContent = New MultipartFormDataContent("------WebKitFormBoundary")
            Dim PartContent As HttpContent
            PartContent = New StreamContent(New FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite))
            PartContent.Headers.Add("Content-Disposition", "form-data; name=""albumArt""; filename=""" & Path.GetFileName(FilePath) & """")
            PartContent.Headers.Add("Content-Type", "image/" & Replace(Path.GetExtension(FilePath), ".", String.Empty))
            Content.Add(PartContent)

            PartContent = New StringContent(JsonConvert.SerializeObject(Request))
            PartContent.Headers.Add("Content-Disposition", "form-data; name=""json""")
            Content.Add(PartContent)

            Dim Url As String = BaseUrl & GetParameter("imageupload", Nothing)
            Dim Response As UploadAlbumArtResponse = New UploadAlbumArtResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadAlbumArtResponse.Field)(HttpMethod.Post, Url, Content, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            Return Response
        End Function
        '==================================================
        Private Function GetParameter(Destination As String, Optional JsonObject As Object = Nothing) As String
            Return GetParameter(Destination, JsonConvert.SerializeObject(JsonObject))
        End Function
        Private Function GetParameter(Destination As String, Optional JsonString As String = Nothing) As String
            If JsonString Is Nothing Then
                Return Destination & "?u=0&xt=" & Auth.XTcookie
            Else
                Return Destination & "?u=0&xt=" & Auth.XTcookie & "&json=" & JsonString
            End If
        End Function
        Private Sub ReportError(ByRef Response As ResponseField, Optional ex As Exception = Nothing)
            Response.status = False

            If Http.LastCode <> HttpStatusCode.OK Then
                Response.description.Add(Http.LastCode.ToString)

                If Http.LastResponseHeader IsNot Nothing Then
                    Dim Dict As Dictionary(Of String, IEnumerable(Of String)) = New Dictionary(Of String, IEnumerable(Of String))
                    For Each Item As KeyValuePair(Of String, IEnumerable(Of String)) In Http.LastResponseHeader.ToList
                        If Item.Key = "X-Rejected-Reason" Then Response.description.AddRange(Item.Value)
                        Dict.Add(Item.Key, Item.Value)
                    Next
                    Response.responseHeader = Dict
                End If
            ElseIf Http.LastCode = 0 Then
                Response.description.Add("GoogleHttp Error")
                Response.description.Add(ex.Message)
            Else
                Response.description.Add("Json Deserialize Error")
            End If
        End Sub
        Private Sub SwitchToWebHttp()
            If Type = HttpType.WEB Then Exit Sub

            Http = New GoogleHttp(Auth.CookieContainer)
            Http.SetReceiveEvent = _ReceiveEvent
            Http.SetSendEvent = _SendEvent

            Type = HttpType.WEB
        End Sub
        Private Sub SwitchToMMHttp()
            If Type = HttpType.MUSIC_MANAGER Then Exit Sub

            Http = New GoogleHttp
            Http.SetReceiveEvent = _ReceiveEvent
            Http.SetSendEvent = _SendEvent

            Http.Headers.Add("User-Agent", "Music Manager (1, 0, 243, 1116 HTTPS - Windows)")
            Http.Headers.Add("Authorization", Auth.TokenType & " " & Auth.AccessToken)
            Http.Headers.Add("X-Device-ID", "mm:" & Auth.DeviceId)

            Type = HttpType.MUSIC_MANAGER
        End Sub
        Private Sub WriteToStream(ByRef Stream As Stream, Str As String)
            Stream.Write(UTF8.GetBytes(Str & vbCrLf), 0, UTF8.GetByteCount(Str & vbCrLf))
        End Sub
        Private Sub WriteToStream(ByRef Stream As Stream, Buffer() As Byte)
            Stream.Write(Buffer, 0, Buffer.Length)
            WriteToStream(Stream)
        End Sub
        Private Sub WriteToStream(ByRef Stream As Stream)
            Stream.Write(UTF8.GetBytes(vbCrLf), 0, UTF8.GetByteCount(vbCrLf))
        End Sub
        Private Function GetProtobufSerializedStream(Obj As Object) As Stream
            Dim Stream As MemoryStream = New MemoryStream
            Serializer.Serialize(Stream, Obj)
            Stream.Position = 0

            Return Stream
        End Function
        Private Async Function UploadAuthorization() As Task(Of RelatedToUploadResponse)
            SwitchToMMHttp()

            Dim Request As UpAuthRequest = New UpAuthRequest
            Request.friendly_name = Auth.UserName
            Request.uploader_id = Auth.DeviceId

            Dim Content As StreamContent = New StreamContent(GetProtobufSerializedStream(Request))

            Dim Url As String = AndroidBaseUrl & "upauth"
            Dim Response As RelatedToUploadResponse = New RelatedToUploadResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadResponse)(HttpMethod.Post, Url, Content, ResultType.PROTOBUF_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.auth_status <> UploadResponse.AuthStatus.OK Then
                Response.status = False
                Response.description.Add(Response.response.auth_status.ToString)
            End If

            Return Response
        End Function
        Private Async Function CancelExisitingJobs() As Task(Of Boolean)
            Dim Jobs As RelatedToUploadResponse = Await GetExisitingJobs()
            If Jobs.status = False Then Return False

            If Jobs.response.getjobs_response.get_tracks_success Then
                If Jobs.response.getjobs_response.tracks_to_upload.Count > 0 Then
                    If DeleteExisitingJobs.Result.status = False Then Return False
                End If
            End If

            Return True
        End Function
        Private Async Function GetExisitingJobs() As Task(Of RelatedToUploadResponse)
            Dim Request As GetJobsRequest = New GetJobsRequest
            Request.uploader_id = Auth.DeviceId

            Dim Content As StreamContent = New StreamContent(GetProtobufSerializedStream(Request))

            Dim Url As String = AndroidBaseUrl & "getjobs?version=1"
            Dim Response As RelatedToUploadResponse = New RelatedToUploadResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadResponse)(HttpMethod.Post, Url, Content, ResultType.PROTOBUF_DESERIALIZE_TYPE) '// 오류 발생 //
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.auth_status <> UploadResponse.AuthStatus.OK Then
                Response.status = False
                Response.description.Add(Response.response.auth_status.ToString)
            End If

            Return Response
        End Function
        Private Async Function DeleteExisitingJobs() As Task(Of RelatedToUploadResponse)
            Dim Request As GetJobsRequest = New GetJobsRequest
            Request.uploader_id = Auth.DeviceId

            Dim Content As StreamContent = New StreamContent(GetProtobufSerializedStream(Request))

            Dim Url As String = AndroidBaseUrl & "deleteuploadrequested"
            Dim Response As RelatedToUploadResponse = New RelatedToUploadResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadResponse)(HttpMethod.Post, Url, Content, ResultType.PROTOBUF_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.auth_status <> UploadResponse.AuthStatus.OK Then
                Response.status = False
                Response.description.Add(Response.response.auth_status.ToString)
            End If

            Return Response
        End Function
        Private Async Function UpdateUploadState(State As UpdateUploadStateRequest.UploadState) As Task(Of RelatedToUploadResponse)
            Dim Request As UpdateUploadStateRequest = New UpdateUploadStateRequest
            Request.uploader_id = Auth.DeviceId
            Request.state = State

            Dim Content As StreamContent = New StreamContent(GetProtobufSerializedStream(Request))

            Dim Url As String = AndroidBaseUrl & "sample?version=1"
            Dim Response As RelatedToUploadResponse = New RelatedToUploadResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadResponse)(HttpMethod.Post, Url, Content, ResultType.PROTOBUF_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.auth_status <> UploadResponse.AuthStatus.OK Then
                Response.status = False
                Response.description.Add(Response.response.auth_status.ToString)
            End If

            Return Response
        End Function
        Private Function GetTrackMetadata(FilePath As String) As Track
            Dim Tag As TagLib.File = TagLib.File.Create(FilePath)
            Dim Metadata As Track = New Track

            With Tag.Tag
                If .Title = String.Empty Then
                    Metadata.title = Path.GetFileNameWithoutExtension(FilePath)
                Else
                    Metadata.title = .Title
                End If
                Metadata.album = .Album
                Metadata.album_artist = .JoinedAlbumArtists
                Metadata.artist = .JoinedPerformers
                Metadata.genre = .JoinedGenres
                Metadata.client_id = GetClientId(FilePath)
                Metadata.composer = .JoinedComposers
                Metadata.year = .Year
                Metadata.disc_number = .Disc
                Metadata.track_number = .Track
                Metadata.total_disc_count = .DiscCount
                Metadata.total_track_count = .TrackCount
                Metadata.original_bit_rate = Tag.Properties.AudioBitrate
                Metadata.estimated_size = New FileInfo(FilePath).Length
                Metadata.duration_millis = Tag.Properties.Duration.TotalMilliseconds
                Metadata.last_modified_timestamp = (New FileInfo(FilePath).LastWriteTimeUtc - New Date(1970, 1, 1, 0, 0, 0, 0).ToLocalTime).TotalMilliseconds
            End With

            Tag.Dispose()

            Return Metadata
        End Function
        Private Function GetAlbumArtData(FilePath As String) As Byte()
            Dim Tag As TagLib.File = TagLib.File.Create(FilePath)
            If Tag.Tag.Pictures.Length = 0 Then Return Nothing

            Dim Result() As Byte = Tag.Tag.Pictures(0).Data.Data

            Tag.Dispose()

            Return Result
        End Function
        Private Function GetClientId(FilePath As String) As String
            Dim Buffer() As Byte
            Using Stream As FileStream = New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                Buffer = MD5.Create.ComputeHash(Stream)
            End Using

            Return System.Convert.ToBase64String(Buffer).Replace("=", String.Empty)
        End Function
        Private Function GetTrackSample(FilePath As String, StartPosition As Long, Duration As Long) As Byte()
            Dim Reader As Mp3FileReader = New Mp3FileReader(FilePath)
            Dim Frame As Mp3Frame
            Dim Buffer() As Byte
            Dim Temp As String = Path.GetTempFileName
            Using Stream As FileStream = New FileStream(Temp, FileMode.Create, FileAccess.ReadWrite)
                Do
                    Frame = Reader.ReadNextFrame
                    If Frame IsNot Nothing Then
                        If Reader.CurrentTime.TotalMilliseconds >= StartPosition Then
                            If Reader.CurrentTime.TotalMilliseconds <= StartPosition + Duration Then
                                Stream.Write(Frame.RawData, 0, Frame.RawData.Length)
                            Else
                                Exit Do
                            End If
                        End If
                    End If
                Loop

                ReDim Buffer(Stream.Length - 1)
                Stream.Read(Buffer, 0, Stream.Length)
            End Using

            File.Delete(Temp)
            Reader.Dispose()

            Return Buffer
        End Function
        Private Async Function UploadMetadata(Metadatas As IEnumerable(Of Track)) As Task(Of RelatedToUploadResponse)
            Dim Request As UploadMetadataRequest = New UploadMetadataRequest
            Request.uploader_id = Auth.DeviceId
            Request.track.AddRange(Metadatas)

            Dim Content As StreamContent = New StreamContent(GetProtobufSerializedStream(Request))

            Dim Url As String = AndroidBaseUrl & "metadata?version=1"
            Dim Response As RelatedToUploadResponse = New RelatedToUploadResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadResponse)(HttpMethod.Post, Url, Content, ResultType.PROTOBUF_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.auth_status <> UploadResponse.AuthStatus.OK Then
                Response.status = False
                Response.description.Add(Response.response.auth_status.ToString)
            End If

            Return Response
        End Function
        Private Async Function UploadSample(Info As IEnumerable(Of UploadTrackRequest)) As Task(Of RelatedToUploadResponse)
            Dim Samples As List(Of TrackSample) = New List(Of TrackSample)
            Dim Sample As TrackSample
            For Each i As UploadTrackRequest In Info
                Sample = New TrackSample
                Sample.signed_challenge_info = i.sci
                Sample.track = i.metadata
                Sample.sample = GetTrackSample(i.filepath, i.sci.challenge_info.start_millis, i.sci.challenge_info.duration_millis)
                Samples.Add(Sample)
            Next

            Dim Request As UploadSampleRequest = New UploadSampleRequest
            Request.uploader_id = Auth.DeviceId
            Request.track_sample.AddRange(Samples)

            Dim Content As StreamContent = New StreamContent(GetProtobufSerializedStream(Request))

            Dim Url As String = AndroidBaseUrl & "sample?version=1"
            Dim Response As RelatedToUploadResponse = New RelatedToUploadResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadResponse)(HttpMethod.Post, Url, Content, ResultType.PROTOBUF_DESERIALIZE_TYPE, "Samples")
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.auth_status <> UploadResponse.AuthStatus.OK Then
                Response.status = False
                Response.description.Add(Response.response.auth_status.ToString)
            End If

            Return Response
        End Function
        Private Async Function GetUploadSession(Info As UploadTrackRequest, CurrentCount As Integer, TotalCount As Integer) As Task(Of UploadSessionResponse)
            Dim Request As UploadSessionRequest = New UploadSessionRequest
            Request.clientId = "Jumper Uploader"
            Request.protocolVersion = "0.8"
            Request.createSessionRequest = New UploadSessionRequest.CreateSessionRequestField

            Dim lst As New List(Of UploadSessionRequest.CreateSessionRequestField.RequestField)
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.ExternalRequestField(Info.filepath, Path.GetFileName(Info.filepath)))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("SyncNow", "true"))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("ClientTotalSongCount", TotalCount))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("CurrentUploadingTrack", Info.metadata.title))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("CurrentTotalUploadedCount", CurrentCount)) '1
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("title", "jumper-uploader-title-42")) 'jumper-uploader-title-6335?
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("TrackDoNotRematch", "false"))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("ServerId", Info.tsr.server_track_id))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("UploaderId", Auth.DeviceId))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("TrackBitRate", Info.metadata.original_bit_rate.ToString))
            lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("ClientId", Info.metadata.client_id))
            If Info.tsr.album_art_url IsNot String.Empty Then
                lst.Add(New UploadSessionRequest.CreateSessionRequestField.InlinedRequestField("AlbumArtUrl", Info.tsr.album_art_url)) '// 테스트
            End If
            Request.createSessionRequest.fields = lst

            Dim Content As StringContent = New StringContent(JsonConvert.SerializeObject(Request))

            Dim Url As String = "https://uploadsj.clients.google.com/uploadsj/scottyagent"
            Dim Response As UploadSessionResponse = New UploadSessionResponse
            Try
                Response.response = Await Http.SendRequest(Of UploadSessionResponse.Field)(HttpMethod.Post, Url, Content, ResultType.JSON_DESERIALIZE_TYPE)
            Catch ex As Exception
                ReportError(Response, ex)
            End Try

            If Response.status = False Then Return Response
            If Response.response.errorMessage IsNot Nothing Then
                Response.status = False
                Response.description.Add(Response.response.errorMessage.Reason)
                Response.description.Add(Response.response.errorMessage.AdditionalInfo.googleRupioAdditionalInfo.completionInfo.requestRejectedInfo.reasonDescription)
            End If

            Return Response
        End Function
        Private Async Function UploadTrack(Info As IEnumerable(Of UploadTrackRequest)) As Task(Of IEnumerable(Of UploadTrackResponse))
            Dim Url As String
            Dim Content As HttpContent
            Dim Response As UploadTrackResponse
            Dim Responses As List(Of UploadTrackResponse) = New List(Of UploadTrackResponse)
            Dim Tasks As List(Of Task) = New List(Of Task)

            For Each Request As UploadTrackRequest In Info
                Url = Request.session.response.sessionStatus.externalFieldTransfers(0).putInfo.URL
                Content = New StreamContent(New FileStream(Request.filepath, FileMode.Open, FileAccess.Read))
                Tasks.Add(Http.SendRequest(Of UploadTrackResponse.Field)(HttpMethod.Put, Url, Content, ResultType.JSON_DESERIALIZE_TYPE, Path.GetFileName(Request.filepath)))
            Next

            For Each Task As Task(Of UploadTrackResponse.Field) In Tasks
                Response = New UploadTrackResponse
                Try
                    Response.response = Await Task
                Catch ex As Exception
                    ReportError(Response, ex)
                End Try

                If Response.response.additionalInfo IsNot Nothing Then
                    If Response.response.additionalInfo.googleRupioAdditionalInfo.completionInfo.requestRejectedInfo IsNot Nothing Then
                        Response.status = False
                        Response.description.Add(Response.response.additionalInfo.googleRupioAdditionalInfo.completionInfo.requestRejectedInfo.reasonDescription)
                    End If
                End If

                Response.filePath = Info(Tasks.IndexOf(Task)).filepath
                Responses.Add(Response)
            Next

            Return Responses
        End Function
    End Class

End Namespace

