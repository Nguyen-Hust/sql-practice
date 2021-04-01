using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("stores", Schema = "sales")]
    public class Store
    {
        [Key]
        public int store_id { get; set; }
        [Required]
        public string store_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        [ForeignKey("store_id")]
        public ICollection<Staff> Staffs { get; set; }
        [ForeignKey("store_id")]
        public ICollection<Order> Orders { get; set; }
        [ForeignKey("store_id")]
        public ICollection<Stock> Stocks { get; set; }
    }
}
