using BelzonaMobile.Views;
using Xamarin.Forms;
using System.Reflection;
using BelzonaMobile.ViewModeles;


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


            System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            System.Diagnostics.Debug.WriteLine("====================================");

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            //if ( Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android )

            var ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            L10n.SetLocale(ci);
            Resx.AppResources.Culture = ci;

            //if (Device.RuntimePlatform == Device.iOS )
            //{
            //    // determine the correct, supported .NET culture
            //    var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            //    BelzonaMobile.Resx.AppResources.Culture = ci; // set the RESX for resource localization
            //    DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            //}

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

