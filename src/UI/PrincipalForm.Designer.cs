namespace MoviesRegister
{
    partial class PrincipalForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.flpMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpFilmesDisponiveis = new System.Windows.Forms.TabPage();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.tbpFilmesFavoritos = new System.Windows.Forms.TabPage();
            this.lblQuantidadeFavoritos = new System.Windows.Forms.Label();
            this.dgvFilmesFavoritos = new System.Windows.Forms.DataGridView();
            this.bdsFilmesFavoritos = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releasedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originallanguageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.popularityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voteaverageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overviewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpFilmesDisponiveis.SuspendLayout();
            this.tbpFilmesFavoritos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmesFavoritos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsFilmesFavoritos)).BeginInit();
            this.SuspendLayout();
            // 
            // flpMovies
            // 
            this.flpMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMovies.AutoScroll = true;
            this.flpMovies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpMovies.Location = new System.Drawing.Point(8, 6);
            this.flpMovies.Name = "flpMovies";
            this.flpMovies.Size = new System.Drawing.Size(838, 654);
            this.flpMovies.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 707);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpFilmesDisponiveis);
            this.tabControl1.Controls.Add(this.tbpFilmesFavoritos);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(862, 707);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpFilmesDisponiveis
            // 
            this.tbpFilmesDisponiveis.Controls.Add(this.lblQuantidade);
            this.tbpFilmesDisponiveis.Controls.Add(this.flpMovies);
            this.tbpFilmesDisponiveis.Location = new System.Drawing.Point(4, 22);
            this.tbpFilmesDisponiveis.Name = "tbpFilmesDisponiveis";
            this.tbpFilmesDisponiveis.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFilmesDisponiveis.Size = new System.Drawing.Size(854, 681);
            this.tbpFilmesDisponiveis.TabIndex = 0;
            this.tbpFilmesDisponiveis.Text = "Filmes Disponíveis";
            this.tbpFilmesDisponiveis.UseVisualStyleBackColor = true;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(8, 663);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(68, 13);
            this.lblQuantidade.TabIndex = 65;
            this.lblQuantidade.Text = "Quantidade: ";
            // 
            // tbpFilmesFavoritos
            // 
            this.tbpFilmesFavoritos.Controls.Add(this.lblQuantidadeFavoritos);
            this.tbpFilmesFavoritos.Controls.Add(this.dgvFilmesFavoritos);
            this.tbpFilmesFavoritos.Location = new System.Drawing.Point(4, 22);
            this.tbpFilmesFavoritos.Name = "tbpFilmesFavoritos";
            this.tbpFilmesFavoritos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFilmesFavoritos.Size = new System.Drawing.Size(254, 681);
            this.tbpFilmesFavoritos.TabIndex = 1;
            this.tbpFilmesFavoritos.Text = "Filmes Favoritos";
            this.tbpFilmesFavoritos.UseVisualStyleBackColor = true;
            // 
            // lblQuantidadeFavoritos
            // 
            this.lblQuantidadeFavoritos.AutoSize = true;
            this.lblQuantidadeFavoritos.Location = new System.Drawing.Point(8, 663);
            this.lblQuantidadeFavoritos.Name = "lblQuantidadeFavoritos";
            this.lblQuantidadeFavoritos.Size = new System.Drawing.Size(68, 13);
            this.lblQuantidadeFavoritos.TabIndex = 66;
            this.lblQuantidadeFavoritos.Text = "Quantidade: ";
            // 
            // dgvFilmesFavoritos
            // 
            this.dgvFilmesFavoritos.AllowUserToAddRows = false;
            this.dgvFilmesFavoritos.AllowUserToDeleteRows = false;
            this.dgvFilmesFavoritos.AllowUserToResizeColumns = false;
            this.dgvFilmesFavoritos.AllowUserToResizeRows = false;
            this.dgvFilmesFavoritos.AutoGenerateColumns = false;
            this.dgvFilmesFavoritos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFilmesFavoritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmesFavoritos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.releasedateDataGridViewTextBoxColumn,
            this.originallanguageDataGridViewTextBoxColumn,
            this.popularityDataGridViewTextBoxColumn,
            this.voteaverageDataGridViewTextBoxColumn,
            this.overviewDataGridViewTextBoxColumn,
            this.Column1});
            this.dgvFilmesFavoritos.DataSource = this.bdsFilmesFavoritos;
            this.dgvFilmesFavoritos.Location = new System.Drawing.Point(8, 6);
            this.dgvFilmesFavoritos.Name = "dgvFilmesFavoritos";
            this.dgvFilmesFavoritos.ReadOnly = true;
            this.dgvFilmesFavoritos.RowHeadersVisible = false;
            this.dgvFilmesFavoritos.Size = new System.Drawing.Size(838, 654);
            this.dgvFilmesFavoritos.TabIndex = 0;
            // 
            // bdsFilmesFavoritos
            // 
            this.bdsFilmesFavoritos.DataSource = typeof(MoviesRegister.BLL.Movie);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Título";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 200;
            // 
            // releasedateDataGridViewTextBoxColumn
            // 
            this.releasedateDataGridViewTextBoxColumn.DataPropertyName = "Release_date";
            this.releasedateDataGridViewTextBoxColumn.HeaderText = "Data de Lançamento";
            this.releasedateDataGridViewTextBoxColumn.Name = "releasedateDataGridViewTextBoxColumn";
            this.releasedateDataGridViewTextBoxColumn.ReadOnly = true;
            this.releasedateDataGridViewTextBoxColumn.Width = 130;
            // 
            // originallanguageDataGridViewTextBoxColumn
            // 
            this.originallanguageDataGridViewTextBoxColumn.DataPropertyName = "Original_language";
            this.originallanguageDataGridViewTextBoxColumn.HeaderText = "Linguagem Original";
            this.originallanguageDataGridViewTextBoxColumn.Name = "originallanguageDataGridViewTextBoxColumn";
            this.originallanguageDataGridViewTextBoxColumn.ReadOnly = true;
            this.originallanguageDataGridViewTextBoxColumn.Width = 120;
            // 
            // popularityDataGridViewTextBoxColumn
            // 
            this.popularityDataGridViewTextBoxColumn.DataPropertyName = "Popularity";
            this.popularityDataGridViewTextBoxColumn.HeaderText = "Popularidade";
            this.popularityDataGridViewTextBoxColumn.Name = "popularityDataGridViewTextBoxColumn";
            this.popularityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // voteaverageDataGridViewTextBoxColumn
            // 
            this.voteaverageDataGridViewTextBoxColumn.DataPropertyName = "Vote_average";
            this.voteaverageDataGridViewTextBoxColumn.HeaderText = "Média de Votos";
            this.voteaverageDataGridViewTextBoxColumn.Name = "voteaverageDataGridViewTextBoxColumn";
            this.voteaverageDataGridViewTextBoxColumn.ReadOnly = true;
            this.voteaverageDataGridViewTextBoxColumn.Width = 110;
            // 
            // overviewDataGridViewTextBoxColumn
            // 
            this.overviewDataGridViewTextBoxColumn.DataPropertyName = "Overview";
            this.overviewDataGridViewTextBoxColumn.HeaderText = "Overview";
            this.overviewDataGridViewTextBoxColumn.Name = "overviewDataGridViewTextBoxColumn";
            this.overviewDataGridViewTextBoxColumn.ReadOnly = true;
            this.overviewDataGridViewTextBoxColumn.Width = 200;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 707);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Filmes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrincipalForm_FormClosing);
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbpFilmesDisponiveis.ResumeLayout(false);
            this.tbpFilmesDisponiveis.PerformLayout();
            this.tbpFilmesFavoritos.ResumeLayout(false);
            this.tbpFilmesFavoritos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmesFavoritos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsFilmesFavoritos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpFilmesDisponiveis;
        private System.Windows.Forms.TabPage tbpFilmesFavoritos;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblQuantidadeFavoritos;
        private System.Windows.Forms.BindingSource bdsFilmesFavoritos;
        private System.Windows.Forms.DataGridView dgvFilmesFavoritos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releasedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originallanguageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn popularityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voteaverageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overviewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

