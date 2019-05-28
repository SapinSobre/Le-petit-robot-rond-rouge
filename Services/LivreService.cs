using Ogre.Database;
using Ogre.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ogre.Services
{
    public class LivreService
    {
        private Connexion connex = new Connexion(SessionUtil.ConnectionString);      

        public List<Livre> ObtenirTousLesLivres()
        {
            Command cmd = new Command("SELECT * FROM [Produit] WHERE CategorieId = 1;");
            List<Livre> listeLivres = new List<Livre>();
            DataSet ds = connex.GetDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listeLivres.Add(new Livre
                    {
                        Id = (int)dr["Id"],
                        Libelle = (string)dr["Libelle"],
                        Fabricant = (string)dr["Fabricant"],
                        Description = (string)dr["Description"],
                        DateReception = Convert.ToDateTime(dr["DateReception"]),
                        CategorieId = (int)dr["CategorieId"],
                        Prix = (float)dr["Prix"],
                        ImagePath = (string)dr["ImagePath"],
                        Auteur = (dr["Auteur"] == DBNull.Value) ? "" : (string)dr["Auteur"],
                        Illustrateur = (dr["Illustrateur"] == DBNull.Value) ? "" : (string)dr["Illustrateur"],
                        Scenariste = (dr["Scenariste"] == DBNull.Value)?"":(string)dr["Scenariste"],
                        AgeLivreId = (int)dr["AgeLivreId"],
                        Theme1 = (int)dr["Theme1"],
                        Theme2 = (int)dr["Theme2"],
                        Theme3 = (int)dr["Theme3"]
                    });
                }
            }
            return listeLivres;
        }

        public Livre ObtenirUnLivre(int? idLivre)
        {
            Livre livre = new Livre();
            List<Livre> listeLivres = ObtenirTousLesLivres();
            if (idLivre.HasValue)
            {
                foreach (Livre li in listeLivres)
                {
                    if (li.Id == idLivre.Value)
                    {
                        livre = li;
                        return livre;
                    }
                }
            }            
            return null;            
        }        

        public int AjouterLivre(Livre livre)
        {
            Command command = new Command("INSERT INTO [Produit](Libelle, Fabricant, Description, CategorieId, Prix, DateReception, ImagePath, Auteur, Illustrateur, Scenariste, AgeLivreId, Theme1, Theme2, Theme3) " +
                "VALUES(@Libelle, @Fabricant, @Description, @CategorieId, @Prix, @DateReception, @ImagePath, @Auteur, @Illustrateur, @Scenariste, @AgeLivreId, @Theme1, @Theme2, @Theme3);");
            command.AddParameter("@Libelle", livre.Libelle);
            command.AddParameter("@Fabricant", livre.Fabricant);
            command.AddParameter("@Description", livre.Description);
            command.AddParameter("@CategorieId", livre.CategorieId);
            command.AddParameter("@Prix", livre.Prix);
            command.AddParameter("@DateReception", DateTime.Now);
            command.AddParameter("@ImagePath", livre.ImagePath);
            command.AddParameter("@Auteur", livre.Auteur);
            command.AddParameter("@Illustrateur", livre.Illustrateur);
            command.AddParameter("@Scenariste", livre.Scenariste);
            command.AddParameter("@AgeLivreId", livre.AgeLivreId);
            command.AddParameter("@Theme1", livre.Theme1);
            command.AddParameter("@Theme2", livre.Theme2);
            command.AddParameter("@Theme3", livre.Theme3);
           
            int livreId = connex.ExecuteNonQuery(command);
            return livreId;
        }

        public List<AgeLivre> ObtenirTousLesAges()
        {
            Command cmd = new Command("SELECT * FROM [AgeLivre];");
            List<AgeLivre> listeAges = new List<AgeLivre>();
            DataSet ds = connex.GetDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listeAges.Add(new AgeLivre
                    {
                        Id = (int)dr["Id"],
                        TrancheDAge = (string)dr["TrancheDAge"],
                        Description = (dr["Description"] == DBNull.Value) ? "" : (string)dr["Description"]
                    });
                }
            }
            return listeAges;
        }

        public List<Theme> ObtenirTousLesThemes()
        {
            Command cmd = new Command("SELECT * FROM [Theme]");
            List<Theme> listeThemes = new List<Theme>();
            DataSet ds = connex.GetDataSet(cmd);
            if(ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listeThemes.Add(new Theme
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Intitule = (string)dr["Intitule"]
                    });
                }
            }
            return listeThemes;
        }

        public int MettreAJourLivre(int? idLivre)
        {
            if (idLivre.HasValue)
            {
                Livre livre = ObtenirTousLesLivres().FirstOrDefault(l => l.Id == idLivre.Value);
                Command cmd = new Command(@"UPDATE [Produit] SET " +
                        "Id=@Id, " +
                        "Libelle = @Libelle, " +
                        "Auteur = @Auteur, " +
                        "Scenariste = @Scenariste, " +
                        "Ilustrateur = @Illustrateur, " +
                        "Description = @Description, " +
                        "Fabricant = @Fabricant, " +
                        "DateReception = @DateReception, " +
                        "Prix = @Prix, " +
                        "CategorieId = @CategorieId, " +
                        "AgeLivreId = @AgeLivreId, " +
                        "ImagePath = @ImagePath, " +
                        "Theme1 = @Theme1, " +
                        "Theme2 = @Theme2, " +
                        "Theme3 = @Theme3 WHERE Id = @Id;"

                        );
                cmd.AddParameter("@Id", livre.Id);
                cmd.AddParameter("@Libelle", livre.Libelle);
                cmd.AddParameter("@Auteur", livre.Auteur);
                cmd.AddParameter("@Scenariste", livre.Scenariste);
                cmd.AddParameter("@Illustrateur", livre.Illustrateur);
                cmd.AddParameter("@Description", livre.Description);
                cmd.AddParameter("@Fabricant", livre.Fabricant);
                cmd.AddParameter("@DateReception", livre.DateReception);
                cmd.AddParameter("@Prix", livre.Prix);
                cmd.AddParameter("@CategorieId", livre.CategorieId);
                cmd.AddParameter("@AgeLivreId", livre.AgeLivreId);
                cmd.AddParameter("@ImagePath", livre.ImagePath);
                cmd.AddParameter("@Theme1", livre.Theme1);
                cmd.AddParameter("@Theme2", livre.Theme2);
                cmd.AddParameter("@Theme3", livre.Theme3);
                int idLivreMisAJour = (int)connex.ExecuteScalar(cmd);
                return idLivreMisAJour;
            }
            return 0;
        }

        public void EffacerLivre (int? Id)
        {
            if (Id.HasValue)
            {
                Command cmd = new Command(@"DELETE FROM [Produit] WHERE Id = @Id;");
                cmd.AddParameter("@Id", Id.Value);
                connex.ExecuteNonQuery(cmd);
            }           
        }
    }
}