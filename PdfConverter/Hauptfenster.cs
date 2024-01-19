using Aspose.Pdf.Facades;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
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
        private List<string> GetPdfDateienFromDataGridView()
        {
            List<string> pdfDateien = new List<string>();

            // Annahme: Der Name der Spalte mit den Dateipfaden ist "ColumnDateipfad"
            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
                if (row.Cells["ColumnDateipfad"].Value != null)
                {
                    string dateipfad = row.Cells["ColumnDateipfad"].Value.ToString();
                    pdfDateien.Add(dateipfad);
                }
            }

            return pdfDateien;
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

        }

        void MergePdf()
        {

        }

        void OpenJpg()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Joint Photographic Experts Group (*.jpg)|*.jpg|"
                + "ABC (*.pdf)|*.pdf";
                //+ "W3C Portable Network Graphics (*.png)|*.png";
            ofd.Multiselect = true;
            if (ofd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            foreach (String filename in ofd.FileNames)
            {
                FileInfo fileInfo = new FileInfo(filename);                 // Zum aufrufen der Parameter für die DGV

                PdfPictureBox pictureBoxJpgBild = new PdfPictureBox();      // Statt PictureBox -> PdfPictureBox || Klasse "PdfPictureBox" wurde erweitert

                // Bild öffnen
                FileStream imageStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                // Image der Picturebox setzen - IMAGE NICHT PDF
                // TODO - Wie Pdf anzeigen - PdfPictureBox???? 
                // ggf. : GhostScript.Net - http://habjan.blogspot.com/2013/09/how-to-use-ghostscriptnet-library-to.html
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
                string dateipfad = openFileDialogPdfZsm.FileName;
                string PdfNr = "Nr." + 1;
                string seitenNr = "Seite " + seitenAnzahlDgv;
                // TODO Name Formatieren/Gekürzt anzeigen (jpg/pdf -> Hervorgehoben)
                string name = fileInfo.Name;
                // TODO Kybi to Kb to MB - Anzeigen der Kürzel "kb" / "mb" - 
                double speicher = fileInfo.Length;
                BilddateiInfo d = new BilddateiInfo(dateipfad, PdfNr, seitenNr, name, speicher);
                AddInfoDgv(d);
                seitenAnzahlDgv++;
            }
        }

        int seitenAnzahlDgv = 1;
        int selectedPdfCount = 0;
        void OpenPdf()
        {
            // TODO - AUFRÄUMEN!!!
            // TODO - Code auslagern -> ggf. nach Button Auswählen oder eigene Methoden (void PdfOeffnen || void JpgOeffnen)
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Adobe Portable Document Format (*.pdf)|*.pdf|"
                + "Joint Photographic Experts Group(*.jpg)| *.jpg";
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
            
            // Aktualisierung der DGV sowie JPG u. PDF bewärkstelligen
            dataGridViewImages.Rows.RemoveAt(index);
            groupBoxJpgBilder.Refresh();
            //pictureBoxes.Remove(index);
        }

        private void buttonPdfZusammenfuegen_Click(object sender, EventArgs e)
        {
            string name = textBoxMergedName.Text;
            if(name.Length == 0)
            {
                textBoxMergedName.Focus();
                return;
            }

            PdfFileEditor pdfFileEditor = new PdfFileEditor();

            // Hole die Liste der Dateipfade aus der DataGridView
            List<string> pdfDateien = GetPdfDateienFromDataGridView();

            if (pdfDateien.Count > 0)
            {
                // Konvertiere die Liste der Dateipfade in ein Array
                string[] filesArray = pdfDateien.ToArray();

                // Führe die PDF-Dateien zusammen
                pdfFileEditor.Concatenate(filesArray, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".pdf"));
            }
            //-----------------------------------------------------

            //List<string> pdfDateien = pdfPictureBoxes; // Rufe deine externe Liste hier auf

            //// Verwende die Liste, um Seiten zu zählen und in das Array einzufügen
            //int gesamtSeitenNummer = 1;
            //string[] filesArray = new string[pdfDateien.Count];

            //foreach (string dateipfad in pdfDateien)
            //{
            //    PdfDocument pdfDocument = PdfDocument.Load(dateipfad);

            //    for (int seitenNummer = 1; seitenNummer <= pdfDocument.PageCount; seitenNummer++)
            //    {
            //        // Erstelle einen eindeutigen Namen für die Seite
            //        string seitenName = "Seite " + gesamtSeitenNummer;

            //        // Füge die Seite zur DataGridView hinzu
            //        dataGridViewImages.Rows.Add(seitenName, dateipfad);

            //        // Füge den Dateipfad zur Liste hinzu
            //        filesArray[gesamtSeitenNummer - 1] = dateipfad;

            //        // Erhöhe die Gesamtseitennummer für jede Seite
            //        gesamtSeitenNummer++;
            //    }
            //}

            //// Verwende das Array zum Zusammenführen der PDFs
            //PdfFileEditor pdfFileEditor = new PdfFileEditor();
            //pdfFileEditor.Concatenate(filesArray, "Desktop\\Merged.pdf");


            //-----------------------------------------------------

            //PdfFileEditor pdfFileEditor = new PdfFileEditor();
            //int seitenNummer = 1;

            //for (int index = 0; index < dataGridViewImages.Rows.Count; index++)
            //{
            //    string dateipfad = dataGridViewImages.Rows[index].Cells["ColumnDateipfad"].Value.ToString();

            //    // Überprüfe, ob die Datei existiert
            //    if (File.Exists(dateipfad))
            //    {
            //        PdfDocument pdfDocument = PdfDocument.Load(dateipfad);

            //        for (int seiteIndex = 0; seiteIndex < pdfDocument.PageCount; seiteIndex++)
            //        {
            //            string seitenName = "Seite " + seitenNummer;

            //            // Füge die Seite zur DataGridView hinzu
            //            dataGridViewImages.Rows.Add(seitenName, dateipfad);

            //            // Erhöhe die Seitennummer nur für ungerade Seiten (erste Seite in einem PDF mit zwei Seiten)
            //            if (seiteIndex % 2 == 1)
            //            {
            //                seitenNummer++;
            //            }
            //        }
            //    }
            //}

            //// Erstelle ein leeres PdfDocument für die zusammengeführten Seiten
            //int seite = 0;

            //PdfDocument mergedDocument = new PdfDocument();

            //// Füge die Seiten in der Reihenfolge der DataGridView hinzu
            //foreach (DataGridViewRow row in dataGridViewImages.Rows)
            //{
            //    string dateipfad = row.Cells["ColumnDateipfad"].Value.ToString();
            //    PdfDocument document = PdfDocument.Load(dateipfad);

            //    foreach (var page in document.Pages)
            //    {
            //        // Füge die Seite zum zusammengeführten Dokument hinzu
            //        mergedDocument.AddPage(page);
            //    }
            //}

            //// Speichere das zusammengeführte Dokument
            //mergedDocument.Save("Desktop\\Merged.pdf");


            //---------------------------------------------

            //for (int index = 0; index < 3; index++)
            //{

            //    PdfFileEditor pdfFileEditor = new PdfFileEditor();

            //    string[] filesArray = new string[3];
            //    //filesArray[0] = dataGridViewImages.Columns.IndexOf("ColumnName");
            //    filesArray[0] = dataGridViewImages.Rows[index].Cells["ColumnDateipfad"].Value.ToString();
            //    filesArray[1] = dataGridViewImages.Rows[index].Cells["ColumnDateipfad"].Value.ToString();
            //    filesArray[2] = dataGridViewImages.Rows[index].Cells["ColumnDateipfad"].Value.ToString();

            //    pdfFileEditor.Concatenate(filesArray, "Desktop");
            //}

            //---------------------------------------------

            //// Konvertiere die Liste von PdfPictureBox-Objekten in ein Array
            //PdfPictureBox[] pdfPictureBoxArray = pdfPictureBoxes.ToArray();

            //// Erstelle ein leeres PdfDocument
            //PdfPictureBox mergedDocument = new PdfPictureBox();

            //foreach(var pdfPictureBox in pdfPictureBoxArray)
            //{
            //    string filePath = OpenPdf();

            //    PdfDocument document = PdfDocument.Load(filePath);

            //    foreach(var page in document.Pages)
            //    {
            //        mergedDocument.AddPage(page);
            //    }
            //}

            //-------------------------------------------

            //string[] filesArray = new string[pdfPictureBoxArray.Length];

            //for (int i = 0; i < pdfPictureBoxArray.Length; i++)
            //{
            //    // Speichere den Dateinamen des aktuellen PdfPictureBox-Objekts im String-Array
            //    filesArray[i] = pdfPictureBoxArray[i].Tag.ToString(); // Ändere dies entsprechend der tatsächlichen Eigenschaft des Dateinamens
            //}
            //// Dateien zusammenführen
            //pdfPictureBoxArray.Concatenate(filesArray, "merged.pdf");
        }

    private void buttonPdfFunktionen_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialogPdfZsm_FileOk(object sender, CancelEventArgs e)
        {
            // TODO - Gesamt Pdf generieren und Speichern
            // Funktion unnötig?? Mouton fragen
        }

        private void textBoxMergedName_Click(object sender, EventArgs e)
        {
            textBoxMergedName.Clear();
        }
    }
}
