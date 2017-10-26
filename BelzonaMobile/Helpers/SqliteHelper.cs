using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BelzonaMobile.Helpers
{
    public class SqliteHelper
    {
        public SqliteHelper()
        {


        }
        public void CreateAllTables()
        {
            var db = DependencyService.Get<ISQLiteService>().GetConnection();

            db.CreateTable<Models.dbProduct>();
        }

        public async Task CreateAllTablesAsync()
        {
            var db = DependencyService.Get<ISQLiteService>().GetAsyncConnection();

            await db.CreateTableAsync<Models.dbProduct>().ConfigureAwait(false);
        }

        /// <summary>
        /// Dropping tables ONLY works using the synchronous DB connection
        /// For some reason, dropping asynchronously fails miserably
        /// </summary>
        public void DropAllTables()
        {
            var db = DependencyService.Get<ISQLiteService>().GetConnection();

            db.DropTable<Models.dbProduct>();
        }
        //public bool TableExist()
        //{
        //    var db = DependencyService.Get<ISQLite>().GetConnection();
        //    var settings = db.Table<Movie>().ToList();
        //    return (settings.Count > 0) ? true : false;

        //}
        public static bool TableExists<T>(string TableName)
        {
            var db = DependencyService.Get<ISQLiteService>().GetConnection();
            string query = string.Format("SELECT name FROM sqlite_master WHERE type='table' AND name='{0}'", TableName);
            var cmd = db.CreateCommand(query, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }

    }
}
