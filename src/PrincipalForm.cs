using Newtonsoft.Json;
using MoviesRegister.Base;
using MoviesRegister.BLL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MoviesRegister.UI;

namespace MoviesRegister
{
    public partial class PrincipalForm : BaseForm
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            lblQuantidade.Text = "";
            LocalizarFilmes();
        }

        private void PrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja realmente fechar o sistema?",
                    "MoviesRegister",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;
                OnClosing(e);
            }
        }

        private bool VerificarExistenciaFilme(int id)
        {
            if (Movie.GetMovieById(id) == null)
                return true;
            else
                return false;
        }

        private Panel NovoPainel(int id, string title, string urlImagem, string releaseDate, Movie movie)
        {
            Panel panel = new Panel();
            panel.Height = 400;
            panel.Width = 250;
            panel.Margin = new Padding(10);
            panel.BorderStyle = BorderStyle.None;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.BackColor = Color.WhiteSmoke;
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.RemoveAt(1);

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;

            try
            {
                pictureBox.LoadCompleted += (s, e) =>
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                };

                pictureBox.LoadAsync(urlImagem);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar a imagem: " + ex.Message);
            }

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font(titleLabel.Font.FontFamily, 12, FontStyle.Bold);
            titleLabel.ForeColor = Color.Black;

            Label releaseDateLabel = new Label();
            releaseDateLabel.Text = releaseDate;
            releaseDateLabel.AutoSize = true;
            releaseDateLabel.Font = new Font(releaseDateLabel.Font.FontFamily, 9);
            releaseDateLabel.ForeColor = Color.Gray;

            Label favorito = new Label();
            favorito.BackColor = Color.WhiteSmoke;
            favorito.ForeColor = Color.Black;
            favorito.FlatStyle = FlatStyle.Flat;
            favorito.Image = VerificarExistenciaFilme(id) ? null : Properties.Resources.favoritar;
            favorito.Size = new Size(20, 20);

            Button button = new Button();
            button.Text = "Detalhes";
            button.BackColor = Color.LightGray;
            button.ForeColor = Color.Black;
            button.FlatStyle = FlatStyle.Flat;
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.FlatAppearance.BorderSize = 0;

            Panel footer = new Panel();
            button.Location = new Point((footer.Width - button.Width), 0);
            favorito.Location = new Point(0, 0);
            footer.Controls.Add(favorito);
            footer.Controls.Add(button);
            footer.Dock = DockStyle.Fill;
            footer.Height = 25;

            button.Click += (sender, e) =>
            {
                int pos = flpMovies.VerticalScroll.Value;

                MovieDetails(movie);
                LocalizarFilmes();

                flpMovies.VerticalScroll.Value = pos;
            };

            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(titleLabel, 0, 1);
            tableLayoutPanel.Controls.Add(releaseDateLabel, 0, 2);
            tableLayoutPanel.Controls.Add(footer, 0, 3);

            panel.Controls.Add(tableLayoutPanel);

            panel.Paint += (sender, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle bounds = panel.ClientRectangle;
                    bounds.Width--;
                    bounds.Height--;
                    int radius = 10;
                    path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                    path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
                    path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90);
                    path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
                    panel.Region = new Region(path);
                }
            };

            return panel;
        }

        private void MovieDetails(Movie movie)
        {
            MoviesForm moviesForm = new MoviesForm(movie);
            moviesForm.ShowDialog();
        }

        private void LocalizarFilmes()
        {
            this.flpMovies.Controls.Clear();

            SortableBindingList<MoviesHelper> movies = new SortableBindingList<MoviesHelper>();

            movies = MoviesHelper.GetMovies();

            string urlImagem = "https://image.tmdb.org/t/p/w300_and_h450_bestv2/";

            foreach (MoviesHelper item in movies)
            {
                Movie movie = new Movie();

                movie.Id = item.id;
                movie.Original_language = item.original_language;
                movie.Original_title = item.original_title;
                movie.Popularity = item.popularity;
                movie.Poster_path = item.poster_path;
                movie.Release_date = item.release_date;
                movie.Title = item.title;
                movie.Vote_average = item.vote_average;

                this.flpMovies.Controls.Add(NovoPainel(item.id, item.title.Length > 25 ? item.title.Substring(0, 25) + "..." : item.title, urlImagem + item.poster_path, item.release_date.ToString().Substring(0, 10), movie));
            }

            lblQuantidade.Text = "Quantidade: " + movies.Count.ToString();
        }
    }
}
