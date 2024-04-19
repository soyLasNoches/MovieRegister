using MoviesRegister.Base;
using MoviesRegister.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesRegister.UI
{
    public partial class MoviesForm : BaseForm
    {
        public Movie _movie;

        public MoviesForm(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
            AtualizaTela();
        }

        public void AtualizaTela()
        {
            string urlImagem = "https://image.tmdb.org/t/p/w300_and_h450_bestv2/" + _movie.Poster_path;

            ptbPosterFilme.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbPosterFilme.LoadAsync(urlImagem);

            txtCodigo.Text = _movie.Id.ToString();
            txtLinguagemOriginal.Text = _movie.Original_language.ToString();
            txtTituloOriginal.Text = _movie.Original_title.ToString();
            txtPopularidade.Text = _movie.Popularity.ToString();
            txtDataLancamento.Text = _movie.Release_date.ToString().Substring(0, 10);
            txtTitulo.Text = _movie.Title.ToString();
            txtMediaVotos.Text = _movie.Vote_average.ToString();
            txtOverview.Text = _movie.Overview.ToString();

            VerificarExistenciaFilme();

        }

        private bool VerificarExistenciaFilme()
        {
            if (Movie.GetMovieById(_movie.Id) == null)
            {
                btnAddMovie.Text = "Adicionar";
                btnAddMovie.Image = Properties.Resources.desfavoritar;
                return true;
            }
            else
            {
                btnAddMovie.Text = "Remover";
                btnAddMovie.Image = Properties.Resources.favoritar;
                return false;
            }
        }

        public void AdicionarFilmeFavorito()
        {
            Movie movie = new Movie();
            movie.Id = _movie.Id;
            movie.Original_language = _movie.Original_language;
            movie.Original_title = _movie.Original_title;
            movie.Popularity = _movie.Popularity;
            movie.Poster_path = _movie.Poster_path;
            movie.Release_date = _movie.Release_date;
            movie.Title = _movie.Title;
            movie.Vote_average = _movie.Vote_average;
            movie.Overview = _movie.Overview;

            movie.Save();
        }

        public void RemoverFilmeFavorito()
        {
            Movie.DeleteMovie(_movie.Id);
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            if (VerificarExistenciaFilme())
            {
                AdicionarFilmeFavorito();
            }
            else
                RemoverFilmeFavorito();

            VerificarExistenciaFilme();
        }
    }
}
