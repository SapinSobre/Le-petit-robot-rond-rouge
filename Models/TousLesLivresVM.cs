using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class TousLesLivresVM
    {
        public List<Livre> ListeLivres { get; set; }
        public List<AgeLivre> ListeAges { get; set; }
        public List<Theme> ListeThemes1 { get; set; }
        public List<Theme> ListeThemes2 { get; set; }
        public List<Theme> ListeThemes3 { get; set; }
    }
}