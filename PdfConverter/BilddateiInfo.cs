using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfConverter
{
    public class BilddateiInfo
    {
        public string Dateipfad { get; set; }
        public string PdfNr { get; set; }
        public string SeitenNr { get; set; }
        public string Name { get; set; }
        public double Speicher { get; set; }
        public BilddateiInfo(string dateipfad, string pdfNr, string seitenNr, string name, double speicher)
        {
            Dateipfad = dateipfad;
            PdfNr = pdfNr;
            SeitenNr = seitenNr;
            Name = name;
            Speicher = speicher;
        }
    }
}
