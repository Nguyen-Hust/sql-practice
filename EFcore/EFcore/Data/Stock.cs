using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("stocks", Schema = "production")]
    public class Stock
    {
        public Store Store { get; set; }
        [Key, Column(Order=0)]
        public int store_id { get; set; }
        public Product Product { get; set; }
        [Key, Column(Order = 1)]
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
