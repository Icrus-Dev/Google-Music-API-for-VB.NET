Namespace Model
    <System.Serializable, ProtoBuf.ProtoContract(Name:="GetTracksToExportRequest")>
    Partial Public Class GetTracksToExportRequest
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _client_id As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property client_id() As String
            Get
                Return _client_id
            End Get
            Set
                _client_id = Value
            End Set
        End Property
        Private _continuation_token As String = ""
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="continuation_token", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property continuation_token() As String
            Get
                Return _continuation_token
            End Get
            Set
                _continuation_token = Value
            End Set
        End Property
        Private _export_type As Model.GetTracksToExportRequest.TracksToExportType = Model.GetTracksToExportRequest.TracksToExportType.ALL
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="export_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.GetTracksToExportRequest.TracksToExportType.ALL)>
        Public Property export_type() As Model.GetTracksToExportRequest.TracksToExportType
            Get
                Return _export_type
            End Get
            Set
                _export_type = Value
            End Set
        End Property
        Private _updated_min As Long = 0
        <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="updated_min", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property updated_min() As Long
            Get
                Return _updated_min
            End Get
            Set
                _updated_min = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="TracksToExportType")>
        Public Enum TracksToExportType

            <ProtoBuf.ProtoEnum(Name:="ALL", Value:=1)>
            ALL = 1

            <ProtoBuf.ProtoEnum(Name:="PURCHASED_AND_PROMOTIONAL", Value:=2)>
            PURCHASED_AND_PROMOTIONAL = 2
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="DownloadTrackInfo")>
    Partial Public Class DownloadTrackInfo
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _id As String = ""
        <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        Private _title As String = ""
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="title", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property title() As String
            Get
                Return _title
            End Get
            Set
                _title = Value
            End Set
        End Property
        Private _album As String = ""
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="album", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property album() As String
            Get
                Return _album
            End Get
            Set
                _album = Value
            End Set
        End Property
        Private _album_artist As String = ""
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="album_artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property album_artist() As String
            Get
                Return _album_artist
            End Get
            Set
                _album_artist = Value
            End Set
        End Property
        Private _artist As String = ""
        <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property artist() As String
            Get
                Return _artist
            End Get
            Set
                _artist = Value
            End Set
        End Property
        Private _track_number As Integer = 0
        <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="track_number", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property track_number() As Integer
            Get
                Return _track_number
            End Get
            Set
                _track_number = Value
            End Set
        End Property
        Private _track_size As Long = 0
        <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="track_size", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property track_size() As Long
            Get
                Return _track_size
            End Get
            Set
                _track_size = Value
            End Set
        End Property
        Private _disc_number As Integer = 0
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="disc_number", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property disc_number() As Integer
            Get
                Return _disc_number
            End Get
            Set
                _disc_number = Value
            End Set
        End Property
        Private _total_disc_count As Integer = 0
        <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="total_disc_count", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property total_disc_count() As Integer
            Get
                Return _total_disc_count
            End Get
            Set
                _total_disc_count = Value
            End Set
        End Property
        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="GetTracksToExportResponse")>
    Partial Public Class GetTracksToExportResponse
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _status As Model.GetTracksToExportResponse.TracksToExportStatus
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="status", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property status() As Model.GetTracksToExportResponse.TracksToExportStatus
            Get
                Return _status
            End Get
            Set
                _status = Value
            End Set
        End Property
        Private ReadOnly _download_track_info As New Global.System.Collections.Generic.List(Of Model.DownloadTrackInfo)()
        <ProtoBuf.ProtoMember(2, Name:="download_track_info", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property download_track_info() As Global.System.Collections.Generic.List(Of Model.DownloadTrackInfo)
            Get
                Return _download_track_info
            End Get
        End Property

        Private _continuation_token As String = ""
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="continuation_token", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property continuation_token() As String
            Get
                Return _continuation_token
            End Get
            Set
                _continuation_token = Value
            End Set
        End Property
        Private _updated_min As Long = 0
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="updated_min", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property updated_min() As Long
            Get
                Return _updated_min
            End Get
            Set
                _updated_min = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="TracksToExportStatus")>
        Public Enum TracksToExportStatus

            <ProtoBuf.ProtoEnum(Name:="OK", Value:=1)>
            OK = 1

            <ProtoBuf.ProtoEnum(Name:="TRANSIENT_ERROR", Value:=2)>
            TRANSIENT_ERROR = 2

            <ProtoBuf.ProtoEnum(Name:="MAX_NUM_CLIENTS_REACHED", Value:=3)>
            MAX_NUM_CLIENTS_REACHED = 3

            <ProtoBuf.ProtoEnum(Name:="UNABLE_TO_AUTHENTICATE_CLIENT", Value:=4)>
            UNABLE_TO_AUTHENTICATE_CLIENT = 4

            <ProtoBuf.ProtoEnum(Name:="UNABLE_TO_REGISTER_CLIENT", Value:=5)>
            UNABLE_TO_REGISTER_CLIENT = 5
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class
    <System.Serializable, ProtoBuf.ProtoContract(Name:="AudioRef")>
    Partial Public Class AudioRef
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _store As Model.AudioRef.eStore
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="store", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property store() As Model.AudioRef.eStore
            Get
                Return _store
            End Get
            Set
                _store = Value
            End Set
        End Property
        Private _ref As Byte()
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="ref", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property ref() As Byte()
            Get
                Return _ref
            End Get
            Set
                _ref = Value
            End Set
        End Property
        Private _url As String = ""
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="url", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property url() As String
            Get
                Return _url
            End Get
            Set
                _url = Value
            End Set
        End Property
        Private _bit_rate As Integer = 0
        <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="bit_rate", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property bit_rate() As Integer
            Get
                Return _bit_rate
            End Get
            Set
                _bit_rate = Value
            End Set
        End Property
        Private _sample_rate As Integer = 0
        <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="sample_rate", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property sample_rate() As Integer
            Get
                Return _sample_rate
            End Get
            Set
                _sample_rate = Value
            End Set
        End Property
        Private _downloadable As Boolean = False
        <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="downloadable", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property downloadable() As Boolean
            Get
                Return _downloadable
            End Get
            Set
                _downloadable = Value
            End Set
        End Property
        Private _duration_millis As Long = 0
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="duration_millis", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property duration_millis() As Long
            Get
                Return _duration_millis
            End Get
            Set
                _duration_millis = Value
            End Set
        End Property
        Private _rematch_timestamp As Long = 0
        <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="rematch_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property rematch_timestamp() As Long
            Get
                Return _rematch_timestamp
            End Get
            Set
                _rematch_timestamp = Value
            End Set
        End Property
        Private _invalid_due_to_wipeout As Boolean = False
        <ProtoBuf.ProtoMember(10, IsRequired:=False, Name:="invalid_due_to_wipeout", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property invalid_due_to_wipeout() As Boolean
            Get
                Return _invalid_due_to_wipeout
            End Get
            Set
                _invalid_due_to_wipeout = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="Store")>
        Public Enum eStore

            <ProtoBuf.ProtoEnum(Name:="BLOBSTORE", Value:=1)>
            BLOBSTORE = 1

            <ProtoBuf.ProtoEnum(Name:="SM_V2", Value:=2)>
            SM_V2 = 2
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="ImageRef")>
    Partial Public Class ImageRef
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _store As Model.ImageRef.eStore = Model.ImageRef.eStore.SHOEBOX
        <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="store", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.ImageRef.eStore.SHOEBOX)>
        Public Property store() As Model.ImageRef.eStore
            Get
                Return _store
            End Get
            Set
                _store = Value
            End Set
        End Property
        Private _width As UInteger = 0
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="width", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property width() As UInteger
            Get
                Return _width
            End Get
            Set
                _width = Value
            End Set
        End Property
        Private _height As UInteger = 0
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="height", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property height() As UInteger
            Get
                Return _height
            End Get
            Set
                _height = Value
            End Set
        End Property
        Private _url As String = ""
        <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="url", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property url() As String
            Get
                Return _url
            End Get
            Set
                _url = Value
            End Set
        End Property
        Private _invalid_due_to_wipeout As Boolean = False
        <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="invalid_due_to_wipeout", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property invalid_due_to_wipeout() As Boolean
            Get
                Return _invalid_due_to_wipeout
            End Get
            Set
                _invalid_due_to_wipeout = Value
            End Set
        End Property
        Private _origin As Model.ImageRef.eOrigin = Model.ImageRef.eOrigin.PERSONAL
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="origin", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.ImageRef.eOrigin.PERSONAL)>
        Public Property origin() As Model.ImageRef.eOrigin
            Get
                Return _origin
            End Get
            Set
                _origin = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="Store")>
        Public Enum eStore

            <ProtoBuf.ProtoEnum(Name:="SHOEBOX", Value:=3)>
            SHOEBOX = 3
        End Enum

        <ProtoBuf.ProtoContract(Name:="Origin")>
        Public Enum eOrigin

            <ProtoBuf.ProtoEnum(Name:="PERSONAL", Value:=1)>
            PERSONAL = 1

            <ProtoBuf.ProtoEnum(Name:="STORE", Value:=2)>
            STORE = 2
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadedUitsId3Tag")>
    Partial Public Class UploadedUitsId3Tag
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _owner As String = ""
        <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="owner", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property owner() As String
            Get
                Return _owner
            End Get
            Set
                _owner = Value
            End Set
        End Property
        Private _data As Byte() = Nothing
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="data", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property data() As Byte()
            Get
                Return _data
            End Get
            Set
                _data = Value
            End Set
        End Property
        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="AdditionalMetadata")>
    Partial Public Class AdditionalMetadata
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _tag_name As String
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="tag_name", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property tag_name() As String
            Get
                Return _tag_name
            End Get
            Set
                _tag_name = Value
            End Set
        End Property
        Private _value As Byte()
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="value", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property value() As Byte()
            Get
                Return _value
            End Get
            Set
                _value = Value
            End Set
        End Property
        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="TrackExtras")>
    Partial Public Class TrackExtras
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private ReadOnly _additional_metadata As New Global.System.Collections.Generic.List(Of Model.AdditionalMetadata)()
        <ProtoBuf.ProtoMember(2, Name:="additional_metadata", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property additional_metadata() As Global.System.Collections.Generic.List(Of Model.AdditionalMetadata)
            Get
                Return _additional_metadata
            End Get
        End Property

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="Track")>
    Partial Public Class Track
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _id As String = ""
        <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        Private _client_id As String = ""
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property client_id() As String
            Get
                Return _client_id
            End Get
            Set
                _client_id = Value
            End Set
        End Property
        Private _creation_timestamp As Long = 0
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="creation_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property creation_timestamp() As Long
            Get
                Return _creation_timestamp
            End Get
            Set
                _creation_timestamp = Value
            End Set
        End Property
        Private _last_modified_timestamp As Long = 0
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="last_modified_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property last_modified_timestamp() As Long
            Get
                Return _last_modified_timestamp
            End Get
            Set
                _last_modified_timestamp = Value
            End Set
        End Property
        Private _deleted As Boolean = CBool(False)
        <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="deleted", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(CBool(False))>
        Public Property deleted() As Boolean
            Get
                Return _deleted
            End Get
            Set
                _deleted = Value
            End Set
        End Property
        Private _title As String = ""
        <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="title", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property title() As String
            Get
                Return _title
            End Get
            Set
                _title = Value
            End Set
        End Property
        Private _artist As String = ""
        <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property artist() As String
            Get
                Return _artist
            End Get
            Set
                _artist = Value
            End Set
        End Property
        Private _artist_hash As Long = 0
        <ProtoBuf.ProtoMember(46, IsRequired:=False, Name:="artist_hash", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property artist_hash() As Long
            Get
                Return _artist_hash
            End Get
            Set
                _artist_hash = Value
            End Set
        End Property
        Private _composer As String = ""
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="composer", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property composer() As String
            Get
                Return _composer
            End Get
            Set
                _composer = Value
            End Set
        End Property
        Private _album As String = ""
        <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="album", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property album() As String
            Get
                Return _album
            End Get
            Set
                _album = Value
            End Set
        End Property
        Private _album_artist As String = ""
        <ProtoBuf.ProtoMember(10, IsRequired:=False, Name:="album_artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property album_artist() As String
            Get
                Return _album_artist
            End Get
            Set
                _album_artist = Value
            End Set
        End Property
        Private _canonical_album As String = ""
        <ProtoBuf.ProtoMember(56, IsRequired:=False, Name:="canonical_album", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property canonical_album() As String
            Get
                Return _canonical_album
            End Get
            Set
                _canonical_album = Value
            End Set
        End Property
        Private _canonical_artist As String = ""
        <ProtoBuf.ProtoMember(57, IsRequired:=False, Name:="canonical_artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property canonical_artist() As String
            Get
                Return _canonical_artist
            End Get
            Set
                _canonical_artist = Value
            End Set
        End Property
        Private _canonical_genre_album As String = ""
        <ProtoBuf.ProtoMember(58, IsRequired:=False, Name:="canonical_genre_album", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property canonical_genre_album() As String
            Get
                Return _canonical_genre_album
            End Get
            Set
                _canonical_genre_album = Value
            End Set
        End Property
        Private _year As Integer = 0
        <ProtoBuf.ProtoMember(11, IsRequired:=False, Name:="year", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property year() As Integer
            Get
                Return _year
            End Get
            Set
                _year = Value
            End Set
        End Property
        Private _comment As String = ""
        <ProtoBuf.ProtoMember(12, IsRequired:=False, Name:="comment", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property comment() As String
            Get
                Return _comment
            End Get
            Set
                _comment = Value
            End Set
        End Property
        Private _track_number As Integer = 0
        <ProtoBuf.ProtoMember(13, IsRequired:=False, Name:="track_number", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property track_number() As Integer
            Get
                Return _track_number
            End Get
            Set
                _track_number = Value
            End Set
        End Property
        Private _genre As String = ""
        <ProtoBuf.ProtoMember(14, IsRequired:=False, Name:="genre", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property genre() As String
            Get
                Return _genre
            End Get
            Set
                _genre = Value
            End Set
        End Property
        Private _duration_millis As Long = 0
        <ProtoBuf.ProtoMember(15, IsRequired:=False, Name:="duration_millis", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property duration_millis() As Long
            Get
                Return _duration_millis
            End Get
            Set
                _duration_millis = Value
            End Set
        End Property
        Private _beats_per_minute As Integer = 0
        <ProtoBuf.ProtoMember(16, IsRequired:=False, Name:="beats_per_minute", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property beats_per_minute() As Integer
            Get
                Return _beats_per_minute
            End Get
            Set
                _beats_per_minute = Value
            End Set
        End Property
        Private _original_bit_rate As Integer = 0
        <ProtoBuf.ProtoMember(44, IsRequired:=False, Name:="original_bit_rate", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property original_bit_rate() As Integer
            Get
                Return _original_bit_rate
            End Get
            Set
                _original_bit_rate = Value
            End Set
        End Property
        Private ReadOnly _audio_ref As New Global.System.Collections.Generic.List(Of Model.AudioRef)()
        <ProtoBuf.ProtoMember(17, Name:="audio_ref", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property audio_ref() As Global.System.Collections.Generic.List(Of Model.AudioRef)
            Get
                Return _audio_ref
            End Get
        End Property

        Private ReadOnly _album_art_ref As New Global.System.Collections.Generic.List(Of Model.ImageRef)()
        <ProtoBuf.ProtoMember(18, Name:="album_art_ref", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property album_art_ref() As Global.System.Collections.Generic.List(Of Model.ImageRef)
            Get
                Return _album_art_ref
            End Get
        End Property

        Private _availability_status As Model.Track.AvailabilityStatus = Model.Track.AvailabilityStatus.PENDING
        <ProtoBuf.ProtoMember(19, IsRequired:=False, Name:="availability_status", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.AvailabilityStatus.PENDING)>
        Public Property availability_status() As Model.Track.AvailabilityStatus
            Get
                Return _availability_status
            End Get
            Set
                _availability_status = Value
            End Set
        End Property
        Private _play_count As Integer = 0
        <ProtoBuf.ProtoMember(20, IsRequired:=False, Name:="play_count", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property play_count() As Integer
            Get
                Return _play_count
            End Get
            Set
                _play_count = Value
            End Set
        End Property
        Private _content_type As Model.Track.ContentType = Model.Track.ContentType.MP3
        <ProtoBuf.ProtoMember(25, IsRequired:=False, Name:="content_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.ContentType.MP3)>
        Public Property content_type() As Model.Track.ContentType
            Get
                Return _content_type
            End Get
            Set
                _content_type = Value
            End Set
        End Property
        Private _total_track_count As Integer = 0
        <ProtoBuf.ProtoMember(26, IsRequired:=False, Name:="total_track_count", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property total_track_count() As Integer
            Get
                Return _total_track_count
            End Get
            Set
                _total_track_count = Value
            End Set
        End Property
        Private _disc_number As Integer = 0
        <ProtoBuf.ProtoMember(27, IsRequired:=False, Name:="disc_number", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property disc_number() As Integer
            Get
                Return _disc_number
            End Get
            Set
                _disc_number = Value
            End Set
        End Property
        Private _total_disc_count As Integer = 0
        <ProtoBuf.ProtoMember(28, IsRequired:=False, Name:="total_disc_count", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property total_disc_count() As Integer
            Get
                Return _total_disc_count
            End Get
            Set
                _total_disc_count = Value
            End Set
        End Property
        Private _channels As Model.Track.eChannels = Model.Track.eChannels.MONO
        <ProtoBuf.ProtoMember(29, IsRequired:=False, Name:="channels", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.eChannels.MONO)>
        Public Property channels() As Model.Track.eChannels
            Get
                Return _channels
            End Get
            Set
                _channels = Value
            End Set
        End Property
        Private _track_type As Model.Track.TrackType = Model.Track.TrackType.MATCHED_TRACK
        <ProtoBuf.ProtoMember(30, IsRequired:=False, Name:="track_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.TrackType.MATCHED_TRACK)>
        Public Property track_type() As Model.Track.TrackType
            Get
                Return _track_type
            End Get
            Set
                _track_type = Value
            End Set
        End Property
        Private _use_single_server_copy As Boolean = False
        <ProtoBuf.ProtoMember(59, IsRequired:=False, Name:="use_single_server_copy", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property use_single_server_copy() As Boolean
            Get
                Return _use_single_server_copy
            End Get
            Set
                _use_single_server_copy = Value
            End Set
        End Property
        Private _rating As Model.Track.eRating = Model.Track.eRating.NOT_RATED
        <ProtoBuf.ProtoMember(31, IsRequired:=False, Name:="rating", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.eRating.NOT_RATED)>
        Public Property rating() As Model.Track.eRating
            Get
                Return _rating
            End Get
            Set
                _rating = Value
            End Set
        End Property
        Private _estimated_size As Long = 0
        <ProtoBuf.ProtoMember(32, IsRequired:=False, Name:="estimated_size", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property estimated_size() As Long
            Get
                Return _estimated_size
            End Get
            Set
                _estimated_size = Value
            End Set
        End Property
        Private _store_id As String = ""
        <ProtoBuf.ProtoMember(33, IsRequired:=False, Name:="store_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property store_id() As String
            Get
                Return _store_id
            End Get
            Set
                _store_id = Value
            End Set
        End Property
        Private _metajam_id As String = ""
        <ProtoBuf.ProtoMember(34, IsRequired:=False, Name:="metajam_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property metajam_id() As String
            Get
                Return _metajam_id
            End Get
            Set
                _metajam_id = Value
            End Set
        End Property
        Private _metajam_id_confidence As Double = CDbl(0)
        <ProtoBuf.ProtoMember(43, IsRequired:=False, Name:="metajam_id_confidence", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(CDbl(0))>
        Public Property metajam_id_confidence() As Double
            Get
                Return _metajam_id_confidence
            End Get
            Set
                _metajam_id_confidence = Value
            End Set
        End Property
        Private _uits As String = ""
        <ProtoBuf.ProtoMember(35, IsRequired:=False, Name:="uits", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property uits() As String
            Get
                Return _uits
            End Get
            Set
                _uits = Value
            End Set
        End Property
        Private _uits_metadata As Model.UitsMetadata = Nothing
        <ProtoBuf.ProtoMember(40, IsRequired:=False, Name:="uits_metadata", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property uits_metadata() As Model.UitsMetadata
            Get
                Return _uits_metadata
            End Get
            Set
                _uits_metadata = Value
            End Set
        End Property
        Private _compilation As Boolean = False
        <ProtoBuf.ProtoMember(36, IsRequired:=False, Name:="compilation", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property compilation() As Boolean
            Get
                Return _compilation
            End Get
            Set
                _compilation = Value
            End Set
        End Property
        Private _client_date_added As Long = 0
        <ProtoBuf.ProtoMember(37, IsRequired:=False, Name:="client_date_added", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property client_date_added() As Long
            Get
                Return _client_date_added
            End Get
            Set
                _client_date_added = Value
            End Set
        End Property
        Private _recent_timestamp As Long = 0
        <ProtoBuf.ProtoMember(38, IsRequired:=False, Name:="recent_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property recent_timestamp() As Long
            Get
                Return _recent_timestamp
            End Get
            Set
                _recent_timestamp = Value
            End Set
        End Property
        Private _do_not_rematch As Boolean = CBool(False)
        <ProtoBuf.ProtoMember(39, IsRequired:=False, Name:="do_not_rematch", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(CBool(False))>
        Public Property do_not_rematch() As Boolean
            Get
                Return _do_not_rematch
            End Get
            Set
                _do_not_rematch = Value
            End Set
        End Property
        Private _from_album_purchase As Boolean = False
        <ProtoBuf.ProtoMember(41, IsRequired:=False, Name:="from_album_purchase", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property from_album_purchase() As Boolean
            Get
                Return _from_album_purchase
            End Get
            Set
                _from_album_purchase = Value
            End Set
        End Property
        Private _album_metajam_id As String = ""
        <ProtoBuf.ProtoMember(42, IsRequired:=False, Name:="album_metajam_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property album_metajam_id() As String
            Get
                Return _album_metajam_id
            End Get
            Set
                _album_metajam_id = Value
            End Set
        End Property
        Private _transaction_id As String = ""
        <ProtoBuf.ProtoMember(45, IsRequired:=False, Name:="transaction_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property transaction_id() As String
            Get
                Return _transaction_id
            End Get
            Set
                _transaction_id = Value
            End Set
        End Property
        Private _debug_track As Boolean = False
        <ProtoBuf.ProtoMember(47, IsRequired:=False, Name:="debug_track", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(False)>
        Public Property debug_track() As Boolean
            Get
                Return _debug_track
            End Get
            Set
                _debug_track = Value
            End Set
        End Property
        Private _normalized_title As String = ""
        <ProtoBuf.ProtoMember(48, IsRequired:=False, Name:="normalized_title", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property normalized_title() As String
            Get
                Return _normalized_title
            End Get
            Set
                _normalized_title = Value
            End Set
        End Property
        Private _normalized_artist As String = ""
        <ProtoBuf.ProtoMember(49, IsRequired:=False, Name:="normalized_artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property normalized_artist() As String
            Get
                Return _normalized_artist
            End Get
            Set
                _normalized_artist = Value
            End Set
        End Property
        Private _normalized_album As String = ""
        <ProtoBuf.ProtoMember(50, IsRequired:=False, Name:="normalized_album", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property normalized_album() As String
            Get
                Return _normalized_album
            End Get
            Set
                _normalized_album = Value
            End Set
        End Property
        Private _normalized_album_artist As String = ""
        <ProtoBuf.ProtoMember(51, IsRequired:=False, Name:="normalized_album_artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property normalized_album_artist() As String
            Get
                Return _normalized_album_artist
            End Get
            Set
                _normalized_album_artist = Value
            End Set
        End Property
        Private _normalized_canonical_album As String = ""
        <ProtoBuf.ProtoMember(54, IsRequired:=False, Name:="normalized_canonical_album", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property normalized_canonical_album() As String
            Get
                Return _normalized_canonical_album
            End Get
            Set
                _normalized_canonical_album = Value
            End Set
        End Property
        Private _normalized_canonical_artist As String = ""
        <ProtoBuf.ProtoMember(55, IsRequired:=False, Name:="normalized_canonical_artist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property normalized_canonical_artist() As String
            Get
                Return _normalized_canonical_artist
            End Get
            Set
                _normalized_canonical_artist = Value
            End Set
        End Property
        Private _uploader_id As String = ""
        <ProtoBuf.ProtoMember(52, IsRequired:=False, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property uploader_id() As String
            Get
                Return _uploader_id
            End Get
            Set
                _uploader_id = Value
            End Set
        End Property
        Private _client_album_id As String = ""
        <ProtoBuf.ProtoMember(53, IsRequired:=False, Name:="client_album_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property client_album_id() As String
            Get
                Return _client_album_id
            End Get
            Set
                _client_album_id = Value
            End Set
        End Property
        Private _label_owner_code As String = ""
        <ProtoBuf.ProtoMember(60, IsRequired:=False, Name:="label_owner_code", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property label_owner_code() As String
            Get
                Return _label_owner_code
            End Get
            Set
                _label_owner_code = Value
            End Set
        End Property
        Private _original_content_type As Model.Track.ContentType = Model.Track.ContentType.MP3
        <ProtoBuf.ProtoMember(61, IsRequired:=False, Name:="original_content_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.ContentType.MP3)>
        Public Property original_content_type() As Model.Track.ContentType
            Get
                Return _original_content_type
            End Get
            Set
                _original_content_type = Value
            End Set
        End Property
        Private ReadOnly _uploaded_uits As New Global.System.Collections.Generic.List(Of Model.UploadedUitsId3Tag)()
        <ProtoBuf.ProtoMember(71, Name:="uploaded_uits", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property uploaded_uits() As Global.System.Collections.Generic.List(Of Model.UploadedUitsId3Tag)
            Get
                Return _uploaded_uits
            End Get
        End Property

        Private _explicit_type As Model.Track.ExplicitType = Model.Track.ExplicitType.EXPLICIT
        <ProtoBuf.ProtoMember(74, IsRequired:=False, Name:="explicit_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Track.ExplicitType.EXPLICIT)>
        Public Property explicit_type() As Model.Track.ExplicitType
            Get
                Return _explicit_type
            End Get
            Set
                _explicit_type = Value
            End Set
        End Property
        Private _track_extras As Model.TrackExtras = Nothing
        <ProtoBuf.ProtoMember(75, IsRequired:=False, Name:="track_extras", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property track_extras() As Model.TrackExtras
            Get
                Return _track_extras
            End Get
            Set
                _track_extras = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="AvailabilityStatus")>
        Public Enum AvailabilityStatus

            <ProtoBuf.ProtoEnum(Name:="PENDING", Value:=1)>
            PENDING = 1

            <ProtoBuf.ProtoEnum(Name:="MATCHED", Value:=2)>
            MATCHED = 2

            <ProtoBuf.ProtoEnum(Name:="UPLOAD_REQUESTED", Value:=3)>
            UPLOAD_REQUESTED = 3

            <ProtoBuf.ProtoEnum(Name:="AVAILABLE", Value:=4)>
            AVAILABLE = 4

            <ProtoBuf.ProtoEnum(Name:="FORCE_REUPLOAD", Value:=5)>
            FORCE_REUPLOAD = 5

            <ProtoBuf.ProtoEnum(Name:="UPLOAD_PERMANENTLY_FAILED", Value:=6)>
            UPLOAD_PERMANENTLY_FAILED = 6
        End Enum

        <ProtoBuf.ProtoContract(Name:="ContentType")>
        Public Enum ContentType

            <ProtoBuf.ProtoEnum(Name:="MP3", Value:=1)>
            MP3 = 1

            <ProtoBuf.ProtoEnum(Name:="M4A", Value:=2)>
            M4A = 2

            <ProtoBuf.ProtoEnum(Name:="AAC", Value:=3)>
            AAC = 3

            <ProtoBuf.ProtoEnum(Name:="FLAC", Value:=4)>
            FLAC = 4

            <ProtoBuf.ProtoEnum(Name:="OGG", Value:=5)>
            OGG = 5

            <ProtoBuf.ProtoEnum(Name:="WMA", Value:=6)>
            WMA = 6

            <ProtoBuf.ProtoEnum(Name:="M4P", Value:=7)>
            M4P = 7

            <ProtoBuf.ProtoEnum(Name:="ALAC", Value:=8)>
            ALAC = 8
        End Enum

        <ProtoBuf.ProtoContract(Name:="Channels")>
        Public Enum eChannels

            <ProtoBuf.ProtoEnum(Name:="MONO", Value:=1)>
            MONO = 1

            <ProtoBuf.ProtoEnum(Name:="STEREO", Value:=2)>
            STEREO = 2
        End Enum

        <ProtoBuf.ProtoContract(Name:="TrackType")>
        Public Enum TrackType

            <ProtoBuf.ProtoEnum(Name:="MATCHED_TRACK", Value:=1)>
            MATCHED_TRACK = 1

            <ProtoBuf.ProtoEnum(Name:="UNMATCHED_TRACK", Value:=2)>
            UNMATCHED_TRACK = 2

            <ProtoBuf.ProtoEnum(Name:="LOCAL_TRACK", Value:=3)>
            LOCAL_TRACK = 3

            <ProtoBuf.ProtoEnum(Name:="PURCHASED_TRACK", Value:=4)>
            PURCHASED_TRACK = 4

            <ProtoBuf.ProtoEnum(Name:="METADATA_ONLY_MATCHED_TRACK", Value:=5)>
            METADATA_ONLY_MATCHED_TRACK = 5

            <ProtoBuf.ProtoEnum(Name:="PROMO_TRACK", Value:=6)>
            PROMO_TRACK = 6
        End Enum

        <ProtoBuf.ProtoContract(Name:="Rating")>
        Public Enum eRating

            <ProtoBuf.ProtoEnum(Name:="NOT_RATED", Value:=1)>
            NOT_RATED = 1

            <ProtoBuf.ProtoEnum(Name:="ONE_STAR", Value:=2)>
            ONE_STAR = 2

            <ProtoBuf.ProtoEnum(Name:="TWO_STARS", Value:=3)>
            TWO_STARS = 3

            <ProtoBuf.ProtoEnum(Name:="THREE_STARS", Value:=4)>
            THREE_STARS = 4

            <ProtoBuf.ProtoEnum(Name:="FOUR_STARS", Value:=5)>
            FOUR_STARS = 5

            <ProtoBuf.ProtoEnum(Name:="FIVE_STARS", Value:=6)>
            FIVE_STARS = 6
        End Enum

        <ProtoBuf.ProtoContract(Name:="ExplicitType")>
        Public Enum ExplicitType

            <ProtoBuf.ProtoEnum(Name:="EXPLICIT", Value:=1)>
            EXPLICIT = 1

            <ProtoBuf.ProtoEnum(Name:="CLEAN", Value:=2)>
            CLEAN = 2

            <ProtoBuf.ProtoEnum(Name:="EDITED", Value:=3)>
            EDITED = 3
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="Tracks")>
    Partial Public Class Tracks
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private ReadOnly _track As New Global.System.Collections.Generic.List(Of Model.Track)()
        <ProtoBuf.ProtoMember(1, Name:="track", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property track() As Global.System.Collections.Generic.List(Of Model.Track)
            Get
                Return _track
            End Get
        End Property

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="Playlist")>
    Partial Public Class Playlist
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _id As String = ""
        <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        Private _client_id As String = ""
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property client_id() As String
            Get
                Return _client_id
            End Get
            Set
                _client_id = Value
            End Set
        End Property
        Private _creation_timestamp As Long = 0
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="creation_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property creation_timestamp() As Long
            Get
                Return _creation_timestamp
            End Get
            Set
                _creation_timestamp = Value
            End Set
        End Property
        Private _last_modified_timestamp As Long = 0
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="last_modified_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property last_modified_timestamp() As Long
            Get
                Return _last_modified_timestamp
            End Get
            Set
                _last_modified_timestamp = Value
            End Set
        End Property
        Private _deleted As Boolean = CBool(False)
        <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="deleted", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(CBool(False))>
        Public Property deleted() As Boolean
            Get
                Return _deleted
            End Get
            Set
                _deleted = Value
            End Set
        End Property
        Private _name As String = ""
        <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="name", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property name() As String
            Get
                Return _name
            End Get
            Set
                _name = Value
            End Set
        End Property
        Private _playlist_type As Model.Playlist.PlaylistType = Model.Playlist.PlaylistType.USER_GENERATED
        <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="playlist_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.Playlist.PlaylistType.USER_GENERATED)>
        Public Property playlist_type() As Model.Playlist.PlaylistType
            Get
                Return _playlist_type
            End Get
            Set
                _playlist_type = Value
            End Set
        End Property
        Private _playlist_art_ref As Model.ImageRef = Nothing
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="playlist_art_ref", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property playlist_art_ref() As Model.ImageRef
            Get
                Return _playlist_art_ref
            End Get
            Set
                _playlist_art_ref = Value
            End Set
        End Property
        Private _recent_timestamp As Long = 0
        <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="recent_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property recent_timestamp() As Long
            Get
                Return _recent_timestamp
            End Get
            Set
                _recent_timestamp = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="PlaylistType")>
        Public Enum PlaylistType

            <ProtoBuf.ProtoEnum(Name:="USER_GENERATED", Value:=1)>
            USER_GENERATED = 1

            <ProtoBuf.ProtoEnum(Name:="MAGIC", Value:=2)>
            MAGIC = 2

            <ProtoBuf.ProtoEnum(Name:="PROMO", Value:=3)>
            PROMO = 3
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="PlaylistEntry")>
    Partial Public Class PlaylistEntry
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _playlist_id As String = ""
        <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="playlist_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property playlist_id() As String
            Get
                Return _playlist_id
            End Get
            Set
                _playlist_id = Value
            End Set
        End Property
        Private _absolute_position As Long = 0
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="absolute_position", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property absolute_position() As Long
            Get
                Return _absolute_position
            End Get
            Set
                _absolute_position = Value
            End Set
        End Property
        Private _place_after_entry_id As String = ""
        <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="place_after_entry_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property place_after_entry_id() As String
            Get
                Return _place_after_entry_id
            End Get
            Set
                _place_after_entry_id = Value
            End Set
        End Property
        Private _track_id As String = ""
        <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="track_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property track_id() As String
            Get
                Return _track_id
            End Get
            Set
                _track_id = Value
            End Set
        End Property
        Private _id As String = ""
        <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        Private _client_id As String = ""
        <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property client_id() As String
            Get
                Return _client_id
            End Get
            Set
                _client_id = Value
            End Set
        End Property
        Private _creation_timestamp As Long = 0
        <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="creation_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property creation_timestamp() As Long
            Get
                Return _creation_timestamp
            End Get
            Set
                _creation_timestamp = Value
            End Set
        End Property
        Private _last_modified_timestamp As Long = 0
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="last_modified_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(0)>
        Public Property last_modified_timestamp() As Long
            Get
                Return _last_modified_timestamp
            End Get
            Set
                _last_modified_timestamp = Value
            End Set
        End Property
        Private _deleted As Boolean = CBool(False)
        <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="deleted", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(CBool(False))>
        Public Property deleted() As Boolean
            Get
                Return _deleted
            End Get
            Set
                _deleted = Value
            End Set
        End Property
        Private _relative_position_id_type As Model.PlaylistEntry.RelativePositionIdType = Model.PlaylistEntry.RelativePositionIdType.SERVER
        <ProtoBuf.ProtoMember(10, IsRequired:=False, Name:="relative_position_id_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.PlaylistEntry.RelativePositionIdType.SERVER)>
        Public Property relative_position_id_type() As Model.PlaylistEntry.RelativePositionIdType
            Get
                Return _relative_position_id_type
            End Get
            Set
                _relative_position_id_type = Value
            End Set
        End Property
        Private _track As Model.Track = Nothing
        <ProtoBuf.ProtoMember(15, IsRequired:=False, Name:="track", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property track() As Model.Track
            Get
                Return _track
            End Get
            Set
                _track = Value
            End Set
        End Property
        Private _place_before_entry_id As String = ""
        <ProtoBuf.ProtoMember(16, IsRequired:=False, Name:="place_before_entry_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property place_before_entry_id() As String
            Get
                Return _place_before_entry_id
            End Get
            Set
                _place_before_entry_id = Value
            End Set
        End Property
        Private _string_position As String = ""
        <ProtoBuf.ProtoMember(17, IsRequired:=False, Name:="string_position", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property string_position() As String
            Get
                Return _string_position
            End Get
            Set
                _string_position = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="RelativePositionIdType")>
        Public Enum RelativePositionIdType

            <ProtoBuf.ProtoEnum(Name:="SERVER", Value:=1)>
            SERVER = 1

            <ProtoBuf.ProtoEnum(Name:="CLIENT", Value:=2)>
            CLIENT = 2
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class
    <System.Serializable, ProtoBuf.ProtoContract(Name:="ProductId")>
    Partial Public Class ProductId
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _type As Model.ProductId.eType
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property type() As Model.ProductId.eType
            Get
                Return _type
            End Get
            Set
                _type = Value
            End Set
        End Property
        Private _completed As Boolean = CBool(False)
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="completed", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(CBool(False))>
        Public Property completed() As Boolean
            Get
                Return _completed
            End Get
            Set
                _completed = Value
            End Set
        End Property
        Private _id As String
        <ProtoBuf.ProtoMember(3, IsRequired:=True, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="Type")>
        Public Enum eType

            <ProtoBuf.ProtoEnum(Name:="UPC", Value:=1)>
            UPC = 1

            <ProtoBuf.ProtoEnum(Name:="GRID", Value:=2)>
            GRID = 2
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="AssetId")>
    Partial Public Class AssetId
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _type As Model.AssetId.eType
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property type() As Model.AssetId.eType
            Get
                Return _type
            End Get
            Set
                _type = Value
            End Set
        End Property
        Private _id As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="Type")>
        Public Enum eType

            <ProtoBuf.ProtoEnum(Name:="ISRC", Value:=1)>
            ISRC = 1
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="TransactionId")>
    Partial Public Class TransactionId
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _version As String
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="version", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property version() As String
            Get
                Return _version
            End Get
            Set
                _version = Value
            End Set
        End Property
        Private _id As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property id() As String
            Get
                Return _id
            End Get
            Set
                _id = Value
            End Set
        End Property
        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="MediaId")>
    Partial Public Class MediaId
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _algorithm_type As Model.MediaId.AlgorithmType
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="algorithm_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property algorithm_type() As Model.MediaId.AlgorithmType
            Get
                Return _algorithm_type
            End Get
            Set
                _algorithm_type = Value
            End Set
        End Property
        Private _hash As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="hash", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property hash() As String
            Get
                Return _hash
            End Get
            Set
                _hash = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="AlgorithmType")>
        Public Enum AlgorithmType

            <ProtoBuf.ProtoEnum(Name:="SHA256", Value:=1)>
            SHA256 = 1
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="UrlInfo")>
    Partial Public Class UrlInfo
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _type As Model.UrlInfo.eType
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property type() As Model.UrlInfo.eType
            Get
                Return _type
            End Get
            Set
                _type = Value
            End Set
        End Property
        Private _url As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="url", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property url() As String
            Get
                Return _url
            End Get
            Set
                _url = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="Type")>
        Public Enum eType

            <ProtoBuf.ProtoEnum(Name:="WCOM", Value:=1)>
            WCOM = 1

            <ProtoBuf.ProtoEnum(Name:="WCOP", Value:=2)>
            WCOP = 2

            <ProtoBuf.ProtoEnum(Name:="WOAF", Value:=3)>
            WOAF = 3

            <ProtoBuf.ProtoEnum(Name:="WOAR", Value:=4)>
            WOAR = 4

            <ProtoBuf.ProtoEnum(Name:="WOAS", Value:=5)>
            WOAS = 5

            <ProtoBuf.ProtoEnum(Name:="WORS", Value:=6)>
            WORS = 6

            <ProtoBuf.ProtoEnum(Name:="WPAY", Value:=7)>
            WPAY = 7

            <ProtoBuf.ProtoEnum(Name:="WPUB", Value:=8)>
            WPUB = 8
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="CopyrightStatus")>
    Partial Public Class CopyrightStatus
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _type As Model.CopyrightStatus.eType
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property type() As Model.CopyrightStatus.eType
            Get
                Return _type
            End Get
            Set
                _type = Value
            End Set
        End Property
        Private _copyright As String = ""
        <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="copyright", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue("")>
        Public Property copyright() As String
            Get
                Return _copyright
            End Get
            Set
                _copyright = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="Type")>
        Public Enum eType

            <ProtoBuf.ProtoEnum(Name:="UNSPECIFIED", Value:=1)>
            UNSPECIFIED = 1

            <ProtoBuf.ProtoEnum(Name:="ALLRIGHTSRESERVED", Value:=2)>
            ALLRIGHTSRESERVED = 2

            <ProtoBuf.ProtoEnum(Name:="PRERELEASE", Value:=3)>
            PRERELEASE = 3

            <ProtoBuf.ProtoEnum(Name:="OTHER", Value:=4)>
            OTHER = 4
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="Extra")>
    Partial Public Class Extra
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _type As String
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="type", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property type() As String
            Get
                Return _type
            End Get
            Set
                _type = Value
            End Set
        End Property
        Private _value As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="value", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property value() As String
            Get
                Return _value
            End Get
            Set
                _value = Value
            End Set
        End Property
        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="UitsMetadata")>
    Partial Public Class UitsMetadata
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _nonce As String
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="nonce", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property nonce() As String
            Get
                Return _nonce
            End Get
            Set
                _nonce = Value
            End Set
        End Property
        Private _distributor_id As String
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="distributor_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property distributor_id() As String
            Get
                Return _distributor_id
            End Get
            Set
                _distributor_id = Value
            End Set
        End Property
        Private _transaction_date As String
        <ProtoBuf.ProtoMember(3, IsRequired:=True, Name:="transaction_date", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property transaction_date() As String
            Get
                Return _transaction_date
            End Get
            Set
                _transaction_date = Value
            End Set
        End Property
        Private _product_id As Model.ProductId
        <ProtoBuf.ProtoMember(4, IsRequired:=True, Name:="product_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property product_id() As Model.ProductId
            Get
                Return _product_id
            End Get
            Set
                _product_id = Value
            End Set
        End Property
        Private _asset_id As Model.AssetId
        <ProtoBuf.ProtoMember(5, IsRequired:=True, Name:="asset_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property asset_id() As Model.AssetId
            Get
                Return _asset_id
            End Get
            Set
                _asset_id = Value
            End Set
        End Property
        Private _transaction_id As Model.TransactionId
        <ProtoBuf.ProtoMember(6, IsRequired:=True, Name:="transaction_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property transaction_id() As Model.TransactionId
            Get
                Return _transaction_id
            End Get
            Set
                _transaction_id = Value
            End Set
        End Property
        Private _media_id As Model.MediaId
        <ProtoBuf.ProtoMember(7, IsRequired:=True, Name:="media_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property media_id() As Model.MediaId
            Get
                Return _media_id
            End Get
            Set
                _media_id = Value
            End Set
        End Property
        Private _url_info As Model.UrlInfo = Nothing
        <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="url_info", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property url_info() As Model.UrlInfo
            Get
                Return _url_info
            End Get
            Set
                _url_info = Value
            End Set
        End Property
        Private _parental_advisory_type As Model.UitsMetadata.ParentalAdvisoryType = Model.UitsMetadata.ParentalAdvisoryType.UNSPECIFIED
        <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="parental_advisory_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        <System.ComponentModel.DefaultValue(Model.UitsMetadata.ParentalAdvisoryType.UNSPECIFIED)>
        Public Property parental_advisory_type() As Model.UitsMetadata.ParentalAdvisoryType
            Get
                Return _parental_advisory_type
            End Get
            Set
                _parental_advisory_type = Value
            End Set
        End Property
        Private _copyright_status As Model.CopyrightStatus = Nothing
        <ProtoBuf.ProtoMember(10, IsRequired:=False, Name:="copyright_status", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
        Public Property copyright_status() As Model.CopyrightStatus
            Get
                Return _copyright_status
            End Get
            Set
                _copyright_status = Value
            End Set
        End Property
        Private ReadOnly _extra As New Global.System.Collections.Generic.List(Of Model.Extra)()
        <ProtoBuf.ProtoMember(11, Name:="extra", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public ReadOnly Property extra() As Global.System.Collections.Generic.List(Of Model.Extra)
            Get
                Return _extra
            End Get
        End Property

        <ProtoBuf.ProtoContract(Name:="ParentalAdvisoryType")>
        Public Enum ParentalAdvisoryType

            <ProtoBuf.ProtoEnum(Name:="UNSPECIFIED", Value:=1)>
            UNSPECIFIED = 1

            <ProtoBuf.ProtoEnum(Name:="EXPLICIT", Value:=2)>
            EXPLICIT = 2

            <ProtoBuf.ProtoEnum(Name:="EDITED", Value:=3)>
            EDITED = 3
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="UitsSignature")>
    Partial Public Class UitsSignature
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _algorithm_type As Model.UitsSignature.AlgorithmType
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="algorithm_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property algorithm_type() As Model.UitsSignature.AlgorithmType
            Get
                Return _algorithm_type
            End Get
            Set
                _algorithm_type = Value
            End Set
        End Property
        Private _canonicalization_type As Model.UitsSignature.CanonicalizationType
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="canonicalization_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
        Public Property canonicalization_type() As Model.UitsSignature.CanonicalizationType
            Get
                Return _canonicalization_type
            End Get
            Set
                _canonicalization_type = Value
            End Set
        End Property
        Private _key_id As String
        <ProtoBuf.ProtoMember(3, IsRequired:=True, Name:="key_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property key_id() As String
            Get
                Return _key_id
            End Get
            Set
                _key_id = Value
            End Set
        End Property
        Private _value As String
        <ProtoBuf.ProtoMember(4, IsRequired:=True, Name:="value", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property value() As String
            Get
                Return _value
            End Get
            Set
                _value = Value
            End Set
        End Property
        <ProtoBuf.ProtoContract(Name:="AlgorithmType")>
        Public Enum AlgorithmType

            <ProtoBuf.ProtoEnum(Name:="RSA2048", Value:=1)>
            RSA2048 = 1

            <ProtoBuf.ProtoEnum(Name:="DSA2048", Value:=2)>
            DSA2048 = 2
        End Enum

        <ProtoBuf.ProtoContract(Name:="CanonicalizationType")>
        Public Enum CanonicalizationType

            <ProtoBuf.ProtoEnum(Name:="NONE", Value:=1)>
            NONE = 1
        End Enum

        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
    End Class

    <System.Serializable, ProtoBuf.ProtoContract(Name:="Uits")>
    Partial Public Class Uits
        Implements Global.ProtoBuf.IExtensible
        Public Sub New()
        End Sub

        Private _metadata As Model.UitsMetadata
        <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="metadata", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property metadata() As Model.UitsMetadata
            Get
                Return _metadata
            End Get
            Set
                _metadata = Value
            End Set
        End Property
        Private _signature As Model.UitsSignature
        <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="signature", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
        Public Property signature() As Model.UitsSignature
            Get
                Return _signature
            End Get
            Set
                _signature = Value
            End Set
        End Property
        Private extensionObject As Global.ProtoBuf.IExtension
        Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
            Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
        End Function
        <System.Serializable, ProtoBuf.ProtoContract(Name:="ResponseStatus")>
        Partial Public Class ResponseStatus
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _response_code As ResponseStatus.ResponseCode
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="response_code", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            Public Property response_code() As ResponseStatus.ResponseCode
                Get
                    Return _response_code
                End Get
                Set
                    _response_code = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="ResponseCode")>
            Public Enum ResponseCode

                <ProtoBuf.ProtoEnum(Name:="OK", Value:=1)>
                OK = 1

                <ProtoBuf.ProtoEnum(Name:="ALREADY_EXISTS", Value:=2)>
                ALREADY_EXISTS = 2

                <ProtoBuf.ProtoEnum(Name:="SOFT_ERROR", Value:=3)>
                SOFT_ERROR = 3

                <ProtoBuf.ProtoEnum(Name:="METADATA_TOO_LARGE", Value:=4)>
                METADATA_TOO_LARGE = 4
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadOperation")>
        Partial Public Class UploadOperation
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _operation As UploadOperation.eOperation
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="operation", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            Public Property operation() As UploadOperation.eOperation
                Get
                    Return _operation
                End Get
                Set
                    _operation = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="Operation")>
            Public Enum eOperation

                <ProtoBuf.ProtoEnum(Name:="OPERATION_CREATE", Value:=1)>
                OPERATION_CREATE = 1

                <ProtoBuf.ProtoEnum(Name:="OPERATION_MODIFY", Value:=2)>
                OPERATION_MODIFY = 2

                <ProtoBuf.ProtoEnum(Name:="OPERATION_DELETE", Value:=3)>
                OPERATION_DELETE = 3
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="EnhancedChallenge")>
        Partial Public Class EnhancedChallenge
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _hash_algorithm As EnhancedChallenge.HashAlgorithm = EnhancedChallenge.HashAlgorithm.SHA_256
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="hash_algorithm", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(EnhancedChallenge.HashAlgorithm.SHA_256)>
            Public Property hash_algorithm() As EnhancedChallenge.HashAlgorithm
                Get
                    Return _hash_algorithm
                End Get
                Set
                    _hash_algorithm = Value
                End Set
            End Property
            Private _random_seed As Byte() = Nothing
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="random_seed", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property random_seed() As Byte()
                Get
                    Return _random_seed
                End Get
                Set
                    _random_seed = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="HashAlgorithm")>
            Public Enum HashAlgorithm

                <ProtoBuf.ProtoEnum(Name:="SHA_256", Value:=1)>
                SHA_256 = 1

                <ProtoBuf.ProtoEnum(Name:="MD5", Value:=2)>
                MD5 = 2
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="ChallengeInfo")>
        Partial Public Class ChallengeInfo
            ' : global::ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _client_track_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="client_track_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property client_track_id() As String
                Get
                    Return _client_track_id
                End Get
                Set
                    _client_track_id = Value
                End Set
            End Property
            Private _start_millis As Integer
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="start_millis", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property start_millis() As Integer
                Get
                    Return _start_millis
                End Get
                Set
                    _start_millis = Value
                End Set
            End Property
            Private _duration_millis As Integer
            <ProtoBuf.ProtoMember(3, IsRequired:=True, Name:="duration_millis", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property duration_millis() As Integer
                Get
                    Return _duration_millis
                End Get
                Set
                    _duration_millis = Value
                End Set
            End Property
            Private _challenge_user_id As String = ""
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="challenge_user_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property challenge_user_id() As String
                Get
                    Return _challenge_user_id
                End Get
                Set
                    _challenge_user_id = Value
                End Set
            End Property
            Private _challenge_timestamp As Long = 0
            <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="challenge_timestamp", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(0)>
            Public Property challenge_timestamp() As Long
                Get
                    Return _challenge_timestamp
                End Get
                Set
                    _challenge_timestamp = Value
                End Set
            End Property
            Private _expect_match As Boolean = False
            <ProtoBuf.ProtoMember(6, IsRequired:=True, Name:="expect_match", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property expect_match() As Boolean
                Get
                    Return _expect_match
                End Get
                Set
                    _expect_match = Value
                End Set
            End Property
            'private Protocol.EnhancedChallenge _enhanced_challenge = null;
            '[global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"enhanced_challenge", DataFormat = global::ProtoBuf.DataFormat.Default)]
            '[global::System.ComponentModel.DefaultValue(null)]
            'public Protocol.EnhancedChallenge enhanced_challenge
            '{
            '  get { return _enhanced_challenge; }
            '  set { _enhanced_challenge = value; }
            '}
            'private global::ProtoBuf.IExtension extensionObject;
            'global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            '  { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="EnhancedChallengeResponse")>
        Partial Public Class EnhancedChallengeResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _challenge_answer As Byte() = Nothing
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="challenge_answer", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property challenge_answer() As Byte()
                Get
                    Return _challenge_answer
                End Get
                Set
                    _challenge_answer = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="SignedChallengeInfo")>
        Partial Public Class SignedChallengeInfo
            ' : global::ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _challenge_info As ChallengeInfo
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="challenge_info", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property challenge_info() As ChallengeInfo
                Get
                    Return _challenge_info
                End Get
                Set
                    _challenge_info = Value
                End Set
            End Property
            Private _signature As Byte()
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="signature", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property signature() As Byte()
                Get
                    Return _signature
                End Get
                Set
                    _signature = Value
                End Set
            End Property
            'private global::ProtoBuf.IExtension extensionObject;
            'global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            '  { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="TrackSample")>
        Partial Public Class TrackSample
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _track As Model.Track
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="track", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property track() As Model.Track
                Get
                    Return _track
                End Get
                Set
                    _track = Value
                End Set
            End Property
            Private _signed_challenge_info As SignedChallengeInfo
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="signed_challenge_info", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property signed_challenge_info() As SignedChallengeInfo
                Get
                    Return _signed_challenge_info
                End Get
                Set
                    _signed_challenge_info = Value
                End Set
            End Property
            Private _sample As Byte() = Nothing
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="sample", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property sample() As Byte()
                Get
                    Return _sample
                End Get
                Set
                    _sample = Value
                End Set
            End Property
            Private _sample_format As Model.Track.ContentType = Model.Track.ContentType.MP3
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="sample_format", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(Model.Track.ContentType.MP3)>
            Public Property sample_format() As Model.Track.ContentType
                Get
                    Return _sample_format
                End Get
                Set
                    _sample_format = Value
                End Set
            End Property
            Private _user_album_art As ImageUnion = Nothing
            <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="user_album_art", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property user_album_art() As ImageUnion
                Get
                    Return _user_album_art
                End Get
                Set
                    _user_album_art = Value
                End Set
            End Property
            Private _enhanced_challenge_response As Byte() = Nothing
            <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="enhanced_challenge_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property enhanced_challenge_response() As Byte()
                Get
                    Return _enhanced_challenge_response
                End Get
                Set
                    _enhanced_challenge_response = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadPlaylistRequest")>
        Partial Public Class UploadPlaylistRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _upload_operation As UploadOperation
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="upload_operation", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property upload_operation() As UploadOperation
                Get
                    Return _upload_operation
                End Get
                Set
                    _upload_operation = Value
                End Set
            End Property
            Private ReadOnly _playlist As New Global.System.Collections.Generic.List(Of Model.Playlist)()
            <ProtoBuf.ProtoMember(2, Name:="playlist", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property playlist() As Global.System.Collections.Generic.List(Of Model.Playlist)
                Get
                    Return _playlist
                End Get
            End Property

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(3, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="PlaylistResponse")>
        Partial Public Class PlaylistResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _response_status As ResponseStatus
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="response_status", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property response_status() As ResponseStatus
                Get
                    Return _response_status
                End Get
                Set
                    _response_status = Value
                End Set
            End Property
            Private _client_id As String = ""
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property client_id() As String
                Get
                    Return _client_id
                End Get
                Set
                    _client_id = Value
                End Set
            End Property
            Private _server_id As String = ""
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="server_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property server_id() As String
                Get
                    Return _server_id
                End Get
                Set
                    _server_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadPlaylistResponse")>
        Partial Public Class UploadPlaylistResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _playlist_response As New Global.System.Collections.Generic.List(Of PlaylistResponse)()
            <ProtoBuf.ProtoMember(1, Name:="playlist_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property playlist_response() As Global.System.Collections.Generic.List(Of PlaylistResponse)
                Get
                    Return _playlist_response
                End Get
            End Property

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadPlaylistEntryRequest")>
        Partial Public Class UploadPlaylistEntryRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _upload_operation As UploadOperation
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="upload_operation", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property upload_operation() As UploadOperation
                Get
                    Return _upload_operation
                End Get
                Set
                    _upload_operation = Value
                End Set
            End Property
            Private ReadOnly _playlist_entry As New Global.System.Collections.Generic.List(Of Model.PlaylistEntry)()
            <ProtoBuf.ProtoMember(2, Name:="playlist_entry", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property playlist_entry() As Global.System.Collections.Generic.List(Of Model.PlaylistEntry)
                Get
                    Return _playlist_entry
                End Get
            End Property

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(3, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="PlaylistEntryResponse")>
        Partial Public Class PlaylistEntryResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _response_status As ResponseStatus
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="response_status", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property response_status() As ResponseStatus
                Get
                    Return _response_status
                End Get
                Set
                    _response_status = Value
                End Set
            End Property
            Private _client_id As String = ""
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property client_id() As String
                Get
                    Return _client_id
                End Get
                Set
                    _client_id = Value
                End Set
            End Property
            Private _server_id As String = ""
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="server_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property server_id() As String
                Get
                    Return _server_id
                End Get
                Set
                    _server_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadPlaylistEntryResponse")>
        Partial Public Class UploadPlaylistEntryResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _playlist_entry_response As New Global.System.Collections.Generic.List(Of PlaylistEntryResponse)()
            <ProtoBuf.ProtoMember(1, Name:="playlist_entry_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property playlist_entry_response() As Global.System.Collections.Generic.List(Of PlaylistEntryResponse)
                Get
                    Return _playlist_entry_response
                End Get
            End Property

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadMetadataRequest")>
        Partial Public Class UploadMetadataRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _track As New Global.System.Collections.Generic.List(Of Model.Track)()
            <ProtoBuf.ProtoMember(1, Name:="track", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property track() As Global.System.Collections.Generic.List(Of Model.Track)
                Get
                    Return _track
                End Get
            End Property

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UpdateUploadStateRequest")>
        Partial Public Class UpdateUploadStateRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _state As UpdateUploadStateRequest.UploadState
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="state", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            Public Property state() As UpdateUploadStateRequest.UploadState
                Get
                    Return _state
                End Get
                Set
                    _state = Value
                End Set
            End Property
            Private _uploader_id As String
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="UploadState")>
            Public Enum UploadState

                <ProtoBuf.ProtoEnum(Name:="START", Value:=1)>
                START = 1

                <ProtoBuf.ProtoEnum(Name:="PAUSED", Value:=2)>
                PAUSED = 2

                <ProtoBuf.ProtoEnum(Name:="STOPPED", Value:=3)>
                STOPPED = 3
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="ClientStateRequest")>
        Partial Public Class ClientStateRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private _get_purchased_tracks_since As Long = 0
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="get_purchased_tracks_since", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property get_purchased_tracks_since() As Long
                Get
                    Return _get_purchased_tracks_since
                End Get
                Set
                    _get_purchased_tracks_since = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="ClientStateResponse")>
        Partial Public Class ClientStateResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _locker_track_limit As Long = 0
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="locker_track_limit", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property locker_track_limit() As Long
                Get
                    Return _locker_track_limit
                End Get
                Set
                    _locker_track_limit = Value
                End Set
            End Property
            Private _user_songs_in_locker As Long = 0
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="user_songs_in_locker", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property user_songs_in_locker() As Long
                Get
                    Return _user_songs_in_locker
                End Get
                Set
                    _user_songs_in_locker = Value
                End Set
            End Property
            Private _track_size_limit_in_mb As Integer = 0
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="track_size_limit_in_mb", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property track_size_limit_in_mb() As Integer
                Get
                    Return _track_size_limit_in_mb
                End Get
                Set
                    _track_size_limit_in_mb = Value
                End Set
            End Property
            Private _user_purchased_tracks_since As Long = 0
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="user_purchased_tracks_since", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property user_purchased_tracks_since() As Long
                Get
                    Return _user_purchased_tracks_since
                End Get
                Set
                    _user_purchased_tracks_since = Value
                End Set
            End Property
            Private _total_track_count As Long = 0
            <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="total_track_count", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property total_track_count() As Long
                Get
                    Return _total_track_count
                End Get
                Set
                    _total_track_count = Value
                End Set
            End Property
            Private _override_config As OverrideConfigValueCollection = Nothing
            <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="override_config", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property override_config() As OverrideConfigValueCollection
                Get
                    Return _override_config
                End Get
                Set
                    _override_config = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadMetadataResponse")>
        Partial Public Class UploadMetadataResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _signed_challenge_info As New Global.System.Collections.Generic.List(Of SignedChallengeInfo)()
            <ProtoBuf.ProtoMember(1, Name:="signed_challenge_info", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property signed_challenge_info() As Global.System.Collections.Generic.List(Of SignedChallengeInfo)
                Get
                    Return _signed_challenge_info
                End Get
            End Property

            Private ReadOnly _upload_id As New Global.System.Collections.Generic.List(Of String)()
            <ProtoBuf.ProtoMember(2, Name:="upload_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property upload_id() As Global.System.Collections.Generic.List(Of String)
                Get
                    Return _upload_id
                End Get
            End Property

            Private ReadOnly _track_sample_response As New Global.System.Collections.Generic.List(Of TrackSampleResponse)()
            <ProtoBuf.ProtoMember(3, Name:="track_sample_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property track_sample_response() As Global.System.Collections.Generic.List(Of TrackSampleResponse)
                Get
                    Return _track_sample_response
                End Get
            End Property

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="TrackSampleResponse")>
        Partial Public Class TrackSampleResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _client_track_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="client_track_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property client_track_id() As String
                Get
                    Return _client_track_id
                End Get
                Set
                    _client_track_id = Value
                End Set
            End Property
            Private _response_code As TrackSampleResponse.ResponseCode
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="response_code", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            Public Property response_code() As TrackSampleResponse.ResponseCode
                Get
                    Return _response_code
                End Get
                Set
                    _response_code = Value
                End Set
            End Property
            Private _server_track_id As String = ""
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="server_track_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property server_track_id() As String
                Get
                    Return _server_track_id
                End Get
                Set
                    _server_track_id = Value
                End Set
            End Property
            Private _album_art_url As String = ""
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="album_art_url", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property album_art_url() As String
                Get
                    Return _album_art_url
                End Get
                Set
                    _album_art_url = Value
                End Set
            End Property
            Private _expect_match As Boolean = False
            <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="expect_match", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property expect_match() As Boolean
                Get
                    Return _expect_match
                End Get
                Set
                    _expect_match = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="ResponseCode")>
            Public Enum ResponseCode

                <ProtoBuf.ProtoEnum(Name:="MATCHED", Value:=1)>
                MATCHED = 1

                <ProtoBuf.ProtoEnum(Name:="UPLOAD_REQUESTED", Value:=2)>
                UPLOAD_REQUESTED = 2

                <ProtoBuf.ProtoEnum(Name:="INVALID_SIGNATURE", Value:=3)>
                INVALID_SIGNATURE = 3

                <ProtoBuf.ProtoEnum(Name:="ALREADY_EXISTS", Value:=4)>
                ALREADY_EXISTS = 4

                <ProtoBuf.ProtoEnum(Name:="TRANSIENT_ERROR", Value:=5)>
                TRANSIENT_ERROR = 5

                <ProtoBuf.ProtoEnum(Name:="PERMANENT_ERROR", Value:=6)>
                PERMANENT_ERROR = 6

                <ProtoBuf.ProtoEnum(Name:="TRACK_COUNT_LIMIT_REACHED", Value:=7)>
                TRACK_COUNT_LIMIT_REACHED = 7

                <ProtoBuf.ProtoEnum(Name:="REJECT_STORE_TRACK", Value:=8)>
                REJECT_STORE_TRACK = 8

                <ProtoBuf.ProtoEnum(Name:="REJECT_STORE_TRACK_BY_LABEL", Value:=9)>
                REJECT_STORE_TRACK_BY_LABEL = 9

                <ProtoBuf.ProtoEnum(Name:="REJECT_DRM_TRACK", Value:=10)>
                REJECT_DRM_TRACK = 10
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadSampleRequest")>
        Partial Public Class UploadSampleRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _track_sample As New Global.System.Collections.Generic.List(Of TrackSample)()
            <ProtoBuf.ProtoMember(1, Name:="track_sample", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property track_sample() As Global.System.Collections.Generic.List(Of TrackSample)
                Get
                    Return _track_sample
                End Get
            End Property

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadSampleResponse")>
        Partial Public Class UploadSampleResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _track_sample_response As New Global.System.Collections.Generic.List(Of TrackSampleResponse)()
            <ProtoBuf.ProtoMember(1, Name:="track_sample_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property track_sample_response() As Global.System.Collections.Generic.List(Of TrackSampleResponse)
                Get
                    Return _track_sample_response
                End Get
            End Property

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="ImageUnion")>
        Partial Public Class ImageUnion
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _user_album_art As Byte() = Nothing
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="user_album_art", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property user_album_art() As Byte()
                Get
                    Return _user_album_art
                End Get
                Set
                    _user_album_art = Value
                End Set
            End Property
            Private _album_art_url As String = ""
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="album_art_url", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property album_art_url() As String
                Get
                    Return _album_art_url
                End Get
                Set
                    _album_art_url = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadResponse")>
        Partial Public Class UploadResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _response_type As UploadResponse.ResponseType = UploadResponse.ResponseType.METADATA_RESPONSE
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="response_type", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(UploadResponse.ResponseType.METADATA_RESPONSE)>
            Public Property response_type() As UploadResponse.ResponseType
                Get
                    Return _response_type
                End Get
                Set
                    _response_type = Value
                End Set
            End Property
            Private _metadata_response As UploadMetadataResponse = Nothing
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="metadata_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property metadata_response() As UploadMetadataResponse
                Get
                    Return _metadata_response
                End Get
                Set
                    _metadata_response = Value
                End Set
            End Property
            Private _playlist_response As UploadPlaylistResponse = Nothing
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="playlist_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property playlist_response() As UploadPlaylistResponse
                Get
                    Return _playlist_response
                End Get
                Set
                    _playlist_response = Value
                End Set
            End Property
            Private _playlist_entry_response As UploadPlaylistEntryResponse = Nothing
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="playlist_entry_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property playlist_entry_response() As UploadPlaylistEntryResponse
                Get
                    Return _playlist_entry_response
                End Get
                Set
                    _playlist_entry_response = Value
                End Set
            End Property
            Private _sample_response As UploadSampleResponse = Nothing
            <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="sample_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property sample_response() As UploadSampleResponse
                Get
                    Return _sample_response
                End Get
                Set
                    _sample_response = Value
                End Set
            End Property
            Private _getjobs_response As GetJobsResponse = Nothing
            <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="getjobs_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property getjobs_response() As GetJobsResponse
                Get
                    Return _getjobs_response
                End Get
                Set
                    _getjobs_response = Value
                End Set
            End Property
            Private _clientstate_response As ClientStateResponse = Nothing
            <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="clientstate_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property clientstate_response() As ClientStateResponse
                Get
                    Return _clientstate_response
                End Get
                Set
                    _clientstate_response = Value
                End Set
            End Property
            Private _policy As ClientPolicy = Nothing
            <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="policy", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property policy() As ClientPolicy
                Get
                    Return _policy
                End Get
                Set
                    _policy = Value
                End Set
            End Property
            Private _auth_status As UploadResponse.AuthStatus = UploadResponse.AuthStatus.OK
            <ProtoBuf.ProtoMember(11, IsRequired:=False, Name:="auth_status", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(UploadResponse.AuthStatus.OK)>
            Public Property auth_status() As UploadResponse.AuthStatus
                Get
                    Return _auth_status
                End Get
                Set
                    _auth_status = Value
                End Set
            End Property
            Private _auth_error As Boolean = False
            <ProtoBuf.ProtoMember(12, IsRequired:=False, Name:="auth_error", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property auth_error() As Boolean
                Get
                    Return _auth_error
                End Get
                Set
                    _auth_error = Value
                End Set
            End Property
            Private _upauth_response As UpAuthResponse = Nothing
            <ProtoBuf.ProtoMember(13, IsRequired:=False, Name:="upauth_response", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(DirectCast(Nothing, Object))>
            Public Property upauth_response() As UpAuthResponse
                Get
                    Return _upauth_response
                End Get
                Set
                    _upauth_response = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="ResponseType")>
            Public Enum ResponseType

                <ProtoBuf.ProtoEnum(Name:="METADATA_RESPONSE", Value:=1)>
                METADATA_RESPONSE = 1

                <ProtoBuf.ProtoEnum(Name:="PLAYLIST_RESPONSE", Value:=2)>
                PLAYLIST_RESPONSE = 2

                <ProtoBuf.ProtoEnum(Name:="PLAYLIST_ENTRY_RESPONSE", Value:=3)>
                PLAYLIST_ENTRY_RESPONSE = 3

                <ProtoBuf.ProtoEnum(Name:="SAMPLE_RESPONSE", Value:=4)>
                SAMPLE_RESPONSE = 4

                <ProtoBuf.ProtoEnum(Name:="GETJOBS_RESPONSE", Value:=5)>
                GETJOBS_RESPONSE = 5

                <ProtoBuf.ProtoEnum(Name:="AUTH_RESPONSE", Value:=6)>
                AUTH_RESPONSE = 6

                <ProtoBuf.ProtoEnum(Name:="CLIENT_STATE_RESPONSE", Value:=7)>
                CLIENT_STATE_RESPONSE = 7

                <ProtoBuf.ProtoEnum(Name:="UPDATE_UPLOAD_STATE_RESPONSE", Value:=8)>
                UPDATE_UPLOAD_STATE_RESPONSE = 8

                <ProtoBuf.ProtoEnum(Name:="DELETE_UPLOAD_REQUESTED_RESPONSE", Value:=9)>
                DELETE_UPLOAD_REQUESTED_RESPONSE = 9
            End Enum

            <ProtoBuf.ProtoContract(Name:="AuthStatus")>
            Public Enum AuthStatus

                <ProtoBuf.ProtoEnum(Name:="OK", Value:=8)>
                OK = 8

                <ProtoBuf.ProtoEnum(Name:="MAX_LIMIT_REACHED", Value:=9)>
                MAX_LIMIT_REACHED = 9

                <ProtoBuf.ProtoEnum(Name:="CLIENT_BOUND_TO_OTHER_ACCOUNT", Value:=10)>
                CLIENT_BOUND_TO_OTHER_ACCOUNT = 10

                <ProtoBuf.ProtoEnum(Name:="CLIENT_NOT_AUTHORIZED", Value:=11)>
                CLIENT_NOT_AUTHORIZED = 11

                <ProtoBuf.ProtoEnum(Name:="MAX_PER_MACHINE_USERS_EXCEEDED", Value:=12)>
                MAX_PER_MACHINE_USERS_EXCEEDED = 12

                <ProtoBuf.ProtoEnum(Name:="CLIENT_PLEASE_RETRY", Value:=13)>
                CLIENT_PLEASE_RETRY = 13

                <ProtoBuf.ProtoEnum(Name:="NOT_SUBSCRIBED", Value:=14)>
                NOT_SUBSCRIBED = 14

                <ProtoBuf.ProtoEnum(Name:="INVALID_REQUEST", Value:=15)>
                INVALID_REQUEST = 15

                <ProtoBuf.ProtoEnum(Name:="UPGRADE_MUSIC_MANAGER", Value:=16)>
                UPGRADE_MUSIC_MANAGER = 16
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="TracksToUpload")>
        Partial Public Class TracksToUpload
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _client_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="client_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property client_id() As String
                Get
                    Return _client_id
                End Get
                Set
                    _client_id = Value
                End Set
            End Property
            Private _server_id As String
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="server_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property server_id() As String
                Get
                    Return _server_id
                End Get
                Set
                    _server_id = Value
                End Set
            End Property
            Private _status As TracksToUpload.TrackStatus
            <ProtoBuf.ProtoMember(5, IsRequired:=True, Name:="status", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            Public Property status() As TracksToUpload.TrackStatus
                Get
                    Return _status
                End Get
                Set
                    _status = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="TrackStatus")>
            Public Enum TrackStatus

                <ProtoBuf.ProtoEnum(Name:="FORCE_REUPLOAD", Value:=3)>
                FORCE_REUPLOAD = 3

                <ProtoBuf.ProtoEnum(Name:="UPLOAD_REQUESTED", Value:=4)>
                UPLOAD_REQUESTED = 4
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="GetJobsRequest")>
        Partial Public Class GetJobsRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="GetJobsResponse")>
        Partial Public Class GetJobsResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _tracks_to_upload As New Global.System.Collections.Generic.List(Of TracksToUpload)()
            <ProtoBuf.ProtoMember(1, Name:="tracks_to_upload", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property tracks_to_upload() As Global.System.Collections.Generic.List(Of TracksToUpload)
                Get
                    Return _tracks_to_upload
                End Get
            End Property

            Private _get_tracks_success As Boolean
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="get_tracks_success", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property get_tracks_success() As Boolean
                Get
                    Return _get_tracks_success
                End Get
                Set
                    _get_tracks_success = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UpAuthRequest")>
        Partial Public Class UpAuthRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private _friendly_name As String = ""
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="friendly_name", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property friendly_name() As String
                Get
                    Return _friendly_name
                End Get
                Set
                    _friendly_name = Value
                End Set
            End Property
            Private _mac_identifier As String = ""
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="mac_identifier", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property mac_identifier() As String
                Get
                    Return _mac_identifier
                End Get
                Set
                    _mac_identifier = Value
                End Set
            End Property
            Private _hash_identifier As String = ""
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="hash_identifier", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property hash_identifier() As String
                Get
                    Return _hash_identifier
                End Get
                Set
                    _hash_identifier = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UpAuthResponse")>
        Partial Public Class UpAuthResponse
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _uploader_id As String = ""
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="DeleteUploadRequestedRequest")>
        Partial Public Class DeleteUploadRequestedRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _uploader_id As String
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="uploader_id", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property uploader_id() As String
                Get
                    Return _uploader_id
                End Get
                Set
                    _uploader_id = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="ClientPolicy")>
        Partial Public Class ClientPolicy
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _pause_uploads As Boolean = False
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="pause_uploads", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property pause_uploads() As Boolean
                Get
                    Return _pause_uploads
                End Get
                Set
                    _pause_uploads = Value
                End Set
            End Property
            Private _abort As Boolean = False
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="abort", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property abort() As Boolean
                Get
                    Return _abort
                End Get
                Set
                    _abort = Value
                End Set
            End Property
            Private _retry_in_minutes As Integer = 0
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="retry_in_minutes", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property retry_in_minutes() As Integer
                Get
                    Return _retry_in_minutes
                End Get
                Set
                    _retry_in_minutes = Value
                End Set
            End Property
            Private _bandwidth_cap_kbps As Integer = 0
            <ProtoBuf.ProtoMember(4, IsRequired:=False, Name:="bandwidth_cap_kbps", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property bandwidth_cap_kbps() As Integer
                Get
                    Return _bandwidth_cap_kbps
                End Get
                Set
                    _bandwidth_cap_kbps = Value
                End Set
            End Property
            Private _pause_downloads As Boolean = False
            <ProtoBuf.ProtoMember(5, IsRequired:=False, Name:="pause_downloads", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property pause_downloads() As Boolean
                Get
                    Return _pause_downloads
                End Get
                Set
                    _pause_downloads = Value
                End Set
            End Property
            Private _download_bandwidth_cap_kbps As Integer = 0
            <ProtoBuf.ProtoMember(6, IsRequired:=False, Name:="download_bandwidth_cap_kbps", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(0)>
            Public Property download_bandwidth_cap_kbps() As Integer
                Get
                    Return _download_bandwidth_cap_kbps
                End Get
                Set
                    _download_bandwidth_cap_kbps = Value
                End Set
            End Property
            Private _send_analytics As Boolean = False
            <ProtoBuf.ProtoMember(7, IsRequired:=False, Name:="send_analytics", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property send_analytics() As Boolean
                Get
                    Return _send_analytics
                End Get
                Set
                    _send_analytics = Value
                End Set
            End Property
            Private _analytics_url As String = ""
            <ProtoBuf.ProtoMember(8, IsRequired:=False, Name:="analytics_url", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property analytics_url() As String
                Get
                    Return _analytics_url
                End Get
                Set
                    _analytics_url = Value
                End Set
            End Property
            Private _enable_gapless As Boolean = False
            <ProtoBuf.ProtoMember(9, IsRequired:=False, Name:="enable_gapless", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property enable_gapless() As Boolean
                Get
                    Return _enable_gapless
                End Get
                Set
                    _enable_gapless = Value
                End Set
            End Property
            Private _enable_m4p As Boolean = False
            <ProtoBuf.ProtoMember(10, IsRequired:=False, Name:="enable_m4p", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue(False)>
            Public Property enable_m4p() As Boolean
                Get
                    Return _enable_m4p
                End Get
                Set
                    _enable_m4p = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="UploadMetadataInternalRequest")>
        Partial Public Class UploadMetadataInternalRequest
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _gaiaid As ULong
            <ProtoBuf.ProtoMember(1, IsRequired:=True, Name:="gaiaid", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            Public Property gaiaid() As ULong
                Get
                    Return _gaiaid
                End Get
                Set
                    _gaiaid = Value
                End Set
            End Property
            Private _request As UploadMetadataRequest
            <ProtoBuf.ProtoMember(2, IsRequired:=True, Name:="request", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public Property request() As UploadMetadataRequest
                Get
                    Return _request
                End Get
                Set
                    _request = Value
                End Set
            End Property
            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="OverrideConfigValue")>
        Partial Public Class OverrideConfigValue
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private _key As String = ""
            <ProtoBuf.ProtoMember(1, IsRequired:=False, Name:="key", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property key() As String
                Get
                    Return _key
                End Get
                Set
                    _key = Value
                End Set
            End Property
            Private _value As String = ""
            <ProtoBuf.ProtoMember(2, IsRequired:=False, Name:="value", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            <System.ComponentModel.DefaultValue("")>
            Public Property value() As String
                Get
                    Return _value
                End Get
                Set
                    _value = Value
                End Set
            End Property
            Private _priority As OverrideConfigValue.OverridePriority = OverrideConfigValue.OverridePriority.DEFAULT_PRIORITY
            <ProtoBuf.ProtoMember(3, IsRequired:=False, Name:="priority", DataFormat:=Global.ProtoBuf.DataFormat.TwosComplement)>
            <System.ComponentModel.DefaultValue(OverrideConfigValue.OverridePriority.DEFAULT_PRIORITY)>
            Public Property priority() As OverrideConfigValue.OverridePriority
                Get
                    Return _priority
                End Get
                Set
                    _priority = Value
                End Set
            End Property
            <ProtoBuf.ProtoContract(Name:="OverridePriority")>
            Public Enum OverridePriority

                <ProtoBuf.ProtoEnum(Name:="DEFAULT_PRIORITY", Value:=-1)>
                DEFAULT_PRIORITY = -1

                <ProtoBuf.ProtoEnum(Name:="LOWEST_PRIORITY", Value:=100)>
                LOWEST_PRIORITY = 100

                <ProtoBuf.ProtoEnum(Name:="LOW_PRIORITY", Value:=200)>
                LOW_PRIORITY = 200

                <ProtoBuf.ProtoEnum(Name:="MEDIUM_PRIORITY", Value:=300)>
                MEDIUM_PRIORITY = 300

                <ProtoBuf.ProtoEnum(Name:="HIGH_PRIORITY", Value:=400)>
                HIGH_PRIORITY = 400

                <ProtoBuf.ProtoEnum(Name:="HIGHEST_PRIORITY", Value:=500)>
                HIGHEST_PRIORITY = 500
            End Enum

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class

        <System.Serializable, ProtoBuf.ProtoContract(Name:="OverrideConfigValueCollection")>
        Partial Public Class OverrideConfigValueCollection
            Implements Global.ProtoBuf.IExtensible
            Public Sub New()
            End Sub

            Private ReadOnly _value As New Global.System.Collections.Generic.List(Of OverrideConfigValue)()
            <ProtoBuf.ProtoMember(1, Name:="value", DataFormat:=Global.ProtoBuf.DataFormat.[Default])>
            Public ReadOnly Property value() As Global.System.Collections.Generic.List(Of OverrideConfigValue)
                Get
                    Return _value
                End Get
            End Property

            Private extensionObject As Global.ProtoBuf.IExtension
            Private Function ProtoBuf_IExtensible_GetExtensionObject(createIfMissing As Boolean) As Global.ProtoBuf.IExtension Implements Global.ProtoBuf.IExtensible.GetExtensionObject
                Return Global.ProtoBuf.Extensible.GetExtensionObject(extensionObject, createIfMissing)
            End Function
        End Class
    End Class
End Namespace