using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace BelzonaMobile
{
    public class BelProductGroup: ObservableCollection<BelProduct>
    {
        public string GroupName { get; set; }

    }
    public class BelProduct
    {
        [JsonProperty(PropertyName = "file_path")]
        public string FilePath { get; set; }
        [JsonProperty(PropertyName = "formulation_number")] 
        public string Formulation { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string ProductName { get; set; }
        [JsonProperty(PropertyName = "series_id")]
        public int SeriesId { get; set; }
        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDesc { get; set; }
        [JsonProperty(PropertyName = "long_description")]
        public string LongDesc { get; set; }
        //public string ProductInfo { get; set; }
        public string ProductImage   { get; set; }

        public string GroupName => String.Format("{0} Series", (SeriesId * 1000).ToString());
        public string NameSort => ProductName[0].ToString();
        public string ProductCode => String.Format("{0}.{1}.{2}", SeriesId.ToString(),Formulation.Trim(),TypeId.ToString());

        //public int VideoId { get; set; }
        //public string CategoryCode { get; set; }

        //public int Fileize { get; set; }
        //public string VideoName { get; set; }
        //public string VideoLink { get; set; }
        //public string YoutubeLink { get; set; }

    }
    public class BelProductIndus
    {
        [JsonProperty(PropertyName = "video_")]
        public string VideoId { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDesc { get; set; }
        [JsonProperty(PropertyName = "long_description")]
        public string LongDesc { get; set; }

        public string VideoName { get; set; }
        public string DataLink { get; set; }
        public int Size { get; set; }
        public string YoutubeLink { get; set; }
        public string VideoDescription { get; set; }

        //public string ProductImage { get; set; }

        //public string GroupName => String.Format("{0} Series", (SeriesId * 1000).ToString());
        //public string NameSort => ProductName[0].ToString();
        //public string ProductCode => String.Format("{0}.{1}.{2}", SeriesId.ToString(), Formulation.Trim(), TypeId.ToString());

    }
}

