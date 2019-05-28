using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class Activite
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
        [MaxLength(500)]
        public string Chapeau { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }
        public DateTime DateDebut {get;set;}
        public string DateDebutStr { get; set; }
        public DateTime DateFin { get; set; }
        public string DateFinStr { get; set; }
        public int NombreParticipantsMax { get; set; }
        public int NombreParticipantsInscrits { get; set; }
        [MaxLength(10)]
        public string Age { get; set; }
        [Required]
        public bool Lecture { get; set; }
        [Required]
        public bool Ecriture { get; set; }
        [Required]
        public bool Programmation { get; set; }
        [Required]
        public bool Robot { get; set; }
        [Required]
        public bool Bricolage { get; set; }
        [Required]
        public bool Dessin { get; set; }
        [Required]
        public bool Musique { get; set; }
        [Required]
        public bool Edition { get; set; }
        [Required]
        public bool Scratch { get; set; }
        [Required]
        public bool Arduino { get; set; }
        [Required]
        public bool Cubetto { get; set; }
        public int LivreId { get; set; }
        public int JouetId { get; set; }
        public float Prix { get; set; }
        public int NombreSeances { get; set; }
        public int EmployeId { get; set; }

        
    }    
}