using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class Theme
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Intitule { get; set; }
    }
}