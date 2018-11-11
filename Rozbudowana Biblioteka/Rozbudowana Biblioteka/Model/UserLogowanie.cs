using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozbudowana_biblioteka.Model
{
    public class UserLogowanie
    {
        public int UserLogowanieId { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public Log Log{ get; set; }
        public Czytelnik Czytelnik { get; set; }

    }
}
