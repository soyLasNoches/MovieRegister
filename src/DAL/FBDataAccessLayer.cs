using FirebirdSql.Data.FirebirdClient;
using MoviesRegister.Base;
using MoviesRegister.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoviesRegister.DAL
{
    public class FBDataAccessLayer : DataAccess
    {
        /// <summary>
        /// Converte o resultado da consulta para uma lista
        /// </summary>
        protected delegate void TGenerateListFromReader<T>(FbDataReader returnData, ref SortableBindingList<T> tempList);
        private static FBDataCacheController DataCacheController = new FBDataCacheController();
        private static int _FilterReadInit = -1;
        private static int _FilterReadEnd = -1;

        private static string _CustomCacheFncNames = "";
        private static bool _CheckedCacheFnc = false;
        private static StringBuilder _CheckedCacheFncNames = new StringBuilder();

        private static bool _SQLCommandsLog = false;
        private static List<string> _LastSQLCommands = new List<string>();


        #region General
        public override bool CheckDBConnection(ref string errorMsg)
        {
            bool connected = false;
            FbConnection connection = new FbConnection();

            try
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();
                connected = (connection.State == ConnectionState.Open);
            }
            catch (Exception e)
            {
                errorMsg = String.Format(
                    "Ocorreu um erro ao tentar conectar ao banco de dados MovieRegister.\n" +
                    "Erro: {0}", e.Message);
            }
            finally
            {
                if (connected)
                    connection.Close();
            }
            return connected;
        }

        public override bool SetSQLCommandLog(bool active)
        {
            _SQLCommandsLog = active;
            return _SQLCommandsLog;
        }


        public override string GetConnectionString()
        {
            List<string[]> conData = new List<string[]>();
            foreach (string cmd in this.ConnectionString.Split(';'))
                conData.Add(cmd.Split('='));

            string dataSource = "";
            string dataFile = "";
            foreach (string[] cmds in conData)
            {
                if (cmds[0] == "data source")
                    dataSource = cmds[1];

                if (cmds[0] == "initial catalog")
                    dataFile = cmds[1];
            }

            return String.Format("{0}:{1}", dataSource, dataFile);
        }


        public bool IsCachedMethod(string methodName)
        {
            if (_CheckedCacheFnc)
                _CheckedCacheFncNames.Append(methodName + ";");

            // IndicadorPessoal
            if (methodName == "GetIndicadorPessoalByProprietarioId")
                return true;

            if (methodName == "GetIndicadorPessoalByImovelId")
                return true;

            if (methodName == "GetIndicadorPessoalByMovimentacaoImovelId")
                return true;

            if (methodName == "GetIndicadorPessoalByFiltro")
                return true;

            // IndicadorReal
            if (methodName == "GetIndicadorRealByImovelId")
                return true;

            if (methodName == "GetIndicadorRealByFiltro")
                return true;

            if (_CustomCacheFncNames.IndexOf(methodName + ";") > -1)
                return true;

            return false;
        }

        public override void ResetFilterRead()
        {
            _FilterReadInit = -1;
            _FilterReadEnd = -1;
        }

        public byte[] BytesToASCII(byte[] buffer)
        {
            //for (int i = 0; i < buffer.Length; i++)
            //    if (buffer[i] == 199)
            //        buffer[i] = 231;

            byte[] newbuffer = new byte[buffer.Length / 2];
            for (int i = 0; i < newbuffer.Length; i++)
            {
                newbuffer[i] = buffer[i * 2];
            }

            return newbuffer;
        }
        #endregion

        #region Movie
        private const string SP_MOVIE_CREATE = "INSERT INTO Movie (Id, Original_language, Original_title, Popularity, Poster_path, Release_date, Title, Vote_average, Overview) VALUES (@Id, @Original_language, @Original_title, @Popularity, @Poster_path, @Release_date, @Title, @Vote_average, @Overview)";
        private const string SP_MOVIE_DELETE = "DELETE FROM Movie WHERE (Id=@Id)";
        private const string SP_MOVIE_GETALL = "SELECT Id, Original_language, Original_title, Popularity, Poster_path, Release_date, Title, Vote_average, Overview FROM Movie";
        private const string SP_MOVIE_GETBYID = "SELECT Id, Original_language, Original_title, Popularity, Poster_path, Release_date, Title, Vote_average, Overview FROM Movie WHERE (Id=@Id)";
        private const string SP_MOVIE_UPDATE = "UPDATE Movie SET Id=@Id, Original_language=@Original_language, Original_title=@Original_title, Popularity=@Popularity, Poster_path=@Poster_path, Release_date=@Release_date, Title=@Title, Vote_average=@Vote_average, Overview=@Overview WHERE (Id=@Id)";

        public override int CreateNewMovie(Movie newMovie)
        {
            if (newMovie == null)
                throw (new ArgumentNullException("newMovie"));

            FbCommand fbCmd = new FbCommand();
            AddParamToFBCmd(fbCmd, "@Id", FbDbType.Integer, 4, ParameterDirection.Input, newMovie.Id);
            AddParamToFBCmd(fbCmd, "@Original_language", FbDbType.VarChar, 250, ParameterDirection.Input, newMovie.Original_language);
            AddParamToFBCmd(fbCmd, "@Original_title", FbDbType.VarChar, 250, ParameterDirection.Input, newMovie.Original_title);
            AddParamToFBCmd(fbCmd, "@Popularity", FbDbType.VarChar, 250, ParameterDirection.Input, newMovie.Popularity);
            AddParamToFBCmd(fbCmd, "@Poster_path", FbDbType.VarChar, 100, ParameterDirection.Input, newMovie.Poster_path);
            AddParamToFBCmd(fbCmd, "@Release_date", FbDbType.TimeStamp, 0, ParameterDirection.Input, newMovie.Release_date);
            AddParamToFBCmd(fbCmd, "@Title", FbDbType.VarChar, 20, ParameterDirection.Input, newMovie.Title);
            AddParamToFBCmd(fbCmd, "@Vote_average", FbDbType.Decimal, 18, ParameterDirection.Input, newMovie.Vote_average);
            AddParamToFBCmd(fbCmd, "@Overview", FbDbType.VarChar, 250, ParameterDirection.Input, newMovie.Overview);

            SetCommandType(fbCmd, CommandType.Text, SP_MOVIE_CREATE);
            ExecuteScalarCmd(fbCmd);
            return newMovie.Id;
        }

        public override bool UpdateMovie(Movie MovieToUpdate)
        {
            if (MovieToUpdate == null)
                throw (new ArgumentNullException("MovieToUpdate"));

            FbCommand fbCmd = new FbCommand();
            AddParamToFBCmd(fbCmd, "@Id", FbDbType.Integer, 4, ParameterDirection.Input, MovieToUpdate.Id);
            AddParamToFBCmd(fbCmd, "@Original_language", FbDbType.VarChar, 250, ParameterDirection.Input, MovieToUpdate.Original_language);
            AddParamToFBCmd(fbCmd, "@Original_title", FbDbType.VarChar, 250, ParameterDirection.Input, MovieToUpdate.Original_title);
            AddParamToFBCmd(fbCmd, "@Popularity", FbDbType.VarChar, 1, ParameterDirection.Input, MovieToUpdate.Popularity);
            AddParamToFBCmd(fbCmd, "@Poster_path", FbDbType.VarChar, 100, ParameterDirection.Input, MovieToUpdate.Poster_path);
            AddParamToFBCmd(fbCmd, "@Release_date", FbDbType.TimeStamp, 0, ParameterDirection.Input, MovieToUpdate.Release_date);
            AddParamToFBCmd(fbCmd, "@Title", FbDbType.VarChar, 20, ParameterDirection.Input, MovieToUpdate.Title);
            AddParamToFBCmd(fbCmd, "@Vote_average", FbDbType.Decimal, 18, ParameterDirection.Input, MovieToUpdate.Vote_average);
            AddParamToFBCmd(fbCmd, "@Overview", FbDbType.VarChar, 250, ParameterDirection.Input, MovieToUpdate.Overview);

            SetCommandType(fbCmd, CommandType.Text, SP_MOVIE_UPDATE);
            int returnValue = ExecuteNonQueryCmd(fbCmd);
            return (returnValue > 0 ? true : false);
        }

        public override bool DeleteMovie(int Id)
        {
            FbCommand fbCmd = new FbCommand();
            AddParamToFBCmd(fbCmd, "@Id", FbDbType.Integer, 0, ParameterDirection.Input, Id);
            SetCommandType(fbCmd, CommandType.Text, SP_MOVIE_DELETE);
            int returnValue = ExecuteNonQueryCmd(fbCmd);
            return (returnValue > 0 ? true : false);
        }

        public override SortableBindingList<Movie> GetAllMovies()
        {
            FbCommand fbCmd = new FbCommand();
            SetCommandType(fbCmd, CommandType.Text, SP_MOVIE_GETALL);
            SortableBindingList<Movie> movieList = new SortableBindingList<Movie>();
            TExecuteReaderCmd<Movie>(fbCmd, TGenerateMovieListFromReader<Movie>, ref movieList);
            return movieList;
        }

        public override Movie GetMovieById(int Id)
        {
            FbCommand fbCmd = new FbCommand();
            AddParamToFBCmd(fbCmd, "@Id", FbDbType.Integer, 0, ParameterDirection.Input, Id);
            SetCommandType(fbCmd, CommandType.Text, SP_MOVIE_GETBYID);
            SortableBindingList<Movie> movieList = new SortableBindingList<Movie>();
            TExecuteReaderCmd<Movie>(fbCmd, TGenerateMovieListFromReader<Movie>, ref movieList);
            return (movieList.Count == 0) ? null : movieList[0];
        }

        #endregion Movie

        #region TGenerateMovieListFromReader
        private void TGenerateMovieListFromReader<T>(FbDataReader returnData, ref SortableBindingList<Movie> movieList)
        {
            while (returnData.Read())
            {
                Movie movie = new Movie(
                    Convert.IsDBNull(returnData["Id"]) ? DefaultValues.IdNullValue : (int)returnData["Id"],
                    Convert.IsDBNull(returnData["Original_language"]) ? String.Empty : (string)returnData["Original_language"],
                    Convert.IsDBNull(returnData["Original_title"]) ? String.Empty : (string)returnData["Original_title"],
                    Convert.IsDBNull(returnData["Popularity"]) ? String.Empty : (string)returnData["Popularity"],
                    Convert.IsDBNull(returnData["Poster_path"]) ? String.Empty : (string)returnData["Poster_path"],
                    Convert.IsDBNull(returnData["Release_date"]) ? DateTime.MinValue : (DateTime)returnData["Release_date"],
                    Convert.IsDBNull(returnData["Title"]) ? String.Empty : (string)returnData["Title"],
                    Convert.IsDBNull(returnData["Vote_average"]) ? Decimal.Zero : (Decimal)returnData["Vote_average"],
                    Convert.IsDBNull(returnData["Overview"]) ? String.Empty : (string)returnData["Overview"]
                );

                movieList.Add(movie);
            }
        }
        #endregion

        private string ParameterValueForSQL(FbParameter sp)
        {
            string retval = "";

            if ((sp.Value == Convert.DBNull) || (sp.Value == null))
            {
                retval = "NULL";
            }
            else
            {
                switch (sp.DbType)
                {
                    case DbType.Time:
                    case DbType.AnsiString:
                    case DbType.AnsiStringFixedLength:
                    case DbType.String:
                    case DbType.StringFixedLength:
                    case DbType.Xml:
                    case DbType.Date:
                    case DbType.DateTime:
                    case DbType.DateTime2:
                    case DbType.DateTimeOffset:
                        retval = "'" + sp.Value.ToString().Replace("'", "''") + "'";
                        break;

                    case DbType.Boolean:
                        retval = (Convert.ToBoolean(sp.Value)) ? "1" : "0";
                        break;

                    default:
                        retval = sp.Value.ToString().Replace("'", "''");
                        break;
                }
            }

            return retval;
        }

        private void SetLastSQLCommand(FbCommand fbCmd)
        {
            if (_SQLCommandsLog)
                return;

            string paramName = String.Empty;
            string paramValue = String.Empty;

            try
            {
                //string match = "[^a-zA-Z @]*[ |\\,]+";
                string match = "[^a-zA-Z @]*";
                string query = fbCmd.CommandText;
                if (!Regex.Match(query, "INSERT INTO Log|UPDATE Log SET").Success)
                {
                    foreach (FbParameter p in fbCmd.Parameters)
                    {
                        paramName = p.ParameterName.Substring(1);
                        paramValue = ParameterValueForSQL(p);
                        if (paramValue == "System.Byte[]")
                        {
                            query = Regex.Replace(query, "(@" + paramName + ")(" + match + ")", " ", RegexOptions.IgnoreCase);
                            query = Regex.Replace(query, "(" + match + ")(" + paramName + ")(" + match + ")", " ", RegexOptions.IgnoreCase);
                        }
                        else
                        {
                            query = Regex.Replace(query, "(@" + paramName + ")(" + match + ")", paramValue + "$2", RegexOptions.IgnoreCase);
                        }
                    }
                    _LastSQLCommands.Add(query);
                }
            }
            catch (Exception)
            {

            }
        }

        //
        // Metodos auxiliares para manipulacao SQL
        //
        #region AddParamToFBCmd
        /// <summary>
        /// Método para adicionar parâmetros a instrução SQL
        /// </summary>
        /// <param name="SqlCommand">Comando que irá receber o parâmetro</param>
        protected void AddParamToFBCmd(FbCommand fbCmd, string paramId, FbDbType fbType, int paramSize,
            ParameterDirection paramDirection, object paramValue)
        {
            if (fbCmd == null)
                throw (new ArgumentNullException("fbCmd"));

            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            bool exists = false;
            foreach (FbParameter fbPrm in fbCmd.Parameters)
                if (fbPrm.ParameterName == paramId)
                {
                    exists = true;
                    break;
                }

            if (!exists)
            {
                FbParameter newFbParam = new FbParameter();
                newFbParam.ParameterName = paramId;
                newFbParam.FbDbType = fbType;
                newFbParam.Direction = paramDirection;

                if (paramSize > 0)
                    newFbParam.Size = paramSize;

                if (paramValue != null)
                    newFbParam.Value = paramValue;

                if (newFbParam.FbDbType == FbDbType.Text)
                {
                    newFbParam.FbDbType = FbDbType.Binary;
                    if (newFbParam.Value != null)
                        newFbParam.Value = StringToByteArray((string)newFbParam.Value);
                }

                if (newFbParam.FbDbType == FbDbType.Binary)
                    newFbParam.Size = 0;

                fbCmd.Parameters.Add(newFbParam);
            }
        }
        #endregion

        #region ExecuteScalarCmd
        /// <summary>
        /// Executando o commando
        /// </summary>
        /// <param name="SqlCommand">Comando</param>
        private void ExecuteScalarCmd(FbCommand fbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (fbCmd == null)
                throw (new ArgumentNullException("fbCmd"));

            using (FbConnection cn = new FbConnection(this.ConnectionString))
            {
                fbCmd.Connection = cn;
                cn.Open();

                fbCmd.ExecuteScalar();
                cn.Close();
            }
        }
        #endregion

        #region ExecuteNonQueryCmd
        protected int ExecuteNonQueryCmd(FbCommand fbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (fbCmd == null)
                throw (new ArgumentNullException("fbCmd"));

            using (FbConnection cn = new FbConnection(this.ConnectionString))
            {
                fbCmd.Connection = cn;
                cn.Open();

                SetLastSQLCommand(fbCmd);
                return fbCmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region ExecuteReaderCmd
        protected object ExecuteReaderCmd(FbCommand fbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (fbCmd == null)
                throw (new ArgumentNullException("fbCmd"));

            using (FbConnection cn = new FbConnection(this.ConnectionString))
            {
                fbCmd.Connection = cn;
                cn.Open();
                FbDataReader returnData = fbCmd.ExecuteReader();
                if (returnData.Read())
                {
                    if (returnData[0] == DBNull.Value)
                        return null;
                    return returnData[0];
                }
                else
                    return null;
            }
        }
        #endregion

        #region GetNextGenerator
        protected int GetNextGenerator(string generator)
        {
            return GetGenerator(generator, 1);
        }
        #endregion

        #region GetGenerator
        protected int GetGenerator(string generatorName)
        {
            return GetGenerator(generatorName, 0);
        }

        protected int GetGenerator(string generatorName, int step)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            FbCommand fbCmd = new FbCommand();
            fbCmd.CommandText = String.Format("SELECT GEN_ID({0}, {1}) AS KEY_VALUE FROM RDB$DATABASE", generatorName, step);
            FbConnection cn = new FbConnection(this.ConnectionString);
            fbCmd.Connection = cn;
            cn.Open();
            FbDataReader returnData = fbCmd.ExecuteReader();
            long keyValue = 0;
            if (returnData.Read())
            {
                keyValue = (long)returnData["KEY_VALUE"];
                returnData.Close();
            }
            cn.Close();
            cn = null;
            return (int)keyValue;
        }
        #endregion

        #region SetGenerator
        protected bool SetGenerator(string generatorName, int valor)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            FbCommand fbCmd = new FbCommand();
            SetCommandType(fbCmd, CommandType.Text, String.Format("SET GENERATOR {0} TO {1}", generatorName, valor));
            int returnValue = ExecuteNonQueryCmd(fbCmd);
            return (returnValue > 0) ? true : false;
        }
        #endregion

        #region SetCommandType
        protected void SetCommandType(FbCommand fbCmd, CommandType cmdType, string cmdText)
        {
            fbCmd.CommandType = cmdType;

            string cmdSQL = cmdText;
            if ((_FilterReadInit > -1) && (_FilterReadEnd > -1))
            {
                cmdSQL = cmdSQL.Replace("SELECT", String.Format("SELECT FIRST {0} SKIP {1}", _FilterReadEnd - _FilterReadInit, _FilterReadInit));
            }

            fbCmd.CommandText = cmdSQL;
        }
        #endregion

        #region TExecuteReaderCmd
        protected void TExecuteReaderCmd<T>(FbCommand fbCmd, TGenerateListFromReader<T> gcfr, ref SortableBindingList<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (fbCmd == null)
                throw (new ArgumentNullException("fbCmd"));

            using (FbConnection cn = new FbConnection(this.ConnectionString))
            {
                bool canCache = IsCachedMethod(new StackTrace().GetFrame(1).GetMethod().Name);
                if (canCache)
                    DataCacheController.EnableCache();

                DateTime dtStartTime = DateTime.MinValue;
                DateTime dtEndTime = DateTime.MinValue;

                if (!DataCacheController.ExecuteCacheControl<T>(fbCmd, ref List))
                {
                    fbCmd.Connection = cn;

                    dtStartTime = DateTime.Now;

                    cn.Open();
                    gcfr(fbCmd.ExecuteReader(), ref List);

                    dtEndTime = DateTime.Now;

                    if (DataCacheController.IsEnabled())
                        DataCacheController.SetCacheControl<T>(fbCmd, ref List);
                }
                else
                {

                }

                if (canCache)
                    DataCacheController.DisableCache();
            }


            ResetFilterRead();
        }
        #endregion

        #region CreateFbCommand
        protected FbCommand CreateFbCommand(FbConnection cn, string sql, params ParamObject[] paramsToCmd)
        {
            FbCommand cmd = new FbCommand(sql, cn);
            cmd.CommandType = CommandType.Text;

            foreach (ParamObject param in paramsToCmd)
                if (param != null)
                    AddParamToFBCmd(cmd, "@" + param.Name, param.DbDataType, param.Size, ParameterDirection.Input, param.Data);

            return cmd;
        }
        #endregion

        #region CreateDataReaderCmd
        protected FbDataReader CreateDataReaderCmd(FbConnection cn, ref FbCommand cmd, string sql, params ParamObject[] paramsToCmd)
        {
            cmd = CreateFbCommand(cn, sql, paramsToCmd);
            return cmd.ExecuteReader();
        }
        #endregion

        #region ExecuteDataReaderCmd
        protected List<object[]> ExecuteDataReaderCmd(FbDataReader rdrAux)
        {
            List<object[]> results = new List<object[]>();

            while (rdrAux.Read())
            {
                object[] row = new object[rdrAux.FieldCount];
                for (int i = 0; i < rdrAux.FieldCount; i++)
                    row[i] = rdrAux.GetValue(i);

                results.Add(row);
            }
            rdrAux.Close();

            return results;
        }
        #endregion

        #region ReadDataCmd
        protected object ReadDataCmd(FbDataReader rdrAux, int col, int row)
        {
            List<object[]> results = ExecuteDataReaderCmd(rdrAux);

            if (results.Count > col)
                if (results[col].Length > row)
                    return results[col][row];

            return null;
        }
        #endregion

        //
        // Tipos auxiliares
        //
        public class ParamObject
        {
            private string _Name;
            private int _Size;
            private object _Data;
            private FbDbType _DbDataType;

            public ParamObject(string paramName, int paramSize, object paramData, FbDbType _DbDataType)
            {
                this._Name = paramName;
                this._Size = paramSize;
                this._Data = paramData;
                this._DbDataType = _DbDataType;
            }

            public string Name { get { return _Name; } }
            public int Size { get { return _Size; } }
            public object Data { get { return _Data; } }
            public FbDbType DbDataType { get { return _DbDataType; } }
        }

        public ParamObject ParamStringObject(string paramName, int paramSize, object paramData)
        {
            return new ParamObject(paramName, paramSize, paramData, FbDbType.VarChar);
        }

        public ParamObject ParamIntObject(string paramName, object paramData)
        {
            return new ParamObject(paramName, 4, paramData, FbDbType.Integer);
        }

        public ParamObject ParamDataObject(string paramName, object paramData)
        {
            return new ParamObject(paramName, 0, paramData, FbDbType.TimeStamp);
        }

        //
        // Metodos auxiliares para convercao de tipos
        //
        #region BitmapToByteArray
        protected static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            if (bitmap == null)
                throw (new ArgumentNullException("bitmap"));

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        #endregion

        #region StringToByteArray
        public static byte[] StringToByteArray(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }
        #endregion

        #region ByteArrayToString
        protected string ByteArrayToString(byte[] buffer)
        {
            ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(buffer);
        }
        #endregion
    }
}
