using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [MaxLength(20)]
        public string Pwd { get; set; }
    }
}