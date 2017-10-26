using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BelzonaMobile
{
    public class BelProductDatabase 
	{
		static object locker = new object ();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
        public BelProductDatabase()
		{
            database = DependencyService.Get<ISQLiteService> ().GetConnection ();
			// create the tables
            database.CreateTable<BelProduct>();
		}

        public IEnumerable<BelProduct> GetItems ()
		{
			lock (locker) {
                return (from i in database.Table<BelProduct>() select i).ToList();
			}
		}

        public IEnumerable<BelProduct> GetItemsNotDone ()
		{
			lock (locker) {
                return database.Query<BelProduct>("SELECT * FROM [BelProduct] WHERE [Done] = 0");
			}
		}

        public BelProduct GetItem (int id) 
		{
			lock (locker) {
                //return database.Table<BelProduct>().FirstOrDefault(x => x.ID == id);
                return database.Table<BelProduct>().FirstOrDefault(x => x.SeriesId == id);
			}
		}

        public int SaveItem (BelProduct item) 
		{
			lock (locker) {

                if (item.SeriesId != 0) {
                  database.Update(item);
                    return item.SeriesId;
                } else {
                  return database.Insert(item);
                }
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
                return database.Delete<BelProduct>(id);
			}
		}
	}
}

