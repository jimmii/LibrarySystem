using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class Grafik
    {
        public int GrafikId { get; set; }
        public int Zmiana { get; set; }
        public DateTime PoczatekZmian { get; set; }
        public DateTime KonieckZmian { get; set; }
        public bool Status { get; set; }
        public Czytelnik czytelnik { get; set; }
    }
}
