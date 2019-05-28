using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class Frais
    {
        public int Id { get; set; }
        public string IntitulePoste {get;set;}
        public float Montant { get; set; }
    }
}