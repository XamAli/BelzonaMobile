using System;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
	public class TabbedPageCS : TabbedPage
	{
        public TabbedPageCS()
		{
            //Title = "Product Info";
            Title = Resx.AppResources.PageTitle;

           // Icon = "belzonalogo_es_24.png";
            var navigationPage = new NavigationPage();
            //        var navigationPage = new NavigationPage (new PageOneCS ());
            //navigationPage.Icon = "Favorites.png";
            //navigationPage.Title = "Page One";

            String MenuTab1 = Resx.AppResources.MenuTab1.ToString();
            String MenuTab2 = Resx.AppResources.MenuTab2.ToString();
            String MenuTab3 = Resx.AppResources.MenuTab3.ToString();
            String MenuTab4 = Resx.AppResources.MenuTab4.ToString();
            String MenuTab5 = Resx.AppResources.MenuTab5.ToString();
               
			//Children.Add(navigationPage);
            Children.Add(new ItemsPage(){Icon="Series.png", Title=MenuTab1});
            Children.Add(new ProductsPage() { Icon = "Industry.png", Title = MenuTab2 });

            Children.Add(new LocalHtml() { Icon = "Application.png", Title = MenuTab3 });
            Children.Add(new FirstPage(){ Icon = "Videos.png", Title = MenuTab4 });
            Children.Add(new MasterPageCS() { Icon = "hamburger.png", Title = string.Format("{0} ...",MenuTab5) });

            //this.CurrentPageChanged += (object sender, EventArgs e) => {
            //    var i = this.Children.IndexOf(this.CurrentPage);
            //    System.Diagnostics.Debug.WriteLine("Page No:" + i);
            //};
		}
        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();
        //    Title = CurrentPage?.Title ?? string.Empty;
        //}
       
	}
}

