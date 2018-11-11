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
using System.Data.Entity;

namespace Rozbudowana_biblioteka.Wins
{
    /// <summary>
    /// Interaction logic for ZwrotKsiazki.xaml
    /// </summary>
    public partial class ZwrotKsiazki : Window
    {
        public ZwrotKsiazki()
        {
            InitializeComponent();
        }

        private void ConfirmRentACCBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ImieRentTxtBox.Text != "" && NazwiskoRentTxtBox.Text != "" && TytulRentTxtBox.Text != "" && AutorRentTxtBox.Text != "")
            {                
                    using (var context = new BibliotekaDBContext())
                    {
                        var sprawdzczyosobaistnieje = context.Czytelniks.FirstOrDefault(s => s.Imie == ImieRentTxtBox.Text && s.Nazwisko == NazwiskoRentTxtBox.Text);
                        var sprawdzczyKsiazkaistnieje = context.Ksiazkas.FirstOrDefault(k => k.Tytul == TytulRentTxtBox.Text);
                        var sprawdzczyAutoristnieje = context.Ksiazkas.FirstOrDefault(a => a.AutorKsiazki.Nazwisko == AutorRentTxtBox.Text);

                        if (sprawdzczyKsiazkaistnieje != null && sprawdzczyAutoristnieje != null && sprawdzczyosobaistnieje != null)
                        {
                        var sprawdzWypozyczenie = context.WypozyczenieKsiazkis.Include(s=>s.Czytelnik).Where(s => s.Czytelnik.Imie == ImieRentTxtBox.Text && s.Czytelnik.Nazwisko == NazwiskoRentTxtBox.Text && 
                                                  s.Ksiazka.AutorKsiazki.Nazwisko == AutorRentTxtBox.Text).FirstOrDefault();

                        if (sprawdzWypozyczenie!=null)
                        {
                            if (sprawdzczyKsiazkaistnieje.CzyksiazkaWypozyczona == CzyksiazkaWypozyczona.tak)
                            {
                                sprawdzczyKsiazkaistnieje.CzyksiazkaWypozyczona = CzyksiazkaWypozyczona.nie;
                                sprawdzczyosobaistnieje.CzytelnikPosiadaWypozyczoneKsiazki = CzyCzytelnikPosiadaWypozyczoneKsiazki.nie;
                                sprawdzWypozyczenie.Status = Status.nieaktywny;

                                context.SaveChanges();
                                MessageBox.Show("Ksiazke zwrocono pomyslnie", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Ksiazka nie jest wypozyczona", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                            else
                            MessageBox.Show("Na pewno ksiazke wypozyczono?", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);


                    }
                    else
                        MessageBox.Show("Nie ma takiej ksiazki lub czytelnika w bazie", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                
            }
            else
                MessageBox.Show("Pola nie moga pozostac puste", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
