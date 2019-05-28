using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class Employe
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; }
        [Required]
        public float TarifDeLHeure { get; set; }
        public string PhotoEmploye { get; set; }
    }
}