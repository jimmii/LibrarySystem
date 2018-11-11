using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class Wiadomosci
    {
        public int WiadomosciId { get; set; }
        public string Tresc { get; set; }
        public Status Status { get; set; }
        public string ImieNadawcy { get; set; }
        public string NazwiskoNadawcy { get; set; }
        public DateTime Datawyslania { get; set; }
        
    }
}
