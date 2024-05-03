namespace PdfConverter
{
    partial class Hauptfenster
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonJpgAuswaehlen = new System.Windows.Forms.Button();
            this.openFileDialogPdfZsm = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewImages = new System.Windows.Forms.DataGridView();
            this.ColumnDateipfad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPdfNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeitenNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpeicher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxJpgBilder = new System.Windows.Forms.GroupBox();
            this.buttonPdfJpgEntfernen = new System.Windows.Forms.Button();
            this.buttonPdfZusammenfuegen = new System.Windows.Forms.Button();
            this.buttonPdfFunktionen = new System.Windows.Forms.Button();
            this.panelScroll = new System.Windows.Forms.Panel();
            this.groupBoxPdfBilder = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxMergedName = new System.Windows.Forms.TextBox();
            this.labelMergedName = new System.Windows.Forms.Label();
            this.buttonPdfAuswaehlen = new System.Windows.Forms.Button();
            this.radioButtonKomprimieren = new System.Windows.Forms.RadioButton();
            this.radioButtonPdfTrennen = new System.Windows.Forms.RadioButton();
            this.radioButtonJpgZuPdf = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).BeginInit();
            this.panelScroll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonJpgAuswaehlen
            // 
            this.buttonJpgAuswaehlen.Location = new System.Drawing.Point(267, 260);
            this.buttonJpgAuswaehlen.Name = "buttonJpgAuswaehlen";
            this.buttonJpgAuswaehlen.Size = new System.Drawing.Size(114, 50);
            this.buttonJpgAuswaehlen.TabIndex = 0;
            this.buttonJpgAuswaehlen.Text = "JPG Auswählen";
            this.buttonJpgAuswaehlen.UseVisualStyleBackColor = true;
            this.buttonJpgAuswaehlen.Click += new System.EventHandler(this.buttonJpgAuswaehlen_Click);
            // 
            // openFileDialogPdfZsm
            // 
            this.openFileDialogPdfZsm.FileName = "Pdf Auswählen zum Zusammenfügen";
            this.openFileDialogPdfZsm.Multiselect = true;
            this.openFileDialogPdfZsm.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogPdfZsm_FileOk);
            // 
            // dataGridViewImages
            // 
            this.dataGridViewImages.AllowUserToAddRows = false;
            this.dataGridViewImages.AllowUserToDeleteRows = false;
            this.dataGridViewImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateipfad,
            this.ColumnPdfNr,
            this.ColumnSeitenNr,
            this.ColumnName,
            this.ColumnSpeicher});
            this.dataGridViewImages.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewImages.Name = "dataGridViewImages";
            this.dataGridViewImages.ReadOnly = true;
            this.dataGridViewImages.RowHeadersWidth = 51;
            this.dataGridViewImages.RowTemplate.Height = 24;
            this.dataGridViewImages.Size = new System.Drawing.Size(509, 242);
            this.dataGridViewImages.TabIndex = 2;
            // 
            // ColumnDateipfad
            // 
            this.ColumnDateipfad.HeaderText = "Dateipfad";
            this.ColumnDateipfad.MinimumWidth = 6;
            this.ColumnDateipfad.Name = "ColumnDateipfad";
            this.ColumnDateipfad.ReadOnly = true;
            this.ColumnDateipfad.Visible = false;
            this.ColumnDateipfad.Width = 125;
            // 
            // ColumnPdfNr
            // 
            this.ColumnPdfNr.HeaderText = "Pdf Nr.";
            this.ColumnPdfNr.MinimumWidth = 6;
            this.ColumnPdfNr.Name = "ColumnPdfNr";
            this.ColumnPdfNr.ReadOnly = true;
            this.ColumnPdfNr.Width = 125;
            // 
            // ColumnSeitenNr
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnSeitenNr.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSeitenNr.HeaderText = "Seiten Nr.";
            this.ColumnSeitenNr.MinimumWidth = 6;
            this.ColumnSeitenNr.Name = "ColumnSeitenNr";
            this.ColumnSeitenNr.ReadOnly = true;
            this.ColumnSeitenNr.Width = 75;
            // 
            // ColumnName
            // 
            dataGridViewCellStyle5.Format = "ABCD123";
            dataGridViewCellStyle5.NullValue = null;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 215;
            // 
            // ColumnSpeicher
            // 
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.ColumnSpeicher.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnSpeicher.HeaderText = "Speicher";
            this.ColumnSpeicher.MinimumWidth = 6;
            this.ColumnSpeicher.Name = "ColumnSpeicher";
            this.ColumnSpeicher.ReadOnly = true;
            this.ColumnSpeicher.Width = 125;
            // 
            // groupBoxJpgBilder
            // 
            this.groupBoxJpgBilder.Location = new System.Drawing.Point(3, 5);
            this.groupBoxJpgBilder.Name = "groupBoxJpgBilder";
            this.groupBoxJpgBilder.Size = new System.Drawing.Size(577, 269);
            this.groupBoxJpgBilder.TabIndex = 3;
            this.groupBoxJpgBilder.TabStop = false;
            this.groupBoxJpgBilder.Text = "Ausgewählte JPG´s:";
            // 
            // buttonPdfJpgEntfernen
            // 
            this.buttonPdfJpgEntfernen.Location = new System.Drawing.Point(407, 260);
            this.buttonPdfJpgEntfernen.Name = "buttonPdfJpgEntfernen";
            this.buttonPdfJpgEntfernen.Size = new System.Drawing.Size(114, 50);
            this.buttonPdfJpgEntfernen.TabIndex = 4;
            this.buttonPdfJpgEntfernen.Text = "PDF/JPG Entfernen";
            this.buttonPdfJpgEntfernen.UseVisualStyleBackColor = true;
            this.buttonPdfJpgEntfernen.Click += new System.EventHandler(this.buttonPdfJpgEntfernen_Click);
            // 
            // buttonPdfZusammenfuegen
            // 
            this.buttonPdfZusammenfuegen.Location = new System.Drawing.Point(15, 302);
            this.buttonPdfZusammenfuegen.Name = "buttonPdfZusammenfuegen";
            this.buttonPdfZusammenfuegen.Size = new System.Drawing.Size(137, 50);
            this.buttonPdfZusammenfuegen.TabIndex = 5;
            this.buttonPdfZusammenfuegen.Text = "PDF Zusammenfügen";
            this.buttonPdfZusammenfuegen.UseVisualStyleBackColor = true;
            this.buttonPdfZusammenfuegen.Click += new System.EventHandler(this.buttonPdfZusammenfuegen_Click);
            // 
            // buttonPdfFunktionen
            // 
            this.buttonPdfFunktionen.Location = new System.Drawing.Point(407, 438);
            this.buttonPdfFunktionen.Name = "buttonPdfFunktionen";
            this.buttonPdfFunktionen.Size = new System.Drawing.Size(132, 54);
            this.buttonPdfFunktionen.TabIndex = 6;
            this.buttonPdfFunktionen.Text = "Image \"Funktionen\"";
            this.buttonPdfFunktionen.UseVisualStyleBackColor = true;
            this.buttonPdfFunktionen.Click += new System.EventHandler(this.buttonPdfFunktionen_Click);
            // 
            // panelScroll
            // 
            this.panelScroll.AutoScroll = true;
            this.panelScroll.Controls.Add(this.groupBoxJpgBilder);
            this.panelScroll.Location = new System.Drawing.Point(575, 12);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Size = new System.Drawing.Size(583, 274);
            this.panelScroll.TabIndex = 8;
            // 
            // groupBoxPdfBilder
            // 
            this.groupBoxPdfBilder.Location = new System.Drawing.Point(0, 5);
            this.groupBoxPdfBilder.Name = "groupBoxPdfBilder";
            this.groupBoxPdfBilder.Size = new System.Drawing.Size(577, 269);
            this.groupBoxPdfBilder.TabIndex = 10;
            this.groupBoxPdfBilder.TabStop = false;
            this.groupBoxPdfBilder.Text = "Ausgewählte PDF´s:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBoxPdfBilder);
            this.panel1.Location = new System.Drawing.Point(575, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 274);
            this.panel1.TabIndex = 11;
            // 
            // textBoxMergedName
            // 
            this.textBoxMergedName.AccessibleName = "ABCD";
            this.textBoxMergedName.Location = new System.Drawing.Point(12, 274);
            this.textBoxMergedName.Name = "textBoxMergedName";
            this.textBoxMergedName.Size = new System.Drawing.Size(184, 22);
            this.textBoxMergedName.TabIndex = 12;
            this.textBoxMergedName.Text = "Keine Sonderzeichen!";
            this.textBoxMergedName.Click += new System.EventHandler(this.textBoxMergedName_Click);
            // 
            // labelMergedName
            // 
            this.labelMergedName.AutoSize = true;
            this.labelMergedName.Location = new System.Drawing.Point(12, 255);
            this.labelMergedName.Name = "labelMergedName";
            this.labelMergedName.Size = new System.Drawing.Size(184, 16);
            this.labelMergedName.TabIndex = 13;
            this.labelMergedName.Text = "Name der Gespeicherten Pdf:";
            // 
            // buttonPdfAuswaehlen
            // 
            this.buttonPdfAuswaehlen.Location = new System.Drawing.Point(267, 316);
            this.buttonPdfAuswaehlen.Name = "buttonPdfAuswaehlen";
            this.buttonPdfAuswaehlen.Size = new System.Drawing.Size(114, 50);
            this.buttonPdfAuswaehlen.TabIndex = 14;
            this.buttonPdfAuswaehlen.Text = "PDF Auswählen";
            this.buttonPdfAuswaehlen.UseVisualStyleBackColor = true;
            this.buttonPdfAuswaehlen.Click += new System.EventHandler(this.buttonPdfAuswaehlen_Click);
            // 
            // radioButtonKomprimieren
            // 
            this.radioButtonKomprimieren.AutoSize = true;
            this.radioButtonKomprimieren.Location = new System.Drawing.Point(418, 498);
            this.radioButtonKomprimieren.Name = "radioButtonKomprimieren";
            this.radioButtonKomprimieren.Size = new System.Drawing.Size(111, 20);
            this.radioButtonKomprimieren.TabIndex = 15;
            this.radioButtonKomprimieren.TabStop = true;
            this.radioButtonKomprimieren.Text = "Komprimieren";
            this.radioButtonKomprimieren.UseVisualStyleBackColor = true;
            // 
            // radioButtonPdfTrennen
            // 
            this.radioButtonPdfTrennen.AutoSize = true;
            this.radioButtonPdfTrennen.Location = new System.Drawing.Point(418, 524);
            this.radioButtonPdfTrennen.Name = "radioButtonPdfTrennen";
            this.radioButtonPdfTrennen.Size = new System.Drawing.Size(108, 20);
            this.radioButtonPdfTrennen.TabIndex = 16;
            this.radioButtonPdfTrennen.TabStop = true;
            this.radioButtonPdfTrennen.Text = "PDF Trennen";
            this.radioButtonPdfTrennen.UseVisualStyleBackColor = true;
            // 
            // radioButtonJpgZuPdf
            // 
            this.radioButtonJpgZuPdf.AutoSize = true;
            this.radioButtonJpgZuPdf.Location = new System.Drawing.Point(418, 550);
            this.radioButtonJpgZuPdf.Name = "radioButtonJpgZuPdf";
            this.radioButtonJpgZuPdf.Size = new System.Drawing.Size(100, 20);
            this.radioButtonJpgZuPdf.TabIndex = 17;
            this.radioButtonJpgZuPdf.TabStop = true;
            this.radioButtonJpgZuPdf.Text = "JPG zu PDF";
            this.radioButtonJpgZuPdf.UseVisualStyleBackColor = true;
            // 
            // Hauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1170, 582);
            this.Controls.Add(this.radioButtonJpgZuPdf);
            this.Controls.Add(this.radioButtonPdfTrennen);
            this.Controls.Add(this.radioButtonKomprimieren);
            this.Controls.Add(this.buttonPdfAuswaehlen);
            this.Controls.Add(this.labelMergedName);
            this.Controls.Add(this.textBoxMergedName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelScroll);
            this.Controls.Add(this.buttonPdfFunktionen);
            this.Controls.Add(this.buttonPdfZusammenfuegen);
            this.Controls.Add(this.buttonPdfJpgEntfernen);
            this.Controls.Add(this.dataGridViewImages);
            this.Controls.Add(this.buttonJpgAuswaehlen);
            this.Name = "Hauptfenster";
            this.Text = "Pdf Zusammenfügen";
            this.Load += new System.EventHandler(this.Hauptfenster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).EndInit();
            this.panelScroll.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonJpgAuswaehlen;
        private System.Windows.Forms.OpenFileDialog openFileDialogPdfZsm;
        private System.Windows.Forms.DataGridView dataGridViewImages;
        private System.Windows.Forms.GroupBox groupBoxJpgBilder;
        private System.Windows.Forms.Button buttonPdfJpgEntfernen;
        private System.Windows.Forms.Button buttonPdfZusammenfuegen;
        private System.Windows.Forms.Button buttonPdfFunktionen;
        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.GroupBox groupBoxPdfBilder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxMergedName;
        private System.Windows.Forms.Label labelMergedName;
        private System.Windows.Forms.Button buttonPdfAuswaehlen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateipfad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPdfNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeitenNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpeicher;
        private System.Windows.Forms.RadioButton radioButtonKomprimieren;
        private System.Windows.Forms.RadioButton radioButtonPdfTrennen;
        private System.Windows.Forms.RadioButton radioButtonJpgZuPdf;
    }
}

