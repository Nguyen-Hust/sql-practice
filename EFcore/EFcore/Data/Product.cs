using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("products", Schema = "production")]
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public int brand_id { get; set; }
        public Categorie Categorie { get; set; }
        [Required]
        public int category_id { get; set; }
        [Required]
        public int model_year { get; set; }
        [Required]
        public double list_price { get; set; }
        [ForeignKey("product_id")]
        public ICollection<OrderItem> OrderItems { get; set; }
        [ForeignKey("product_id")]
        public ICollection<Stock> Stocks { get; set; }
    }
}
