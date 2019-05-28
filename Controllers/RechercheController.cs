using Ogre.Models;
using Ogre.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ogre.Controllers
{
    public class RechercheController : Controller
    {
        private LivreService livreService = new LivreService();

        [HttpGet]
        public ActionResult RechercheLivreParAge()
        {
            RechercheLivreVM rechercheLivreVM = new RechercheLivreVM();
            List<SelectListItem> listeSelectListItems = new List<SelectListItem>();
            listeSelectListItems.Add(new SelectListItem { Text = "Veuillez sélectionner un âge", Value = "0" });
            foreach(AgeLivre ageLivre in livreService.ObtenirTousLesAges())
            {
                listeSelectListItems.Add(new SelectListItem
                {
                    Text = ageLivre.TrancheDAge + " ans",
                    Value = ageLivre.Id.ToString()
                });
            }           
            rechercheLivreVM.ListeAgesLivres = new SelectList( listeSelectListItems, "Value", "Text");
            return View(rechercheLivreVM);
        }

        [HttpPost]
        [ActionName("RechercheLivreParAge")]
        public ActionResult RechercheLivreParAgePost(RechercheLivreVM rechercheLivre)
        {
            if (ModelState.IsValid)
            {
                List<Livre> listeLivre = livreService.ObtenirTousLesLivres().FindAll(l => l.AgeLivreId == rechercheLivre.AgeLivreId);
                if (listeLivre.Count == 0)
                {
                    return RedirectToAction("TousLesLivres", "Livre");
                }
                return RedirectToAction("TousLesLivresPourUnAge", new { trancheAgeLivreId = rechercheLivre.AgeLivreId });
            }
            else            
                return View(rechercheLivre);                
        }

        public ActionResult TousLesLivresPourUnAge(int? trancheAgeLivreId)
        {
            TousLesLivresVM tousLesLivresVM = new TousLesLivresVM();           
            if (trancheAgeLivreId.HasValue)
            {
                List<Livre> listeLivres = livreService.ObtenirTousLesLivres().FindAll(l => l.AgeLivreId == trancheAgeLivreId.Value);
                if (listeLivres == null)
                    return View("Error");
                tousLesLivresVM.ListeLivres = listeLivres;
                AgeLivre ageLivre = livreService.ObtenirTousLesAges().FirstOrDefault(a => a.Id == trancheAgeLivreId);
                if (ageLivre == null)
                    return View("Error");
                tousLesLivresVM.ListeAges = new List<AgeLivre>();
                for(int i = 0; i < tousLesLivresVM.ListeLivres.Count; i++)
                {
                    tousLesLivresVM.ListeAges.Add(ageLivre);
                }                
                List<Theme> listeThemes1 = new List<Theme>();
                List<Theme> listeThemes2 = new List<Theme>();
                List<Theme> listeThemes3 = new List<Theme>();
                foreach (Livre livre in tousLesLivresVM.ListeLivres)
                {
                    foreach (Theme theme in livreService.ObtenirTousLesThemes())
                    {
                        if (livre.Theme1 == 0) listeThemes1.Add(null);
                        else
                        {
                            if (livre.Theme1 == theme.Id) listeThemes1.Add(theme);
                        }
                        if (livre.Theme2 == 0) listeThemes2.Add(null);
                        else
                        {
                            if (livre.Theme2 == theme.Id) listeThemes2.Add(theme);
                        }
                        if (livre.Theme3 == 0) listeThemes3.Add(null);
                        else
                        {
                            if (livre.Theme3 == theme.Id) listeThemes3.Add(theme);
                        }
                    }
                }
                tousLesLivresVM.ListeThemes1 = listeThemes1;
                tousLesLivresVM.ListeThemes2 = listeThemes2;
                tousLesLivresVM.ListeThemes3 = listeThemes3;
                return View(tousLesLivresVM);
            }
            else
                return HttpNotFound();
        }     
        
        
        public ActionResult RechercheLivreParTheme()
        {
            RechercheLivreParThemeVM rechercheLivreParThemeVM = new RechercheLivreParThemeVM();
            List<SelectListItem> listeSelect = new List<SelectListItem>();
            listeSelect.Add(new SelectListItem { Text = "Veuillez sélectionner un thème", Value = "0" });
            foreach (Theme theme in livreService.ObtenirTousLesThemes())
            {
                listeSelect.Add(new SelectListItem { Text = theme.Intitule, Value = theme.Id.ToString()});
            }
            rechercheLivreParThemeVM.ListeThemesLivres = new SelectList(listeSelect, "Value", "Text");
            return View(rechercheLivreParThemeVM);
        }

        [HttpPost]
        [ActionName("RechercheLivreParTheme")]
        public ActionResult RechercheLivreParThemePost(RechercheLivreParThemeVM rechercheLivreParThemeVM)
        {
            if (ModelState.IsValid){                
                List<Livre> listeLivre = livreService.ObtenirTousLesLivres().FindAll(l => l.Theme1 == rechercheLivreParThemeVM.ThemeLivreId || l.Theme2 == rechercheLivreParThemeVM.ThemeLivreId || l.Theme3 == rechercheLivreParThemeVM.ThemeLivreId);
                if (listeLivre.Count == 0)
                {
                    return RedirectToAction("TousLesLivres", "Livre");
                }
                return RedirectToAction("TousLesLivresParTheme", new { themeId = rechercheLivreParThemeVM.ThemeLivreId });
            }
            List<SelectListItem> listeSelect = new List<SelectListItem>();
            listeSelect.Add(new SelectListItem { Text = "Veuillez sélectionner un thème", Value = "0" });
            foreach (Theme theme in livreService.ObtenirTousLesThemes())
            {
                listeSelect.Add(new SelectListItem { Text = theme.Intitule, Value = theme.Id.ToString() });
            }
            rechercheLivreParThemeVM.ListeThemesLivres = new SelectList(listeSelect, "Value", "Text");
            return View(rechercheLivreParThemeVM);
        }

        public ActionResult TousLesLivresParTheme(int? themeId)
        {
            TousLesLivresVM tousLesLivresVM = new TousLesLivresVM();
            if (themeId.HasValue)
            {
                ViewBag.titre = livreService.ObtenirTousLesThemes().FirstOrDefault(t => t.Id == themeId.Value).Intitule;
                List<Livre> listeLivres = livreService.ObtenirTousLesLivres().FindAll(l => l.Theme1 == themeId.Value || l.Theme2 == themeId.Value || l.Theme3 == themeId.Value);
                if (listeLivres == null)
                    return View("Error");
                List<Theme> listeThemes1 = new List<Theme>();
                List<Theme> listeThemes2 = new List<Theme>();
                List<Theme> listeThemes3 = new List<Theme>();
                List<AgeLivre> listeAges = new List<AgeLivre>();
                
                foreach (Livre li in listeLivres)
                {
                    foreach(Theme th in livreService.ObtenirTousLesThemes())
                    {
                        if (li.Theme1 == 0) listeThemes1.Add(null);
                        else
                        {
                            if(li.Theme1 == th.Id) listeThemes1.Add(th);
                        }
                        if (li.Theme2 == 0) listeThemes2.Add(null);
                        else
                        {
                            if (li.Theme2 == th.Id) listeThemes2.Add(th);
                        }
                        if (li.Theme3 == 0) listeThemes3.Add(null);
                        else
                        {
                            if (li.Theme3 == th.Id) listeThemes3.Add(th);
                        }
                    }
                    foreach(AgeLivre agl in livreService.ObtenirTousLesAges())
                    {
                        if(agl.Id == li.AgeLivreId)
                        {
                            listeAges.Add(agl);
                        }
                    }
                }
                tousLesLivresVM.ListeLivres = listeLivres;
                tousLesLivresVM.ListeAges = listeAges;
                tousLesLivresVM.ListeThemes1 = listeThemes1;
                tousLesLivresVM.ListeThemes2 = listeThemes2;
                tousLesLivresVM.ListeThemes3 = listeThemes3;
                return View(tousLesLivresVM);
            }
            else
                return HttpNotFound();
        }

        public ActionResult TousLesLivresPourForm()
        {
            TousLesLivresVM tousLesLivresVM = new TousLesLivresVM();
            tousLesLivresVM.ListeLivres = livreService.ObtenirTousLesLivres();
            List<AgeLivre> listeAgesLivres = livreService.ObtenirTousLesAges();
            List<AgeLivre> nouvelleListeAges = new List<AgeLivre>();
            for (int i = 0; i < tousLesLivresVM.ListeLivres.Count; i++)
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

        [HttpGet]
        public ActionResult RechercheLivreParNom()
        {
            RechercheLivreParNomVM rechercheLivreParNom = new RechercheLivreParNomVM();
            return View(rechercheLivreParNom);
        }

        [HttpPost]
        [ActionName("RechercheLivreParNom")]
        public ActionResult RechercheLivreParNomPost(RechercheLivreParNomVM rechercheLivreParNomVM)
        {
            if (ModelState.IsValid)
            {
                 return RedirectToAction("TousLesLivresParNom", new { nomLivre = rechercheLivreParNomVM.Recherche });
            }
            return View(rechercheLivreParNomVM);
        }

        public ActionResult TousLesLivresParNom (string nomLivre)
        {
            TousLesLivresVM tousLesLivresVM = new TousLesLivresVM();
            List<Livre> listeLivres = new List<Livre>();
            
            listeLivres = livreService.ObtenirTousLesLivres().FindAll(l => l.Libelle == nomLivre
                || l.Auteur == nomLivre || l.Scenariste == nomLivre || l.Illustrateur == nomLivre);
            
            if (listeLivres == null)
                    return View("Error");
            tousLesLivresVM.ListeLivres = listeLivres;
            
            tousLesLivresVM.ListeAges = new List<AgeLivre>();
            foreach (Livre livre in tousLesLivresVM.ListeLivres)
            {
                foreach(AgeLivre age in livreService.ObtenirTousLesAges()) {
                    if(livre.AgeLivreId == age.Id)
                    {
                        tousLesLivresVM.ListeAges.Add(age);
                    }
                }
            }
            List<Theme> listeThemes1 = new List<Theme>();
            List<Theme> listeThemes2 = new List<Theme>();
            List<Theme> listeThemes3 = new List<Theme>();
            foreach (Livre livre in tousLesLivresVM.ListeLivres)
            {
                foreach (Theme theme in livreService.ObtenirTousLesThemes())
                {
                    if (livre.Theme1 == 0) listeThemes1.Add(null);
                    else{
                        if (livre.Theme1 == theme.Id) listeThemes1.Add(theme);
                    }
                    if (livre.Theme2 == 0) listeThemes2.Add(null);
                    else{
                        if (livre.Theme2 == theme.Id) listeThemes2.Add(theme);
                    }
                    if (livre.Theme3 == 0) listeThemes3.Add(null);
                    else{
                        if (livre.Theme3 == theme.Id) listeThemes3.Add(theme);
                    }
                }
            }
            tousLesLivresVM.ListeThemes1 = listeThemes1;
            tousLesLivresVM.ListeThemes2 = listeThemes2;
            tousLesLivresVM.ListeThemes3 = listeThemes3;
                return View(tousLesLivresVM);           
        }
    }
}