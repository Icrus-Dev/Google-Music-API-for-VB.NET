# Google Music API for VB.NET
- �� ������Ʈ�� Unofficial Google Music API�� VB.NET ���� �ڵ��� ������Ʈ�Դϴ�.
- �� ������Ʈ�� Simon-Weber ���� gmusicapi: an unofficial API for Google Play Music [https://github.com/simon-weber/gmusicapi] �� �����Ͽ����ϴ�.

==================================================================================================

- �� ������Ʈ�� Google OAuth 2.0 �� ���� Google���� ������ Nuget Package�� ����ϰ� �ֽ��ϴ�.
  o/oauth2/programmatic_auth �� �̿��� �ڵ� ������ ������ �� �ֽ��ϴ�.
  
- �� ������Ʈ�� API�� �ִ� ��� �Լ��� Request�� Response�� �����Ǿ��ֽ��ϴ�.
  �ش� API �Լ��� ��ȯ�ϴ� ���� �� �Լ��� �´� Response�� �̿��� ���� �� �ֽ��ϴ�.
  Response�� status, description, response �� ����������, 
  status�� Request ���� ����(boolean), description�� status�� false�� ��쿡 ��ȯ�Ǵ� ���� ����, response�� request�� ���� JSON Response�� ��Ÿ���ϴ�.
  
### TODO
- AddPlaylistContentsRequest �� �ʿ��� JSON name ���� ã��, ������Ʈ �� ��.
- I'm Feeling Lucky! �� �̿��� Random Track List�� ������ �Լ� �ۼ��� ��.
- https://play.google.com/music/services/recordplaying �� ������ �˾Ƴ� ��.
- AddTracks �Լ��� �ڵ带 ����ȭ �� ��
- �������� ���� ó�� ����� ������ ��. (GoogleHttp �� SendRequest���� ���ܰ� �߻��� �� ReportError�� �������� �ʴ� ������ ����) 