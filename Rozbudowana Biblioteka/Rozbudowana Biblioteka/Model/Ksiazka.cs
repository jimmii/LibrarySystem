using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class Ksiazka
    {
        public int KsiazkaId { get; set; }
        public string Tytul { get; set; }
        public string Numer_Seryjny { get; set; }
        public DateTime RokWydania { get; set; }
        public Status Status { get; set; }
        public DateTime DataDodania { get; set; }
        public CzyksiazkaWypozyczona CzyksiazkaWypozyczona { get; set; }
        public AutorKsiazki AutorKsiazki { get; set; }
    }
}
