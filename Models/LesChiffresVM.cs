using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class LesChiffresVM
    {
        public float TotalStockLivres { get; set; }
        public float TotalStockJouets { get; set; }
        public int QuantiteStockLivres { get; set; }
        public int QuantiteStockJouets { get; set; }
        public List<Frais> ListeFrais { get; set; }
    }
}