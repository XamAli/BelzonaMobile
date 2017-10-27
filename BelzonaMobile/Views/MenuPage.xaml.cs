using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public partial class MenuPage : ContentPage
    {
        MasterMenuItem menu = new MasterMenuItem();
        public MenuPage()
        {
            InitializeComponent();

        }
        async void OnAboutClicked(object sender, EventArgs e)
        {
            await DisplayAlert("About Page Clicked", "", "ok");
            await Navigation.PushAsync(new ContactPage());
     
        }
        async void OnContactClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Help Page Clicked", "", "ok");
            await Navigation.PushAsync(new ContactPage());
     

        }
        async void OnHelpClicked(object sender, EventArgs e)
        {
            await DisplayAlert("OnContactClicked Page Clicked", "", "ok");
            await Navigation.PushAsync(new ContactPage());
     

        }
        async void OnSettingsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("OnSettingsClicked Page Clicked", "", "ok");
            await Navigation.PushAsync(new ContactPage());
     

        }
        async void OnAdminClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnAdminClicked Page Clicked", "", "ok");
            await Navigation.PushAsync(new SqlAdmin());
     

        }
    }
}
