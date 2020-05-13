using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
    }
}
