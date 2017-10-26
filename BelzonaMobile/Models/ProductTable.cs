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
}
