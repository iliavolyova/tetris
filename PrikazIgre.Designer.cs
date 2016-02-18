namespace Tetris
{
    partial class PrikazIgre
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panelSljedeciDrugi = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_bonus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelSljedeciPrvi = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_nivo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_rez = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_brzina = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::Tetris.Properties.Resources.bs_bright;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 553);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(314, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lbl_brzina);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbl_nivo);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(434, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 530);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackgroundImage = global::Tetris.Properties.Resources.box2;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel7.Controls.Add(this.panelSljedeciDrugi);
            this.panel7.Location = new System.Drawing.Point(1, 349);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(219, 132);
            this.panel7.TabIndex = 5;
            // 
            // panelSljedeciDrugi
            // 
            this.panelSljedeciDrugi.Location = new System.Drawing.Point(57, 19);
            this.panelSljedeciDrugi.Name = "panelSljedeciDrugi";
            this.panelSljedeciDrugi.Size = new System.Drawing.Size(100, 100);
            this.panelSljedeciDrugi.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::Tetris.Properties.Resources.box1;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lbl_bonus);
            this.panel6.Location = new System.Drawing.Point(5, 134);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 36);
            this.panel6.TabIndex = 4;
            // 
            // lbl_bonus
            // 
            this.lbl_bonus.AutoSize = true;
            this.lbl_bonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_bonus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_bonus.Location = new System.Drawing.Point(5, 5);
            this.lbl_bonus.Margin = new System.Windows.Forms.Padding(3, 6, 0, 2);
            this.lbl_bonus.Name = "lbl_bonus";
            this.lbl_bonus.Size = new System.Drawing.Size(18, 20);
            this.lbl_bonus.TabIndex = 0;
            this.lbl_bonus.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tetris.Properties.Resources.smjer_dolje;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 487);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::Tetris.Properties.Resources.box2;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel4.Controls.Add(this.panelSljedeciPrvi);
            this.panel4.Location = new System.Drawing.Point(0, 211);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(219, 132);
            this.panel4.TabIndex = 4;
            // 
            // panelSljedeciPrvi
            // 
            this.panelSljedeciPrvi.Location = new System.Drawing.Point(57, 19);
            this.panelSljedeciPrvi.Name = "panelSljedeciPrvi";
            this.panelSljedeciPrvi.Size = new System.Drawing.Size(100, 100);
            this.panelSljedeciPrvi.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(0, 183);
            this.label5.Margin = new System.Windows.Forms.Padding(10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sljedeći";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(0, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bonus";
            // 
            // lbl_nivo
            // 
            this.lbl_nivo.AutoSize = true;
            this.lbl_nivo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_nivo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_nivo.Location = new System.Drawing.Point(0, 75);
            this.lbl_nivo.Margin = new System.Windows.Forms.Padding(10);
            this.lbl_nivo.Name = "lbl_nivo";
            this.lbl_nivo.Size = new System.Drawing.Size(80, 25);
            this.lbl_nivo.TabIndex = 4;
            this.lbl_nivo.Text = "Nivo: 1";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Tetris.Properties.Resources.box1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.lbl_rez);
            this.panel3.Location = new System.Drawing.Point(5, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 36);
            this.panel3.TabIndex = 3;
            // 
            // lbl_rez
            // 
            this.lbl_rez.AutoSize = true;
            this.lbl_rez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_rez.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_rez.Location = new System.Drawing.Point(5, 5);
            this.lbl_rez.Margin = new System.Windows.Forms.Padding(3, 6, 0, 2);
            this.lbl_rez.Name = "lbl_rez";
            this.lbl_rez.Size = new System.Drawing.Size(18, 20);
            this.lbl_rez.TabIndex = 0;
            this.lbl_rez.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rezultat";
            // 
            // lbl_brzina
            // 
            this.lbl_brzina.AutoSize = true;
            this.lbl_brzina.BackColor = System.Drawing.Color.Transparent;
            this.lbl_brzina.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_brzina.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_brzina.Location = new System.Drawing.Point(100, 75);
            this.lbl_brzina.Margin = new System.Windows.Forms.Padding(10);
            this.lbl_brzina.Name = "lbl_brzina";
            this.lbl_brzina.Size = new System.Drawing.Size(109, 25);
            this.lbl_brzina.TabIndex = 8;
            this.lbl_brzina.Text = "Brzina: 1x";
            // 
            // PrikazIgre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PrikazIgre";
            this.ShowIcon = false;
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrikazIgre_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_nivo;
        private System.Windows.Forms.Label lbl_rez;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelSljedeciPrvi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_bonus;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panelSljedeciDrugi;
        private System.Windows.Forms.Label lbl_brzina;
    }
}