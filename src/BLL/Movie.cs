using System;
using System.Collections.Generic;
using MoviesRegister.DAL;
using MoviesRegister.Base;

namespace MoviesRegister.BLL
{
    public class Movie
    {
        #region Member Variables
        private int _Id;
        private string _Original_language;
        private string _Original_title;
        private string _Popularity;
        private string _Poster_path;
        private DateTime _Release_date;
        private string _Title;
        private Decimal _Vote_average;
        private string _Overview;
        #endregion

        #region Constructors
        public Movie()
        {
        }

        public Movie(int id, string original_language, string original_title, string popularity, string poster_path, DateTime release_date, string title, Decimal vote_average, string overview)
        {
            _Id = id;
            _Original_language = original_language;
            _Original_title = original_title;
            _Popularity = popularity;
            _Poster_path = poster_path;
            _Release_date = release_date;
            _Title = title;
            _Vote_average = vote_average;
            _Overview = overview;
        }
        #endregion

        #region Public Properties
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Original_language
        {
            get { return _Original_language; }
            set { _Original_language = value; }
        }

        public string Original_title
        {
            get { return _Original_title; }
            set { _Original_title = value; }
        }

        public string Popularity
        {
            get { return _Popularity; }
            set { _Popularity = value; }
        }

        public string Poster_path
        {
            get { return _Poster_path; }
            set { _Poster_path = value; }
        }

        public DateTime Release_date
        {
            get { return _Release_date; }
            set { _Release_date = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public Decimal Vote_average
        {
            get { return _Vote_average; }
            set { _Vote_average = value; }
        }

        public string Overview
        {
            get { return _Overview; }
            set { _Overview = value; }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Apaga o Movie
        /// </summary>
        /// <returns>Retorna true caso nao ocorra nenhum erro</returns>
        public bool Delete()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return DALLayer.DeleteMovie(this.Id);
        }

        /// <summary>
        /// Insere ou atualiza o Movie
        /// </summary>
        /// <returns>Retorna true caso nao ocorra nenhum erro</returns>
        public bool Save()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            int TempId = DALLayer.CreateNewMovie(this);
            _Id = (TempId > DefaultValues.IdNullValue ? TempId : DefaultValues.IdNullValue);
            return (TempId > 0);

        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Apaga o Movie
        /// </summary>
        /// <param name="Id">Idenficador</param>
        /// <returns>Retorna true caso nao ocorra nenhum erro</returns>
        public static bool DeleteMovie(int id)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.DeleteMovie(id));
        }

        /// <summary>
        /// Busca a lista de Movie
        /// </summary>
        /// <returns>Lista de Movies</returns>
        public static SortableBindingList<Movie> GetAllMovies()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetAllMovies());
        }

        /// <summary>
        /// Retorna o objeto Movie encontrado
        /// </summary>
        /// <param name="Id">Identificador</param>
        /// <returns>Retorna o objeto encontrado</returns>
        public static Movie GetMovieById(int id)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMovieById(id));
        }
        #endregion
    }
}