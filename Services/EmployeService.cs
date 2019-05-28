using Ogre.Database;
using Ogre.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ogre.Services
{
    public class EmployeService
    {
        private Connexion connex = new Connexion(SessionUtil.ConnectionString);

        public List<Employe> ObtenirTousLesEmployes()
        {
            List<Employe> listeEmployes = new List<Employe>();
            Command cmd = new Command("SELECT * FROM [Employe];");
            DataSet ds = connex.GetDataSet(cmd);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    listeEmployes.Add(new Employe
                    {
                        Id = (int)dr["Id"],
                        Nom = (string)dr["Nom"],
                        Prenom = (string)dr["Prenom"],
                        TarifDeLHeure = (float)dr["TarifDeLHeure"],
                        PhotoEmploye = (string)dr["PhotoEmploye"]
                    });
                }
            }
            return listeEmployes;
        }
    }   
}