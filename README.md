# Google Music API for VB.NET
- 이 프로젝트는 Unofficial Google Music API를 VB.NET 으로 코딩한 프로젝트입니다.
- 이 프로젝트는 Simon-Weber 님의 gmusicapi: an unofficial API for Google Play Music [https://github.com/simon-weber/gmusicapi] 를 참조하였습니다.

### Feature

- 이 프로젝트는 Google OAuth 2.0 을 위해 Google에서 제공한 Nuget Package를 사용하고 있습니다.
  o/oauth2/programmatic_auth 를 이용해 자동 인증을 진행할 수 있습니다.
  
- 이 프로젝트의 API에 있는 모든 함수는 Request와 Response로 구성되어있습니다.
  해당 API 함수가 반환하는 값은 그 함수에 맞는 Response를 이용해 받을 수 있습니다.
  Response는 status, description, response 로 나누어지며, 
  status는 Request 성공 여부(boolean), description은 status가 false일 경우에 반환되는 오류 내용, response는 request에 대한 JSON Response를 나타냅니다.

- 이 프로젝트는 Google Music에서 제공하는 Web Player와 Music Manager를 이용하며, 다음과 같은 기능을 지원합니다.
 - **AddTrack** : 1개의 Track을 업로드합니다.
 - **AddTracks** : 다수의 Track을 업로드합니다. 이 업로드는 멀티 업로드로 진행됩니다.
 - **AddPlaylist** : Playlist를 추가합니다.
 - **AddPlaylistContent** : Playlist에 1개의 Track을 추가합니다.
 - **AddPlaylistContents** : Playlist에 다수의 Track을 추가합니다.
 - **DeleteTrack** : 1개의 Track을 제거합니다.
 - **DeleteTracks** : 다수의 Track을 제거합니다.
 - **DeletePlaylist** : Playlist를 제거합니다.
 - **DeletePlaylistContent** : Playlist에 포함된 1개의 Track을 Playlist에서 제거합니다.
 - **DeletePlaylistContents** : Playlist에 포함된 다수의 Track을 Playlist에서 제거합니다.
 - **EditTrack** : 1개의 Track의 정보를 수정합니다. (Title, Album, Artist, Composer, Year, Genre, etc...)
 - **EditTracks** : 다수의 Trakc의 정보를 동일한 내용으로 수정합니다. (Album, Artist 등을 한번에 처리하는데 유용.)
 - **EditPlaylist** : Playlist의 Name, Description을 수정합니다.
 - **EditLabSettings** : Google Music Web Player의 Lab 설정을 변경합니다.
 - **FindTracks** : 입력한 값과 동일한 Title을 가진 Track을 찾습니다.
 - **FindPlaylists** : 입력한 값과 동일한 Name을 가진 Playlist를 찾습니다.
 - **FetchQuerySuggestions** : 입력한 값을 통해 연관 검색어를 불러옵니다.
 - **GetAllTracks** : 모든 Track을 불러옵니다. IncludeDeletedTracks 를 True로 설정하면 Trash에 있는 Track도 불러옵니다.
 - **GetAllPlaylists** : 모든 Playlist를 불러옵니다.
 - **GetPlaylistContents** : Playlist에 포함된 모든 Track을 불러옵니다.
 - **GetAutoPlaylistContents** : auto-playlist-??? 에 포함된 모든 Track을 불러옵니다. (현재, auto-playlist-trash 만 가능)
 - **GetDeletedTracks** : auto-playlist-trash 에 포함된 모든 Track을 불러옵니다.
 - **GetPermanentlyDeletedTracks** : 영구적으로 삭제된 모든 Track을 불러옵니다.
 - **GetRandomTracks** // 미완성 //
 - **GetSuggestedMetadata** : MatchedId를 통해 Google Music에서 제안하는 곡 정보를 불러옵니다.
 - **GetStreamingUrl** : 해당 곡의 스트리밍 주소를 불러옵니다.
 - **GetDownloadUrl** : 해당 곡의 다운로드 주소를 불러옵니다.
 - **GetRegisteredDevices** : 현재 인증된 기기들의 목록을 불러옵니다.
 - **GetAllSettings** : 설정에 있는 모든 항목을 불러옵니다. (인증된 기기 목록, 최대 곡 수, 등...)
 - **GetDismissedItems** : Web Player에서 표시하기를 원치않는 항목(Radio, etc..?)으로 설정된 것을 불러옵니다.
 - **GetStatus** : 현재 업로드 상태, 현재 곡 수를 불러옵니다.
 - **GetOffer** : Google에서 제안하는 곡들의 정보를 불러옵니다.
 - **GetListenNowItems** : ListenNow 항목을 불러옵니다.
 - **RestoreDeletedTrack** : auto-playlist-trash 에 있는 1개의 Track을 복구합니다.
 - **RestoreDeletedTracks** : auto-playlist-trash 에 있는 다수의 Track을 복구합니다.
 - **RestorePermanentlyDeletedTrack** : 영구적으로 삭제된 1개의 Track을 복구합니다.
 - **RestorePermanentlyDeletedTracks** : 영구적으로 삭제된 다수의 Track을 복구합니다.
 - **SearchStoreTracks** : 입력한 값에 대한 Google Music Store의 검색결과를 불러옵니다.
 - **SearchPlaylists** : 입력한 값을 포함하는 Name, Description을 가진 Playlist를 불러옵니다.
 - **UploadAlbumArt** : Album Art를 업로드합니다.
 
================================================================================================
### TODO
- I'm Feeling Lucky! 를 이용한 Random Track List를 가져올 함수 작성할 것.
- https://play.google.com/music/services/recordplaying 의 역할을 알아낼 것.
