﻿//using System;
//namespace BelzonaMobile.ViewModeles
//{
//    public class ItemsViewModel
//    {
//        public ItemsViewModel()
//        {
//        }
//    }
//}
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using BelzonaMobile.Views;
using Xamarin.Forms;

namespace BelzonaMobile.ViewModeles
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<BelProduct> BelProductItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            //Title = "Product List";
            BelProductItems = new ObservableCollection<BelProduct>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, BelProduct>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as BelProduct;
                BelProductItems.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                BelProductItems.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    BelProductItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
