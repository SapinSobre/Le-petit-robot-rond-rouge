using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Ogre.Database;
using Ogre.Models;

namespace Ogre.Services
{
    public class ActiviteService
    {
        private Connexion connex = new Connexion(SessionUtil.ConnectionString);

        public List<Activite> ObtenirToutesLesActivites()
        {
            DataSet ds = new DataSet();
            Command cmd = new Command("SELECT * FROM [Activite];");
            ds = connex.GetDataSet(cmd);
            List<Activite> listeActivites = new List<Activite>();
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    listeActivites.Add(new Activite
                    {
                        Id = (int)dr["Id"],
                        Nom = dr["Nom"].ToString(),
                        Chapeau = dr["Chapeau"].ToString(),
                        Description = dr["Description"].ToString(),
                        DateDebut = Convert.ToDateTime(dr["DateDebut"]),
                        DateFin = Convert.ToDateTime(dr["DateFin"]),
                        Age = dr["Age"].ToString(),
                        NombreParticipantsMax = (int)dr["NombreParticipantsMax"],
                        NombreParticipantsInscrits = (int)dr["NombreParticipantsInscrits"],
                        Bricolage = Convert.ToBoolean(dr["Bricolage"]),
                        Dessin = Convert.ToBoolean(dr["Dessin"]),
                        Musique = Convert.ToBoolean(dr["Musique"]),
                        Edition = Convert.ToBoolean(dr["Edition"]),
                        Lecture = Convert.ToBoolean(dr["Lecture"]),
                        Ecriture = Convert.ToBoolean(dr["Ecriture"]),
                        Programmation = Convert.ToBoolean(dr["Programmation"]),
                        Robot = Convert.ToBoolean(dr["Robot"]),
                        Scratch = Convert.ToBoolean(dr["Scratch"]),
                        Arduino = Convert.ToBoolean(dr["Arduino"]),
                        NombreSeances = (int)dr["NombreSeances"],
                        Prix = (float)dr["Prix"],
                        LivreId = (int)dr["LivreId"],
                        JouetId = (int)dr["JouetId"],
                        EmployeId = (int)dr["EmployeId"],
                        Cubetto = (bool)dr["Cubetto"]
                    });
                }
            }
            return listeActivites;
        }

        public List<Activite> ObtenirToutesLesActivitesParAge(string age)
        {
            List<Activite> listeActivites = new List<Activite>();
            DataSet ds = new DataSet();
            Command cmd = new Command("SELECT * FROM [Activite] WHERE Age = @Age;");
            cmd.AddParameter("@Age", age);
            ds = connex.GetDataSet(cmd);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    listeActivites.Add(new Activite
                    {
                        Id = (int)dr["Id"],
                        Nom = dr["Nom"].ToString(),
                        Chapeau = dr["Chapeau"].ToString(),
                        Description = dr["Description"].ToString(),
                        DateDebut = Convert.ToDateTime(dr["DateDebut"]),
                        DateFin = Convert.ToDateTime(dr["DateFin"]),
                        Age = dr["Age"].ToString(),
                        NombreParticipantsMax = (int)dr["NombreParticipantsMax"],
                        NombreParticipantsInscrits = (int)dr["NombreParticipantsInscrits"],
                        Bricolage = Convert.ToBoolean(dr["Bricolage"]),
                        Dessin = Convert.ToBoolean(dr["Dessin"]),
                        Musique = Convert.ToBoolean(dr["Musique"]),
                        Edition = Convert.ToBoolean(dr["Edition"]),
                        Lecture = Convert.ToBoolean(dr["Lecture"]),
                        Ecriture = Convert.ToBoolean(dr["Ecriture"]),
                        Programmation = Convert.ToBoolean(dr["Programmation"]),
                        Robot = Convert.ToBoolean(dr["Robot"]),
                        Scratch = Convert.ToBoolean(dr["Scratch"]),
                        Arduino = Convert.ToBoolean(dr["Arduino"]),
                        NombreSeances = (int)dr["NombreSeances"],
                        Prix = (float)dr["Prix"],
                        LivreId = (int)dr["LivreId"],
                        JouetId = (int)dr["JouetId"],
                        EmployeId = (int)dr["EmployeId"],
                        Cubetto = (bool)dr["Cubetto"]
                    });
                }
            }
            return listeActivites;
        }
    }
}