using System;
using BelzonaMobile.Helpers;
using BelzonaMobile.ViewModels;
using BelzonaMobile.Views;
using Xamarin.Forms;

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

