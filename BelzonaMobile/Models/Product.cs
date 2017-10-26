namespace BelzonaMobile
{
    public class Product
    {
 

        public string Name { get; set; }  // title or name or industry or Application
        public string Location { get; set; }
        public string Details { get; set; }
        //URL for our monkey image!
        public string Image { get; set; }

        public string NameSort => Name[0].ToString();
    }
}
