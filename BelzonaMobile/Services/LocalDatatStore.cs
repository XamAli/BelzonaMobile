
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace BelzonaMobile
{
    public class LocalDataStore
    {
        readonly SQLiteAsyncConnection database;

        public LocalDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //database.CreateTableAsync<ProductTable>().Wait();
        }
        public Task<List<LocalTable>>  GetLocalTablesAsync()
        {
            try
            {
                return database.QueryAsync<LocalTable>("Select * from sqlite_master Where Name !='sqlite_sequence'");
            }
            catch { return null;  }
        }
        public Task<List<IndustryTable>> GetIndustryTablesAsync()
        {
            try
            {
                //return database.QueryAsync<LocalTable>("Select * from Industry");
                return database.Table<IndustryTable>().ToListAsync();
            }
            catch { return null; }
        }
        public Task<List<VideoTable>> GetVideoTablesAsync()
        {
            try
            {
                //return database.QueryAsync<LocalTable>("Select * from Industry");
                return database.Table<VideoTable>().ToListAsync();
            }
            catch { return null; }
        }
        public Task<List<VideoTable>> GetVideoTablesAsync(string code)
        {
            try
            {
                return database.Table<VideoTable>().Where(i => i.IndustryCode == code).ToListAsync();
            }
            catch { return null; }
        }
        public Task<SettingTable> GetSettingsAsync()
        {
            //return database.Table<SettingTable>();
            return database.Table<SettingTable>().Where(i => i.CurrentLingo != null).FirstOrDefaultAsync();
        }
        public Task<List<ProductTable>> GetProductTableAsync()
        {
            return database.Table<ProductTable>().ToListAsync();
        }
        public Task<List<ProductTable>> GetSelectedProductsAsync()
        {
            return  database.QueryAsync<ProductTable>("Select ID, Code, ProductName, ShortDesc, ProductImage, Favourite from ProductTable Where Favourite = 1");
            //return database.QueryAsync("SELECT * FROM ProductTable WHERE Symbol = ?", "A").ToListAsync();
        }
        public Task<List<ProductTable>> GetAllProductsAsync()
        {
            return database.QueryAsync<ProductTable>("Select ID, Code, ProductName, ShortDesc, ProductImage, Favourite from ProductTable");
        }
        public Task<ProductTable> GetDetailProductAsync(string code)
        {
            if (code == null)
            {
                throw new System.ArgumentNullException(nameof(code));
            }

            return database.Table<ProductTable>().Where(i => i.Code == code).FirstOrDefaultAsync();
        }
        //var stocksStartingWithA = db.Query<Stock>("SELECT * FROM Items WHERE Symbol = ?", "A");
        //var apple = from s in db.Table<Stock>()
                    //where s.Symbol.StartsWith("A")
                    //select s;
        public Task<ProductTable> GetItemAsync(int id)
        {
            return database.Table<ProductTable>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProductTableAsync(ProductTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveSettingAsync(SettingTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveIndustryAsync(IndustryTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveVideoAsync(VideoTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteProductTableAsync(ProductTable item)
        {
            try { return database.DeleteAsync(item); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error:{0}", ex.Message.ToString()); return null; }
        }
        public Task<int> DeleteIndustryTableAsync(IndustryTable item)
        {
            try { return database.DeleteAsync(item); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error:{0}", ex.Message.ToString()); return null; }
        }
        public Task<int> DeleteVideoTableAsync(VideoTable item)
        {
            try { return database.DeleteAsync(item); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error:{0}", ex.Message.ToString()); return null; }
        }
        public void CreateSettingTableAsync()
        {
            database.CreateTableAsync<SettingTable>().Wait();
        }
        public void CreateProductTableAsync()
        {
            database.CreateTableAsync<ProductTable>().Wait();
        }
        public void CreateIndustryTableAsync()
        {
            database.CreateTableAsync<IndustryTable>().Wait();
        }
        public void CreateVideoTableAsync()
        {
            database.CreateTableAsync<VideoTable>().Wait();
        }
        //string locationpath = string.Empty;
            //try
            //{
            //    locationpath = DependencyService.Get<IFileHelper>().GetLocalFilePath("BelProduct.db3");
            //    LocalDataStore db = new LocalDataStore(locationpath);
            //    List<ProductTable> table = TransformDTO();
            //    foreach (ProductTable item in table)
            //    {
            //        System.Diagnostics.Debug.WriteLine(String.Format("Product:D {0}", item.Code));
            //        db.SaveItemAsync(item);
            //    }

            //}
            //catch (Exception ex){
            //    System.Diagnostics.Debug.WriteLine(String.Format("Error:D {0}", ex.Message.ToString()));
            //}
    }
}
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace BelzonaMobile
//{
//    public class LocalDataStore : IDataStore<BelProduct>
//    {
//        //List<BelProduct> BelItem;
//        public static ObservableCollection<Grouping<string, BelProduct>> BelProdGrouped { get; set; }
//        public static ObservableCollection<BelProduct> BelProducts { get; set; }

//        public LocalDataStore()
//        {
//            //BelItem = new List<BelProduct>();

//            var assembly = typeof(Views.HomePage).GetTypeInfo().Assembly;
//            //foreach (var res in assembly.GetManifestResourceNames())
//            //{
//            //    System.Diagnostics.Debug.WriteLine("found resource: " + res);
//            //}
//            try
//            {
//                Stream stream = assembly.GetManifestResourceStream("BelzonaMobile.Data.app-manifest-products-us.json");

//                using (var reader = new System.IO.StreamReader(stream))
//                {

//                    var json = reader.ReadToEnd();
//                    BelProducts = TransformObject(JsonConvert.DeserializeObject<List<BelProduct>>(json));

//                    //var data  = JsonConvert.DeserializeObject<BelProduct>(json) ;

//                    var sorted = from prd in BelProducts
//                                 orderby prd.ProductName
//                                            group prd by prd.ProductName into prdGroup
//                                 select new Grouping<string, BelProduct>(prdGroup.Key, prdGroup);


//                    BelProdGrouped = new ObservableCollection<Grouping<string, BelProduct>>(sorted);
//                    //System.Diagnostics.Debug.WriteLine(string.Format("Group:{0}", BelProdGrouped.Count.ToString()));

//                }
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine(string.Format("Error:{0}", ex.Message.ToString()));
//            }
//        }
//        private ObservableCollection<BelProduct> TransformObject(List<BelProduct> products)
//        {

//            ObservableCollection<BelProduct> _list = new ObservableCollection<BelProduct>();
//            foreach (var p in products)
//            {
//                BelProduct _bp = new BelProduct();
//                _bp.SeriesId = p.SeriesId;
//                _bp.TypeId = p.TypeId;
//                _bp.ProductName = p.ProductName;
//                //_bp.ShortDesc = Regex.Replace(p.ShortDesc, @"<(.|\n)*?>");
//                _bp.ShortDesc = Regex.Replace(p.ShortDesc, @"<(.|\n)*?>", string.Empty);
//                _bp.LongDesc = p.LongDesc;
//                _bp.FilePath = p.FilePath;
//                _bp.Formulation = p.Formulation;
//                //_bp.ProductInfo = Regex.Replace(p.LongDesc.Substring(0, 100), @"<(.|\n)*?>", string.Empty) + "...";
//                _bp.ProductImage = "belzonalogo_en_full.png";
//                //_bp.NextImage = (Convert.ToChar(62)).ToString();
//                _list.Add(_bp);
//            }
//            return _list;
//        }

//        public async Task<bool> AddItemAsync(BelProduct item)
//        {
//            BelProducts.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> UpdateItemAsync(BelProduct item)
//        {
//            var _item = BelProducts.Where((BelProduct arg) => arg.ShortDesc == item.ShortDesc).FirstOrDefault();
//            BelProducts.Remove(_item);
//            BelProducts.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> DeleteItemAsync(string id)
//        {
//            var _item = BelProducts.Where((BelProduct arg) => arg.ShortDesc == id).FirstOrDefault();
//            BelProducts.Remove(_item);

//            return await Task.FromResult(true);
//        }

//        public async Task<BelProduct> GetItemAsync(string id)
//        {
//            return await Task.FromResult(BelProducts.FirstOrDefault(s => s.ShortDesc == id));
//        }

//        public async Task<IEnumerable<BelProduct>> GetItemsAsync(bool forceRefresh = false)
//        {
//            return await Task.FromResult(BelProducts);
//        }
//        public async Task<IEnumerable<Grouping<string, BelProduct>>> GetItemGroupAsync()
//        {
//            return await Task.FromResult(BelProdGrouped);
//        }
//    }
//}
