using BelzonaMobile.Views;
using Xamarin.Forms;
using System.Reflection;
using BelzonaMobile.ViewModeles;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        //static BelProductDatabase database;

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

     
            //MainPage =  new MenuPage();
            //ProductManager = new ProductManager(new RestService());
            //MainPage = new MainPageCS();
           
            if (Constants.UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                //MainPage = new TabbedPageCS();
                MainPage = new NavigationPage(new TabbedPageCS());
                 //MainPage = new ItemsPage();
            else
                MainPage = new NavigationPage(new TabbedPageCS());
            
        }

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

