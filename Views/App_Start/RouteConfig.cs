using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ogre
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MettreAJourFrais",
                url: "Gestion/MettreAJourFrais/{id}",
                defaults: new { controller = "Gestion", action = "MettreAJourFrais", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SupprimerFrais",
                url: "Gestion/SupprimerFrais/{id}",
                defaults: new { controller = "Gestion", action = "SupprimerFrais", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MettreAJourLivre",
                url: "Livre/MettreAJourLivre/{id}",
                defaults: new { controller = "Livre", action = "MettreAJourLivre", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EffacerLivre",
                url: "Livre/EffacerLivre/{id}",
                defaults: new { controller = "Livre", action = "EffacerLivre", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TousLesLivresParNom",
                url: "Recherche/TousLesLivresParNom/{nomLivre}",
                defaults: new { controller = "Recherche", action = "TousLesLivresParNom", nomLivre = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TousLesLivresParTheme",
                url: "Recherche/TousLesLivresParTheme/{themeId}",
                defaults: new { controller = "Recherche", action = "TousLesLivresParTheme", themeId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TousLesLivresParAge",
                url: "Recherche/TousLesLivresParAge/{trancheAgeLivreId}",
                defaults: new { controller = "Recherche", action = "TousLesLivresPourUnAge", trancheAgeLivreId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RechercheLivreParTheme",
                url: "Recherche/RechercheLivreParTheme/{id}",
                defaults: new { controller = "Recherche", action = "RechercheLivreParTheme", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RechercheLivreParAge",
                url: "Recherche/RechercheLivreParAge/{id}",
                defaults: new { controller = "Recherche", action = "RechercheLivreParAge", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RechercheLivreParNom",
                url: "Recherche/RechercheLivreParNom/{id}",
                defaults: new { controller = "Recherche", action = "RechercheLivreParNom", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FicheLivre",
                url: "Livre/FicheLivre/{id}",
                defaults: new { controller = "Livre", action = "FicheLivre", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
