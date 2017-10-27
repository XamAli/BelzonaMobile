//using System;
//using System.Collections.Generic;

//using Xamarin.Forms;

//namespace BelzonaMobile.Views
//{
//    public partial class FavouriteList : ContentPage
//    {
//        public FavouriteList()
//        {
//            InitializeComponent();
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BelzonaMobile.ViewModeles;
using Xamarin.Forms;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

//Product List Page datasource = ProductViewModel --> ProductHelper -->BelzonaMobile.Data.app-manifest-products-us.json
namespace BelzonaMobile.Views
{
    public partial class FavouriteList : ContentPage
    {
        public ObservableCollection<ProductTable> ProductTable { get; set; }
        public FavouriteList(string pTitle)
        {
            
            InitializeComponent();
            this.Title = pTitle;
            // BindingContext = new ProductListLocalDbViewModel();
        }

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
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            if (item != null)
            {
                //ProductDetailWebView
                //var newPage = new DetailsPage(item.Code);
                var newPage = new WebViewPage(item.Code);
                Navigation.PushAsync(newPage);
            }
            else { return; }
        }

        protected override async void OnAppearing()
        {
            //((App)App.Current).ResumeAtTodoId = -1;
            List<ProductTable> results = new List<BelzonaMobile.ProductTable>();
            try { results = await App.LocalDatabase.GetSelectedProductsAsync(); }
            catch { return; }

            //ObservableCollection<Grouping<string, ProductTable>> Group = SortAndGroup(results);
            ObservableCollection<ProductTable> objProd = new ObservableCollection<ProductTable>();
            int cntr = 0;
            foreach (ProductTable p in results)
            {
                p.ProductName = (p.ProductName.Length > 30) ? String.Format("{0}...", p.ProductName.Substring(0, 28)) : p.ProductName;
                p.ProductImage = (cntr % 2 == 0) ? p.ProductImage : "thumb_1111.png";
                p.Opacity = (p.Favourite == 1) ? 1 : .25;
                objProd.Add((p));
                cntr++;
            }

            listView.ItemsSource = objProd;
            //inser first time or every time content expires or Localization changes

            //string locationpath = string.Empty;
            //try
            //{
            //    locationpath = DependencyService.Get<IFileHelper>().GetLocalFilePath("BelProduct.db3");
            //    LocalDataStore db = new LocalDataStore(locationpath);
            //    List<ProductTable> table = TransformDTO();
            //    foreach (ProductTable item in table)
            //    {
            //        System.Diagnostics.Debug.WriteLine(String.Format("Product:D {0}", item.Code));
            //        db.SaveItemAsync(item);
            //    }

            //}
            //catch (Exception ex){
            //    System.Diagnostics.Debug.WriteLine(String.Format("Error:D {0}", ex.Message.ToString()));
            //}
            //DisplayAlert("Item Appearing", "test", "Ok");
            //base.OnAppearing();

            //if (viewModel.Items.Count == 0)
            //viewModel.LoadItemsCommand.Execute(null);
        }
        //async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var item = args.SelectedItem as BelProduct;
        //    if (item == null)
        //        return;

        //    //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        //    await DisplayAlert("Alert", "Detail page selected", "Ok");
        //    // Manually deselect item
        //    //ItemsListView.SelectedItem = null;
        //}
        async void onImageStarTapped(object sender, EventArgs args)
        {
            var image = sender as Image;
            var answer = await DisplayAlert("My Favorite:", "Would you like to add your favorite list?", "Yes", "No");
            //Debug.WriteLine("Answer: " + answer);
            if (answer)
                image.Opacity = 1;

        }

    }
}


