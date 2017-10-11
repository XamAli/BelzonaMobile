using BelzonaMobile.Helpers;
using BelzonaMobile.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace BelzonaMobile.ViewModels
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Grouping<string, Product>> ProductGrouped { get; set; }

        public ProductsViewModel()
        {

            Products = ProductHelper.Products;
            ProductGrouped = ProductHelper.ProdGrouped;
        }

        public int ProductCount => Products.Count;
    }
}
