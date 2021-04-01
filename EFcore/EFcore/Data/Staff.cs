using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    [Table("staffs", Schema = "sales")]
    public class Staff
    {
        [Key]
        public int staff_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string email { get; set; }
        public string phone { get; set; }
        [Required]
        public int active { get; set; }
        [Required]
        public int store_id { get; set; }
        public int manager_id { get; set; }

        [ForeignKey("manager_id")]
        public ICollection<Staff> Staffs { get; set; }
        [ForeignKey("staff_id")]
        public ICollection<Order> Orders { get; set; }
    }
}
