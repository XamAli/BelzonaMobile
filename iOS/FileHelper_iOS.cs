using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BelzonaMobile.iOS.FileHelper_iOS))]

namespace BelzonaMobile.iOS
{
    public class FileHelper_iOS : IFileHelper
	{
        public string GetNameWithPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", filename);
        }

        public Task<string> LoadLocalFileAsync (string filename)
		{
			try
			{
				return Task.FromResult(File.ReadAllText(GetNameWithPath(filename)));
			}
			catch 
			{
				return Task.FromResult<string>(null);
			}
		}

		public Task<bool> SaveLocalFileAsync (string filename, string data)
		{
			File.WriteAllText (GetNameWithPath(filename), data);

			return Task.FromResult (true);
		}
	}
}