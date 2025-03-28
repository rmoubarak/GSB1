namespace GSB
{
    partial class FrmVisiteMaj
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRendezVous = new System.Windows.Forms.Label();
            this.btnModifie = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dgvVisitesMaj = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitesMaj)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblNom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblRendezVous);
            this.panel2.Controls.Add(this.btnModifie);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(505, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 384);
            this.panel2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "est remi au";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(148, 79);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "label3";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(148, 23);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 4;
            this.lblNom.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "prévu initialement le";
            // 
            // lblRendezVous
            // 
            this.lblRendezVous.AutoSize = true;
            this.lblRendezVous.Location = new System.Drawing.Point(25, 23);
            this.lblRendezVous.Name = "lblRendezVous";
            this.lblRendezVous.Size = new System.Drawing.Size(106, 13);
            this.lblRendezVous.TabIndex = 2;
            this.lblRendezVous.Text = "Le rendez-vous chez";
            // 
            // btnModifie
            // 
            this.btnModifie.Location = new System.Drawing.Point(87, 211);
            this.btnModifie.Name = "btnModifie";
            this.btnModifie.Size = new System.Drawing.Size(75, 23);
            this.btnModifie.TabIndex = 1;
            this.btnModifie.Text = "Modifier";
            this.btnModifie.UseVisualStyleBackColor = true;
            this.btnModifie.Click += new System.EventHandler(this.btnModifie_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(28, 158);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // dgvVisitesMaj
            // 
            this.dgvVisitesMaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitesMaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisitesMaj.Location = new System.Drawing.Point(0, 29);
            this.dgvVisitesMaj.Name = "dgvVisitesMaj";
            this.dgvVisitesMaj.Size = new System.Drawing.Size(505, 384);
            this.dgvVisitesMaj.TabIndex = 14;
            this.dgvVisitesMaj.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisitesMaj_CellContentClick);
            this.dgvVisitesMaj.SelectionChanged += new System.EventHandler(this.dgvVisitesMaj_SelectionChanged);
            // 
            // FrmVisiteMaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvVisitesMaj);
            this.Controls.Add(this.panel2);
            this.Name = "FrmVisiteMaj";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmVisiteMaj_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvVisitesMaj, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitesMaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnModifie;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dgvVisitesMaj;
        private System.Windows.Forms.Label lblRendezVous;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label label2;
    }
}