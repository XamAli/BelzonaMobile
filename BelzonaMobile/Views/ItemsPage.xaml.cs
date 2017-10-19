using System;
using System.Collections.Generic;
using BelzonaMobile.ViewModeles;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as BelProduct;
            if (item == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            await DisplayAlert("Alert", "Detail page selected", "Ok");
            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NewItemPage());
            await DisplayAlert("Add", "Page to add .........", "Ok");
        }

        protected override void OnAppearing()
        {
            //DisplayAlert("On Appearing", "Page to add .........", "Ok");
            base.OnAppearing();

            if (viewModel.BelProductItems.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);

            //ItemsListView.ItemsSource = App.Database.GetItems();
        }

    }
}
