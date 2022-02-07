using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id  { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Display Order")] // it uses "Display Order" string for validation errors 
        public int DisplayOrder { get; set; }
        public DateTime CreationTime{ get; set; } = DateTime.Now;
    }
}
