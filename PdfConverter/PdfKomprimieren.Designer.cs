namespace PdfConverter
{
    partial class PdfKomprimieren
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonPdfAuswaehlen = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.labelDateiname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonPdfAuswaehlen
            // 
            this.buttonPdfAuswaehlen.Location = new System.Drawing.Point(12, 166);
            this.buttonPdfAuswaehlen.Name = "buttonPdfAuswaehlen";
            this.buttonPdfAuswaehlen.Size = new System.Drawing.Size(99, 44);
            this.buttonPdfAuswaehlen.TabIndex = 0;
            this.buttonPdfAuswaehlen.Text = "Pdf Auswählen";
            this.buttonPdfAuswaehlen.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Niedrig",
            "Mittel",
            "Hoch"});
            this.checkedListBox1.Location = new System.Drawing.Point(199, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(126, 55);
            this.checkedListBox1.TabIndex = 1;
            // 
            // labelDateiname
            // 
            this.labelDateiname.AutoSize = true;
            this.labelDateiname.Location = new System.Drawing.Point(196, 70);
            this.labelDateiname.Name = "labelDateiname";
            this.labelDateiname.Size = new System.Drawing.Size(83, 16);
            this.labelDateiname.TabIndex = 2;
            this.labelDateiname.Text = "\"Dateiname\"";
            // 
            // PdfKomprimieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(337, 344);
            this.Controls.Add(this.labelDateiname);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.buttonPdfAuswaehlen);
            this.Name = "PdfKomprimieren";
            this.Text = "Pdf Komprimieren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonPdfAuswaehlen;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label labelDateiname;
    }
}