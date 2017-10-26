using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace BelzonaMobile
{
    public static class ProductHelper
    {

        public static ObservableCollection<Grouping<string, BelProduct>> ProdGrouped { get; set; }
        public static ObservableCollection<BelProduct> Products { get; set; }

        static ProductHelper()
        {
            //random = new Random();
            //client = new HttpClient();
            Products = new ObservableCollection<BelProduct>();

            //1 check if exisit in Local DB ...
            //2. Get from Belzona API Call ....... B. Save in local storage
            //3. if non ..... get from mockup jason stream
            //Products2.Clear();
            //Products2 = GetCloudData();

            Products = GetJsonFile();
            //ProdGrouped.Clear();
            ProdGrouped = SortAndGroup();
         }

        private static ObservableCollection<Grouping<string, BelProduct>> SortAndGroup()
        {
            var obj = new ObservableCollection<Grouping<string, BelProduct>>();
            var sorted = from prd in Products
                         orderby prd.GroupName
                                    group prd by prd.GroupName into prdGroup
                                    select new Grouping<string, BelProduct>(prdGroup.Key, prdGroup);

            obj = new ObservableCollection<Grouping<string, BelProduct>>(sorted);
            return obj;
        }

        private static ObservableCollection<BelProduct> GetJsonFile()
        {
            //BelItem = new List<BelProduct>();

            var assembly = typeof(Views.ContactPage).GetTypeInfo().Assembly;
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
                    return TransformObject(JsonConvert.DeserializeObject<List<BelProduct>>(json));


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error:{0}", ex.Message.ToString()));
            }
            return null;
        }
        private static ObservableCollection<BelProduct> TransformObject(List<BelProduct> products)
        {
            //throw new NotImplementedException();

            ObservableCollection<BelProduct> obj = new ObservableCollection<BelProduct>();
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
                obj.Add(_bp);
            }
            return obj;
        }

    }
}
