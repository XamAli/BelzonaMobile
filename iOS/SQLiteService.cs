//using System;
//namespace MyListView.iOS
//{
//    public class SQLiteService
//    {
//        public SQLiteService()
//        {
//        }
//    }
//}
using System;
using System.Diagnostics;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(BelzonaMobile.iOS.SQLiteService))]
namespace BelzonaMobile.iOS
{
    public class SQLiteService : ISQLiteService
    {
        private SQLiteConnectionWithLock _conn;
        private string _database = "BelProducts.db3";
        public string DatabaseName
        {
            get { return _database; }
        }
        public SQLiteConnectionWithLock Connection
        {
            get { return _conn; }
            set {_conn = value;}
        }
        string GetPath()
        {
            if (string.IsNullOrWhiteSpace(DatabaseName))
            {
                throw new ArgumentException("Invalid database name", nameof(DatabaseName));
            }
            //var sqliteFilename = databaseName; //$"{databaseName}.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, DatabaseName);
            //Console.WriteLine("SQlite:" + path.ToString() );
            Debug.WriteLine("SQlite:" + path);
            return path;
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public long GetSize()
        {
            //var fileInfo = null;
            try {
                var fileInfo = new FileInfo(GetPath());
                return fileInfo != null ? fileInfo.Length : 0;
            }
            catch (Exception ex) {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
            //var fileInfo = new FileInfo(GetPath());
            //return fileInfo != null ? fileInfo.Length : 0;
        }
        public Boolean DatabaseExist()
        {           
            try
            {
                //return fileInfo != null ? fileInfo.Length : 0;
                return File.Exists(GetPath()) ? true : false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }

        }
        public void DeleteDatabase()
        {
            if (DatabaseExist())
            {
                File.Delete(GetPath());
            }
            CloseConnection();

        }
        public void CloseConnection()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;

                // Must be called as the disposal of the connection is not released until the GC runs.
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
