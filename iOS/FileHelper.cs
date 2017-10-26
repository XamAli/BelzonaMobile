using System;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(BelzonaMobile.iOS.FileHelper))]
namespace BelzonaMobile.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            var path = Path.Combine(libFolder, filename);
            System.Diagnostics.Debug.WriteLine("Sqlite path:" + path.ToString());
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return path;
        }
    }
}