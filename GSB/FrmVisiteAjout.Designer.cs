namespace GSB {
    partial class FrmVisiteAjout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panelGauche = new System.Windows.Forms.Panel();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPraticien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMotif = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.panelDroit = new System.Windows.Forms.Panel();
            this.dgvVisites = new System.Windows.Forms.DataGridView();
            this.panelGauche.SuspendLayout();
            this.grpbox.SuspendLayout();
            this.panelDroit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGauche
            // 
            this.panelGauche.Controls.Add(this.grpbox);
            this.panelGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGauche.Location = new System.Drawing.Point(0, 93);
            this.panelGauche.Name = "panelGauche";
            this.panelGauche.Size = new System.Drawing.Size(321, 404);
            this.panelGauche.TabIndex = 13;
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.btnAjouter);
            this.grpbox.Controls.Add(this.label1);
            this.grpbox.Controls.Add(this.label3);
            this.grpbox.Controls.Add(this.cbxPraticien);
            this.grpbox.Controls.Add(this.label2);
            this.grpbox.Controls.Add(this.cbxMotif);
            this.grpbox.Controls.Add(this.dtpDate);
            this.grpbox.Location = new System.Drawing.Point(12, 27);
            this.grpbox.Name = "grpbox";
            this.grpbox.Size = new System.Drawing.Size(303, 310);
            this.grpbox.TabIndex = 7;
            this.grpbox.TabStop = false;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(97, 261);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(130, 23);
            this.btnAjouter.TabIndex = 6;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Praticien";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date et Heure";
            // 
            // cbxPraticien
            // 
            this.cbxPraticien.FormattingEnabled = true;
            this.cbxPraticien.Location = new System.Drawing.Point(97, 61);
            this.cbxPraticien.Name = "cbxPraticien";
            this.cbxPraticien.Size = new System.Drawing.Size(200, 21);
            this.cbxPraticien.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motif";
            // 
            // cbxMotif
            // 
            this.cbxMotif.FormattingEnabled = true;
            this.cbxMotif.Location = new System.Drawing.Point(97, 124);
            this.cbxMotif.Name = "cbxMotif";
            this.cbxMotif.Size = new System.Drawing.Size(200, 21);
            this.cbxMotif.TabIndex = 4;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(97, 183);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 5;
            // 
            // panelDroit
            // 
            this.panelDroit.Controls.Add(this.dgvVisites);
            this.panelDroit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDroit.Location = new System.Drawing.Point(321, 93);
            this.panelDroit.Name = "panelDroit";
            this.panelDroit.Size = new System.Drawing.Size(615, 404);
            this.panelDroit.TabIndex = 14;
            // 
            // dgvVisites
            // 
            this.dgvVisites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisites.Location = new System.Drawing.Point(0, 0);
            this.dgvVisites.Name = "dgvVisites";
            this.dgvVisites.Size = new System.Drawing.Size(615, 404);
            this.dgvVisites.TabIndex = 0;
            // 
            // FrmVisiteAjout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 534);
            this.Controls.Add(this.panelDroit);
            this.Controls.Add(this.panelGauche);
            this.Name = "FrmVisiteAjout";
            this.Text = "FrmVisiteAjout";
            this.Load += new System.EventHandler(this.FrmVisiteAjout_Load);
            this.Controls.SetChildIndex(this.panelGauche, 0);
            this.Controls.SetChildIndex(this.panelDroit, 0);
            this.panelGauche.ResumeLayout(false);
            this.grpbox.ResumeLayout(false);
            this.grpbox.PerformLayout();
            this.panelDroit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGauche;
        private System.Windows.Forms.Panel panelDroit;
        private System.Windows.Forms.ComboBox cbxMotif;
        private System.Windows.Forms.ComboBox cbxPraticien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dgvVisites;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.GroupBox grpbox;
    }
}