using System;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
	public class TabbedPageCS : TabbedPage
	{
        public TabbedPageCS()
		{
            Title = "Product Info";
           // Icon = "belzonalogo_es_24.png";
            var navigationPage = new NavigationPage();
   //        var navigationPage = new NavigationPage (new PageOneCS ());
			//navigationPage.Icon = "Favorites.png";
			//navigationPage.Title = "Page One";

			//Children.Add(navigationPage);
            Children.Add(new ProductsPage(){Icon="Favorites.png", Title="Page One"});
            Children.Add(new ProductsPage() { Icon = "Series.png", Title = "Page Two" });

            Children.Add(new ProductsPage() { Icon = "Industry.png", Title = "Page Three" });
            Children.Add(new ProductsPage(){ Icon = "Application.png", Title = "Page Four" });
            Children.Add(new ProductsPage() { Icon = "Videos.png", Title = "Page Five" });

            //this.CurrentPageChanged += (object sender, EventArgs e) => {
            //    var i = this.Children.IndexOf(this.CurrentPage);
            //    System.Diagnostics.Debug.WriteLine("Page No:" + i);
            //};
		}

	}
}

