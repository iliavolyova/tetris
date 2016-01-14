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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_rez = new System.Windows.Forms.Label();
            this.lbl_nivo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_bonus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_smjer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(115, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 372);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(465, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 124);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rezultat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(482, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slijedi:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(465, 201);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(116, 124);
            this.panel3.TabIndex = 2;
            // 
            // lbl_rez
            // 
            this.lbl_rez.AutoSize = true;
            this.lbl_rez.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_rez.Location = new System.Drawing.Point(38, 49);
            this.lbl_rez.Name = "lbl_rez";
            this.lbl_rez.Size = new System.Drawing.Size(30, 36);
            this.lbl_rez.TabIndex = 4;
            this.lbl_rez.Text = "0";
            // 
            // lbl_nivo
            // 
            this.lbl_nivo.AutoSize = true;
            this.lbl_nivo.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_nivo.Location = new System.Drawing.Point(38, 154);
            this.lbl_nivo.Name = "lbl_nivo";
            this.lbl_nivo.Size = new System.Drawing.Size(30, 36);
            this.lbl_nivo.TabIndex = 6;
            this.lbl_nivo.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(20, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nivo:";
            // 
            // lbl_bonus
            // 
            this.lbl_bonus.AutoSize = true;
            this.lbl_bonus.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_bonus.Location = new System.Drawing.Point(31, 252);
            this.lbl_bonus.Name = "lbl_bonus";
            this.lbl_bonus.Size = new System.Drawing.Size(30, 36);
            this.lbl_bonus.TabIndex = 8;
            this.lbl_bonus.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(13, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "Bonus:";
            // 
            // lbl_smjer
            // 
            this.lbl_smjer.AutoSize = true;
            this.lbl_smjer.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_smjer.Location = new System.Drawing.Point(12, 328);
            this.lbl_smjer.Name = "lbl_smjer";
            this.lbl_smjer.Size = new System.Drawing.Size(84, 33);
            this.lbl_smjer.TabIndex = 9;
            this.lbl_smjer.Text = "(smjer)";
            // 
            // PrikazIgre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 397);
            this.Controls.Add(this.lbl_smjer);
            this.Controls.Add(this.lbl_bonus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_nivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_rez);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PrikazIgre";
            this.ShowIcon = false;
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrikazIgre_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_rez;
        private System.Windows.Forms.Label lbl_nivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_bonus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_smjer;
    }
}