using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class AgeLivre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Age")]
        public string TrancheDAge { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }
    }
}