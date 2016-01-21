Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Net.Http.Handlers

Imports ProtoBuf
Imports Newtonsoft.Json


Namespace Http
    Public Class GoogleHttp
        Public Enum ResultType
            NULL_TYPE
            STRING_TYPE
            STREAM_TYPE
            PROTOBUF_DESERIALIZE_TYPE
            JSON_DESERIALIZE_TYPE
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
        Public ReadOnly Property LastCode As HttpStatusCode
            Get
                Return _LastCode
            End Get
        End Property
        Public ReadOnly Property LastResponseHeader As HttpResponseHeaders
            Get
                Return _LastResponseHeader
            End Get
        End Property
        Public ReadOnly Property LastResponseCookies As CookieContainer
            Get
                Return Container
            End Get
        End Property

        Public Headers As Dictionary(Of String, String) = New Dictionary(Of String, String)
        '==================================================
        Private _ReceiveEvent As Action(Of Long, Long, Integer, String)
        Private _SendEvent As Action(Of Long, Long, Integer, String)

        Private Client As HttpClient
        Private Request As HttpRequestMessage
        Private Response As HttpResponseMessage
        Private Container As CookieContainer

        Private _LastCode As HttpStatusCode
        Private _LastResponseHeader As HttpResponseHeaders
        Private _Info As Dictionary(Of String, Long)
        '==================================================
        Sub New()
            Container = New CookieContainer
            _Info = New Dictionary(Of String, Long)
            CreateHttpClient()
        End Sub
        Sub New(ByRef CookieContainer As CookieContainer)
            Container = CookieContainer
            _Info = New Dictionary(Of String, Long)
            CreateHttpClient()
        End Sub
        '==================================================
        Public Async Function SendRequest(Method As HttpMethod, Url As String, Content As HttpContent, ResultType As ResultType, Optional Info As String = Nothing) As Task(Of Object)
            Request = New HttpRequestMessage(Method, Url)
            Request.Content = Content
            SetRequestHeaders(Request)

            If Info IsNot Nothing Then _Info.Add(Info, Content.Headers.ContentLength)
            Response = Await Client.SendAsync(Request)
            If Info IsNot Nothing Then _Info.Remove(Info)

            _LastCode = Response.StatusCode
            _LastResponseHeader = Response.Headers

            If Response.IsSuccessStatusCode = False Then
                Return Nothing
            End If

            Select Case ResultType
                Case ResultType.STREAM_TYPE
                    Return Await Response.Content.ReadAsStreamAsync

                Case ResultType.STRING_TYPE
                    Return Await Response.Content.ReadAsStringAsync

                Case Else
                    Return Nothing

            End Select
        End Function
        Public Async Function SendRequest(Method As HttpMethod, Url As String, ResultType As ResultType, Optional Info As String = Nothing) As Task(Of Object)
            Return Await SendRequest(Method, Url, DirectCast(Nothing, HttpContent), ResultType, Info)
        End Function
        Public Async Function SendRequest(Of T)(Method As HttpMethod, Url As String, Content As HttpContent, ResultType As ResultType, Optional Info As String = Nothing) As Task(Of T)
            Select Case ResultType
                Case ResultType.PROTOBUF_DESERIALIZE_TYPE
                    Dim Result As T
                    Dim ResponseStream As Stream = Await SendRequest(Method, Url, Content, ResultType.STREAM_TYPE, Info)
                    Using ResponseStream
                        Result = Serializer.Deserialize(Of T)(ResponseStream)
                    End Using

                    Return Result

                Case ResultType.JSON_DESERIALIZE_TYPE
                    Dim ResponseString As String = Await SendRequest(Method, Url, Content, ResultType.STRING_TYPE, Info)
                    Return JsonConvert.DeserializeObject(Of T)(ResponseString)

                Case Else
                    Return Nothing
            End Select
        End Function
        Public Async Function SendRequest(Of T)(Method As HttpMethod, Url As String, ResultType As ResultType, Optional Info As String = Nothing) As Task(Of T)
            Return Await SendRequest(Of T)(Method, Url, DirectCast(Nothing, HttpContent), ResultType, Info)
        End Function
        '==================================================
        Private Sub CreateHttpClient()
            Dim ClientHandler As HttpClientHandler = New HttpClientHandler
            ClientHandler.AllowAutoRedirect = False
            ClientHandler.UseCookies = True
            ClientHandler.UseProxy = False
            ClientHandler.CookieContainer = Container

            Dim MessageHandler As ProgressMessageHandler = New ProgressMessageHandler
            AddHandler MessageHandler.HttpReceiveProgress, AddressOf ReceiveEvent
            AddHandler MessageHandler.HttpSendProgress, AddressOf SendEvent

            Client = HttpClientFactory.Create(ClientHandler, MessageHandler)
        End Sub
        Private Sub SetRequestHeaders(Request As HttpRequestMessage)
            For Each Item As KeyValuePair(Of String, String) In Headers
                Request.Headers.Add(Item.Key, Item.Value)
            Next
        End Sub
        Private Function NullString(str As String) As String
            If String.IsNullOrWhiteSpace(str) Then Return "NULL"

            Return str
        End Function
        '==================================================
        Private Sub ReceiveEvent(sender As Object, e As HttpProgressEventArgs)
            Dim Info As String
            Try
                Info = _Info.Single(Function(Func) Func.Value = e.TotalBytes).Key
            Catch ex As Exception
                Exit Sub
            End Try

            _ReceiveEvent.Invoke(e.BytesTransferred, e.TotalBytes, e.ProgressPercentage, Info)
        End Sub
        Private Sub SendEvent(sender As Object, e As HttpProgressEventArgs)
            Dim Info As String
            Try
                Info = _Info.Single(Function(Func) Func.Value = e.TotalBytes).Key
            Catch ex As Exception
                Exit Sub
            End Try

            _SendEvent.Invoke(e.BytesTransferred, e.TotalBytes, e.ProgressPercentage, Info)
        End Sub
    End Class
End Namespace