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

namespace Rozbudowana_biblioteka.Wins
{
    /// <summary>
    /// Interaction logic for StatusKsiazki.xaml
    /// </summary>
    public partial class StatusKsiazki : Window
    {
        public StatusKsiazki()
        {
            InitializeComponent();
        }

        private void ConfirmStatusBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TytulStatusTxtBox.Text != "" && AutorStatusTxtBox.Text != "")
            {
                using (var context = new BibliotekaDBContext())
                {
                    var sprawdzczyKsiazkaistnieje = context.Ksiazkas.FirstOrDefault(k => k.Tytul == TytulStatusTxtBox.Text);
                    var sprawdzczyAutoristnieje = context.Ksiazkas.FirstOrDefault(a => a.AutorKsiazki.Nazwisko == AutorStatusTxtBox.Text);

                    if (sprawdzczyKsiazkaistnieje != null && sprawdzczyAutoristnieje != null)
                    {
                        
                            var ksiazka = context
                           .Ksiazkas
                           .Where(k => k.Tytul == TytulStatusTxtBox.Text && k.AutorKsiazki.Nazwisko == AutorStatusTxtBox.Text)
                           .First();

                            if(ksiazka.CzyksiazkaWypozyczona==Model.CzyksiazkaWypozyczona.nie)
                                MessageBox.Show("Ksiazka nie jest wypozyczona", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                            else
                                 {
                            var listaKsiazek = context.WypozyczenieKsiazkis
                                .Where(l => l.Ksiazka.Tytul==TytulStatusTxtBox.Text && l.Ksiazka.AutorKsiazki.Nazwisko==AutorStatusTxtBox.Text)
                                .Select(l => new { l.Czytelnik.Imie, l.Czytelnik.Nazwisko })
                                .ToList();

                            string msg = "";
                            foreach (var i in listaKsiazek)
                                if (i != null)
                                {
                                    msg += i;
                                }


                            MessageBox.Show("Ksiazka wypozyczona przez: " + msg, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
             
                                 }
    
                    }
                    else
                        MessageBox.Show("Nie ma takiej ksiazki w bazie", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
                MessageBox.Show("Pola nie moga pozostac puste", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    
}
