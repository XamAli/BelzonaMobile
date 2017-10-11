using System;
using System.Collections.Generic;
using BelzonaMobile.ViewModels;
using Xamarin.Forms;
using BelzonaMobile.Models;

namespace BelzonaMobile.Views
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = new ProductsViewModel();
        }

        //void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //=> ((ListView)sender).SelectedItem = null;
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var item = ((ListView)sender).SelectedItem as Product;
            if (item == null)
                return;

            //DisplayAlert("Item Tabbed", e.ToString(), "Ok");

        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as Product;

            //if (item == null)
            //return;

            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            if (item != null)
            {
                var newPage = new DetailsPage(item);
                Navigation.PushAsync(newPage);
            }
            else { return; }
        }

    }
}


