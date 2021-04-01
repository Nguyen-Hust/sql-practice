using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("order_items",Schema = "sales")]
    public class OrderItem
    {
        public Order Order { get; set; }
        [Key, Column(Order = 0)]
        public int order_id { get; set; }
        [Key, Column(Order = 1)]
        public int item_id { get; set; }
        public Product Product { get; set; }
        [Required]
        public int product_id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public double list_price { get; set; }
        [Required]
        public double discount { get; set; }
    }
}
