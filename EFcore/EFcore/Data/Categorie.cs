using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("categories", Schema = "production")]
    public class Categorie
    {
        [Key]
        public int category_id { get; set; }
        [Required]
        public string category_name { get; set; }
        [ForeignKey("category_id")]
        public ICollection<Product> Products { get; set; }
    }
}
