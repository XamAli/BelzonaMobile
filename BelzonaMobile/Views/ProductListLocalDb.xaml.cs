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
    public partial class ProductListLocalDb : ContentPage
    {
        public ObservableCollection<ProductTable> ProductTable { get; set; }
        public string PageTitle { get; set; }
        public ProductListLocalDb(string pTitle)
        {
            InitializeComponent();
            PageTitle = pTitle;
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

        protected override async void OnAppearing()
        {
            //((App)App.Current).ResumeAtTodoId = -1;

            List <ProductTable> results = await App.LocalDatabase.GetAllProductsAsync();

            //ObservableCollection<Grouping<string, ProductTable>> Group = SortAndGroup(results);
            ObservableCollection<ProductTable> objProd = new ObservableCollection<ProductTable>();
            //foreach(ProductTable p in results) {
            //    //System.Diagnostics.Debug.WriteLine(String.Format("Error:D {0}", p.ShortDesc.ToString()));
            //    objProd.Add((p));
            //}
            int cntr = 0;
            foreach (ProductTable p in results)
            {
                p.ProductName = (p.ProductName.Length > 30) ? String.Format("{0}...", p.ProductName.Substring(0, 28)) : p.ProductName;
                p.ProductImage = (cntr % 2 == 0) ? p.ProductImage : "thumb_1111.png";
                p.Opacity = (p.Favourite == 1) ? 1 : .25;
                objProd.Add((p));
                cntr++;
            }
            var sorted = from item in objProd
                         orderby item.GroupName
                         group item by item.GroupName into itemGroup
                         select new Grouping<string, ProductTable>(itemGroup.Key, itemGroup);
     

            ObservableCollection<Grouping<string, ProductTable>> ProdGrouped = new ObservableCollection<Grouping<string, ProductTable>>();
            ProdGrouped = new ObservableCollection<Grouping<string, ProductTable>>(sorted);
            listView.ItemsSource = ProdGrouped;
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
        //public List<ProductTable> TransformDTO()
        //{
        //    ObservableCollection<BelProduct> Products = ProductHelper.Products;
        //    List<ProductTable> table = new List<ProductTable>();
        //    foreach (BelProduct p in Products)
        //    {
        //        ProductTable pt = new ProductTable();
        //        pt.Code = p.ProductCode;
        //        pt.Name = p.ProductName;
        //        pt.ShortDesc = p.ShortDesc;
        //        pt.LongDesc = p.LongDesc;
        //        pt.Favourite = false;
        //        pt.CreatedDate = System.DateTime.Now;
        //        pt.ExpirationDate = System.DateTime.Now.AddMonths(2);
        //        table.Add(pt);
        //        //System.Diagnostics.Debug.WriteLine(String.Format("Product:D {0}", p.ProductName));
        //        //db.SaveItemAsync(p);
        //    }
        //    return table;
        //}
        async void onImageStarTapped(object sender, EventArgs args)
        {
            var image = sender as Image;
            var answer = await DisplayAlert("My Favorite:", "Would you like to add your favorite list?", "Yes", "No");
            //Debug.WriteLine("Answer: " + answer);
            if (answer)
            {
                image.Opacity = 1;
                //save to favo
            }
        }
    }
}


