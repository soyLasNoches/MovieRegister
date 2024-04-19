using MoviesRegister.Base;
using MoviesRegister.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRegister.DAL
{
    public abstract class DataAccess
    {
        const string PROVIDER = "Firebird";
        //const string PROVIDER = "SQLServer";
        //const string PROVIDER = "connectionString";

        #region ConnectionString
        /// <summary>
        /// String de conexao
        /// </summary>
        /// <return>
        /// String de conex?o com o banco de dados
        /// </return>
        protected string ConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings[PROVIDER] == null)
                    throw (new NullReferenceException("ConnectionString configuration is missing from you <appname>.exe.config."));

                string connectionString = ConfigurationManager.ConnectionStrings[PROVIDER].ConnectionString;
                if (connectionString.IndexOf("%exedir%") > -1)
                    connectionString = connectionString.Replace("%exedir%", System.Windows.Forms.Application.StartupPath);

                if (String.IsNullOrEmpty(connectionString))
                    throw (new NullReferenceException("ConnectionString configuration is missing from you <appname>.exe.config."));
                else
                    return (connectionString);
            }
        }
        #endregion

        #region General
        public abstract bool CheckDBConnection(ref string errorMsg);
        public abstract string GetConnectionString();
        public abstract void ResetFilterRead();
        public abstract bool SetSQLCommandLog(bool active);
        #endregion

        #region Movie
        public abstract int CreateNewMovie(Movie newMovie);
        public abstract bool UpdateMovie(Movie MovieToUpdate);
        public abstract bool DeleteMovie(int Id);
        public abstract SortableBindingList<Movie> GetAllMovies();
        public abstract Movie GetMovieById(int Id);
        #endregion
    }
}
