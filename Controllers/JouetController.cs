using System;
using Ogre.Models;
using Ogre.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace Ogre.Controllers
{
    public class JouetController : Controller
    {
        private JouetService jouetService = new JouetService();

        public ActionResult JouetHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AjouterJouet()
        {
            Jouet jouet = new Jouet
            {
                CategorieId = 1002
                
            };
            return View(jouet);
        }

        [ActionName("AjouterJouet")]
        public ActionResult AjouterJouetPost(Jouet jouet)
        {
            if (!ModelState.IsValid)
            {          
                string fileName = Path.GetFileNameWithoutExtension(jouet.ImageFile.FileName);
                string extension = Path.GetExtension(jouet.ImageFile.FileName);
                fileName = fileName + extension;
                jouet.ImagePath = fileName;
                jouetService.AjouterJouet(jouet);
                               
                return RedirectToAction("TousLesJouets", "Jouet");
            }
            return View(jouet);
        }

        public ActionResult TousLesJouets()
        {
            List<Jouet> listeJouets = jouetService.ObtenirTousLesJouets();
            return View(listeJouets);
        }
    }
}