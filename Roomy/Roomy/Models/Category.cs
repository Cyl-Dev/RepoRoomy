using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(50)]
        [Display(Name = "NomCateg")]
        public string Name { get; set; }
    
    }
}