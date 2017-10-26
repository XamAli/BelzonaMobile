using System.Collections.ObjectModel;

namespace BelzonaMobile.ViewModeles
{
    public class ProductsViewModel
    {
        public ObservableCollection<BelProduct> Products { get; set; }
        public ObservableCollection<Grouping<string, BelProduct>> ProductGrouped { get; set; }

        //public Product[] earthquakes { get; set; }
        public ProductsViewModel()
        {

            Products = ProductHelper.Products;
            ProductGrouped = ProductHelper.ProdGrouped;
            //System.Diagnostics.Debug.WriteLine(string.Format("ProductsViewMode Count:{0}", Products.Count.ToString()));
            //System.Diagnostics.Debug.WriteLine(string.Format("ProductsViewMode Group:{0}", ProductGrouped.Count.ToString()));
   
        }

        public int ProductCount => Products.Count;
    }
}
