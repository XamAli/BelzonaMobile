//using System;
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
        public ObservableCollection<BelProduct> BelProducts { get; set; }
        public  ObservableCollection<Grouping<string, BelProduct>> BelProdGrouped { get; set; }
        public Command LoadItemsCommand { get; set; }
       
        public ItemsViewModel()
        {
            //Title = "Product List";
            BelProducts = new ObservableCollection<BelProduct>();
            BelProdGrouped = new ObservableCollection<Grouping<string, BelProduct>>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            System.Diagnostics.Debug.WriteLine(string.Format("ItemsPage :{0}", BelProducts.Count.ToString()));

          //MessagingCenter.Subscribe<NewItemPage, BelProduct>(this, "AddItem", async (obj, item) =>
            //{
            //    var _item = item as BelProduct;
            //    BelProducts.Add(_item);
            //    await DataStore.AddItemAsync(_item);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                BelProducts.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    BelProducts.Add(item);
                }
                //DisplayAlert("On Disappearing", String.Format("Page OnDisappearing {0}", BelProducts.Count.ToString()), "Ok");
                System.Diagnostics.Debug.WriteLine(string.Format("ExecuteLoadItemsCommand Product:{0}", BelProducts.Count.ToString()));
                BelProdGrouped.Clear();
                //BelProdGrouped = await DataStore.GetItemGroupAsync();
                    //(System.Collections.ObjectModel.ObservableCollection<BelzonaMobile.Grouping<string, BelzonaMobile.BelProduct>>) await DataStore.GetItemGroupAsync();
                //foreach (var grp in gItems)
                //{
                //    BelProdGrouped.Add(grp);
                //}

                //BelProdGrouped = grp;
                System.Diagnostics.Debug.WriteLine(string.Format("ExecuteLoadItemsCommand Group:{0}", BelProdGrouped.Count.ToString()));
                //System.Diagnostics.Debug.WriteLine(string.Format("ExecuteLoadItemsCommand Group:{0}", BelProdGrouped.Count.ToString()));

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
        //public int GroupCount => ItemsViewModel.BelProdGrouped.Count;
    }
}
