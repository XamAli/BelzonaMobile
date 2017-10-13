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
            Children.Add(new ProductsPage(){Icon="Favorites.png", Title="Favorites"});
            Children.Add(new ProductsPage() { Icon = "Series.png", Title = "By Series" });

            Children.Add(new LocalHtml() { Icon = "Industry.png", Title = "By Industry" });
            Children.Add(new FirstPage(){ Icon = "Application.png", Title = "Application" });
            Children.Add(new MasterPageCS() { Icon = "todo.png", Title = "More ..." });

            //this.CurrentPageChanged += (object sender, EventArgs e) => {
            //    var i = this.Children.IndexOf(this.CurrentPage);
            //    System.Diagnostics.Debug.WriteLine("Page No:" + i);
            //};
		}

	}
}

