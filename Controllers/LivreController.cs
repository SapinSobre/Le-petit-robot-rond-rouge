using Ogre.Models;
using Ogre.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Controllers
{
    public class LivreController : Controller
    {
        private LivreService livreService = new LivreService();

        public ActionResult LivreHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AjouterLivre()
        {
            Livre livre = new Livre
            {
                CategorieId = 1
            };

            List<SelectListItem> listeItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "Veuillez sélectionner une tranche d'âge", Value = null }
            };
            foreach (AgeLivre age in livreService.ObtenirTousLesAges())
            {
                SelectListItem item = new SelectListItem { Text = age.TrancheDAge, Value = age.Id.ToString() };
                listeItems.Add(item);
            }
            livre.ListeAgesLivres = new SelectList(listeItems, "Value", "Text");
                       
            livre.ListeThemeCheckboxVM = livreService.ObtenirTousLesThemes().Select(t => new ThemeCheckboxVM { Id = t.Id, NomTheme = t.Intitule }).ToList();

            return View(livre);           
        }

        [HttpPost]
        [ActionName("AjouterLivre")]
        public ActionResult AjouterLivrePost(Livre livre)
        {
            if (!ModelState.IsValid)
            {               
                string fileName = Path.GetFileNameWithoutExtension(livre.ImageFile.FileName);
                string extension = Path.GetExtension(livre.ImageFile.FileName);
                fileName = fileName + extension;
                livre.ImagePath = fileName;
                livre.CategorieId = 1;                

                foreach (ThemeCheckboxVM th in livre.ListeThemeCheckboxVM)
                {
                    if (th.EstSelectionne)
                    {
                        if(livre.Theme1 == 0)
                        livre.Theme1 = th.Id;
                        else
                        {
                            if (livre.Theme2 == 0)
                                livre.Theme2 = th.Id;
                            else
                                livre.Theme3 = th.Id;
                        }                        
                    }
                }                
                livreService.AjouterLivre(livre);
                return RedirectToAction("TousLesLivres", "Livre");
            }


            List<SelectListItem> listeItems = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Veuillez sélectionner une tranche d'âge", Value = "0" }
                };
            foreach (AgeLivre age in livreService.ObtenirTousLesAges())
            {
                SelectListItem item = new SelectListItem { Text = age.TrancheDAge, Value = age.Id.ToString() };
                listeItems.Add(item);
            }
            livre.ListeAgesLivres = new SelectList(listeItems, "Value", "Text");

            livre.ListeThemeCheckboxVM = livreService.ObtenirTousLesThemes().Select(t => new ThemeCheckboxVM { Id = t.Id, NomTheme = t.Intitule }).ToList();

            return View(livre);
        }

        public ActionResult TousLesLivres()
        {
            TousLesLivresVM tousLesLivresVM = new TousLesLivresVM();
            tousLesLivresVM.ListeLivres = livreService.ObtenirTousLesLivres();
            List<AgeLivre> listeAgesLivres = livreService.ObtenirTousLesAges();
            List<AgeLivre> nouvelleListeAges = new List<AgeLivre>();
            for(int i = 0; i < tousLesLivresVM.ListeLivres.Count; i++)
            {
                for (int j = 0; j < listeAgesLivres.Count; j++)
                {
                    if (tousLesLivresVM.ListeLivres[i].AgeLivreId == listeAgesLivres[j].Id)
                    {
                        nouvelleListeAges.Add(new AgeLivre
                        {
                            Id = listeAgesLivres[j].Id,
                            TrancheDAge = listeAgesLivres[j].TrancheDAge,
                            Description = listeAgesLivres[j].Description
                        });
                    }
                }
            }
            tousLesLivresVM.ListeAges = nouvelleListeAges;
            List<Theme> listeThemes1 = new List<Theme>();
            List<Theme> listeThemes2 = new List<Theme>();
            List<Theme> listeThemes3 = new List<Theme>();
            foreach (Livre livre in livreService.ObtenirTousLesLivres())
            {
                foreach (Theme theme in livreService.ObtenirTousLesThemes())
                {
                    if (livre.Theme1 == 0) listeThemes1.Add(null);
                    else
                    {
                        if (livre.Theme1 == theme.Id) listeThemes1.Add(new Theme { Id = theme.Id, Intitule = theme.Intitule });
                    }
                    if (livre.Theme2 == 0) listeThemes2.Add(null);
                    else
                    {
                        if (livre.Theme2 == theme.Id) listeThemes2.Add(new Theme { Id = theme.Id, Intitule = theme.Intitule });
                    }
                    if (livre.Theme3 == 0) listeThemes3.Add(null);
                    else
                    {
                        if (livre.Theme3 == theme.Id) listeThemes3.Add(new Theme { Id = theme.Id, Intitule = theme.Intitule });
                    }
                }
            }           
            tousLesLivresVM.ListeThemes1 = listeThemes1;
            tousLesLivresVM.ListeThemes2 = listeThemes2;
            tousLesLivresVM.ListeThemes3 = listeThemes3;
            return View(tousLesLivresVM);
        }

        public ActionResult FicheLivre(int? id)
        {
            if (id.HasValue)
            {
                FicheLivreVM ficheLivreVM = new FicheLivreVM();
                Livre livre = livreService.ObtenirTousLesLivres().FirstOrDefault(l => l.Id == id.Value);
              
                AgeLivre ageLivre = livreService.ObtenirTousLesAges().FirstOrDefault(a => a.Id == livre.AgeLivreId);
                if (livre == null)
                    return View("Error");
                if (ageLivre == null)
                {
                    return RedirectToAction("TousLesJouets", "Jouet");                        
                }
                ficheLivreVM.ListeThemes = new List<Theme>();
                ficheLivreVM.ListeThemes.Add(livreService.ObtenirTousLesThemes().FirstOrDefault(t => t.Id == livre.Theme1));
                ficheLivreVM.ListeThemes.Add(livreService.ObtenirTousLesThemes().FirstOrDefault(t => t.Id == livre.Theme2));
                ficheLivreVM.ListeThemes.Add(livreService.ObtenirTousLesThemes().FirstOrDefault(t => t.Id == livre.Theme3));
                
                ficheLivreVM.Livre = livre;
                ficheLivreVM.AgeLivre = ageLivre;
                return View(ficheLivreVM);
            }
            else
                return HttpNotFound();
        }

        public ActionResult MettreAJourLivre(int? id)
        {
            if (id.HasValue)
            {
                FicheLivreVM ficheLivreVM = new FicheLivreVM();
                Livre livre = livreService.ObtenirTousLesLivres().FirstOrDefault(l => l.Id == id.Value);

                AgeLivre ageLivre = livreService.ObtenirTousLesAges().FirstOrDefault(a => a.Id == livre.AgeLivreId);
                if (livre == null)
                    return View("Error");
                if (ageLivre == null)
                {
                    return RedirectToAction("TousLesJouets", "Jouet");
                }
                List<SelectListItem> listeItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "Veuillez sélectionner une tranche d'âge", Value = null }
            };
                foreach (AgeLivre age in livreService.ObtenirTousLesAges())
                {
                    SelectListItem item = new SelectListItem { Text = age.TrancheDAge, Value = age.Id.ToString() };
                    listeItems.Add(item);
                }
                livre.ListeAgesLivres = new SelectList(listeItems, "Value", "Text");

                livre.ListeThemeCheckboxVM = livreService.ObtenirTousLesThemes().Select(t => new ThemeCheckboxVM { Id = t.Id, NomTheme = t.Intitule }).ToList();

                ficheLivreVM.Livre = livre;
                ficheLivreVM.AgeLivre = ageLivre;
                return View(ficheLivreVM);
            }
            else
                return HttpNotFound();
        }

        public ActionResult EffacerLivre(int? id)
        {
            if (id.HasValue)
            {
                livreService.EffacerLivre(id.Value);
                return RedirectToAction("TousLesLivres", "Livre");
            }
            else return HttpNotFound();
        }
    }
}