using System;
using Xamarin.Forms;

/*
 * Master detail page .... implement Hamburger menu
 * Master apage: Menu Items (MasterPageCS)
 * Detail Page: Tabbed Page (TabbedPageCS)
 * not in use
 */
namespace BelzonaMobile.Views
{
    public class MainPageCS : MasterDetailPage
	{
		MasterPageCS masterPage;

        public MainPageCS()
        {
            masterPage = new MasterPageCS();
            Master = masterPage;
  			Detail = new NavigationPage (new TabbedPageCS());

			masterPage.ListView.ItemSelected += OnItemSelected;



		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
            var item = e.SelectedItem as MasterMenuItem;
			if (item != null)
            {
				Detail = new NavigationPage ((Page)Activator.CreateInstance (item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}
