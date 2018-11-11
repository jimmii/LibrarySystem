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
using Rozbudowana_biblioteka.Wins;
using Rozbudowana_biblioteka.Model;

namespace Rozbudowana_biblioteka.Wins
{
    /// <summary>
    /// Interaction logic for BibliotekaMain.xaml
    /// </summary>
    public partial class BibliotekaMain : Window
    {

        public BibliotekaMain()
        {
            InitializeComponent();

            GetLogin();
           
        }

        private void StatusOsobyBTNClick(object sender, RoutedEventArgs e)
        {
            StatusCzytelnika statusCzytelnika = new StatusCzytelnika();
            statusCzytelnika.Show();

        }

        private void StatusKsiazkiBTNClick(object sender, RoutedEventArgs e)
        {
            StatusKsiazki statusKsiazki = new StatusKsiazki();
            statusKsiazki.Show();
        }

        private void WypozyczKsiazkeBTNClick(object sender, RoutedEventArgs e)
        {
            WypozyczKsiazke wypozyczKsiazke = new WypozyczKsiazke();
            wypozyczKsiazke.Show();
        } 

        private void ZwrotSkiazkiBTNClick(object sender, RoutedEventArgs e)
        {
            ZwrotKsiazki zwrotKsiazki = new ZwrotKsiazki();
            zwrotKsiazki.Show();
        }

        private void ZarejestrujOsobeBTNClick(object sender, RoutedEventArgs e)
        {
            
                DodajCzytelnika dodajCzytelnika = new DodajCzytelnika();
                dodajCzytelnika.Show();
            
        }

        private void DodajKsiazkeBTNClick(object sender, RoutedEventArgs e)
        {
            DodajKsiazke dodajKsiazke = new DodajKsiazke();
            dodajKsiazke.Show();
        }

        private void UsunOsobeBTNClick(object sender, RoutedEventArgs e)
        {
            UsunCzytelnika usunCzytelnika = new UsunCzytelnika();
            usunCzytelnika.Show();

        }

        private void UsunKsiazkeBTNClick(object sender, RoutedEventArgs e)
        {
            UsunKsiazke usunKsiazke = new UsunKsiazke();
            usunKsiazke.Show();
        }

        private void PokazKsiazkiWdatagridzieBTNClick(object sender, RoutedEventArgs e)
        {
            using (var context = new BibliotekaDBContext())
            {
                
                var listaKsiazek = context.Ksiazkas
                    .Where(l => l.Status == Status.aktywny)
                    .Select(l => new { l.Tytul, l.Numer_Seryjny, l.RokWydania, l.DataDodania, l.AutorKsiazki.Imie, l.AutorKsiazki.Nazwisko })
                    .ToList();
                MainWindowDatagrid.ItemsSource = listaKsiazek;
            }
        }

        private void PokazCzytelnikowWdatagridzieBTNClick(object sender, RoutedEventArgs e)
        {
            using (var context = new BibliotekaDBContext())
            {
                
                var listaOsob = context.Czytelniks
                    .Where(l => l.Status == Status.aktywny && l.PelnionaFunkcja==PelnionaFunkcja.czytelnik)
                    .Select(l => new { l.Imie, l.Nazwisko, l.DataDodania })
                    .ToList();
                MainWindowDatagrid.ItemsSource = listaOsob;
            }

            
        }

        private void WylogujBTNClick(object sender, RoutedEventArgs e)
        {
            using (var context = new BibliotekaDBContext())
            {
                var zalogowany = context.UserLogowanies.Where(z => z.Log == Log.zalogowany).First();

                zalogowany.Log = Log.niezalogowany;

                context.SaveChanges();
            }

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
        }

        private void NapiszWiadomoscBTNClick(object sender, RoutedEventArgs e)
        {
            Wiadomosc wiadomosc = new Wiadomosc();
            wiadomosc.Show();
        }


        public  void GetLogin()
        {
            using (var context = new BibliotekaDBContext())
            {
                var zalogowany = context.UserLogowanies.Where(z => z.Log == Log.zalogowany).First();
                NickLabel.Content = zalogowany.Login;
            }
        }
    }

   
}
