namespace BelzonaMobile
{
    public class Product
    {
        //series list view
        //list view ..... Title, short desc, 

        //public int SeriesId { get; set;  }
        //public int TypeId { get; set; }
        //public string FilePath { get; set; }
        //public string ShortDesc { get; set; }
        //public string LongDesc { get; set; }


        //public int VideoId { get; set; }
        //public string CategoryCode { get; set; }

        //public int Fileize { get; set; }
        //public string VideoName { get; set; }
        //public string VideoLink { get; set; }
        //public string YoutubeLink { get; set; }



        public string Name { get; set; }  // title or name or industry or Application
        public string Location { get; set; }
        public string Details { get; set; }
        //URL for our monkey image!
        public string Image { get; set; }

        public string NameSort => Name[0].ToString();
    }
}
