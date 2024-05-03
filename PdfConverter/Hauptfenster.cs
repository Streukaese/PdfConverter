using Aspose.Pdf;
using Aspose.Pdf.Facades;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfConverter
{
                                    // "System.Windows.Forms." MUSS wegen KONFLIKT mit "Apose.Pdf.Facades;"
    public partial class Hauptfenster : System.Windows.Forms.Form
    {
        public Hauptfenster()
        {
            InitializeComponent();
        }

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PdfPictureBox> pdfPictureBoxes = new List<PdfPictureBox>();
        private List<string> GetDateienFromDataGridView()
        {
            List<string> dateiPfade = new List<string>();

            // Annahme: Der Name der Spalte mit den Dateipfaden ist "ColumnDateipfad"
            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
                if (row.Cells["ColumnDateipfad"].Value != null)
                {
                    string dateipfad = row.Cells["ColumnDateipfad"].Value.ToString();
                    dateiPfade.Add(dateipfad);
                }
            }

            return dateiPfade;
        }
        readonly Dictionary<int, BilddateiInfo> dateien = new Dictionary<int, BilddateiInfo>();

        private void Hauptfenster_Load(object sender, EventArgs e)
        {
            openFileDialogPdfZsm = new OpenFileDialog();
        }

        // TODO - Keine Doppelten Daten wenn Pdf oder Png mehr als 1 Seite hat
        void AddInfoDgv(BilddateiInfo d)
        {
            int index = dataGridViewImages.Rows.Add();
            dataGridViewImages.Rows[index].Cells["ColumnDateipfad"].Value = d.Dateipfad;
            dataGridViewImages.Rows[index].Cells["ColumnPdfNr"].Value = d.PdfNr;
            dataGridViewImages.Rows[index].Cells["ColumnSeitenNr"].Value = d.SeitenNr;
            dataGridViewImages.Rows[index].Cells["ColumnName"].Value = d.Name;
            dataGridViewImages.Rows[index].Cells["ColumnSpeicher"].Value = d.Speicher;
        }

        void MergeJpg()
        {
            // ToDo - Jpg werden Ineinander zusammengefügt - Bilder sollen Untereinander eingefügt werden (Randlos/Rand?|| Wahl zwischen beiden`?)

            string name = textBoxMergedName.Text.Trim();
            string vordefinierterText = "Keine Sonderzeichen!";
            if (name.Length <= 0 || name == vordefinierterText)
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Dateinamen ein.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMergedName.Focus();
                return;
            }

            List<string> jpgFiles = GetDateienFromDataGridView();

            if(jpgFiles.Count > 0)
            {
                Bitmap mergedImage = null;
                foreach(string jpgFile in jpgFiles)
                {
                    using(Bitmap image = new Bitmap(jpgFile))
                    {
                        if(mergedImage == null)
                        {
                            mergedImage = new Bitmap(image);
                        }
                        else
                        {
                            using(Graphics g = Graphics.FromImage(mergedImage))
                            {
                                g.DrawImage(image, Point.Empty);
                            }
                        }
                    }
                }
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string outputPath = Path.Combine(desktopPath, $"{name}.jpg");

                mergedImage.Save(outputPath, ImageFormat.Jpeg);

                MessageBox.Show("Die JPG-Dateien wurden erfolgreich zusammengeführt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Es wurden keine JPG-Dateien ausgewählt.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void MergePdf()
        {
            string name = textBoxMergedName.Text;
            string vordefinierterText = "Keine Sonderzeichen!";
            if (name.Length <= 0 || name == vordefinierterText)
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Dateinamen ein.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMergedName.Focus();
                return;
            }

            PdfFileEditor pdfFileEditor = new PdfFileEditor();

            // Holt Liste der Dateipfade aus der DGV
            List<string> pdfDateien = GetDateienFromDataGridView();

            // Zum einbinden vorhandener Lizensen
            //Aspose.Pdf.License licensePDF = new Aspose.Pdf.License();
            //licensePDF.SetLicense("Aspose.PDF.lic");

            // Entfernt duplikate aus der Liste der Dateipfade(mehrseitige PDF´s == 1 < DGV)
            pdfDateien = pdfDateien.Distinct().ToList();

            if (pdfDateien.Count > 0)
            {
                // Konvertiert Liste der Dateipfade in ein Array
                string[] filesArray = pdfDateien.ToArray(); 

                // Merge PDF-Dateien 
                pdfFileEditor.Concatenate(filesArray, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".pdf"));
                MessageBox.Show("Die PDF-Dateien wurden erfolgreich zusammengeführt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Es wurden keine PDF-Dateien ausgewählt.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}

        void OpenJpg()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Joint Photographic Experts Group (*.jpg)|*.jpg|"
                + "ABC (*.pdf)|*.pdf";
                // TODO - png Anzeigen + Konvertieren in PDF
                //+ "W3C Portable Network Graphics (*.png)|*.png";
            ofd.Multiselect = true;
            if (ofd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            foreach (String filename in ofd.FileNames)
            {
                // Zum aufrufen der Parameter für die DGV
                FileInfo fileInfo = new FileInfo(filename);

                // Statt PictureBox -> PdfPictureBox || Klasse "PdfPictureBox" wurde erweitert
                PdfPictureBox pictureBoxJpgBild = new PdfPictureBox();

                // Bild öffnen
                FileStream imageStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                pictureBoxJpgBild.Image = System.Drawing.Image.FromStream(imageStream);
                pictureBoxJpgBild.Location = new System.Drawing.Point(6 + pictureBoxes.Count * (182 + 6), 21);
                pictureBoxJpgBild.Name = "pictureBoxPdfBild" + pictureBoxes.Count;
                pictureBoxJpgBild.Size = new System.Drawing.Size(182, 211);
                pictureBoxJpgBild.TabIndex = 1 + pictureBoxes.Count;
                pictureBoxJpgBild.TabStop = false;
                pictureBoxJpgBild.BorderStyle = BorderStyle.Fixed3D;
                pictureBoxJpgBild.SizeMode = PictureBoxSizeMode.StretchImage;
                groupBoxJpgBilder.Controls.Add(pictureBoxJpgBild);
                pictureBoxes.Add(pictureBoxJpgBild);
                groupBoxJpgBilder.Size = new System.Drawing.Size(6 + pictureBoxes.Count * (182 + 6), 242);

                // Parameter in die DGV einfügen
                string dateipfad = filename; //openFileDialogPdfZsm.FileName;
                string PdfNr = "Nr." + 1;
                string seitenNr = "Seite " + seitenAnzahlDgv;
                string name = fileInfo.Name;
                // TODO Kybi to Kb to MB - Anzeigen der Kürzel "kb" / "mb" - 
                double speicher = fileInfo.Length;
                BilddateiInfo d = new BilddateiInfo(dateipfad, PdfNr, seitenNr, name, speicher);
                AddInfoDgv(d);
                seitenAnzahlDgv++;
            }
        }

        // Seiten/Pdf Nr FÜR DGV
        int seitenAnzahlDgv = 1;
        int selectedPdfCount = 0;
        void OpenPdf()
        {
            // TODO - AUFRÄUMEN!!!
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Adobe Portable Document Format (*.pdf)|*.pdf|"
                        +"Joint Photographic Experts Group(*.jpg)| *.jpg";
            //Adobe Portable Document Format (*.pdf)|*.pdf|Alle Dateien (*.*)|*.*
            ofd.Multiselect = true;
            ofd.CheckFileExists = true;

            if (ofd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            foreach (String filename in ofd.FileNames)
            {
                PdfDocument pdfDocument = PdfDocument.Load(filename);

                FileInfo fileInfo = new FileInfo(filename);                 // Zum aufrufen der Parameter für die DGV

                if (pdfDocument.PageCount > 0)
                {
                    selectedPdfCount++;
                    // Wähle die erste Seite des PDF-Dokuments aus
                    // pdfPage = pdfDocument.GetPage(0);

                    for (int seite = 0; seite < pdfDocument.PageCount; seite++)
                    {
                        // Konvertiere die PDF-Seite in ein Bild
                        Image imagePdf = pdfDocument.Render(seite, 180, 200, 300, 300, PdfRenderFlags.Annotations);    // Renderung Anpassen
                        PdfPictureBox pictureBoxPdfBild = new PdfPictureBox();
                        pictureBoxPdfBild.Location = new System.Drawing.Point(6 + pdfPictureBoxes.Count * (182 + 6), 21);
                        pictureBoxPdfBild.Name = "pdfPictureBoxBild" + pdfPictureBoxes.Count;
                        pictureBoxPdfBild.Size = new System.Drawing.Size(185, 230);
                        pictureBoxPdfBild.TabIndex = 9;
                        pictureBoxPdfBild.TabStop = false;
                        pictureBoxPdfBild.Image = imagePdf;
                        //pictureBoxPdfBild.SizeMode = PictureBoxSizeMode.AutoSize;
                        pdfPictureBoxes.Add(pictureBoxPdfBild);
                        groupBoxPdfBilder.Controls.Add(pictureBoxPdfBild);
                        //pdfPictureBoxBild.Controls.Add(pictureBoxPdfBild);      // Benötigt???

                        // Parameter in die DGV einfügen
                        string dateipfad = filename;
                        //foreach(pdfDocument != dataGridViewImages.Columns["ColumnName"].Name.)
                        //{

                        //}
                        string PdfNr = "Pdf Nr." + selectedPdfCount;
                        string seitenNr = "Seiten Nr. " + seitenAnzahlDgv;
                        // TODO Name Formatieren/Gekürzt anzeigen (jpg/pdf -> Hervorgehoben)
                        string name = fileInfo.Name;
                        // TODO Kybi to Kb to MB - Anzeigen der Kürzel "kb" / "mb" - 
                        double speicher = fileInfo.Length;
                        BilddateiInfo d = new BilddateiInfo(dateipfad, PdfNr, seitenNr, name, speicher);
                        AddInfoDgv(d);
                        seitenAnzahlDgv++;
                    }
                    groupBoxPdfBilder.Size = new System.Drawing.Size(6 + pdfPictureBoxes.Count * (182 + 6), 269);
                }   
            }
        }

        void JpgZuPdf()
        {
            string name = textBoxMergedName.Text;
            string vordefinierterText = "Keine Sonderzeichen!";
            if (name.Length <= 0 || name == vordefinierterText)
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Dateinamen ein.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMergedName.Focus();
                return;
            }

            // Erzeuge ein neues Document-Objekt
            Document pdfDocument = new Document();

            // Hole die Liste der Dateipfade aus der DataGridView
            List<string> jpgFiles = GetDateienFromDataGridView();

            if (jpgFiles.Count > 0)
            {
                // Durchlaufe die Liste der JPG-Dateien und füge sie dem PDF-Dokument hinzu
                foreach (string jpgFile in jpgFiles)
                {
                    // Lade das JPG-Bild und füge es als Seite zum PDF-Dokument hinzu
                    using (FileStream stream = new FileStream(jpgFile, FileMode.Open))
                    {
                        pdfDocument.Pages.Add(stream);
                    }
                }

                // Speichere das PDF-Dokument
                pdfDocument.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".pdf"));

                MessageBox.Show("Die JPG-Dateien wurden erfolgreich zu einer PDF-Datei zusammengeführt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Es wurden keine JPG-Dateien ausgewählt.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //---------------------------------------------------------------

            //string name = textBoxMergedName.Text;
            //string vordefinierterText = "Keine Sonderzeichen!";
            //if (name.Length <= 0 || name == vordefinierterText)
            //{
            //    MessageBox.Show("Bitte geben Sie einen gültigen Dateinamen ein.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    textBoxMergedName.Focus();
            //    return;
            //}

            //// Erzeuge ein neues PdfFileEditor-Objekt
            //PdfFileEditor pdfFileEditor = new PdfFileEditor();

            //// Hole die Liste der Dateipfade aus der DataGridView
            //List<string> pdfFiles = GetDateienFromDataGridView();

            //if(pdfFiles.Count > 0 )
            //{
            //    // Array für Dateipfade der PDF-Dateien
            //    string[] filesArray = pdfFiles.ToArray();

            //    // Führe die PDF-Dateien zusammen
            //    pdfFileEditor.Concatenate(filesArray, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".pdf"));

            //    MessageBox.Show("Die JPG-Dateien wurden erfolgreich zusammengeführt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Es wurden keine JPG-Dateien ausgewählt.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            
            //---------------------------------------------------------------

            //List<string> imagePaths = GetDateienFromDataGridView();

            //// Erstelle ein neues PDF-Dokument
            //Document pdfDoc = new Document();

            //// Durchlaufe alle Bilder in der Liste
            //foreach (string imagePath in imagePaths)
            //{
            //    // Lade das Bild in ein Stream
            //    using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            //    {
            //        var image = System.Drawing.Image.FromStream(imageStream);
            //        var page = pdfDoc.Pages.Add();
            //        page.Resources.Images.Add(image);
            //    }
            //}

            //--------------------------------------------------------

            //string name = textBoxMergedName.Text;
            //if (name.Length <= 0)
            //{
            //    textBoxMergedName.Focus();
            //    return;
            //}

            //// Lade die JPG-Datei in eine Bitmap
            //Bitmap bitmap = new Bitmap("deine_jpg_datei.jpg");

            //// Erzeuge ein neues PDF-Dokument
            //PdfDocument document = new PdfDocument();

            //// Iteriere über jede Seite in der JPG-Datei
            //for (int i = 0; i < bitmap.GetFrameCount(FrameDimension.Page); i++)
            //{
            //    // Erzeuge eine neue Seite im PDF-Dokument
            //    PdfPage page = document.AddPage();

            //    // Erzeuge ein XGraphics-Objekt für die Seite
            //    XGraphics gfx = XGraphics.FromPdfPage(page);

            //    // Lade das aktuelle Bild aus der JPG-Datei
            //    bitmap.SelectActiveFrame(FrameDimension.Page, i);

            //    // Konvertiere das Bitmap-Bild in ein XImage
            //    XImage image = XImage.FromGdiPlusImage(bitmap);

            //    // Bestimme die Größe des Bildes und skaliere es, um auf die Seite zu passen
            //    XSize scaledSize = new XSize(page.Width, page.Width * (image.PointHeight / (double)image.PointWidth));

            //    // Berechne die Position, um das Bild zentriert auf die Seite zu platzieren
            //    double x = (page.Width - scaledSize.Width) / 2;
            //    double y = (page.Height - scaledSize.Height) / 2;

            //    // Zeichne das Bild auf die Seite
            //    gfx.DrawImage(image, x, y, scaledSize.Width, scaledSize.Height);
            //}

            //// Speichere das PDF-Dokument
            //document.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".pdf"));
        }

        void DateiKomprimieren()
        {

        }

        void PdfTrennen()
        {

        }

        private void buttonJpgAuswaehlen_Click(object sender, EventArgs e)
        {
            OpenJpg();
        }

        private void buttonPdfAuswaehlen_Click(object sender, EventArgs e)
        {
            OpenPdf();
        }

        private void buttonPdfJpgEntfernen_Click(object sender, EventArgs e)
        {
            int index = -1;

            if (dataGridViewImages.SelectedRows.Count == 1)
            {
                index = dataGridViewImages.SelectedRows[0].Index;
            }
            else if (dataGridViewImages.SelectedCells.Count == 1)
            {
                index = dataGridViewImages.SelectedCells[0].RowIndex;
            }
            if (index == -1)
            {
                return;
            }
            
            // TODO - Aktualisierung der DGV sowie JPG u. PDF bewärkstelligen
            dataGridViewImages.Rows.RemoveAt(index);
            groupBoxJpgBilder.Refresh();
            groupBoxPdfBilder.Refresh();
            //pictureBoxes.Remove(index);
        }

        private void buttonPdfZusammenfuegen_Click(object sender, EventArgs e)
        {
            if(pdfPictureBoxes.Count >= 1)
            {
                MergePdf();
            }
            else
            {
                MergeJpg();
            }
        }
        public void FunktionenAuswahl()
        {
            if (radioButtonJpgZuPdf.Checked || radioButtonKomprimieren.Checked || radioButtonPdfTrennen.Checked)
            {
                if (radioButtonJpgZuPdf.Checked == true)
                {
                    JpgZuPdf();
                    MessageBox.Show("Die JPG-Dateien wurden erfolgreich umgewandelt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (radioButtonKomprimieren.Checked == true)
                {
                    DateiKomprimieren();
                }
                else if (radioButtonPdfTrennen.Checked == true)
                {
                    PdfTrennen();
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Kategorie aus!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonPdfFunktionen_Click(object sender, EventArgs e)
        {

            //bool jpgZuPdf = checkedListBoxPdfFunktionen.CheckedItems.Contains("JPG zu PDF");
            //bool komprimieren = checkedListBoxPdfFunktionen.CheckedItems.Contains("Komprimieren");
            //bool pdfTrennen = checkedListBoxPdfFunktionen.CheckedItems.Contains("Pdf trennen");
            //if (radioButtonJpgZuPdf.Checked || radioButtonKomprimieren.Checked || radioButtonPdfTrennen.Checked)
            //{
            //    if (radioButtonJpgZuPdf.Checked == true)
            //    {
            //        JpgZuPdf();
            //        MessageBox.Show("Die JPG-Dateien wurden erfolgreich umgewandelt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (radioButtonKomprimieren.Checked == true)
            //    {
            //        DateiKomprimieren();
            //    }
            //    else if (radioButtonPdfTrennen.Checked == true)
            //    {
            //        PdfTrennen();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Bitte wählen Sie eine Kategorie aus!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            string name = textBoxMergedName.Text.Trim();
            string vordefinierterText = "Keine Sonderzeichen!";
            if (name.Length <= 0 || name == vordefinierterText)
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Dateinamen ein.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMergedName.Focus();
                return;
            }
            else
            {
                FunktionenAuswahl();
            }
        }

        private void openFileDialogPdfZsm_FileOk(object sender, CancelEventArgs e)
        {
            // TODO - Gesamt Pdf generieren und Speichern
        }

        private void textBoxMergedName_Click(object sender, EventArgs e)
        {
            textBoxMergedName.Clear();
        }
    }
}
