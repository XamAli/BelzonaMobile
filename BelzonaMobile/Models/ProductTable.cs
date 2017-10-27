using System;
using System.Collections.ObjectModel;
using SQLite;

namespace BelzonaMobile
{
    public class ProductGroupTable : ObservableCollection<ProductTable>
    {
        public string GroupName { get; set; }

    }
    public class ProductTable
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public int Favourite { get; set; }
        public string ProductImage { get; set; }
        public double Opacity { get; set; }

        public string GroupName => String.Format("{0}000 Series", (Code.Split('.')[0]).ToString());
        //public string ProductImage => "thumb_1221.png";
    }
    public class SettingTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CurrentLingo { get; set; }
        public DateTime ExpDate { get; set; }
    }
    public class LocalTable
    {
        public string Name { get; set; }
        public int Seq { get; set; }
    }
    //video_id": 93,
    //"code": "",
    //"title": "",
    //"short_description": "",
    //"long_description": "",
    //"VideoName": ",
    //"DataLink": ",
    //"Size": 55,
    //"YoutubeLink": "
    //"VideoDescription":
    public class IndustryTable
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public int Favourite { get; set; }
        public string ProductImage { get; set; }
        public double Opacity { get; set; }
    }
    public class VideoTable
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string IndustryCode { get; set; } //forien key
        public string VideoName { get; set; }
        public string DataLink { get; set; }
        public int Size { get; set; }
        public string YoutubeLink { get; set; }
        public string VideoDescription { get; set; }
    }
}
