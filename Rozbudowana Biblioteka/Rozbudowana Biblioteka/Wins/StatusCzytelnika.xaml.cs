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
using Rozbudowana_biblioteka.Model;

namespace Rozbudowana_biblioteka.Wins
{
    /// <summary>
    /// Interaction logic for StatusCzytelnika.xaml
    /// </summary>
    public partial class StatusCzytelnika : Window
    {
        public StatusCzytelnika()
        {
            InitializeComponent();
        }

        private void ConfirmStatusBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ImieStatusTxtBox.Text != "" && ImieStatusTxtBox.Text != "")
            {
                using (var context = new BibliotekaDBContext())
                {
                    var sprawdzczyImieistnieje = context.Czytelniks.FirstOrDefault(k => k.Imie == ImieStatusTxtBox.Text);
                    var sprawdzczyNazwiskoistnieje = context.Czytelniks.FirstOrDefault(a => a.Nazwisko == NazwiskoStatusTxtBox.Text);

                    if (sprawdzczyImieistnieje != null && sprawdzczyNazwiskoistnieje != null)
                    {

                        var osoba = context
                       .Czytelniks
                       .Where(k => k.Imie == ImieStatusTxtBox.Text && k.Nazwisko == NazwiskoStatusTxtBox.Text)
                       .First();

                        if (osoba.CzytelnikPosiadaWypozyczoneKsiazki==Model.CzyCzytelnikPosiadaWypozyczoneKsiazki.nie)
                            MessageBox.Show("Uzytkownik nie posiada wypozyczonych ksiazek", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                        { 
                            var listaOsob = context.WypozyczenieKsiazkis
                                .Where(l => l.Czytelnik.Imie == ImieStatusTxtBox.Text && l.Czytelnik.Nazwisko == NazwiskoStatusTxtBox.Text)
                                .Select(l => new { l.Ksiazka.Tytul })
                                .ToList();

                            string msg = "";
                            foreach (var i in listaOsob)                            
                                 if( i != null)
                                    {
                                    msg += i;
                                    }
                            
                           
                            MessageBox.Show("Uzytkowanik posiada wypozyczone ksiazki" + msg, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                    }
                    else
                        MessageBox.Show("Nie ma takiej osoby w bazie", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
                MessageBox.Show("Pola nie moga pozostac puste", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    
}
