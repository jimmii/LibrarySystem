using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using Rozbudowana_biblioteka.Model;

namespace Rozbudowana_biblioteka.Wins
{
    /// <summary>
    /// Interaction logic for Wiadomosci_Admin.xaml
    /// </summary>
    public partial class Wiadomosci_Admin : Window
    {
        public Wiadomosci_Admin()
        {
            InitializeComponent();
            InitWiadomosci();
        }

        public void InitWiadomosci()
        {
            using (var context = new BibliotekaDBContext())
            {
                var listaOsob = context.Wiadomoscis
                    .Select(l => new { l.ImieNadawcy, l.NazwiskoNadawcy, l.Datawyslania, l.Tresc })
                    .ToList();

                AdminWiadomosciDatagrid.ItemsSource = listaOsob;

                //MainWindowDatagrid.ItemsSource = listaKsiazek;
            }
        }

        private void WyswietlWszystkieWiadomosciBTN_Click(object sender, RoutedEventArgs e)
        {
            InitWiadomosci();
        }

       
      

        private void WyswietlNieprzeczytaneWiadomosciBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
