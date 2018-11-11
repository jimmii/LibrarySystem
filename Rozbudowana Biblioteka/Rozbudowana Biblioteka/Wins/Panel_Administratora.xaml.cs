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
    /// Interaction logic for Panel_Administratora.xaml
    /// </summary>
    public partial class Panel_Administratora : Window
    {
        public Panel_Administratora()
        {
            InitializeComponent();
            OdswiezDatagrida();
        }

       

        private void WiadomosciOdPracownikowBTN_Click(object sender, RoutedEventArgs e)
        {
            Wiadomosci_Admin wiadomosci_Admin = new Wiadomosci_Admin();
            wiadomosci_Admin.Show();
        }

       

        public void OdswiezDatagrida()
        {
            using (var context = new BibliotekaDBContext())
            {

                var listaOsob = context.Czytelniks                    
                    .Select(l => new { l.Imie, l.Nazwisko, l.DataDodania, l.Status, l.PelnionaFunkcja })
                    .ToList();
                AdminPanelDatagrid.ItemsSource = listaOsob;
            }
        }

        private void OdswierzBTNClick(object sender, RoutedEventArgs e)
        {
            OdswiezDatagrida();
        }

        private void DodajPracownikaBTNClick(object sender, RoutedEventArgs e)
        {
            DodajPracownika dodajPracownika = new DodajPracownika();
            dodajPracownika.Show();
        }

        private void UsunPracownikaAdminBTN_Click(object sender, RoutedEventArgs e)
        {
            UsunOsobeAdmin usunOsobeAdmin = new UsunOsobeAdmin();
            usunOsobeAdmin.Show();
        }

       
    }
}
