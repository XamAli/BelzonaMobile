using System;
using BelzonaMobile.Helpers;
using BelzonaMobile.ViewModels;
using BelzonaMobile.Views;
using Xamarin.Forms;
using System.Reflection;

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
        public App()
        {


            System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            System.Diagnostics.Debug.WriteLine("====================================");

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            //if ( Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android )
            if (Device.RuntimePlatform == Device.iOS )
            {
                // determine the correct, supported .NET culture
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                BelzonaMobile.Resx.AppResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }

            //MainPage =  new MenuPage();
            MainPage = new MainPageCS();
           
            //MainPage = new NavigationPage(new MainPageCS())
            //{
            //    BarTextColor = Color.White,
            //    BarBackgroundColor = Color.FromHex("#B2BABB")
            //};
        }



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

