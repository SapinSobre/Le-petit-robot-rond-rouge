using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre
{
    public static class SessionUtil
    {
        public static string ConnectionString {
            get { return @"Server=(localdb)\MSSQLLocalDB;Database=LOgreEnSoucoupe;Trusted_Connection=true;"; }
        }
    }
}