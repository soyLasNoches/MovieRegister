namespace MoviesRegister.UI
{
    partial class MoviesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbPosterFilme = new System.Windows.Forms.PictureBox();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDataLancamento = new System.Windows.Forms.Label();
            this.lblLinguagemOriginal = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPopularidade = new System.Windows.Forms.Label();
            this.lblMediaVotos = new System.Windows.Forms.Label();
            this.lblTituloOriginal = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtLinguagemOriginal = new System.Windows.Forms.TextBox();
            this.txtTituloOriginal = new System.Windows.Forms.TextBox();
            this.txtPopularidade = new System.Windows.Forms.TextBox();
            this.txtDataLancamento = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtMediaVotos = new System.Windows.Forms.TextBox();
            this.txtOverview = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPosterFilme)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbPosterFilme
            // 
            this.ptbPosterFilme.Location = new System.Drawing.Point(12, 12);
            this.ptbPosterFilme.Name = "ptbPosterFilme";
            this.ptbPosterFilme.Size = new System.Drawing.Size(235, 277);
            this.ptbPosterFilme.TabIndex = 0;
            this.ptbPosterFilme.TabStop = false;
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMovie.Image = global::MoviesRegister.Properties.Resources.favoritar;
            this.btnAddMovie.Location = new System.Drawing.Point(516, 414);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(80, 30);
            this.btnAddMovie.TabIndex = 1;
            this.btnAddMovie.Text = "Adicionar";
            this.btnAddMovie.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(275, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(50, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Código:";
            // 
            // lblDataLancamento
            // 
            this.lblDataLancamento.AutoSize = true;
            this.lblDataLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataLancamento.Location = new System.Drawing.Point(275, 180);
            this.lblDataLancamento.Name = "lblDataLancamento";
            this.lblDataLancamento.Size = new System.Drawing.Size(129, 13);
            this.lblDataLancamento.TabIndex = 2;
            this.lblDataLancamento.Text = "Data de Lançamento:";
            // 
            // lblLinguagemOriginal
            // 
            this.lblLinguagemOriginal.AutoSize = true;
            this.lblLinguagemOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinguagemOriginal.Location = new System.Drawing.Point(275, 60);
            this.lblLinguagemOriginal.Name = "lblLinguagemOriginal";
            this.lblLinguagemOriginal.Size = new System.Drawing.Size(119, 13);
            this.lblLinguagemOriginal.TabIndex = 2;
            this.lblLinguagemOriginal.Text = "Linguagem Original:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(275, 220);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(45, 13);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Título:";
            // 
            // lblPopularidade
            // 
            this.lblPopularidade.AutoSize = true;
            this.lblPopularidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopularidade.Location = new System.Drawing.Point(275, 140);
            this.lblPopularidade.Name = "lblPopularidade";
            this.lblPopularidade.Size = new System.Drawing.Size(85, 13);
            this.lblPopularidade.TabIndex = 4;
            this.lblPopularidade.Text = "Popularidade:";
            // 
            // lblMediaVotos
            // 
            this.lblMediaVotos.AutoSize = true;
            this.lblMediaVotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaVotos.Location = new System.Drawing.Point(275, 260);
            this.lblMediaVotos.Name = "lblMediaVotos";
            this.lblMediaVotos.Size = new System.Drawing.Size(99, 13);
            this.lblMediaVotos.TabIndex = 5;
            this.lblMediaVotos.Text = "Média de Votos:";
            // 
            // lblOverview
            // 
            this.lblOverview.AutoSize = true;
            this.lblOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.Location = new System.Drawing.Point(275, 300);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(99, 13);
            this.lblOverview.TabIndex = 5;
            this.lblOverview.Text = "Overview:";
            // 
            // lblTituloOriginal
            // 
            this.lblTituloOriginal.AutoSize = true;
            this.lblTituloOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloOriginal.Location = new System.Drawing.Point(275, 100);
            this.lblTituloOriginal.Name = "lblTituloOriginal";
            this.lblTituloOriginal.Size = new System.Drawing.Size(92, 13);
            this.lblTituloOriginal.TabIndex = 6;
            this.lblTituloOriginal.Text = "Título Original:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(413, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(183, 20);
            this.txtCodigo.TabIndex = 7;
            // 
            // txtLinguagemOriginal
            // 
            this.txtLinguagemOriginal.Location = new System.Drawing.Point(413, 57);
            this.txtLinguagemOriginal.Name = "txtLinguagemOriginal";
            this.txtLinguagemOriginal.ReadOnly = true;
            this.txtLinguagemOriginal.Size = new System.Drawing.Size(183, 20);
            this.txtLinguagemOriginal.TabIndex = 8;
            // 
            // txtTituloOriginal
            // 
            this.txtTituloOriginal.Location = new System.Drawing.Point(413, 97);
            this.txtTituloOriginal.Name = "txtTituloOriginal";
            this.txtTituloOriginal.ReadOnly = true;
            this.txtTituloOriginal.Size = new System.Drawing.Size(183, 20);
            this.txtTituloOriginal.TabIndex = 8;
            // 
            // txtOverview
            // 
            this.txtOverview.Location = new System.Drawing.Point(413, 300);
            this.txtOverview.Multiline = true;
            this.txtOverview.Name = "txtOverview";
            this.txtOverview.ReadOnly = true;
            this.txtOverview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; // Adicionando barra de rolagem vertical para texto longo
            this.txtOverview.Size = new System.Drawing.Size(183, 100); // Ajuste o tamanho conforme necessário
            this.txtOverview.TabIndex = 9; // Certifique-se de ajustar o índice conforme necessário
            // 
            // txtPopularidade
            // 
            this.txtPopularidade.Location = new System.Drawing.Point(413, 140);
            this.txtPopularidade.Name = "txtPopularidade";
            this.txtPopularidade.ReadOnly = true;
            this.txtPopularidade.Size = new System.Drawing.Size(183, 20);
            this.txtPopularidade.TabIndex = 8;
            // 
            // txtDataLancamento
            // 
            this.txtDataLancamento.Location = new System.Drawing.Point(413, 177);
            this.txtDataLancamento.Name = "txtDataLancamento";
            this.txtDataLancamento.ReadOnly = true;
            this.txtDataLancamento.Size = new System.Drawing.Size(183, 20);
            this.txtDataLancamento.TabIndex = 8;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(413, 217);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.ReadOnly = true;
            this.txtTitulo.Size = new System.Drawing.Size(183, 20);
            this.txtTitulo.TabIndex = 8;
            // 
            // txtMediaVotos
            // 
            this.txtMediaVotos.Location = new System.Drawing.Point(413, 257);
            this.txtMediaVotos.Name = "txtMediaVotos";
            this.txtMediaVotos.ReadOnly = true;
            this.txtMediaVotos.Size = new System.Drawing.Size(183, 20);
            this.txtMediaVotos.TabIndex = 8;
            // 
            // MoviesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 556);
            this.Controls.Add(this.txtMediaVotos);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtDataLancamento);
            this.Controls.Add(this.txtPopularidade);
            this.Controls.Add(this.txtTituloOriginal);
            this.Controls.Add(this.txtLinguagemOriginal);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtOverview);
            this.Controls.Add(this.lblPopularidade);
            this.Controls.Add(this.lblMediaVotos);
            this.Controls.Add(this.lblOverview);
            this.Controls.Add(this.lblTituloOriginal);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblLinguagemOriginal);
            this.Controls.Add(this.lblDataLancamento);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.ptbPosterFilme);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoviesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes do Filme";
            ((System.ComponentModel.ISupportInitialize)(this.ptbPosterFilme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbPosterFilme;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDataLancamento;
        private System.Windows.Forms.Label lblLinguagemOriginal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPopularidade;
        private System.Windows.Forms.Label lblMediaVotos;
        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblTituloOriginal;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtLinguagemOriginal;
        private System.Windows.Forms.TextBox txtTituloOriginal;
        private System.Windows.Forms.TextBox txtPopularidade;
        private System.Windows.Forms.TextBox txtDataLancamento;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtMediaVotos;
        private System.Windows.Forms.TextBox txtOverview;
    }
}