using Xamarin.Forms;
using BelzonaMobile.ViewModeles;

namespace BelzonaMobile.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Product product)
        {
            InitializeComponent();
            BindingContext = new DetailsViewModel(product);
        }
       
    }
}