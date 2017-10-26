using System.Collections.ObjectModel;

namespace BelzonaMobile.ViewModeles
{
    public class ProductListLocalDbViewModel
    {
        public ObservableCollection<ProductTable> Products { get; set; }
        public ObservableCollection<Grouping<string, ProductTable>> ProductGrouped { get; set; }

        //public Product[] earthquakes { get; set; }
        public ProductListLocalDbViewModel()
        {

            Products = LocalDbHelper.Products;
            ProductGrouped = LocalDbHelper.ProdGrouped;
            //System.Diagnostics.Debug.WriteLine(string.Format("ProductsViewMode Count:{0}", Products.Count.ToString()));
            //System.Diagnostics.Debug.WriteLine(string.Format("ProductsViewMode Group:{0}", ProductGrouped.Count.ToString()));

        }

        public int ProductCount => Products.Count;
    }
}