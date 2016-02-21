namespace Tetris
{
    partial class Pravila
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pravila));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHolder = new System.Windows.Forms.Panel();
            this.panelPravila = new System.Windows.Forms.Panel();
            this.lblPravilaTekst = new System.Windows.Forms.Label();
            this.lblPravilaNaslov = new System.Windows.Forms.Label();
            this.pictureTetris = new System.Windows.Forms.PictureBox();
            this.panelDvostruki = new System.Windows.Forms.Panel();
            this.dvostrukiAnimacija = new System.Windows.Forms.PictureBox();
            this.lblDvostrukiNaslov = new System.Windows.Forms.Label();
            this.lblDvostrukiTekst = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHolder.SuspendLayout();
            this.panelPravila.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTetris)).BeginInit();
            this.panelDvostruki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvostrukiAnimacija)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelHolder, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(485, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackgroundImage = global::Tetris.Properties.Resources.line;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(92, 418);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 30);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Tetris.Properties.Resources.button;
            this.pictureBox4.Location = new System.Drawing.Point(270, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tetris.Properties.Resources.button;
            this.pictureBox3.Location = new System.Drawing.Point(180, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tetris.Properties.Resources.button;
            this.pictureBox2.Location = new System.Drawing.Point(90, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tetris.Properties.Resources.button_on;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelHolder
            // 
            this.panelHolder.AutoScroll = true;
            this.panelHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelHolder.Controls.Add(this.panelPravila);
            this.panelHolder.Controls.Add(this.panelDvostruki);
            this.panelHolder.Location = new System.Drawing.Point(10, 10);
            this.panelHolder.Margin = new System.Windows.Forms.Padding(10);
            this.panelHolder.Name = "panelHolder";
            this.panelHolder.Size = new System.Drawing.Size(456, 385);
            this.panelHolder.TabIndex = 1;
            // 
            // panelPravila
            // 
            this.panelPravila.Controls.Add(this.lblPravilaTekst);
            this.panelPravila.Controls.Add(this.lblPravilaNaslov);
            this.panelPravila.Controls.Add(this.pictureTetris);
            this.panelPravila.Location = new System.Drawing.Point(1, 1);
            this.panelPravila.Margin = new System.Windows.Forms.Padding(0);
            this.panelPravila.Name = "panelPravila";
            this.panelPravila.Size = new System.Drawing.Size(441, 222);
            this.panelPravila.TabIndex = 3;
            // 
            // lblPravilaTekst
            // 
            this.lblPravilaTekst.AutoSize = true;
            this.lblPravilaTekst.Location = new System.Drawing.Point(20, 50);
            this.lblPravilaTekst.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblPravilaTekst.Name = "lblPravilaTekst";
            this.lblPravilaTekst.Size = new System.Drawing.Size(279, 91);
            this.lblPravilaTekst.TabIndex = 2;
            this.lblPravilaTekst.Text = resources.GetString("lblPravilaTekst.Text");
            // 
            // lblPravilaNaslov
            // 
            this.lblPravilaNaslov.AutoSize = true;
            this.lblPravilaNaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPravilaNaslov.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblPravilaNaslov.Location = new System.Drawing.Point(20, 20);
            this.lblPravilaNaslov.Name = "lblPravilaNaslov";
            this.lblPravilaNaslov.Size = new System.Drawing.Size(92, 18);
            this.lblPravilaNaslov.TabIndex = 0;
            this.lblPravilaNaslov.Text = "Pravila igre";
            // 
            // pictureTetris
            // 
            this.pictureTetris.Image = global::Tetris.Properties.Resources.nasTetris;
            this.pictureTetris.Location = new System.Drawing.Point(335, 22);
            this.pictureTetris.Name = "pictureTetris";
            this.pictureTetris.Size = new System.Drawing.Size(60, 111);
            this.pictureTetris.TabIndex = 1;
            this.pictureTetris.TabStop = false;
            // 
            // panelDvostruki
            // 
            this.panelDvostruki.Controls.Add(this.dvostrukiAnimacija);
            this.panelDvostruki.Controls.Add(this.lblDvostrukiNaslov);
            this.panelDvostruki.Controls.Add(this.lblDvostrukiTekst);
            this.panelDvostruki.Location = new System.Drawing.Point(1, 1);
            this.panelDvostruki.Margin = new System.Windows.Forms.Padding(0);
            this.panelDvostruki.Name = "panelDvostruki";
            this.panelDvostruki.Size = new System.Drawing.Size(421, 662);
            this.panelDvostruki.TabIndex = 4;
            this.panelDvostruki.Visible = false;
            // 
            // dvostrukiAnimacija
            // 
            this.dvostrukiAnimacija.Image = global::Tetris.Properties.Resources.dvostrukiOblik;
            this.dvostrukiAnimacija.Location = new System.Drawing.Point(80, 123);
            this.dvostrukiAnimacija.Name = "dvostrukiAnimacija";
            this.dvostrukiAnimacija.Size = new System.Drawing.Size(288, 528);
            this.dvostrukiAnimacija.TabIndex = 1;
            this.dvostrukiAnimacija.TabStop = false;
            // 
            // lblDvostrukiNaslov
            // 
            this.lblDvostrukiNaslov.AutoSize = true;
            this.lblDvostrukiNaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDvostrukiNaslov.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDvostrukiNaslov.Location = new System.Drawing.Point(20, 20);
            this.lblDvostrukiNaslov.Name = "lblDvostrukiNaslov";
            this.lblDvostrukiNaslov.Size = new System.Drawing.Size(125, 18);
            this.lblDvostrukiNaslov.TabIndex = 5;
            this.lblDvostrukiNaslov.Text = "Dvostruki oblici";
            // 
            // lblDvostrukiTekst
            // 
            this.lblDvostrukiTekst.AutoSize = true;
            this.lblDvostrukiTekst.Location = new System.Drawing.Point(20, 50);
            this.lblDvostrukiTekst.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblDvostrukiTekst.Name = "lblDvostrukiTekst";
            this.lblDvostrukiTekst.Size = new System.Drawing.Size(399, 52);
            this.lblDvostrukiTekst.TabIndex = 0;
            this.lblDvostrukiTekst.Text = resources.GetString("lblDvostrukiTekst.Text");
            // 
            // Pravila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Pravila";
            this.Text = "Pravila";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHolder.ResumeLayout(false);
            this.panelPravila.ResumeLayout(false);
            this.panelPravila.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTetris)).EndInit();
            this.panelDvostruki.ResumeLayout(false);
            this.panelDvostruki.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvostrukiAnimacija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelHolder;
        private System.Windows.Forms.Label lblPravilaNaslov;
        private System.Windows.Forms.Label lblPravilaTekst;
        private System.Windows.Forms.PictureBox pictureTetris;
        private System.Windows.Forms.Panel panelPravila;
        private System.Windows.Forms.Label lblDvostrukiNaslov;
        private System.Windows.Forms.Panel panelDvostruki;
        private System.Windows.Forms.PictureBox dvostrukiAnimacija;
        private System.Windows.Forms.Label lblDvostrukiTekst;
    }
}