using System;
using System.Collections.Generic;
using BelzonaMobile.ViewModeles;

using Xamarin.Forms;
//Product List Page datasource = ItemsViewModel --> DataStore(CloudDataStore)--> http://development.belzona.com/belzona-app/us/app-manifest-products-us.json

namespace BelzonaMobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public int GroupCount = 0;
        public ItemsPage()
        {

            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();

            //if (viewModel.BelProducts.Count == 0)
            //    viewModel.LoadItemsCommand.Execute(null);
            //System.Diagnostics.Debug.WriteLine(string.Format("ItemsPage :{0}", viewModel.BelProducts.Count.ToString()));
            //System.Diagnostics.Debug.WriteLine(string.Format("ItemsViewModel.BelProdGrouped Group:{0}", ItemsViewModel.BelProdGrouped.Count.ToString()));
  
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as BelProduct;
            if (item == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            await DisplayAlert("Alert", "Detail page selected", "Ok");
            // Manually deselect item
            //ItemsListView.SelectedItem = null;
        }
        protected override void OnDisappearing()
        {
            //DisplayAlert("On Disappearing", String.Format("Page OnDisappearing {0}",viewModel.BelProducts.Count.ToString()), "Ok");
            System.Diagnostics.Debug.WriteLine(string.Format("Disappearing :{0}", viewModel.BelProducts.Count.ToString()));
        }
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NewItemPage());
            await DisplayAlert("Add", "Page to add .........", "Ok");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.BelProducts.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            
            //DisplayAlert("On Appearing", String.Format("Page OnDisappearing {0}", viewModel.BelProducts.Count.ToString()), "Ok");
            System.Diagnostics.Debug.WriteLine(string.Format("OnAppearing :{0}", viewModel.BelProducts.Count.ToString()));
            //var groupedData = ItemsViewModel.BelProdGrouped;
            //foreach (var group in groupedData)
            //{
            //    var groupKey = group.Key;
            //    foreach (var items in group)
            //        //DoSomethingWith(groupKey, groupedItem);
            //        //System.Diagnostics.Debug.WriteLine(string.Format("Key :{0}-{1}",groupKey, items.GroupName));
            //}
            //if ((viewModel != null) && (viewModel.BelProdGrouped != null)) { }
            //    foreach (var K in viewModel.BelProdGrouped)
            //    {

            //    }
            //}
            //GroupCount = groupedData.Count;
            //System.Diagnostics.Debug.WriteLine(string.Format("ItemsViewModel.BelProdGrouped Group:{0}", ItemsViewModel.BelProdGrouped.Count.ToString()));


            //ItemsListView.ItemsSource = App.Database.GetItems();
        }
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var item = ((ListView)sender).SelectedItem as Product;
            if (item == null)
                return;
            //DisplayAlert("Item Tabbed", e.ToString(), "Ok");

        }
        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as ProductTable;

            //if (item == null)
            //return;

            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            if (item != null)
            {
                var newPage = new DetailsPage(item.Code);
                Navigation.PushAsync(newPage);
            }
            else { return; }
        }

        async void onImageStarTapped(object sender, EventArgs args)
        {
            var image = sender as Image;
             var answer = await DisplayAlert("My Favorite:", "Would you like to add your favorite list?", "Yes", "No");
            //Debug.WriteLine("Answer: " + answer);
             if(answer)
            {
                image.Opacity = 1;
                //save to favo
            }            
        } 
    }
}
