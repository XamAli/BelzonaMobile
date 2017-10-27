using BelzonaMobile.Views;
using Xamarin.Forms;
using BelzonaMobile.ViewModeles;
using System.Threading.Tasks;

namespace BelzonaMobile
{

    public static class ViewModelLocator
    {
        static ProductsViewModel productsVM;
        public static ProductsViewModel ProductsViewModel
        => productsVM ?? (productsVM = new ProductsViewModel());

        static DetailsViewModel detailsVM;
        public static DetailsViewModel DetailsViewModel
        => detailsVM ?? (detailsVM = new DetailsViewModel(ProductHelper.Products[0]));
    }

    public class App : Application
    {
        public static ProductManager ProductManager { get; private set; }
        public static LocalDataStore LocalDBConnection;

        public static string CurrentLingo { get; set; }
        public App()
        {

            //System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
            //var assembly = typeof(App).GetTypeInfo().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //    System.Diagnostics.Debug.WriteLine("found resource: " + res);
            //System.Diagnostics.Debug.WriteLine("====================================");


            //========= Localization/Globalization multi-lingual ==========
            //if (Device.RuntimePlatform == Device.iOS )
            var ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            //BelzonaMobile.Resx.AppResources.Culture = ci; // set the RESX for resource localization
            L10n.SetLocale(ci);
            Resx.AppResources.Culture = ci;
            CurrentLingo = ci.ToString();
     
            //MainPage =  new MenuPage();
            //ProductManager = new ProductManager(new RestService());
            //MainPage = new MainPageCS();
           

       
            if (Constants.UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            var nav = new NavigationPage(new TabbedPageCS());
            nav.BarBackgroundColor = Color.FromHex("4BAADE"); //(Color)Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;
            MainPage = nav;
            //    //MainPage = new TabbedPageCS();
            //    MainPage = new NavigationPage(new TabbedPageCS());
            //     //MainPage = new ItemsPage();
            //else
                //MainPage = new NavigationPage(new TabbedPageCS());
            
        }
        public static LocalDataStore LocalDatabase
        {
            get
            {
                if (LocalDBConnection == null)
                {
                    LocalDBConnection = new LocalDataStore(DependencyService.Get<IFileHelper>().GetLocalFilePath("BelProduct.db3"));
                }
                return LocalDBConnection;
            }
        }
        //public void CreateAllTables()
        //{
        //    var db = DependencyService.Get<ISQLiteService>().GetConnection();

        //    db.CreateTable<Models.dbProduct>();
        //}

        //public async Task CreateAllTablesAsync()
        //{
        //    var db = DependencyService.Get<ISQLiteService>().GetAsyncConnection();

        //    await db.CreateTableAsync<Models.dbProduct>().ConfigureAwait(false);
        //}

        ///// <summary>
        ///// Dropping tables ONLY works using the synchronous DB connection
        ///// For some reason, dropping asynchronously fails miserably
        ///// </summary>
        //public void DropAllTables()
        //{
        //    var db = DependencyService.Get<ISQLiteService>().GetConnection();

        //    db.DropTable<Models.dbProduct>();
        //}
        ////public bool TableExist()
        ////{
        ////    var db = DependencyService.Get<ISQLite>().GetConnection();
        ////    var settings = db.Table<Movie>().ToList();
        ////    return (settings.Count > 0) ? true : false;

        ////}
        //public static bool TableExists<T>(string TableName)
        //{
        //    var db = DependencyService.Get<ISQLiteService>().GetConnection();
        //    string query = string.Format("SELECT name FROM sqlite_master WHERE type='table' AND name='{0}'", TableName);
        //    var cmd = db.CreateCommand(query, typeof(T).Name);
        //    return cmd.ExecuteScalar<string>() != null;
        //}
        //public static BelProductDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new BelProductDatabase();
        //        }
        //        return database;
        //    }
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
            //var fileHelper = DependencyService.Get<IFileHelper>();

            //string strText = string.Empty;

            //var assembly = typeof(App).GetTypeInfo().Assembly;

            //using (var stream = assembly.GetManifestResourceStream("BelzonaMobile.Data.app-manifest-products-us.json"))
            //{
            //    strText = new StreamReader(stream).ReadToEnd();
            //}

            //var questions = JsonConvert.DeserializeObject<List<BelProduct>>(strText);

            //var azureService = DependencyService.Get<AzureService>();

            //var questions = await azureService.GetQuestions();

            //CurrentGame = new Game(questions);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

