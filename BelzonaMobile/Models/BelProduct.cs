using System;
using Newtonsoft.Json;

namespace BelzonaMobile
{
    public class BelProduct
    {
        public string file_path { get; set; }
        public string formulation_number { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string ProductName { get; set; }
        public int series_id { get; set; }
        public int type_id { get; set; }
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDesc { get; set; }
        [JsonProperty(PropertyName = "long_description")]
        public string LongDesc { get; set; }
        public string product_image   { get; set; }



        //public int VideoId { get; set; }
        //public string CategoryCode { get; set; }

        //public int Fileize { get; set; }
        //public string VideoName { get; set; }
        //public string VideoLink { get; set; }
        //public string YoutubeLink { get; set; }



        //public string Name { get; set; }  // title or name or industry or Application
        //public string Location { get; set; }
        //public string Details { get; set; }
        ////URL for our monkey image!
        //public string Image { get; set; }

        //public string NameSort => Name[0].ToString();
    }
}
