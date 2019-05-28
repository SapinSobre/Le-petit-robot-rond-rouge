using Ogre.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ogre.Models
{
    public class CRUDUser : ICRUDUser
    {
        private Connexion connex = new Connexion(SessionUtil.ConnectionString);

        public List<User> ObtenirTousLesUtilisateurs()
        {            
            List<User> liste = new List<User>();
            Command cmd = new Command("SELECT * FROM [User];");
            DataSet ds = connex.GetDataSet(cmd);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                liste.Add( new User
                {
                    Id = (int)dr["Id"],
                    Login = (string)dr["Login"],
                    Pwd = (string)dr["Pwd"]
                });
            }
            return liste;
        }

        public User ObtenirUnUtilisateur(int idUser)
        {
            return ObtenirTousLesUtilisateurs().FirstOrDefault(u => u.Id == idUser);       
        }

        public User Authentifier(string login, string pwd)
        {
            return ObtenirTousLesUtilisateurs().FirstOrDefault(u => u.Login == login && u.Pwd == pwd);
        }

        public int AjouterUtilisateur(User user)
        {
            Command cmd = new Command("INSERT INTO [User](Login, Pwd) VALUES (@Login, @Pwd);");
            cmd.AddParameter("@Login", user.Login);
            cmd.AddParameter("@Pwd", user.Pwd);
            int idUser = connex.ExecuteNonQuery(cmd);
            return idUser;

        }

        public void Dispose()
        {

        }
    }
}