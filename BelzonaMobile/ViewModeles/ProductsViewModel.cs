using System.Collections.ObjectModel;

namespace BelzonaMobile.ViewModeles
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> BelProducts { get; set; }
        public ObservableCollection<Grouping<string, Product>> BelProductGrouped { get; set; }

        //public Product[] earthquakes { get; set; }
        public ProductsViewModel()
        {

            BelProducts = ProductHelper.Products;
            BelProductGrouped = ProductHelper.ProdGrouped;
        }

        public int ProductCount => BelProducts.Count;
    }
}
