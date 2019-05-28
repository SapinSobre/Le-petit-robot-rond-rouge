using Ogre.Models;
using Ogre.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Controllers
{
    public class GestionController : Controller
    {
        
        private LivreService livreService = new LivreService();
        private JouetService jouetService = new JouetService();
        private FraisService fraisService = new FraisService();
        // GET: Gestion
        public ActionResult TableauDeBord()
        {
            return View();
        }

        public ActionResult LesChiffres()
        {
            LesChiffresVM lesChiffresVM = new LesChiffresVM();
            lesChiffresVM.TotalStockLivres = livreService.ObtenirTousLesLivres().Sum(l => l.Prix);
            lesChiffresVM.TotalStockJouets = jouetService.ObtenirTousLesJouets().Sum(j => j.Prix);
            lesChiffresVM.QuantiteStockLivres = livreService.ObtenirTousLesLivres().Count;
            lesChiffresVM.QuantiteStockJouets = jouetService.ObtenirTousLesJouets().Count;
            lesChiffresVM.ListeFrais = fraisService.ObtenirTousLesFrais();
            return View(lesChiffresVM);
        }

        [HttpGet]
        public ActionResult AjouterFrais()
        {            
            return View();
        }

        [HttpPost]
        [ActionName("AjouterFrais")]
        public ActionResult AjouterFraisPost(Frais frais)
        {
            if (ModelState.IsValid)
            {
                fraisService.AjouterFrais(frais.IntitulePoste, frais.Montant);
                return RedirectToAction("LesChiffres");
            }
            return View(frais);
        }

        public ActionResult SupprimerFrais(int? id)
        {
            if (id.HasValue)
            {
                fraisService.SupprimerFrais(id.Value);
                return RedirectToAction("LesChiffres");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult MettreAJourFrais(int? id)
        {
            if (id.HasValue)
            {
                Frais frais = fraisService.ObtenirUnFrais(id.Value);
                return View(frais);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ActionName("MettreAJourFrais")]
        public ActionResult MettreAJourFraisPost(Frais frais)
        {
            if (ModelState.IsValid)
            {
                fraisService.MettreAJourFrais(frais.Id);
                return RedirectToAction("LesChiffres");
            }
            return View(frais);
        }
    }
}