using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;


namespace SaveMyGameSaves.Services
{
    public class Auth
    {
        public UserCredential credential;
        private DService dservice = DService.GetInstance();
        #region Singleton
        private Auth() { }
        private static Auth _instance;


        public static Auth GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Auth();
            }
            return _instance;
        }
        #endregion
        public void Authendicade()
        {
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                var scopes = new[] { DriveService.Scope.Drive };
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                     scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

            }
            dservice.service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "SaveMyGameSaves",
            });
        }
    }
}

