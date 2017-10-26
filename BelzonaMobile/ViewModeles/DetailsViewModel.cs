namespace BelzonaMobile.ViewModeles
{
    public class DetailsViewModel
    {
        public BelProduct Product { get; set; }
        public DetailsViewModel(BelProduct product)
        {
            Product = product;
        }
    }
}