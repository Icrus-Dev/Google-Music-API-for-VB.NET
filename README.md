# Google Music API for VB.NET
- 이 프로젝트는 Unofficial Google Music API를 VB.NET 으로 코딩한 프로젝트입니다.
- 이 프로젝트는 Simon-Weber 님의 gmusicapi: an unofficial API for Google Play Music [https://github.com/simon-weber/gmusicapi] 를 참조하였습니다.

==================================================================================================

- 이 프로젝트는 Google OAuth 2.0 을 위해 Google에서 제공한 Nuget Package를 사용하고 있습니다.
  o/oauth2/programmatic_auth 를 이용해 자동 인증을 진행할 수 있습니다.
  
- 이 프로젝트의 API에 있는 모든 함수는 Request와 Response로 구성되어있습니다.
  해당 API 함수가 반환하는 값은 그 함수에 맞는 Response를 이용해 받을 수 있습니다.
  Response는 status, description, response 로 나누어지며, 
  status는 Request 성공 여부(boolean), description은 status가 false일 경우에 반환되는 오류 내용, response는 request에 대한 JSON Response를 나타냅니다.

- 이 프로젝트는 WebClient를 이용하며, 다음과 같은 기능을 지원합니다.
 - AddTrack
 > AddTracks
 > AddPlaylist
 > AddPlaylistContent
 > AddPlaylistContents // 미완성 //
 > DeleteTrack
 > DeleteTracks
 > DeletePlaylist
 > DeletePlaylistContent
 > DeletePlaylistContents
 > EditTrack
 > EditTracks
 > EditPlaylist
 > FindTracks
 > FindPlaylists
 > GetAllTracks
 > GetAllPlaylists
 > GetPlaylistContents
 > GetAutoPlaylistContents
 > GetDeletedTracks
 > GetPermanentlyDeletedTracks
 > GetRandomTracks // 미완성 //
 > GetSuggestedMetadata
 > GetStreamingUrl
 > GetDownloadUrl
 > GetRegisteredDevices
 > GetAllSettings
 > RestoreDeletedTrack
 > RestoreDeletedTracks
 > RestorePermanentlyDeletedTrack
 > RestorePermanentlyDeletedTracks
 > SearchStoreTracks
 > SearchPlaylists
 > UploadAlbumArt
 
### TODO
- AddPlaylistContentsRequest 에 필요한 JSON name 값을 찾고, 업데이트 할 것.
- I'm Feeling Lucky! 를 이용한 Random Track List를 가져올 함수 작성할 것.
- https://play.google.com/music/services/recordplaying 의 역할을 알아낼 것.
- AddTracks 함수의 코드를 최적화 할 것
- 전반적인 예외 처리 방안을 강구할 것. (GoogleHttp 의 SendRequest에서 예외가 발생할 시 ReportError가 동작하지 않는 문제가 있음) 