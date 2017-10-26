using System;
using SQLite;

namespace BelzonaMobile.Models
{
    public class dbProduct
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime ExpTime { get; set; }
    }
}
