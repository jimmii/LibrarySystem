using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class WypozyczenieKsiazki
    {
        public int WypozyczenieKsiazkiId { get; set; }
        public Nullable<DateTime> DataWypozyczenia { get; set; }
        public Nullable<DateTime> DateOddania { get; set; }
        public Czytelnik Czytelnik { get; set; }
        public Status Status { get; set; }
        public Ksiazka Ksiazka { get; set; }
    }
}
