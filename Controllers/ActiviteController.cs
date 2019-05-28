using Ogre.Models;
using Ogre.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Controllers
{
    public class ActiviteController : Controller
    {
        private ActiviteService activiteService = new ActiviteService();
        private EmployeService employeService = new EmployeService();

        // GET: Activite
        public ActionResult ToutesLesActivites()
        {
            ToutesActivitesVM toutesActivitesVM = new ToutesActivitesVM();
            toutesActivitesVM.ListeEmployes = new List<Employe>();
            toutesActivitesVM.ListeActivites = activiteService.ObtenirToutesLesActivites();
            foreach(Activite acti in toutesActivitesVM.ListeActivites)
            {
                acti.DateDebutStr = DateTime.ParseExact(acti.DateDebut.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                acti.DateFinStr = DateTime.ParseExact(acti.DateFin.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                foreach (Employe employe in employeService.ObtenirTousLesEmployes())
                {
                    if(acti.EmployeId == 0)
                    {
                        toutesActivitesVM.ListeEmployes.Add(null);
                    }
                    if(acti.EmployeId == employe.Id)
                    {
                        toutesActivitesVM.ListeEmployes.Add(new Employe{
                            Id = employe.Id,
                            Nom = employe.Nom,
                            Prenom = employe.Prenom,
                            TarifDeLHeure = employe.TarifDeLHeure
                        });
                    }
                }
            }
            
            return View(toutesActivitesVM);
        }

        public ActionResult ToutesLesActivitesParAge(string age)
        {
            ToutesActivitesVM toutesActivitesVM = new ToutesActivitesVM();
            toutesActivitesVM.ListeEmployes = new List<Employe>();
            toutesActivitesVM.ListeActivites = activiteService.ObtenirToutesLesActivitesParAge(age);
            foreach (Activite acti in toutesActivitesVM.ListeActivites)
            {
                acti.DateDebutStr = DateTime.ParseExact(acti.DateDebut.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                acti.DateFinStr = DateTime.ParseExact(acti.DateFin.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");

                foreach (Employe employe in employeService.ObtenirTousLesEmployes())
                {
                    if (acti.EmployeId == 0)
                    {
                        toutesActivitesVM.ListeEmployes.Add(null);
                    }
                    if (acti.EmployeId == employe.Id)
                    {
                        toutesActivitesVM.ListeEmployes.Add(new Employe
                        {
                            Id = employe.Id,
                            Nom = employe.Nom,
                            Prenom = employe.Prenom,
                            TarifDeLHeure = employe.TarifDeLHeure
                        });
                    }
                }
            }
            return View(toutesActivitesVM);
        }
    }
}