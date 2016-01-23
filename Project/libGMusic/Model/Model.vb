Imports Newtonsoft.Json.Linq

Imports libGMusic.Model.Uits

Namespace Model
    Public Class ResponseField
        Public status As Boolean = True
        Public description As List(Of String) = New List(Of String)
        Public responseHeader As Dictionary(Of String, IEnumerable(Of String))
    End Class
    Public Class TrackMetadataField
        Public id As String
        Public title As String
        Public imageBaseUrl As String
        Public artist As String
        Public album As String
        Public albumArtist As String
        Public composer As String
        Public genre As String
        Public durationMillis As Long?
        Public track As Integer?
        Public totalTracks As Integer?
        Public disc As Integer?
        Public totalDiscs As Integer?
        Public year As Integer?
        Public deleted As Boolean? 'integer?
        Public playCount As Integer?
        Public rating As Integer?
        Public creationDate As Long?
        Public lastPlayed As Long?
        Public storeId As String
        Public matchedId As String
        Public type As Integer?
        Public comment As String
        Public albumMatchedId As String
        Public artistMatchedId As String
        Public bitrate As Integer?
        Public recentTimestamp As Long?
        Public explicitType As Integer?
        Public origin() As String = {}
        Public curationSuggested As Boolean?
        Public curatedByUser As Boolean?
        Public playlistEntryId As String
        Public lastPlaybackTimestamp As Long?
        Public lastRatingChangeTimestamp As Long?
        Public previewToken As String
        Public previewInfo As PreviewInfoField
        Public audioMatchedId As String
        Public rightsInfo As RightsInfoField
        Public price As PriceField
        Public artistImage() As String = {}
        Public originalContentType As Integer?
        Public primaryYoutubeVideoId As String '// 있어야 할 물건인가 //
        Public primaryYoutubeVideo As PrimaryYoutubeVideoField '// 있어야 할 물건인가 //

        Public fixMatchNeeded As String
        Public permanentlyDelete As Boolean?
        Public pending As Boolean?
        Public albumPlaybackTimestamp As Long?
        Public Class PreviewInfoField
            Public previewToken As String
        End Class
        Public Class RightsInfoField
            Public trackAvailableForPurchase As Boolean
            Public trackAvailableForSubscription As Boolean
            Public albumAvailableForPurchase As Boolean
        End Class
        Public Class PriceField
            Public micros As Long?
            Public currencyCode As String
        End Class
        Public Class PrimaryYoutubeVideoField
            Public videoId As String
            Public thumbnailUrl As String
        End Class

        Public Function GetArray() As Object()
            Return {id, title, imageBaseUrl, artist, album, albumArtist, Nothing, Nothing, Nothing, Nothing, composer, genre, Nothing, durationMillis, track, totalTracks, disc, totalDiscs,
            year, deleted, permanentlyDelete, pending, playCount, rating, creationDate, lastPlayed, Nothing, storeId, matchedId, type, comment, Nothing, albumMatchedId, artistMatchedId, bitrate, Nothing,
            artistImage, Nothing, explicitType, Nothing, Nothing, Nothing, True}
        End Function
        Public Function DateValueToDate(DateValue As Long) As Date
            Return New DateTime(1970, 01, 01).AddMilliseconds(DateValue / 1000).ToLocalTime
        End Function
        Public Function DateToDateValue(Time As Date) As Long
            Return 1000 * (Time.ToUniversalTime.Subtract(New DateTime(1970, 01, 01)).TotalMilliseconds)
        End Function
    End Class
    Public Class AddTrackRequest
        Inherits UploadTrackRequest
    End Class
    Public Class AddTrackResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public responses As List(Of UploadTrackResponse)
        End Class
    End Class
    Public Class AddPlaylistRequest
        Public sessionId As String
        Public name As String
        Public description As String
        Public track As List(Of TrackField) = New List(Of TrackField)
        Public Class TrackField
            Public id As String
        End Class

        Sub AddTrackField(id As String)
            Dim TrackField As TrackField = New TrackField
            TrackField.id = id

            track.Add(TrackField)
        End Sub
    End Class
    Public Class AddPlaylistResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public id As String
            Public sharedToken As String
            Public track() As TrackField
            Public creationTimestamp As Long

            Public Class TrackField
                Public id As String
                Public type As Integer
                Public entryId As String
            End Class
        End Class
    End Class
    Public Class AddPlaylistContentsRequest
        '## 확인하지 않음 ##
        '[["rqasqdgw14a4",1],["71228933-de0e-461b-b907-a8a10f62e15d",[["6269b26d-6a42-3105-aeb2-36c82b01f4ad",2]]]]
        Public sessionId As String
        Public listId As String
        Public track As List(Of TrackField) = New List(Of TrackField)
        Public Class TrackField
            Public uuid As String
        End Class

        Sub AddTrackField(id As String)
            Dim TrackField As TrackField = New TrackField
            TrackField.uuid = id

            track.Add(TrackField)
        End Sub
    End Class
    Public Class _AddPlaylistContentsRequest
        Public sessionId As String
        Public listId As String
        Public songIds() As String

        Public Function Build() As String
            Dim songs As String = String.Empty
            For Each Id As String In songIds

                If songs = String.Empty Then
                    songs = "[""" & Id & """,2]"
                Else
                    songs &= ",[""" & Id & """,2]"
                End If
            Next

            Return "[[""" & sessionId & """,1],[""" & listId & """,[" & songs & "]]]"
        End Function
    End Class
    Public Class AddPlaylistContentsResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public timestamp As String
            Public songIds As List(Of String)
            Public entryIds As List(Of String)

            Public Sub Build(Response As JToken)
                songIds = New List(Of String)
                entryIds = New List(Of String)
                timestamp = CLng(Response(1).Item(0))
                For Each Token As JToken In Response(1).Item(1)
                    songIds.Add(Token.Item(0).ToString)
                    entryIds.Add(Token.Item(2).ToString)
                Next
            End Sub
        End Class


    End Class
    Public Class DeleteTrackRequest
        Public sessionId As String
        Public songIds() As String
        Public entryIds() As String = {}
        Public ReadOnly listId As String = "all"
    End Class
    Public Class DeleteTrackResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public listId As String
            Public deleteIds() As String
        End Class
    End Class
    Public Class DeletePlaylistRequest
        Public sessionId As String
        Public id As String
    End Class
    Public Class DeletePlaylistResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public deleteId As String
        End Class
    End Class
    Public Class DeletePlaylistContentsRequest
        Public sessionId As String
        Public songIds() As String
        Public entryIds() As String
        Public listId As String
    End Class
    Public Class DeletePlaylistContentsResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public listId As String
            Public deleteIds() As String
        End Class
    End Class
    Public Class EditTrackRequest
        Public sessionId As String
        Public track As List(Of TrackMetadataField) = New List(Of TrackMetadataField)
    End Class
    Public Class EditTrackResponse
        Inherits ResponseField

        Public response As Field = New Field
        Public Class Field
            Public timestampMillis As Long?
        End Class
    End Class
    Public Class EditPlaylistRequest
        Public sessionId As String
        Public id As String
        Public name As String
        Public description As String
    End Class
    Public Class EditPlaylistResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public id As String
            Public sharedToken As String
        End Class
    End Class
    Public Class GetAllTracksRequest
        Public sessionId As String
        Public lastUpdated As Long = 0
        Public contextToken As String
        Public tier As Integer = 1
        Public requestCause As Integer = 1
        Public requestType As Integer = 1
    End Class
    Public Class GetAllTracksResponse
        Inherits ResponseField

        Public response As Field = New Field
        Public Class Field
            Public track As List(Of TrackMetadataField) = New List(Of TrackMetadataField)
        End Class

        Public Sub Build(Response As JToken, IncludeDeletedTrack As Boolean)

            If IncludeDeletedTrack = False Then
                If CInt(Response(19).ToString) = 1 Then Exit Sub
            End If

            Dim Item As TrackMetadataField = New TrackMetadataField
            With Item
                .id = Response(0)
                .title = Response(1)
                .imageBaseUrl = Response(2)
                .artist = Response(3)
                .album = Response(4)
                .albumArtist = Response(5)
                .composer = Response(10)
                .genre = Response(11)
                .durationMillis = Response(13)
                .track = Response(14)
                .totalTracks = Response(15)
                .disc = Response(16)
                .totalDiscs = Response(17)
                .year = Response(18)
                .deleted = Response(19)
                .permanentlyDelete = Response(20)
                .pending = Response(21)
                .playCount = Response(22)
                .rating = Response(23)
                .creationDate = Response(24)
                .lastPlayed = Response(25)
                .storeId = Response(27)
                .matchedId = Response(28)
                .type = Response(29)
                .comment = Response(30)
                .fixMatchNeeded = Response(31)
                .albumMatchedId = Response(32)
                .artistMatchedId = Response(33)
                .bitrate = Response(34)
                .recentTimestamp = Response(35)
                .artistImage = Response(36).Annotation(Of IEnumerable(Of String)) '// 이거 맞나..? //
                .albumPlaybackTimestamp = Response(37)
                .explicitType = Response(38)
                .previewToken = Response(40)
                .curatedByUser = Response(42)
                .playlistEntryId = Response(43)
                .previewInfo = Response(45).Annotation(Of TrackMetadataField.PreviewInfoField)  '// 이거 맞나..? //
                .audioMatchedId = Response(50)
                .primaryYoutubeVideoId = Response(52)
                .primaryYoutubeVideo = Response(55).Annotation(Of TrackMetadataField.PrimaryYoutubeVideoField)
            End With

            Me.response.track.Add(Item)

#Region "Original"
            '## Original ##
            'ID = Data(0)
            'Title = Data(1)
            'AlbumArtUrl = Data(2)
            'Artist = Data(3)
            'Album = Data(4)
            'AlbumArtist = Data(5)
            'TitleNorm = Data(6)
            'ArtistNorm = Data(7)
            'AlbumNorm = Data(8)
            'AlbumArtistNorm = Data(9)
            'Composer = Data(10)
            'Genre = Data(11)
            'FHB = Data(12)
            'Duration = Data(13)
            'Track = Data(14)
            'TotalTracks = Data(15)
            'Disc = Data(16)
            'TotalDiscs = Data(17)
            'Year = Data(18)
            'IsDeleted = Data(19)
            'PermanentlyDelete = Data(20)
            'Pending = Data(21)
            'PlayCount = Data(22)
            'Rating = Data(23)
            'CreationDate = Data(24)
            'LastPlayedDate = Data(25)
            'SubjectToCuration = Data(26)
            'StoreID = Data(27)
            'MatchedID = Data(28)
            'Type = Data(29)
            'Comment = Data(30)
            'FixMatchNeeded = Data(31)
            'MatchedAlbumID = Data(32)
            'MatchedArtistID = Data(33)
            'Bitrate = Data(34)
            'RecentTimestamp = Data(35)
            'ArtURL = Data(36)
            'AlbumPlaybackTimestamp = Data(37)
            'ExplicitType = Data(38)
            'RJB = Data(39)
            'PreviewToken = Data(40)
            'CurationSuggested = Data(41)
            'CuratedByUser = Data(42)
            'PlaylistEntryID = Data(43)
            'SharingInfo = Data(44)
            'PreviewInfo = Data(45)
            'AlbumArtUrl = Data(46)
            'Explanation = Data(47)
            'DIB = Data(48)
            'FIB = Data(49)
            'QEB = Data(50)
            'OtherMatchedID = Data(50)
            'Unknown_51 = Data(51)
            'YoutubeID = Data(52)
            'Unknown_53 = Data(53)
            'Unknown_54 = Data(54)
            'YoutubeInfo = Data(55)
            'u5 = Data(56)
            'Unknown_57 = Data(57)
            'Unknown_58 = Data(58)
            'Unknown_59 = Data(59)
            'Unknown_60 = Data(60)
            'Unknown_61 = Data(61)
#End Region
        End Sub
    End Class
    Public Class GetAllPlaylistsRequest
        Public sessionId As String
    End Class
    Public Class GetAllPlaylistsResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public playlist() As PlaylistField
            Public Class PlaylistField
                Public id As String
                Public title As String
                Public creationTimestamp As Long?
                Public recentTimestamp As String
                Public type As Integer?
                Public sharedToken As String
                Public lastModifiedTimestamp As Long?
                Public description As String
                Public ownerName As String
                Public playlistArtUrl() As String
                Public suggestedPlaylistArtUrl() As String
            End Class
        End Class
    End Class
    Public Class GetDownloadUrlResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public url As String
        End Class
    End Class
    Public Class GetPlaylistContentsRequest
        Public sessionId As String
        Public id As String
    End Class
    Public Class GetPlaylistContentsResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public track() As TrackMetadataField
        End Class
    End Class
    Public Class GetRandomTracksRequest
        Public sessionId As String
    End Class
    Public Class GetSuggestedMetadataRequest
        Public sessionId As String
        Public matchedId() As String '// matchedId
    End Class
    Public Class GetSuggestedMetadataResponse
        Inherits ResponseField
        Public response As Field
        Public Class Field
            Public track() As TrackMetadataField
        End Class
    End Class
    Public Class GetStreamingUrlResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public isFreeRadioUser As Boolean?
            Public tier As Integer?
            Public streamAuthId As String
            Public url As String
            Public replayGain As Integer?
        End Class
    End Class
    Public Class GetAllSettingsRequest
        Public sessionId As String
    End Class
    Public Class GetAllSettingsResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public settings As SettingField

            Public Class SettingField
                Public lab() As LabField
                Public uploadDevice() As UploadDeviceField
                Public maxUploadedTracks As String
                Public entitlementInfo As EntitlementInfoField

                Public Class LabField
                    Public experimentName As String
                    Public displayName As String
                    Public description As String
                    Public enabled As Boolean?
                End Class
                Public Class UploadDeviceField
                    Public id As String
                    Public lastEventTimeMillis As String
                    Public lastAccessedTimeMillis As String
                    Public name As String
                    Public deviceType As Integer?
                    Public carrier As String
                    Public manufacturer As String
                    Public model As String
                    Public lastAccessedFormatted As String
                End Class
                Public Class EntitlementInfoField
                    Public isSubscription As Boolean?
                    Public isTrial As Boolean?
                    Public isCanceled As Boolean?
                    Public subscriptionNewsletter As Boolean?
                End Class
            End Class
        End Class
    End Class
    Public Class GetDismissedItemsRequest
        Public sessionId As String
    End Class
    Public Class GetDismissedItemsResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public item() As ItemField
            Public minLastModifiedMillisIgnored As Boolean?

            Public Class ItemField
                Public uuid As String
                Public itemId As ItemIdField
                Public suggestionReason As Integer?
                Public dismissalTimestampMillis As Long?

                Public Class ItemIdField
                    Public type As Integer?
                    Public albumId As AlbumIdField

                    Public Class AlbumIdField
                        Public title As String
                        Public artist As String
                        Public metajamCompactKey As String
                    End Class
                End Class
            End Class
        End Class
    End Class
    Public Class RestoreDeletedTracksRequest
        Public sessionId As String
        Public songIds() As String
        Public entryIds() As String = {}
        Public ReadOnly listId As String = "all"
    End Class
    Public Class RestoreDeletedTracksResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public listId As String
            Public deleteIds() As String
        End Class
    End Class
    Public Class RelatedToUploadResponse
        Inherits ResponseField

        Public response As UploadResponse
    End Class
    Public Class SearchTracksRequest
        Public sessionId As String
        Public query As String
    End Class
    Public Class SearchTracksResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public subscriptionTrack() As SubscriptionTrackField
            Public subscriptionAlbum() As SubscriptionAlbumField
            Public subscriptionArtist() As SubscriptionArtistField
            Public subscriptionGenre()
            Public station()
            Public youtubeVideo()
            Public situation()
            Public podcastSeries()
            Public bestMatch As BestMatchField
            Public sharedPlaylist()
            Public clusterOrder() As Integer
            Public clusters()

            Public Class SubscriptionTrackField
                Public id As String
                Public title As String
                Public imageBaseUrl As String
                Public artist As String
                Public album As String
                Public albumArtist As String
                Public composer As String
                Public genre As String
                Public durationMillis As Long?
                Public track As Integer?
                Public disc As Integer?
                Public year As Integer?
                Public playCount As Integer?
                Public creationDate As Long?
                Public lastPlayed As Long?
                Public storeId As String
                Public matchedId As String
                Public type As Integer?
                Public albumMatchedId As String
                Public artistMatchedId As String
                Public explicitType As Integer?
                Public origin() As String
                Public previewToken As String
                Public previewInfo As TrackMetadataField.PreviewInfoField
                Public audioMatchedId As String
                Public rightsInfo As TrackMetadataField.RightsInfoField
                Public primaryYoutubeVideoId As String
                Public primaryYoutubeVideo As TrackMetadataField.PrimaryYoutubeVideoField
                Public price As TrackMetadataField.PriceField
                Public artistImage() As String
            End Class
            Public Class SubscriptionAlbumField
                Public title As String
                Public artist As String
                Public imageBaseUrl As String
                Public creationTimestamp As Long?
                Public lastPlayedTimestamp As Long?
                Public track() '// string?
                Public matchedId As String
                Public genre() As String
                Public year As Integer?
                Public artistMatchedId As String
                Public relatedArtist() As String
                Public explicitType As Integer?
                Public albumAvailableForPurchase As Boolean?
                Public albumAvailableForSubscription As Boolean?
                Public price As TrackMetadataField.PriceField
            End Class
            Public Class SubscriptionArtistField
                Public matchedId As String
                Public name As String
                Public totalTrackCount As Integer?
                Public album() As String
                Public imageBaseUrl As String
                Public genre() As String
                Public relatedArtist() As String
                Public topTrack() As String
                Public artistBioAttribution As ArtistBioAttributionField
                Public autogenArt As Boolean?
                Public image() As ImageField
                Public concert() As String

                Public Class ArtistBioAttributionField
                    Public sourceTitle As String
                    Public sourceUrl As String
                    Public licenseTitle As String
                    Public licenseUrl As String
                End Class
                Public Class ImageField
                    Public url As String
                    Public autogen As Boolean?
                    Public aspectRatio As Integer?
                End Class
            End Class

            Public Class BestMatchField
                Public album As SubscriptionAlbumField
            End Class
        End Class
    End Class
    Public Class UploadAlbumArtRequest
        Public sessionId As String
    End Class
    Public Class UploadAlbumArtResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public imageDisplayUrl As String
            Public imageUrl As String
        End Class
    End Class

    Public Class UploadTrackRequest
        Public filepath As String
        Public metadata As Track
        Public sci As SignedChallengeInfo
        Public tsr As TrackSampleResponse
        Public session As UploadSessionResponse
    End Class
    Public Class UploadTrackResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public sessionStatus As SessionStatusField
            Public additionalInfo As AdditionalInfoField
            Public upload_id As String

            Public Class SessionStatusField
                Public state As String
                Public externalFieldTransfers() As ExternalFieldTransfersField

                Public Class ExternalFieldTransfersField
                    Public name As String
                    Public status As String
                    Public bytesTransferred As Long?
                    Public bytesTotal As Long?
                    Public putInfo As PutInfoField
                    Public content_type As String

                    Public Class PutInfoField
                        Public url As String
                    End Class
                End Class
            End Class
        End Class
    End Class
    Public Class UploadSessionRequest
        Public protocolVersion As String
        Public clientId As String
        Public createSessionRequest As CreateSessionRequestField

        Public Class CreateSessionRequestField
            Public fields As IEnumerable(Of RequestField)
            Public Class RequestField
            End Class
            Public Class ExternalRequestField
                Inherits RequestField

                Sub New(Name As String, FileName As String)
                    external = New ExternalField
                    external.name = Name
                    external.filename = FileName
                    external.put = New Object()
                End Sub

                Public external As ExternalField
                Public Class ExternalField
                    Public name As String
                    Public put As Object
                    Public filename As String
                End Class
            End Class
            Public Class InlinedRequestField
                Inherits RequestField

                Sub New(Name As String, Content As String)
                    inlined = New InlinedField
                    inlined.name = Name
                    inlined.content = Content
                End Sub

                Public inlined As InlinedField
                Public Class InlinedField
                    Public name As String
                    Public content As String
                End Class
            End Class
        End Class
    End Class
    Public Class UploadSessionResponse
        Inherits ResponseField

        Public response As Field
        Public Class Field
            Public sessionStatus As SessionStatusField
            Public errorMessage As ErrorMessageField

            Public Class SessionStatusField
                Public State As String
                Public UploadID As String
                Public externalFieldTransfers() As ExternalFieldTransfersField

                Public Class ExternalFieldTransfersField
                    Public Name As String
                    Public Status As String
                    Public BytesTransferred As Integer?
                    Public ContentType As String
                    Public putInfo As PutInfoField

                    Public Class PutInfoField
                        Public URL As String
                    End Class
                End Class
            End Class
            Public Class ErrorMessageField
                Public Reason As String
                Public UploadID As String
                Public AdditionalInfo As AdditionalInfoField
            End Class
        End Class
    End Class
    Public Class AdditionalInfoField
        Public googleRupioAdditionalInfo As GoogleRupioAdditionalInfoField

        Public Class GoogleRupioAdditionalInfoField
            Public completionInfo As CompletionInfoField

            Public Class CompletionInfoField
                Public status As String
                Public customerSpecificInfo As CustomerSpecificInfoField
                Public requestRejectedInfo As RequestRejectedInfoField

                Public Class CustomerSpecificInfoField
                    Public ServerFileReference As String
                    Public ResponseCode As Integer?
                End Class
                Public Class RequestRejectedInfoField
                    Public reasonDescription As String
                End Class
            End Class
        End Class
    End Class

End Namespace