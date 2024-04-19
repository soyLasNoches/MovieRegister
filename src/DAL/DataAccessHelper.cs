using MoviesRegister.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRegister.DAL
{
    public class DataAccessHelper
    {
        private static Dictionary<string, DataAccess> _uniqueDAL = new Dictionary<string, DataAccess>();

        public static string GetDataAccessStringType()
        {
            return ConfigurationManager.AppSettings["MoviesRegister_DataAccessLayerType"];
        }

        public static string GetDataAccessLogDestination()
        {
            return ConfigurationManager.AppSettings["LogDestination"];
        }

        public static DataAccess CreateDataAccess(Type selectedType, string logDestination)
        {

            DataAccess DALObject = null;
            if (_uniqueDAL.ContainsKey(selectedType.FullName))
            {
                DALObject = _uniqueDAL[selectedType.FullName];
            }
            else
            {
                Type tp = Type.GetType("MoviesRegister.DAL.DataAccess");

                if (!tp.IsAssignableFrom(selectedType))
                    throw (new ArgumentException("DataAccessType does not inherits from MoviesRegister.DAL.DataAccess."));

                DALObject = (DataAccess)Activator.CreateInstance(selectedType);
                DALObject.SetSQLCommandLog(Array.IndexOf(logDestination.Split(','), 5) > -1);

                _uniqueDAL[selectedType.FullName] = DALObject;
            }

            return DALObject;
        }

        public static DataAccess CreateDataAccess(string selectedType, string logDestination)
        {
            if (String.IsNullOrEmpty(selectedType))
            {
                throw (new NullReferenceException("DataAccessLayerType configuration is missing from you app.config."));
            }
            else
            {
                return CreateDataAccess(Type.GetType(selectedType), logDestination);
            }
        }

        public static DataAccess GetDataAccess()
        {
            return CreateDataAccess(GetDataAccessStringType(), GetDataAccessLogDestination());
        }
    }
}
