using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class Czytelnik
    {
        public int CzytelnikId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Plec { get; set; }
        public Status Status { get; set; }
        public DateTime DataDodania { get; set; }
        public Nullable<CzyCzytelnikPosiadaWypozyczoneKsiazki> CzytelnikPosiadaWypozyczoneKsiazki { get; set; }
        public PelnionaFunkcja PelnionaFunkcja { get; set; }
        public DaneKontaktoweOsob DaneKontaktoweOsob { get; set; }
    }
}
