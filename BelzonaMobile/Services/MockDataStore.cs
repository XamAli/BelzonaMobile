using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BelzonaMobile
{
    public class MockDataStore : IDataStore<BelProduct>
    {
        //List<BelProduct> BelItem;
        public  ObservableCollection<Grouping<string, BelProduct>> BelProdGrouped { get; set; }
        public  ObservableCollection<BelProduct> BelProducts { get; set; }

        public MockDataStore()
        {
            //BelItem = new List<BelProduct>();

            var assembly = typeof(Views.HomePage).GetTypeInfo().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("found resource: " + res);
            //}
            try
            {
                Stream stream = assembly.GetManifestResourceStream("BelzonaMobile.Data.app-manifest-products-us.json");

                using (var reader = new System.IO.StreamReader(stream))
                {

                    var json = reader.ReadToEnd();
                    BelProducts = TransformObject(JsonConvert.DeserializeObject<List<BelProduct>>(json));

                    //var data  = JsonConvert.DeserializeObject<BelProduct>(json) ;

                    var sorted = from prd in BelProducts
                        orderby prd.GroupName
                                 group prd by prd.GroupName into prdGroup
                                 select new Grouping<string, BelProduct>(prdGroup.Key, prdGroup);

                    //List<BelProduct> _list = new List<BelProduct>();
                    //_list = new List<Grouping<string, BelProduct>>(sorted);

                    //foreach (var item in products)
                    //{
                    //    _list.Add(item);
                    //}

                    BelProdGrouped = new ObservableCollection<Grouping<string, BelProduct>>(sorted);
                    //System.Diagnostics.Debug.WriteLine(string.Format("Group 1:{0}", BelProdGrouped[0].Count.ToString()));
                    System.Diagnostics.Debug.WriteLine(string.Format("MockDataStore Group:{0}", BelProdGrouped.Count.ToString()));

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error:{0}", ex.Message.ToString()));
            }
        }
        private ObservableCollection<BelProduct> TransformObject(List<BelProduct> products)
        {
            //throw new NotImplementedException();

            ObservableCollection<BelProduct> _list = new ObservableCollection<BelProduct>();
            //List<BelProduct> _list = new List<BelProduct>();
            //foreach (var item in products)
            //{
            //    _list.Add(item);
            //}
            //string asciichar = (Convert.ToChar(62)).ToString();
            foreach (var p in products)
            {
                BelProduct _bp = new BelProduct();
                _bp.SeriesId = p.SeriesId;
                _bp.TypeId = p.TypeId;
                _bp.ProductName = p.ProductName;
                //_bp.ShortDesc = Regex.Replace(p.ShortDesc, @"<(.|\n)*?>");
                _bp.ShortDesc = Regex.Replace(p.ShortDesc, @"<(.|\n)*?>", string.Empty);
                _bp.LongDesc = p.LongDesc;
                _bp.FilePath = p.FilePath;
                _bp.Formulation = p.Formulation;
                //_bp.ProductInfo = Regex.Replace(p.LongDesc.Substring(0, 100), @"<(.|\n)*?>", string.Empty) + "...";
                _bp.ProductImage = "belzonalogo_en_full.png";
                //_bp.NextImage = (Convert.ToChar(62)).ToString();
                _list.Add(_bp);
            }
            return _list;
        }

        public async Task<bool> AddItemAsync(BelProduct item)
        {
            BelProducts.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(BelProduct item)
        {
            var _item = BelProducts.Where((BelProduct arg) => arg.ShortDesc == item.ShortDesc).FirstOrDefault();
            BelProducts.Remove(_item);
            BelProducts.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = BelProducts.Where((BelProduct arg) => arg.ShortDesc == id).FirstOrDefault();
            BelProducts.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<BelProduct> GetItemAsync(string id)
        {
            return await Task.FromResult(BelProducts.FirstOrDefault(s => s.ShortDesc == id));
        }

        public async Task<IEnumerable<BelProduct>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(BelProducts);
        }
        public async Task<IEnumerable<Grouping<string, BelProduct>>> GetItemGroupAsync()
        {
            return await Task.FromResult(BelProdGrouped);
        }
        //public async Task<IEnumerable<Grouping<T>>> GetItemGroupsAsync()
        //{
        //    return await Task.FromResult(BelProdGrouped);
        //    //return new Task<IEnumerable<BelProduct>>();
        //}
    }
}