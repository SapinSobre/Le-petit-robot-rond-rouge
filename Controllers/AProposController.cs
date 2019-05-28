using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Controllers
{
    public class AProposController : Controller
    {
        // GET: APropos
        public ActionResult TableDesMatieres()
        {
            return View();
        }

        public ActionResult BonneIdee()
        {
            return View();
        }

        public ActionResult Fondateurs()
        {
            return View();
        }

        public ActionResult Informations()
        {
            return View();
        }

        public ActionResult Strategie()
        {
            return View();
        }       
    }
}