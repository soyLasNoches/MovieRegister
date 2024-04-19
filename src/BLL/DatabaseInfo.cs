using MoviesRegister.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRegister.BLL
{
    public class DatabaseInfo
    {
        public static bool CheckDBConnection(ref string errorMsg)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return DALLayer.CheckDBConnection(ref errorMsg);
        }
    }
}
