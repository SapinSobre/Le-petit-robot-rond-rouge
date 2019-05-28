using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Models
{
    public class Livre : Produit
    {
        [MaxLength(100)]
        public string Auteur { get; set; }
        [MaxLength(100)]
        public string Illustrateur { get; set; }
        [MaxLength(100)]
        [DisplayName("Scénariste")]
        public string Scenariste { get; set; } 
        [DisplayName("Age")]
        public SelectList ListeAgesLivres { get; set; }
        [Required]
        public int AgeLivreId { get; set; }
        [Required]
        public int Theme1 { get; set; }
        [Required]
        public int Theme2 { get; set; }
        [Required]     
        public int Theme3 { get; set; }

        public List<ThemeCheckboxVM> ListeThemeCheckboxVM { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (ListeThemeCheckboxVM.Any(t => t.EstSelectionne))
            {
                yield return new ValidationResult("Vous devez au moins sélectionner un thème.", new[] { "ListeThemeCheckboxVM" });
            }
            if (ListeThemeCheckboxVM.FindAll(th => th.EstSelectionne).Count > 3)
            {
                yield return new ValidationResult("Vous ne pouvez pas choisir plus de trois thèmes.", new[] { "ListeThemeCheckboxVM" });
            }
        }
    }
}