namespace SuperStoreProject
{
    partial class FrmKassirYenile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKassirYenile));
            this.lbl_id = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.lbl_telefon = new System.Windows.Forms.Label();
            this.lbl_maas = new System.Windows.Forms.Label();
            this.lbl_adsoyad = new System.Windows.Forms.Label();
            this.lbl_adsoyad_value = new System.Windows.Forms.Label();
            this.tb_sifre = new System.Windows.Forms.TextBox();
            this.mskd_telefon = new System.Windows.Forms.MaskedTextBox();
            this.tb_maas = new System.Windows.Forms.TextBox();
            this.btn_yenile = new System.Windows.Forms.Button();
            this.btn_sil = new System.Windows.Forms.Button();
            this.gb_kassirler = new System.Windows.Forms.GroupBox();
            this.dgv_kassir = new System.Windows.Forms.DataGridView();
            this.pb_eng = new System.Windows.Forms.PictureBox();
            this.pb_az = new System.Windows.Forms.PictureBox();
            this.gb_kassirler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kassir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_az)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.ForeColor = System.Drawing.Color.White;
            this.lbl_id.Location = new System.Drawing.Point(10, 69);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(30, 21);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "Id :";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(134, 61);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(150, 29);
            this.tb_id.TabIndex = 1;
            // 
            // lbl_sifre
            // 
            this.lbl_sifre.AutoSize = true;
            this.lbl_sifre.ForeColor = System.Drawing.Color.White;
            this.lbl_sifre.Location = new System.Drawing.Point(10, 106);
            this.lbl_sifre.Name = "lbl_sifre";
            this.lbl_sifre.Size = new System.Drawing.Size(49, 21);
            this.lbl_sifre.TabIndex = 2;
            this.lbl_sifre.Text = "Sifre :";
            // 
            // lbl_telefon
            // 
            this.lbl_telefon.AutoSize = true;
            this.lbl_telefon.ForeColor = System.Drawing.Color.White;
            this.lbl_telefon.Location = new System.Drawing.Point(10, 140);
            this.lbl_telefon.Name = "lbl_telefon";
            this.lbl_telefon.Size = new System.Drawing.Size(66, 21);
            this.lbl_telefon.TabIndex = 3;
            this.lbl_telefon.Text = "Telefon :";
            // 
            // lbl_maas
            // 
            this.lbl_maas.AutoSize = true;
            this.lbl_maas.ForeColor = System.Drawing.Color.White;
            this.lbl_maas.Location = new System.Drawing.Point(10, 173);
            this.lbl_maas.Name = "lbl_maas";
            this.lbl_maas.Size = new System.Drawing.Size(54, 21);
            this.lbl_maas.TabIndex = 4;
            this.lbl_maas.Text = "Maas :";
            // 
            // lbl_adsoyad
            // 
            this.lbl_adsoyad.AutoSize = true;
            this.lbl_adsoyad.ForeColor = System.Drawing.Color.White;
            this.lbl_adsoyad.Location = new System.Drawing.Point(10, 34);
            this.lbl_adsoyad.Name = "lbl_adsoyad";
            this.lbl_adsoyad.Size = new System.Drawing.Size(83, 21);
            this.lbl_adsoyad.TabIndex = 5;
            this.lbl_adsoyad.Text = "Ad Soyad :";
            // 
            // lbl_adsoyad_value
            // 
            this.lbl_adsoyad_value.AutoSize = true;
            this.lbl_adsoyad_value.ForeColor = System.Drawing.Color.White;
            this.lbl_adsoyad_value.Location = new System.Drawing.Point(130, 34);
            this.lbl_adsoyad_value.Name = "lbl_adsoyad_value";
            this.lbl_adsoyad_value.Size = new System.Drawing.Size(72, 21);
            this.lbl_adsoyad_value.TabIndex = 6;
            this.lbl_adsoyad_value.Text = "Null Null";
            // 
            // tb_sifre
            // 
            this.tb_sifre.Location = new System.Drawing.Point(134, 96);
            this.tb_sifre.Name = "tb_sifre";
            this.tb_sifre.Size = new System.Drawing.Size(150, 29);
            this.tb_sifre.TabIndex = 7;
            // 
            // mskd_telefon
            // 
            this.mskd_telefon.Location = new System.Drawing.Point(134, 132);
            this.mskd_telefon.Mask = "(000)-00-000-00-00";
            this.mskd_telefon.Name = "mskd_telefon";
            this.mskd_telefon.Size = new System.Drawing.Size(149, 29);
            this.mskd_telefon.TabIndex = 8;
            // 
            // tb_maas
            // 
            this.tb_maas.Location = new System.Drawing.Point(133, 170);
            this.tb_maas.Name = "tb_maas";
            this.tb_maas.Size = new System.Drawing.Size(150, 29);
            this.tb_maas.TabIndex = 9;
            // 
            // btn_yenile
            // 
            this.btn_yenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(92)))), ((int)(((byte)(231)))));
            this.btn_yenile.ForeColor = System.Drawing.Color.White;
            this.btn_yenile.Location = new System.Drawing.Point(65, 230);
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.Size = new System.Drawing.Size(102, 44);
            this.btn_yenile.TabIndex = 10;
            this.btn_yenile.Text = "Yenile";
            this.btn_yenile.UseVisualStyleBackColor = false;
            this.btn_yenile.Click += new System.EventHandler(this.btn_yenile_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(92)))), ((int)(((byte)(231)))));
            this.btn_sil.ForeColor = System.Drawing.Color.White;
            this.btn_sil.Location = new System.Drawing.Point(181, 230);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(102, 44);
            this.btn_sil.TabIndex = 11;
            this.btn_sil.Text = "Sil";
            this.btn_sil.UseVisualStyleBackColor = false;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // gb_kassirler
            // 
            this.gb_kassirler.Controls.Add(this.dgv_kassir);
            this.gb_kassirler.Location = new System.Drawing.Point(301, 34);
            this.gb_kassirler.Name = "gb_kassirler";
            this.gb_kassirler.Size = new System.Drawing.Size(713, 240);
            this.gb_kassirler.TabIndex = 12;
            this.gb_kassirler.TabStop = false;
            this.gb_kassirler.Text = "Kassirler";
            // 
            // dgv_kassir
            // 
            this.dgv_kassir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_kassir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kassir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_kassir.Location = new System.Drawing.Point(3, 25);
            this.dgv_kassir.Name = "dgv_kassir";
            this.dgv_kassir.Size = new System.Drawing.Size(707, 212);
            this.dgv_kassir.TabIndex = 0;
            this.dgv_kassir.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_kassir_CellClick);
            // 
            // pb_eng
            // 
            this.pb_eng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_eng.Image = ((System.Drawing.Image)(resources.GetObject("pb_eng.Image")));
            this.pb_eng.Location = new System.Drawing.Point(976, 4);
            this.pb_eng.Name = "pb_eng";
            this.pb_eng.Size = new System.Drawing.Size(38, 24);
            this.pb_eng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eng.TabIndex = 18;
            this.pb_eng.TabStop = false;
            this.pb_eng.Click += new System.EventHandler(this.pb_eng_Click);
            // 
            // pb_az
            // 
            this.pb_az.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_az.Image = ((System.Drawing.Image)(resources.GetObject("pb_az.Image")));
            this.pb_az.Location = new System.Drawing.Point(922, 4);
            this.pb_az.Name = "pb_az";
            this.pb_az.Size = new System.Drawing.Size(38, 24);
            this.pb_az.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_az.TabIndex = 17;
            this.pb_az.TabStop = false;
            this.pb_az.Click += new System.EventHandler(this.pb_az_Click);
            // 
            // FrmKassirYenile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(92)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1026, 293);
            this.Controls.Add(this.pb_eng);
            this.Controls.Add(this.pb_az);
            this.Controls.Add(this.gb_kassirler);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_yenile);
            this.Controls.Add(this.tb_maas);
            this.Controls.Add(this.mskd_telefon);
            this.Controls.Add(this.tb_sifre);
            this.Controls.Add(this.lbl_adsoyad_value);
            this.Controls.Add(this.lbl_adsoyad);
            this.Controls.Add(this.lbl_maas);
            this.Controls.Add(this.lbl_telefon);
            this.Controls.Add(this.lbl_sifre);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.lbl_id);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmKassirYenile";
            this.Text = "FrmKassirYeniler";
            this.Load += new System.EventHandler(this.FrmKassirYenile_Load);
            this.gb_kassirler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kassir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_az)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.Label lbl_telefon;
        private System.Windows.Forms.Label lbl_maas;
        private System.Windows.Forms.Label lbl_adsoyad;
        private System.Windows.Forms.Label lbl_adsoyad_value;
        private System.Windows.Forms.TextBox tb_sifre;
        private System.Windows.Forms.MaskedTextBox mskd_telefon;
        private System.Windows.Forms.TextBox tb_maas;
        private System.Windows.Forms.Button btn_yenile;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.GroupBox gb_kassirler;
        private System.Windows.Forms.DataGridView dgv_kassir;
        private System.Windows.Forms.PictureBox pb_eng;
        private System.Windows.Forms.PictureBox pb_az;
    }
}