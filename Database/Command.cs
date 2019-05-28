using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogre.Database
{
    public class Command
    {
        private string _Query;
        private Dictionary<string, object> _Parameters;

        public string Query
        {
            get { return _Query; }
            private set { _Query = value; }
        }

        public Dictionary<string, object> Parameters
        {
            get { return _Parameters; }
        }

        public Command(string query)
        {
            Query = query;
            _Parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, value);
        }
    }
}