using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Models
{
    public class MiseAJourLivreVM
    {
        public Livre Livre { get; set; }
        public SelectList ListeSelectAges { get; set; }
        public List<Theme> ListeThemes { get; set; }
    }
}