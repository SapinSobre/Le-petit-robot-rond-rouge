using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ogre.Database
{
    public class Connexion
    {
        private SqlConnection _Connection { get; set; }
        
        public Connexion(string connectionString)
        {
            _Connection = new SqlConnection(connectionString);
            _Connection.Open();
            _Connection.Close();
        }

        public int ExecuteNonQuery(Command command)
        {
            _Connection.Open();
            int i = CreateCommand(command).ExecuteNonQuery();
            _Connection.Close();
            return i;
        }

        public DataSet GetDataSet(Command command)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = CreateCommand(command);
            da.Fill(ds);
            return ds;
        }

        public object ExecuteScalar(Command command)
        {
            _Connection.Open();
            object o = CreateCommand(command).ExecuteScalar();
            _Connection.Close();
            return o;
        }

        public SqlCommand CreateCommand(Command command)
        {
            SqlCommand cmd = _Connection.CreateCommand();
            cmd.CommandText = command.Query;
            foreach(KeyValuePair<string, object> kvp in command.Parameters)
            {
                cmd.Parameters.Add(new SqlParameter {
                    ParameterName = kvp.Key,
                    Value = kvp.Value ?? DBNull.Value.ToString()
                });
            }
            return cmd;
        }
    }
}