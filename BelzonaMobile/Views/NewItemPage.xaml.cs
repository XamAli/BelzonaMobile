//using System;
//using System.Collections.Generic;

//using Xamarin.Forms;

//namespace BelzonaMobile.Views
//{
//    public partial class NewItemPage : ContentPage
//    {
//        public NewItemPage()
//        {
//            InitializeComponent();
//        }
//    }
//}
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public BelProduct Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new BelProduct
            {

                //Text = "Item name",
                //Description = "This is an item description."
                name = "Item name",
                short_description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}