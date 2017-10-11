using System;
using System.Collections.Generic;
using BelzonaMobile.Models;
using BelzonaMobile.ViewModels;
using Xamarin.Forms;

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