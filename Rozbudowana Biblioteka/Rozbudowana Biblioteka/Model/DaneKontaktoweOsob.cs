using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class DaneKontaktoweOsob
    {
        public int DaneKontaktoweOsobId { get; set; }
        public string Ulica { get; set; }
        public string NrUlicy { get; set; }
        public Nullable<int> NrMieszkania { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public int NrTelefonu { get; set; }
        public string Email { get; set; }
    }
}
