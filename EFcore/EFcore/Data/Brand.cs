using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("brands", Schema = "production")]
    public class Brand
    {
        [Key]
        public int brand_id { get; set; }
        [Required]
        public string brand_name { get; set; }
        [ForeignKey("brand_id")]
        public ICollection<Product> Products { get; set; }
    }
}
