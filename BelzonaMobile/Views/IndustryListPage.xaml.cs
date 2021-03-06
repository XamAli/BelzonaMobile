﻿using System;
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
    public partial class IndustryListPage : ContentPage
    {
        //public ObservableCollection<IndustryTable> IndustryTable { get; set; }
        public string PageTitle { get; set; }
        public IndustryListPage(string pTitle)
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
            var item = ((ListView)sender).SelectedItem as IndustryTable;

            //if (item == null)
            //return;

            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            if (item != null)
            {
                var newPage = new VideoListPage("VideoPage", item.Code);
                Navigation.PushAsync(newPage);
            }
            else { return; }
        }

        protected override async void OnAppearing()
        {
            //((App)App.Current).ResumeAtTodoId = -1;

            List<IndustryTable> results = await App.LocalDatabase.GetIndustryTablesAsync();

            //ObservableCollection<Grouping<string, ProductTable>> Group = SortAndGroup(results);
            ObservableCollection<IndustryTable> objProd = new ObservableCollection<IndustryTable>();
 
            int cntr = 0;
            foreach (IndustryTable p in results)
            {
                p.Title = (p.Title.Length > 30) ? String.Format("{0}...", p.Title.Substring(0, 28)) : p.Title;
                p.ProductImage = (cntr % 2 == 0) ? p.ProductImage : "thumb_1111.png";
                p.Opacity = (p.Favourite == 1) ? 1 : .25;
                objProd.Add((p));
                cntr++;
            }
            //var sorted = from item in objProd
            //             orderby item.GroupName
            //             group item by item.GroupName into itemGroup
            //             select new Grouping<string, ProductTable>(itemGroup.Key, itemGroup);


            //ObservableCollection<Grouping<string, ProductTable>> ProdGrouped = new ObservableCollection<Grouping<string, ProductTable>>();
            //ProdGrouped = new ObservableCollection<Grouping<string, ProductTable>>(sorted);
            listView.ItemsSource = objProd;
 
        }

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


