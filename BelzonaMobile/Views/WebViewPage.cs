using System;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public class WebViewPage : ContentPage
    {
        private string ProductCode = string.Empty;
        WebView  browser = new WebView();
        private ProductTable Table{ get; set; }
        public WebViewPage(string _code)
        {

            //var htmlSource = new HtmlWebViewSource();
             Label header = new Label
            {
                Text = "WebView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            //var htmlSource = new HtmlWebViewSource();

            ProductCode = _code;
            //htmlSource.Html = String.Format(@"<html><body><p>{0}</p>{1}{2}{3}</body></html>", Table.ProductName, Table.ProductName, Table.ShortDesc, Table.LongDesc);
            //browser.Source = htmlSource;

            //this.Content = browser;
            //WebView webView = new WebView
            //{
            //    Source = new UrlWebViewSource
            //    {
            //        Url = "http://blog.xamarin.com/",
            //    },
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //// Build the page.
            //this.Content = new StackLayout
            //{
            //    Children =
            //    {
            //        header,
            //        webView
            //    }
            //};
        }
        protected override async void OnAppearing()
        {

            Table = await App.LocalDatabase.GetDetailProductAsync(ProductCode);
            //objProd.LongDesc = Regex.Replace(objProd.LongDesc, @"<(.|\n)*?>", string.Empty);
            Title = Table.ProductName;
            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = String.Format(@"<html><body><p>{0}</p><p>{1}</p>{2}</body></html>",  Table.ProductName, Table.ShortDesc, Table.LongDesc);
            browser.Source = htmlSource;
            //Label header = new Label
            //{
            //    Text = "WebView",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //BindingContext = objProd;
            this.Content = browser;
        }
    }
}

