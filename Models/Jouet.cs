using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class Jouet : Produit
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            return null;
        }
    }
}