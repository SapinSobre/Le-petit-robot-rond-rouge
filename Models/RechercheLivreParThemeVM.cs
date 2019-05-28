using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Models
{
    public class RechercheLivreParThemeVM
    {
        public SelectList ListeThemesLivres { get; set; }
        [Required]
        [DisplayName("Age")]
        public int ThemeLivreId { get; set; }
    }
}