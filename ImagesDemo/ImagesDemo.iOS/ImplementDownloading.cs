using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Foundation;
using ImagesDemo.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImplementDownloading))]
namespace ImagesDemo.iOS
{
    public class ImplementDownloading : IFileService
    {
        public void DownLoadImages(string urlStr)
        {
            createFolder("Sample");

            var webClient = new WebClient();
            webClient.DownloadDataCompleted += (s, e) =>
            {
                if (e.Result != null)
                {
                    var bytes = e.Result;
                    string localPath = getFilePath("Sample/sudhir_1.jpg");
                    File.WriteAllBytes(localPath, bytes); // writes to local storage
                }              
            };
            var url = new Uri(urlStr);
            webClient.DownloadDataAsync(url);
        }

        void createFolder(string name)
        {
            NSFileManager manager = NSFileManager.DefaultManager;
            if (!manager.FileExists(getFilePath(name)))
            {
                manager.CreateDirectory(getFilePath(name), false, null);
            }
        }

        string getFilePath(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string localFilename = fileName;
            string localPath = Path.Combine(documentsPath, localFilename);

            return localPath;
        }
    }
}