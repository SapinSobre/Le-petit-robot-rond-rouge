using Ogre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ogre.Controllers
{
    public class LoginController : Controller
    {
        private CRUDUser crud = new CRUDUser();
        // GET: Login
        public ActionResult Connexion()
        {
            FormAuth form = new FormAuth { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                form.Utilisateur = crud.ObtenirUnUtilisateur(Convert.ToInt32(HttpContext.User.Identity.Name));
            }
            else
            {
                form.Utilisateur = new User();
            }
            return View(form);
        }

        [HttpPost]
        [ActionName("Connexion")]
        public ActionResult ConnexionPost(FormAuth form)
        {
            if (ModelState.IsValid)
            {
                User user = crud.Authentifier(form.Utilisateur.Login, form.Utilisateur.Pwd);
                if(user != null)
                {
                    HttpContext.Session["Login"] = user.Login;
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                return View(form);
            }
            return View(form);
        }

        public ActionResult CreerCompte()
        {
            FormAuth form = new FormAuth { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                form.Utilisateur = crud.ObtenirUnUtilisateur(Convert.ToInt32(HttpContext.User.Identity.Name));
            }
            else
            {
                form.Utilisateur = new User();
            }
            return View(form);
        }

        [HttpPost]
        [ActionName("CreerCompte")]
        public ActionResult CreerComptePost(FormAuth form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                int idUser = crud.AjouterUtilisateur(form.Utilisateur);
                
                if(idUser > -1)
                {
                    Session["Login"] = form.Utilisateur.Login;
                    FormsAuthentication.SetAuthCookie(form.Utilisateur.Id.ToString(), false);
                    return Redirect("/");
                }
            }
            return View(form);
        }

        public ActionResult Deconnexion()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}