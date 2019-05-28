using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Models
{
    public class RechercheLivreVM
    {
        public SelectList ListeAgesLivres { get; set; }
        [Required]
        [DisplayName("Age")]
        public int AgeLivreId { get; set; }
    }
}