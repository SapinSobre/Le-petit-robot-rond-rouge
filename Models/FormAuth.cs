using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class FormAuth
    {
        public User Utilisateur { get; set; }
        public bool Authentifie { get; set; }
    }
}