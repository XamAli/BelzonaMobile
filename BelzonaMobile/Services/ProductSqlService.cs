using SQLite.Net.Async;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using BelzonaMobile.Helpers;

[assembly: Dependency(typeof(BelzonaMobile.Services.ProductSqlService))]
namespace BelzonaMobile.Services
{
    public class ProductSqlService : BelzonaMobile.Services.IProductSqlService
    {
        private static readonly AsyncLock Locker = new AsyncLock();

        //private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLiteService>().GetAsyncConnection();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLiteService>().GetAsyncConnection();

        public async Task AddMovies(IList<Models.dbProduct> movies)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(movies);
            }
        }

        public async Task<IList<Models.dbProduct>> GetMovies()
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<Models.dbProduct>().Where(x => x.Id > 0).ToListAsync();
            }
        }
       
    }
}

