using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Models
{
    public abstract class Produit : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Libelle { get; set; }
        [Required]
        [MaxLength(100)]
        public string Fabricant { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }
        [Required]
        public int CategorieId { get; set; }
        [Required]
        public float Prix { get; set; }
        [Required]
        public DateTime DateReception { get; set; }
        [Required]
        [MaxLength(1000)]
        [DisplayName("Image")]          
        public string ImagePath { get; set; }    
        public HttpPostedFileBase ImageFile { get; set; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext context);
        
    }
}