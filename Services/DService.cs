using Google.Apis.Drive.v3;
using System.Collections.Generic;
using System.Diagnostics;

namespace SaveMyGameSaves.Services
{
    class DService
    {
        #region Singleton
        private static DService _instance;
        public static DService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DService();
            }
            return _instance;
        }
        #endregion
        public DriveService service;


        public void ListFiles()
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Debug.WriteLine("{0} ({1})", file.Name, file.Id);
                }
            }
            else
            {
                Debug.WriteLine("No files found.");
            }
        }
    }
}
