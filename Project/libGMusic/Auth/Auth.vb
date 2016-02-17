Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime.Serialization.Formatters.Binary

Imports Newtonsoft.Json

Imports libGMusic.Http

Namespace Auth
    Public Class MasterAuth
        Public Structure AuthInfo
            Dim GoogleClientID As String
            Dim GoogleClientSecret As String
            Dim GoogleScope As String
            Dim GoogleEmail As String
            Dim GooglePasswd As String
            Dim UserName As String
            Dim DeviceId As String
        End Structure
        '==================================================
        Public ReadOnly Property XTcookie As String
            Get
                Return WebAuth.XTcookie
            End Get
        End Property
        Public ReadOnly Property SessionId As String
            Get
                Return WebAuth.SessionId
            End Get
        End Property
        Public ReadOnly Property CookieContainer As CookieContainer
            Get
                Return WebAuth.CookieContainer
            End Get
        End Property
        Public ReadOnly Property AccessToken As String
            Get
                Return OAuth.AccessToken
            End Get
        End Property
        Public ReadOnly Property TokenType As String
            Get
                Return OAuth.TokenType
            End Get
        End Property
        Public ReadOnly Property UserName As String
            Get
                Return Info.UserName
            End Get
        End Property
        Public ReadOnly Property DeviceId As String
            Get
                Return Info.DeviceId
            End Get
        End Property
        '==================================================
        Private Info As AuthInfo
        Private OAuth As OAuth
        Private WebAuth As WebAuth

        Private UrlSender As Action(Of String)
        '==================================================
        Sub New(Information As AuthInfo)
            Info = Information
        End Sub
        '==================================================
        Public Async Function Login(CookieFilePath As String, OAuthFilePath As String, Optional OAuthJsonString As String = Nothing) As Task(Of Boolean)
            If Await OAuthLogin(OAuthFilePath, String.Empty) = False Then Return False
            If Await WebAuthLogin(CookieFilePath) = False Then Return False
            Return True
        End Function
        '==================================================
        Private Async Function OAuthLogin(OAuthFilePath As String, OAuthJsonString As String) As Task(Of Boolean)
            OAuth = New OAuth(Info.GoogleClientID, Info.GoogleClientSecret, Info.GoogleEmail, Info.GooglePasswd)

            Try
                If OAuthJsonString IsNot String.Empty Then
                    OAuth.LoadTokenFromJsonString(OAuthJsonString)
                    Await OAuth.RefreshToken()
                    OAuth.SaveToken(OAuthFilePath)
                Else
                    If File.Exists(OAuthFilePath) Then
                        OAuth.LoadToken(OAuthFilePath)
                        Await OAuth.RefreshToken
                        OAuth.SaveToken(OAuthFilePath)
                    Else
                        Await OAuth.CreateToken()
                        OAuth.SaveToken(OAuthFilePath)
                    End If
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function
        Private Async Function WebAuthLogin(CookieFilePath As String) As Task(Of Boolean)
            WebAuth = New WebAuth(Info.GoogleEmail, Info.GooglePasswd, CookieFilePath)
            Try
                Return Await WebAuth.Login()
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

    Public Class OAuth
        <Serializable>
        Public Class AccessTokenData
            Public access_token As String
            Public refresh_token As String
            Public expires_in As Integer
            Public token_type As String
            Public issued As Long
            Public scope As String
        End Class
        '==================================================
        Public ReadOnly Property AccessToken As String
            Get
                Return Token.access_token
            End Get
        End Property
        Public ReadOnly Property TokenType As String
            Get
                Return Token.token_type
            End Get
        End Property
        '==================================================
        Private Token As AccessTokenData
        Private Http As GoogleHttp

        Private _ClientId As String
        Private _ClientSecret As String
        Private _AuthorizationUrl As String = "https://accounts.google.com/o/oauth2/auth"
        Private _TokenUrl As String = "https://accounts.google.com/o/oauth2/token"
        Private _Scope As String = "https://www.googleapis.com/auth/musicmanager"
        Private _Email As String
        Private _Passwd As String
        '==================================================
        Sub New(ClientId As String, ClientSecret As String, Email As String, Passwd As String)
            _ClientId = ClientId
            _ClientSecret = ClientSecret
            _Email = Email
            _Passwd = Passwd

            Http = New GoogleHttp
        End Sub
        '==================================================
        Public Async Function CreateToken(Optional AccessTokenData As AccessTokenData = Nothing) As Task
            If AccessTokenData Is Nothing Then
                Token = Await GetAccessToken(Await GetAuthCode())
            Else
                Token = AccessTokenData
            End If
        End Function
        Public Sub SaveToken(FilePath As String)
            Dim Formatter As BinaryFormatter = New BinaryFormatter
            Using Stream As FileStream = New FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite)
                Formatter.Serialize(Stream, Token)
            End Using
        End Sub
        Public Sub LoadToken(FilePath As String)
            Dim Formatter As BinaryFormatter = New BinaryFormatter
            Using stream As FileStream = New FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite)
                Token = Formatter.Deserialize(stream)
            End Using
        End Sub
        Public Sub LoadTokenFromJsonString(JsonString As String)
            Token = JsonConvert.DeserializeObject(Of AccessTokenData)(JsonString)
        End Sub
        Public Async Function RefreshToken(Optional Force As Boolean = False) As Task
            If Force OrElse IsExpired() Then
                Token = Await GetRefreshedToken()
            End If
        End Function
        Public Function IsExpired() As Boolean
            Dim Issued As Date = Date.FromBinary(Token.issued)
            Issued.AddSeconds(Token.expires_in)

            If Issued < Now Then
                Return True
            Else
                Return False
            End If
            'Return _UserCredential.Token.IsExpired(SystemClock.Default)
        End Function
        '==================================================
        Private Async Function CheckSession(Url As String, Keyword As String) As Task(Of Boolean)
            Dim Response As String = Await Http.SendRequest(HttpMethod.Get, Url, GoogleHttp.ResultType.STRING_TYPE)
            If Response.Contains(Keyword) Then
                Return False
            Else
                Return True
            End If
        End Function
        Private Async Function GetSession() As Task(Of Boolean)
            '## 보안 처리는 나중에 ! ##
            Dim Input As Dictionary(Of String, String) = Await GetInputObject("https://accounts.google.com/ServiceLogin")
            If Input.Count = 0 Then Return False

            If Input.ContainsKey("Email") Then Input.Item("Email") = _Email
            If Input.ContainsKey("Passwd") Then Input.Item("Passwd") = _Passwd

            Dim Content As FormUrlEncodedContent = New FormUrlEncodedContent(Input)

            Dim Response As String = Await Http.SendRequest(HttpMethod.Post, "https://accounts.google.com/ServiceLoginAuth", Content, GoogleHttp.ResultType.STRING_TYPE)
            If Response Is Nothing Then Return False

            If Response.Contains("verification code") Then
                Return False
            End If

            Return True
        End Function
        Private Async Function GetInputObject(Url As String) As Task(Of Dictionary(Of String, String))
            Dim Response As String = Await Http.SendRequest(HttpMethod.Get, Url, GoogleHttp.ResultType.STRING_TYPE)
            Return GetInputObjectFromString(Response)
        End Function
        Private Function GetInputObjectFromString(Str As String) As Dictionary(Of String, String)
            Dim Result As Dictionary(Of String, String) = New Dictionary(Of String, String)

            Dim Data As String = Str
            Dim InputString As String = String.Empty
            Dim Name As String = String.Empty
            Dim Value As String = String.Empty

            Do
                Try
                    InputString = "<input" & Split(Split(Data, "<input")(1), ">")(0) & ">"
                Catch ex As Exception
                    InputString = String.Empty
                End Try
                If InputString Is String.Empty Then Exit Do

                Data = Data.Replace(InputString, String.Empty)

                Try
                    Name = Split(Split(InputString, "name=""")(1), """")(0)
                Catch ex As Exception
                    Name = String.Empty
                End Try

                Try
                    Value = Split(Split(InputString, "value=""")(1), """")(0)
                Catch ex As Exception
                    Value = String.Empty
                End Try

                Result.Add(Name, Value)
            Loop

            Return Result
        End Function
        Private Async Function GetAuthCode() As Task(Of String)
            Http = New GoogleHttp(New CookieContainer)

            Dim Url As String = "https://accounts.google.com/o/oauth2/programmatic_auth?client_id=" & _ClientId & "&scope=" & _Scope '& "&access_type=offline" '//https://www.googleapis.com/auth/musicmanager"
            If Await CheckSession(Url, "Moved Temporarily") = False Then
                If Await GetSession() = False Then Return Nothing
                If Await CheckSession(Url, "Moved Temporarily") = False Then Return False
            End If

            Dim ResponseHeader As HttpResponseHeaders = Http.LastResponseHeader

            Dim Response As String
            Response = ResponseHeader.GetValues("Set-Cookie").SingleOrDefault(Function(Func) Func.Contains("oauth_code"))
            Try
                Response = Split(Split(Response, "oauth_code=")(1), ";")(0)
            Catch ex As Exception
                Return False
            End Try

            Return Response
        End Function
        Private Async Function GetAccessToken(AuthCode As String) As Task(Of AccessTokenData)
            Dim Url As String = _TokenUrl
            Dim Content As FormUrlEncodedContent = New FormUrlEncodedContent(New Dictionary(Of String, String) From {{"grant_type", "authorization_code"}, {"code", AuthCode}, {"client_id", _ClientId}, {"client_secret", _ClientSecret}})

            Dim Response As AccessTokenData = Await Http.SendRequest(Of AccessTokenData)(HttpMethod.Post, Url, Content, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Response.issued = Now.ToBinary

            Return Response
        End Function
        Private Async Function GetRefreshedToken() As Task(Of AccessTokenData)
            Dim Url As String = _TokenUrl
            Dim Bak As String = Token.refresh_token
            Dim Content As FormUrlEncodedContent = New FormUrlEncodedContent(New Dictionary(Of String, String) From {{"grant_type", "refresh_token"}, {"refresh_token", Token.refresh_token}, {"client_id", _ClientId}, {"client_secret", _ClientSecret}})

            Dim Response As AccessTokenData = Await Http.SendRequest(Of AccessTokenData)(HttpMethod.Post, Url, Content, GoogleHttp.ResultType.JSON_DESERIALIZE_TYPE)
            Response.issued = Now.ToBinary
            Response.refresh_token = Bak

            Return Response
        End Function
    End Class
    Public Class WebAuth
        Public ReadOnly Property XTcookie As String
            Get
                Return GetCookie("https://play.google.com/music/listen", "xt")
            End Get
        End Property
        Public ReadOnly Property SessionId As String
            Get
                Return _SessionId
            End Get
        End Property
        Public ReadOnly Property CookieContainer As CookieContainer
            Get
                Return _CookieContainer
            End Get
        End Property
        '==================================================
        Private Http As GoogleHttp

        Private _Email As String
        Private _Passwd As String
        Private _SessionId As String
        Private _CookieFilePath As String
        Private _CookieContainer As CookieContainer
        '==================================================
        Sub New(Email As String, Passwd As String, CookieFilePath As String)
            '## 보안 필요 ##
            _Email = Email
            _Passwd = Passwd
            _CookieFilePath = CookieFilePath
            If File.Exists(CookieFilePath) Then
                LoadCookieContainer(CookieFilePath)
            Else
                _CookieContainer = New CookieContainer
            End If
        End Sub
        '==================================================
        Public Async Function Login() As Task(Of Boolean)
            Http = New GoogleHttp(_CookieContainer)

            If Await CheckSession() = False Then
                If Await GetSessionCookies() = False Then Return False
                If Await CheckSession() = False Then Return False
            End If

            If XTcookie = String.Empty Then Return False

            SaveCookieContainer(_CookieFilePath)
            _SessionId = GenerateClientSessionId()

            Return True
        End Function
        '==================================================
        Private Sub SaveCookieContainer(FilePath As String)
            Dim Binary As BinaryFormatter = New BinaryFormatter
            Using Stream As FileStream = New FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Binary.Serialize(Stream, _CookieContainer)
                Stream.Flush()
            End Using
        End Sub
        Private Sub LoadCookieContainer(FilePath As String)
            Dim Binary As BinaryFormatter = New BinaryFormatter
            Using Stream As FileStream = New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                _CookieContainer = Binary.Deserialize(Stream)
            End Using
        End Sub
        Private Function GetCookie(Uri As String, Name As String) As String
            Dim Cookie As Cookie = _CookieContainer.GetCookies(New Uri(Uri)).OfType(Of Cookie).FirstOrDefault(Function(Func) Func.Name = Name)
            If Cookie Is Nothing Then Return String.Empty
            Return Cookie.Value
        End Function
        Private Async Function CheckSession() As Task(Of Boolean)
            Dim Response As String = Await Http.SendRequest(HttpMethod.Get, "https://play.google.com/music/listen", GoogleHttp.ResultType.STRING_TYPE) '// POST?
            If Response.Contains("window['USER_ID']") Then
                Return True
            Else
                Return False
            End If
        End Function
        Private Async Function GetSessionCookies() As Task(Of Boolean)
            Dim Input As Dictionary(Of String, String) = Await GetInputObject()
            If Input.Count = 0 Then Return False

            If Input.ContainsKey("Email") Then Input.Item("Email") = _Email
            If Input.ContainsKey("Passwd") Then Input.Item("Passwd") = _Passwd

            Dim Content As FormUrlEncodedContent = New FormUrlEncodedContent(Input)

            Dim Response As String = Await Http.SendRequest(HttpMethod.Post, "https://accounts.google.com/ServiceLoginAuth", Content, GoogleHttp.ResultType.STRING_TYPE)
            If Response Is Nothing Then Return False

            If Response.Contains("verification code") Then
                Return False
            End If

            Return True
        End Function
        Private Async Function GetInputObject() As Task(Of Dictionary(Of String, String))

            Dim Result As Dictionary(Of String, String) = New Dictionary(Of String, String)

            Dim Response As String = Await Http.SendRequest(HttpMethod.Get, "https://accounts.google.com/ServiceLogin", GoogleHttp.ResultType.STRING_TYPE)
            Dim InputString As String = String.Empty
            Dim Name As String = String.Empty
            Dim Value As String = String.Empty

            Do
                Try
                    InputString = "<input" & Split(Split(Response, "<input")(1), ">")(0) & ">"
                Catch ex As Exception
                    InputString = String.Empty
                End Try
                If InputString Is String.Empty Then Exit Do

                Response = Response.Replace(InputString, String.Empty)

                Try
                    Name = Split(Split(InputString, "name=""")(1), """")(0)
                Catch ex As Exception
                    Name = String.Empty
                End Try

                Try
                    Value = Split(Split(InputString, "value=""")(1), """")(0)
                Catch ex As Exception
                    Value = String.Empty
                End Try

                Result.Add(Name, Value)
            Loop

            Return Result
        End Function
        Private Function GenerateClientSessionId() As String
            Dim Chars As IEnumerable(Of Char) = Enumerable.Range(AscW("a"), 26).Select(Function(Func) ChrW(Func)).Concat(Enumerable.Range(AscW("0"), 10).Select(Function(Func) ChrW(Func))).ToList()
            Dim Rand As Random = New Random
            Dim Id As String = String.Empty
            For i As Byte = 1 To 12
                Id &= Chars(Rand.Next(Chars.Count))
            Next

            Return Id
        End Function
    End Class
End Namespace