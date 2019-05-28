using Ogre.Database;
using Ogre.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ogre.Services
{
    public class FraisService
    {
        private Connexion connex = new Connexion(SessionUtil.ConnectionString);

        public List<Frais> ObtenirTousLesFrais()
        {
            List<Frais> listeFrais = new List<Frais>();
            Command cmd = new Command("SELECT * FROM [Frais];");
            DataSet ds = connex.GetDataSet(cmd);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    listeFrais.Add(new Frais
                    {
                        Id = (int)dr["Id"],
                        IntitulePoste = (string)dr["IntitulePoste"],
                        Montant = (float)dr["Montant"]
                    });
                }
            }
            return listeFrais;
        }

        public int AjouterFrais(string intitulePoste, float montant)
        {
            Command cmd = new Command("INSERT INTO [Frais](IntitulePoste, Montant) VALUES(@IntitulePoste, @Montant);");
            cmd.AddParameter("@IntitulePoste", intitulePoste);
            cmd.AddParameter("@Montant", montant);
            int fraisId = connex.ExecuteNonQuery(cmd);
            return fraisId;
        }

        public void SupprimerFrais(int id)
        {
            Command cmd = new Command("DELETE FROM [Frais] WHERE Id=@Id;");
            cmd.AddParameter("@Id", id);
            connex.ExecuteNonQuery(cmd);
        }

        public Frais ObtenirUnFrais(int id)
        {
            Command cmd = new Command("SELECT * FROM [Frais] WHERE Id=@Id;");
            Frais frais = new Frais();
            cmd.AddParameter("@Id", id);
            DataSet ds = connex.GetDataSet(cmd);
            if(ds.Tables[0].Rows.Count > 0)
            {
                frais.Id = (int)ds.Tables[0].Rows[0]["Id"];
                frais.IntitulePoste = (string)ds.Tables[0].Rows[0]["IntitulePoste"];
                frais.Montant = (float)ds.Tables[0].Rows[0]["Montant"];
            }
            return frais;
        }

        public int MettreAJourFrais(int id)
        {
            Frais frais = ObtenirUnFrais(id);
            Command cmd = new Command("UPDATE [Frais] SET IntitulePoste=@IntitulePoste, Montant=@Montant WHERE Id=@Id;");
            cmd.AddParameter("@Id", frais.Id);
            cmd.AddParameter("@IntitulePoste", frais.IntitulePoste);
            cmd.AddParameter("@Montant", frais.Montant);
            int nbLignesCorrigees = connex.ExecuteNonQuery(cmd);
            return nbLignesCorrigees;
        }
    }
}