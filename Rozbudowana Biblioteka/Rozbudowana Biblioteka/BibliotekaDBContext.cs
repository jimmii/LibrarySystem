using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rozbudowana_biblioteka.Model;
using System.Data.Entity;

namespace Rozbudowana_biblioteka
{
    public class BibliotekaDBContext:DbContext
    {
        public DbSet<AutorKsiazki> AutorKsiazkis { get; set; }
        public DbSet<Czytelnik> Czytelniks { get; set; }
        public DbSet<DaneKontaktoweOsob> DaneKontaktoweOsobs { get; set; }
        public DbSet<Ksiazka> Ksiazkas { get; set; }
        public DbSet<UserLogowanie> UserLogowanies { get; set; }
        public DbSet<Wiadomosci> Wiadomoscis { get; set; }
        public DbSet<WypozyczenieKsiazki> WypozyczenieKsiazkis { get; set; }
        

        public BibliotekaDBContext()
            :base("BibliotekaDB")
        { }
    }
}
