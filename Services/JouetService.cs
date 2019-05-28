using Ogre.Database;
using Ogre.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ogre.Services
{
    public class JouetService
    {
        private Connexion connex = new Connexion(SessionUtil.ConnectionString);

        public List<Jouet> ObtenirTousLesJouets()
        {
            Command cmd = new Command("SELECT * FROM [Produit] WHERE CategorieId = 1002;");
            List<Jouet> listeJouets = new List<Jouet>();
            DataSet ds = connex.GetDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listeJouets.Add(new Jouet
                    {
                        Id = (int)dr["Id"],
                        Libelle = (string)dr["Libelle"],
                        Fabricant = (string)dr["Fabricant"],
                        Description = (string)dr["Description"],
                        DateReception = Convert.ToDateTime(dr["DateReception"]),
                        CategorieId = (int)dr["CategorieId"],
                        Prix = (float)dr["Prix"],
                        ImagePath = (string)dr["ImagePath"]                        
                    });
                }
            }
            return listeJouets;
        }

        public int AjouterJouet(Jouet jouet)
        {
            Command command = new Command("INSERT INTO [Produit](Libelle, Fabricant, Description, CategorieId, Prix, DateReception, ImagePath, AgeLivreId) " +
                "VALUES(@Libelle, @Fabricant, @Description, @CategorieId, @Prix, @DateReception, @ImagePath, @AgeLivreId);");
            command.AddParameter("@Libelle", jouet.Libelle);
            command.AddParameter("@Fabricant", jouet.Fabricant);
            command.AddParameter("@Description", jouet.Description);
            command.AddParameter("@CategorieId", jouet.CategorieId);
            command.AddParameter("@Prix", jouet.Prix);
            command.AddParameter("@DateReception", DateTime.Now);
            command.AddParameter("@ImagePath", jouet.ImagePath);
            command.AddParameter("@AgeLivreId", 0);
            
            int imageId = connex.ExecuteNonQuery(command);
            return imageId;
        }
    }
}