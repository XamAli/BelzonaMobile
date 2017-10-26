using Xamarin.Forms;
using BelzonaMobile.ViewModeles;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BelzonaMobile.Views
{
    public partial class DetailsPage : ContentPage
    {
        
        private string ProductCode = string.Empty;
       
        public DetailsPage(string code)
        {
            InitializeComponent();
            ProductCode = code;
            //BindingContext = new DetailsViewModel(product);
        }
        protected override async void OnAppearing()
        {
   
            ProductTable  objProd = await App.LocalDatabase.GetDetailProductAsync(ProductCode);
            objProd.LongDesc = Regex.Replace(objProd.LongDesc, @"<(.|\n)*?>", string.Empty);
            BindingContext = objProd;
   
        }
    }

}