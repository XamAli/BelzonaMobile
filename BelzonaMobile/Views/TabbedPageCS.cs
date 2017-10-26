using System;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
	public class TabbedPageCS : TabbedPage
	{
        public TabbedPageCS()
		{
            //Title = "Product Info";
            //Title = Resx.AppResources.PageTitle;

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
            /*
             * 1. Favarite Page: Get data from local storage (database: BelProdiucts.db3, Table:ProductTable) with Favarote tage = true
             * 2. ProductList Grouped By Series
             *    a. Get Data from local db  (database: BelProdiucts.db3, Table:ProductTable) 
             *    b.  (first time OR table not exisit, OR Content expired OR Language changed)  --> get from API/Url (belzona-app/us/app-manifest-products-us.json)
             *    c. Store in local db (database: BelProdiucts.db3, Table:ProductTable)
             * 3. Product List Grouped by Industry
             *    a. Get Data from local db  (database: BelProdiucts.db3, Table:ProductIndusTable) 
             *    b.  (first time OR table not exisit, OR Content expired OR Language changed)  --> get from API/Url (belzona-app/us/app-manifest-ind-app-us.json)
             *    c. Store in local db (database: BelProdiucts.db3, Table:ProductTable)
             * 4. Product List Grouped by Application (?????)
             *    a. Get Data from local db  (database: BelProdiucts.db3, Table:?????) 
             *    b.  (first time OR table not exisit, OR Content expired OR Language changed)  --> get from API/Url (?????)
             *    c. Store in local db (database: BelProdiucts.db3, Table:??????)
             * 5. Settings Page
             *    5.A About us Page
             *    5.B Contact us
             *    5.C Help/Learing page
             *    5.D Settings (?????) Page( user defined critea, stored in local db)
             *    5.E Videos page
             *      a. Get Data from local db  (database: BelProdiucts.db3, Table:ProductIndusTable) 
             *      b.  (first time OR table not exisit, OR Content expired OR Language changed)  --> get from API/Url (belzona-app/us/app-manifest-ind-app-us.json)
             *      c. Store in local db (database: BelProdiucts.db3, Table:ProductTable)
             * 
             * Group Industry: Facilities Maintenance, General Industry, Manufacturing, Mining & Quarrying, Marine, Oil & Gas, Pulp & Paper Petrochemical, Power, Water & Waste water, 
             *                 Steel, Agriculture and Fishing, Food & Drinks, Education
             * 
             * Group by Application: Ships & Offshore Structures, Valves, Pipes & Fittings, Centrifugal Pumps, Gaskets, Seals & Shims, Tanks & Chemical Contentment Areas
             *                       Fans Blowers and Compressors, heat Exchangers, Floor Problem Areas, Wall Problem Areas, Engine & Casings,  Mechanical Power Transmission.
             */
            navigationPage.Title = String.Format(@"{0} List", MenuTab1);
  
            Children.Add(new FavouriteList("Favorites") { Icon = "Favorites.png", Title = MenuTab1});
            Children.Add(new ProductListLocalDb() { Icon = "Series.png", Title = MenuTab2 });
            Children.Add(new ItemsPage() { Icon = "Industry.png", Title = MenuTab3 });

            Children.Add(new ItemsPage() { Icon = "Application.png", Title = MenuTab4 });
            Children.Add(new MasterPageCS() { Icon = "hamburger.png", Title = string.Format("{0} ...",MenuTab5) });


           
		}
        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();
        //    Title = CurrentPage?.Title ?? string.Empty;
        //}
       
	}
}

