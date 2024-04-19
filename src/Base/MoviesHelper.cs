using MoviesRegister.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesRegister.Base
{
    public class MoviesHelper
    {
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string popularity { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
        public string title { get; set; }
        public Decimal vote_average { get; set; }
        public int vote_count { get; set; }       
        public string overview { get; set; }       

        public class MoviesApiResponse
        {
            public int Page { get; set; }
            public SortableBindingList<MoviesHelper> Results { get; set; }
            public int TotalPages { get; set; }
            public int TotalResults { get; set; }
        }



        #region Métodos
        public static SortableBindingList<MoviesHelper> GetMovies()
        {
            string urlapi = "https://api.themoviedb.org/3/movie/popular?api_key=d416af5d4faee64e25ab001d87aab5c3";

            SortableBindingList<MoviesHelper> movies = null;

            if (!Utils.IsApiOnline(urlapi))
            {
                MessageBox.Show("A API não está online");
            }

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var httpRequestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(urlapi),
                    };

                    HttpResponseMessage response = httpClient.SendAsync(httpRequestMessage).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string conteudo = response.Content.ReadAsStringAsync().Result;
                        MoviesApiResponse moviesApiResponse = JsonConvert.DeserializeObject<MoviesApiResponse>(conteudo);
                        movies = moviesApiResponse.Results;
                    }
                }
            }
            catch (Exception e)
            {                
                MessageBox.Show(e.Message);
                return null;
            }

            return movies;
        }
        #endregion
    }
}