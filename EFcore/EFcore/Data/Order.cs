using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("orders", Schema = "sales")]
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public Customer Customer { get; set; }
        public int customer_id { get; set; }
        [Required]
        public int order_status { get; set; }
        [Required]
        public DateTime order_date { get; set; }
        [Required]
        public DateTime required_date { get; set; }
        public DateTime shipped_date { get; set; }
        public Store Store { get; set; }
        [Required]
        public int store_id { get; set; }
        public Staff Staff { get; set; }
        [Required]
        public int staff_id { get; set; }
        [ForeignKey("order_id")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
