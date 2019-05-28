using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class FicheLivreVM
    {
        public Livre Livre { get; set; }
        public AgeLivre AgeLivre { get; set; }
        public List<Theme> ListeThemes { get; set; }
    }
}