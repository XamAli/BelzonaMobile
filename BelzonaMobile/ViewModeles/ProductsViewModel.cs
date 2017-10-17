using System.Collections.ObjectModel;

namespace BelzonaMobile.ViewModeles
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
