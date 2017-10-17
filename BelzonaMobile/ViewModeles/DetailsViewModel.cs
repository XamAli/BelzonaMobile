namespace BelzonaMobile.ViewModeles
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }
        public DetailsViewModel(Product product)
        {
            Product = product;
        }
    }
}