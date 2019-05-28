using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class ThemeCheckboxVM
    {
        public int Id { get; set; }
        public string NomTheme { get; set; }
        public bool EstSelectionne { get; set; }
    }
}