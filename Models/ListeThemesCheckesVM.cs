using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class ListeThemesCheckesVM : IValidatableObject
    {
        public List<ThemeCheckboxVM> ListeThemeCheckboxVM = new List<ThemeCheckboxVM>();

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
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
    }}