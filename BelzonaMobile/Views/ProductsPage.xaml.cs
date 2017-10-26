using System;
using BelzonaMobile.ViewModeles;
using Xamarin.Forms;


//Product List Page datasource = ProductViewModel --> ProductHelper -->BelzonaMobile.Data.app-manifest-products-us.json
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

            var item = ((ListView)sender).SelectedItem as BelProduct;
            if (item == null)
                return;

            DisplayAlert("Item Tabbed", e.ToString(), "Ok");

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
        protected override void OnAppearing()
        {

            //DisplayAlert("Item Appearing", "test", "Ok");
            //base.OnAppearing();

            //if (viewModel.Items.Count == 0)
                //viewModel.LoadItemsCommand.Execute(null);
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


