using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace BelzonaMobile.Views
{

    public partial class SqlAdmin : ContentPage
    {
        public string Notes = string.Empty;
        public string SettingTable { get; set; }
        public string ProductTable { get; set; }
        public string IndustryTable { get; set; }
        public string VideoTable { get; set; }
        //public string CurrentLingo { get; set; }
        //public DateTime ExpDatetime { get; set; }
        public SqlAdmin()
        {
            InitializeComponent();
            //BindingContext = Notes;

        }
        protected override async void OnAppearing()
        {
            
            //1. check if DB exisit? not create one (By Checking Connection
            //2. Check Table Exisit? a. Settings, b.ProductTable, c.IndustryTable+Videos, d.OtherTable+Vedios

            var results = await App.LocalDatabase.GetLocalTablesAsync();
            //string msg = string.Empty;
            Notes = string.Empty;
            if (results != null)
            {
                foreach (var p in results)
                {
                    if (p.Name.Equals("ProductTable")) ProductTable = p.Name;
                    if (p.Name.Equals("SettingTable")) SettingTable = p.Name;
                    if (p.Name.Equals("IndustryTable")) IndustryTable = p.Name;
                    System.Diagnostics.Debug.WriteLine(String.Format("Table:D {0}", p.Name.ToString()));
                    Notes += string.Format("Table:{0}\n", p.Name);
                }
            }
            await DisplayAlert("Tables Exist:", Notes, "ok");
            //BindingContext = Notes;
            //Text.BindingContext = inputNumb;
            BindingContext = Notes;
        }
        async void OnCreateProdClicked(object sender, EventArgs e)
        {
            Notes = string.Empty;

            ProductTable _table = new ProductTable();
            //this is  special case or when necessary to Drop Table (expdate is iverdue or language changed)
            if (ProductTable != null && !(ProductTable.Equals(string.Empty)))
            {
                try
                {
                    int action = await App.LocalDatabase.DeleteProductTableAsync(_table);
                    ProductTable = null;
                }
                catch (Exception ex) { Notes = ex.Message.ToString() + "   table not droped....."; }
            }
            //await DisplayAlert("Sql Admin", SettingTable, "ok");
            if (ProductTable == null || ProductTable.Equals(string.Empty))
            {
                //1,. Create Table
                App.LocalDatabase.CreateProductTableAsync();
                Notes += "table created....." ;
                //inser records, populate from API call (for this excercise use mock file)
                List<BelProduct> results = GetMocJsonFile("BelzonaMobile.Data.app-manifest-products-us.json");
                int cntr = 0;
                foreach (var item in results){
                    _table = new ProductTable();
                    _table.ID = 0;
                    _table.ProductName = item.ProductName;
                    _table.Code = String.Format("{0}.{1}.{2}", item.SeriesId.ToString(), item.Formulation.Trim(), item.TypeId.ToString());
                    _table.ShortDesc = Regex.Replace(item.ShortDesc, @"<(.|\n)*?>", string.Empty);
                    _table.LongDesc = item.LongDesc;
                    _table.Favourite = 0;
                     _table.ProductImage = "belzonalogo_en_full.png";
                    try {int inserted = await App.LocalDatabase.SaveProductTableAsync(_table);
                        cntr++;}
                    catch (Exception ex) {System.Diagnostics.Debug.WriteLine("Error:{0}", ex.Message.ToString());}

                    //for each record insert into ProductTable
                }
                Notes += cntr.ToString() + " inserted";
             }
            else
            {
                List<ProductTable>  results = await App.LocalDatabase.GetProductTableAsync();
                //if (results != null) { _table.CurrentLingo = results.CurrentLingo; _table.ExpDate = results.ExpDate; }
                Notes = "Table Exisit ...." + results.Count.ToString();
            }
            await DisplayAlert(ProductTable, Notes, "ok");
        }

        async void OnIndusProdClicked(object sender, EventArgs e)
        {
            Notes = string.Empty;

            IndustryTable _industry = new IndustryTable();
            VideoTable _video= new VideoTable();
            //this is  special case or when necessary to Drop Table (expdate is iverdue or language changed)
            if (IndustryTable != null && !(IndustryTable.Equals(string.Empty)))
            {
                try
                {
                    //delete IndustryTable and VideoTable
                    int action = await App.LocalDatabase.DeleteIndustryTableAsync(_industry);
                    action = await App.LocalDatabase.DeleteVideoTableAsync(_video);
                    IndustryTable = null;
                }
                catch (Exception ex) { Notes = ex.Message.ToString() + "   table not droped....."; }
            }
            //await DisplayAlert("Sql Admin", SettingTable, "ok");
            //IndustryTable = null;
            if (IndustryTable == null || IndustryTable.Equals(string.Empty))
            {
                //1,. Create Table
                App.LocalDatabase.CreateIndustryTableAsync();
                App.LocalDatabase.CreateVideoTableAsync();
                Notes += "table created.....";
                //inser records, populate from API call (for this excercise use mock file)
                List<BelProductIndus> results = GetIndusJsonFile("BelzonaMobile.Data.app-manifest-ind-app-us.json");
                //results.Sort();
                results.Sort((x, y) => string.Compare(x.Code, y.Code, StringComparison.Ordinal));
                int master = 0; int child = 0;  string lastCode = string.Empty;
                foreach (var item in results)
                {
                    _video = new VideoTable();
                    if (item.Code != lastCode)
                    {
                        _industry = new IndustryTable();
                        _industry.ID = 0;
                        _industry.Title = item.Title;
                        _industry.Code = item.Code;
                        _industry.ShortDesc = Regex.Replace(item.ShortDesc, @"<(.|\n)*?>", string.Empty);
                        _industry.LongDesc = item.LongDesc;
                        _industry.Favourite = 0;
                        int iM = await App.LocalDatabase.SaveIndustryAsync(_industry);
                        master++;
                    }
                    _video.ID = 0;
                    _video.IndustryCode = item.Code;
                     _video.VideoName = item.VideoName;
                    _video.Size = item.Size;
                    _video.YoutubeLink = item.YoutubeLink;
                    _video.DataLink = item.DataLink;
                    _video.VideoDescription = item.VideoDescription;
                    int iC = await App.LocalDatabase.SaveIndustryAsync(_industry);
                    lastCode = item.Code;
                    child++;
                }

                Notes = string.Format(@"Inserted {0} master \n {1} child records", master, child);
            }
            else
            {
                List<IndustryTable> results = await App.LocalDatabase.GetIndustryTablesAsync();
                //if (results != null) { _table.CurrentLingo = results.CurrentLingo; _table.ExpDate = results.ExpDate; }
                Notes = "Table Exisit ...." + results.Count.ToString();
            }
            await DisplayAlert(ProductTable, Notes, "ok");
        }

        async void OnSettingsClicked(object sender, EventArgs e)
        {

            SettingTable _table = new SettingTable();

            //await DisplayAlert("Sql Admin", SettingTable, "ok");
            if (SettingTable == null || SettingTable.Equals(string.Empty))
            {
                _table.CurrentLingo = App.CurrentLingo;
                _table.ExpDate = System.DateTime.Now.AddDays(60);
                App.LocalDatabase.CreateSettingTableAsync();
                var results = await App.LocalDatabase.SaveSettingAsync(_table);
                Notes = results.ToString();
            }
            else
            {
                var results = await App.LocalDatabase.GetSettingsAsync();
                if (results != null) { _table.CurrentLingo = results.CurrentLingo; _table.ExpDate = results.ExpDate; }
                Notes = results.ToString();
            }
            await DisplayAlert(SettingTable, Notes, "ok");
                       
        }
        //async void OnOtherClicked(object sender, EventArgs e)
        //{
        //    await DisplayAlert("Sql Admin", IndustryTable, "ok");
 
        //}
        private static List<BelProduct> GetMocJsonFile(string filepath)
        {
            //""

            var assembly = typeof(Views.ContactPage).GetTypeInfo().Assembly;
            try
            {
                Stream stream = assembly.GetManifestResourceStream(filepath);

                using (var reader = new System.IO.StreamReader(stream))
                {

                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<BelProduct>>(json);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error:{0}", ex.Message.ToString()));
            }
            return null;
        }
        private static List<BelProductIndus> GetIndusJsonFile(string filepath)
        {
            //""

            var assembly = typeof(Views.ContactPage).GetTypeInfo().Assembly;
            try
            {
                Stream stream = assembly.GetManifestResourceStream(filepath);

                using (var reader = new System.IO.StreamReader(stream))
                {

                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<BelProductIndus>>(json);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error:{0}", ex.Message.ToString()));
            }
            return null;
        }
    }
}
