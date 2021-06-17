namespace SuperStoreProject
{
    partial class FrmSifreBerpa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifreBerpa));
            this.panel_top = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.btn_berpa_kodu = new System.Windows.Forms.Button();
            this.panel_check_code = new System.Windows.Forms.Panel();
            this.btn_daxil_et = new System.Windows.Forms.Button();
            this.tb_kod = new System.Windows.Forms.TextBox();
            this.panel_berpa = new System.Windows.Forms.Panel();
            this.btn_sifirla = new System.Windows.Forms.Button();
            this.lbl_tekrar = new System.Windows.Forms.Label();
            this.lbl_yeni_sifre = new System.Windows.Forms.Label();
            this.tb_tekrar = new System.Windows.Forms.TextBox();
            this.tb_yeni_sifre = new System.Windows.Forms.TextBox();
            this.pb_eng = new System.Windows.Forms.PictureBox();
            this.pb_az = new System.Windows.Forms.PictureBox();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_check_code.SuspendLayout();
            this.panel_berpa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_az)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(122)))), ((int)(((byte)(230)))));
            this.panel_top.Controls.Add(this.pictureBox1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(553, 41);
            this.panel_top.TabIndex = 0;
            this.panel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_top_MouseDown);
            this.panel_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_top_MouseMove);
            this.panel_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_top_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(516, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_email.Location = new System.Drawing.Point(71, 88);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(59, 21);
            this.lbl_email.TabIndex = 1;
            this.lbl_email.Text = "Email :";
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.tb_email.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_email.ForeColor = System.Drawing.Color.White;
            this.tb_email.Location = new System.Drawing.Point(136, 83);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(379, 26);
            this.tb_email.TabIndex = 2;
            // 
            // btn_berpa_kodu
            // 
            this.btn_berpa_kodu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btn_berpa_kodu.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_berpa_kodu.ForeColor = System.Drawing.Color.White;
            this.btn_berpa_kodu.Location = new System.Drawing.Point(364, 125);
            this.btn_berpa_kodu.Name = "btn_berpa_kodu";
            this.btn_berpa_kodu.Size = new System.Drawing.Size(151, 37);
            this.btn_berpa_kodu.TabIndex = 3;
            this.btn_berpa_kodu.Text = "Bərpa Kodu";
            this.btn_berpa_kodu.UseVisualStyleBackColor = false;
            this.btn_berpa_kodu.Click += new System.EventHandler(this.btn_berpa_kodu_Click);
            // 
            // panel_check_code
            // 
            this.panel_check_code.Controls.Add(this.btn_daxil_et);
            this.panel_check_code.Controls.Add(this.tb_kod);
            this.panel_check_code.Location = new System.Drawing.Point(136, 170);
            this.panel_check_code.Name = "panel_check_code";
            this.panel_check_code.Size = new System.Drawing.Size(379, 100);
            this.panel_check_code.TabIndex = 4;
            this.panel_check_code.Visible = false;
            // 
            // btn_daxil_et
            // 
            this.btn_daxil_et.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btn_daxil_et.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_daxil_et.ForeColor = System.Drawing.Color.White;
            this.btn_daxil_et.Location = new System.Drawing.Point(228, 15);
            this.btn_daxil_et.Name = "btn_daxil_et";
            this.btn_daxil_et.Size = new System.Drawing.Size(148, 37);
            this.btn_daxil_et.TabIndex = 5;
            this.btn_daxil_et.Text = "Daxil Et";
            this.btn_daxil_et.UseVisualStyleBackColor = false;
            this.btn_daxil_et.Click += new System.EventHandler(this.btn_daxil_et_Click);
            // 
            // tb_kod
            // 
            this.tb_kod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.tb_kod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_kod.ForeColor = System.Drawing.Color.White;
            this.tb_kod.Location = new System.Drawing.Point(12, 15);
            this.tb_kod.Name = "tb_kod";
            this.tb_kod.Size = new System.Drawing.Size(202, 26);
            this.tb_kod.TabIndex = 5;
            // 
            // panel_berpa
            // 
            this.panel_berpa.Controls.Add(this.btn_sifirla);
            this.panel_berpa.Controls.Add(this.lbl_tekrar);
            this.panel_berpa.Controls.Add(this.lbl_yeni_sifre);
            this.panel_berpa.Controls.Add(this.tb_tekrar);
            this.panel_berpa.Controls.Add(this.tb_yeni_sifre);
            this.panel_berpa.Location = new System.Drawing.Point(136, 276);
            this.panel_berpa.Name = "panel_berpa";
            this.panel_berpa.Size = new System.Drawing.Size(379, 125);
            this.panel_berpa.TabIndex = 5;
            this.panel_berpa.Visible = false;
            // 
            // btn_sifirla
            // 
            this.btn_sifirla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btn_sifirla.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sifirla.ForeColor = System.Drawing.Color.White;
            this.btn_sifirla.Location = new System.Drawing.Point(188, 82);
            this.btn_sifirla.Name = "btn_sifirla";
            this.btn_sifirla.Size = new System.Drawing.Size(148, 37);
            this.btn_sifirla.TabIndex = 6;
            this.btn_sifirla.Text = "Sıfırla";
            this.btn_sifirla.UseVisualStyleBackColor = false;
            this.btn_sifirla.Click += new System.EventHandler(this.btn_sifirla_Click);
            // 
            // lbl_tekrar
            // 
            this.lbl_tekrar.AutoSize = true;
            this.lbl_tekrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tekrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_tekrar.Location = new System.Drawing.Point(64, 55);
            this.lbl_tekrar.Name = "lbl_tekrar";
            this.lbl_tekrar.Size = new System.Drawing.Size(64, 21);
            this.lbl_tekrar.TabIndex = 8;
            this.lbl_tekrar.Text = "Təkrar :";
            // 
            // lbl_yeni_sifre
            // 
            this.lbl_yeni_sifre.AutoSize = true;
            this.lbl_yeni_sifre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_yeni_sifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_yeni_sifre.Location = new System.Drawing.Point(42, 23);
            this.lbl_yeni_sifre.Name = "lbl_yeni_sifre";
            this.lbl_yeni_sifre.Size = new System.Drawing.Size(86, 21);
            this.lbl_yeni_sifre.TabIndex = 6;
            this.lbl_yeni_sifre.Text = "Yeni Şifrə :";
            // 
            // tb_tekrar
            // 
            this.tb_tekrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.tb_tekrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_tekrar.ForeColor = System.Drawing.Color.White;
            this.tb_tekrar.Location = new System.Drawing.Point(134, 50);
            this.tb_tekrar.Name = "tb_tekrar";
            this.tb_tekrar.Size = new System.Drawing.Size(202, 26);
            this.tb_tekrar.TabIndex = 7;
            // 
            // tb_yeni_sifre
            // 
            this.tb_yeni_sifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.tb_yeni_sifre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_yeni_sifre.ForeColor = System.Drawing.Color.White;
            this.tb_yeni_sifre.Location = new System.Drawing.Point(134, 18);
            this.tb_yeni_sifre.Name = "tb_yeni_sifre";
            this.tb_yeni_sifre.Size = new System.Drawing.Size(202, 26);
            this.tb_yeni_sifre.TabIndex = 6;
            // 
            // pb_eng
            // 
            this.pb_eng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_eng.Image = ((System.Drawing.Image)(resources.GetObject("pb_eng.Image")));
            this.pb_eng.Location = new System.Drawing.Point(503, 47);
            this.pb_eng.Name = "pb_eng";
            this.pb_eng.Size = new System.Drawing.Size(38, 24);
            this.pb_eng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eng.TabIndex = 30;
            this.pb_eng.TabStop = false;
            this.pb_eng.Click += new System.EventHandler(this.pb_eng_Click);
            // 
            // pb_az
            // 
            this.pb_az.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_az.Image = ((System.Drawing.Image)(resources.GetObject("pb_az.Image")));
            this.pb_az.Location = new System.Drawing.Point(449, 47);
            this.pb_az.Name = "pb_az";
            this.pb_az.Size = new System.Drawing.Size(38, 24);
            this.pb_az.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_az.TabIndex = 29;
            this.pb_az.TabStop = false;
            this.pb_az.Click += new System.EventHandler(this.pb_az_Click);
            // 
            // FrmSifreBerpa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Controls.Add(this.pb_eng);
            this.Controls.Add(this.pb_az);
            this.Controls.Add(this.panel_berpa);
            this.Controls.Add(this.panel_check_code);
            this.Controls.Add(this.btn_berpa_kodu);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSifreBerpa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSIfreBerpa";
            this.panel_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_check_code.ResumeLayout(false);
            this.panel_check_code.PerformLayout();
            this.panel_berpa.ResumeLayout(false);
            this.panel_berpa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_az)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Button btn_berpa_kodu;
        private System.Windows.Forms.Panel panel_check_code;
        private System.Windows.Forms.Button btn_daxil_et;
        private System.Windows.Forms.TextBox tb_kod;
        private System.Windows.Forms.Panel panel_berpa;
        private System.Windows.Forms.Button btn_sifirla;
        private System.Windows.Forms.Label lbl_tekrar;
        private System.Windows.Forms.Label lbl_yeni_sifre;
        private System.Windows.Forms.TextBox tb_tekrar;
        private System.Windows.Forms.TextBox tb_yeni_sifre;
        private System.Windows.Forms.PictureBox pb_eng;
        private System.Windows.Forms.PictureBox pb_az;
    }
}