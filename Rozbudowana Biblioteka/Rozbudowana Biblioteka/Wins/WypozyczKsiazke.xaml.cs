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
    /// Interaction logic for WypozyczKsiazke.xaml
    /// </summary>
    public partial class WypozyczKsiazke : Window
    {
        public WypozyczKsiazke()
        {
            InitializeComponent();
        }

        private void ConfirmRentACCBTN_Click(object sender, RoutedEventArgs e)
        {
            int dniTMP;
            if (ImieRentTxtBox.Text != "" && NazwiskoRentTxtBox.Text != "" && TytulRentTxtBox.Text != "" && AutorRentTxtBox.Text != "")
            {
                if (Int32.TryParse(DateRentTxtBox.Text, out dniTMP))
                {
                    using (var context = new BibliotekaDBContext())
                    {
                        var sprawdzczyosobaistnieje = context.Czytelniks.FirstOrDefault(s => s.Imie == ImieRentTxtBox.Text && s.Nazwisko == NazwiskoRentTxtBox.Text);
                        var sprawdzczyKsiazkaistnieje = context.Ksiazkas.FirstOrDefault(k => k.Tytul == TytulRentTxtBox.Text);
                        var sprawdzczyAutoristnieje = context.Ksiazkas.FirstOrDefault(a => a.AutorKsiazki.Nazwisko == AutorRentTxtBox.Text);

                        if (sprawdzczyKsiazkaistnieje != null && sprawdzczyAutoristnieje != null && sprawdzczyosobaistnieje != null)
                        {
                            if (sprawdzczyKsiazkaistnieje.CzyksiazkaWypozyczona == CzyksiazkaWypozyczona.nie)
                            {
                                var Rent = new WypozyczenieKsiazki
                                {
                                    DataWypozyczenia = DateTime.Now,
                                    DateOddania = DateTime.Now.AddDays(Int32.Parse(DateRentTxtBox.Text)),
                                    Czytelnik = sprawdzczyosobaistnieje,
                                    Ksiazka = sprawdzczyKsiazkaistnieje,
                                    Status = Status.aktywny

                                };
                                sprawdzczyosobaistnieje.CzytelnikPosiadaWypozyczoneKsiazki = CzyCzytelnikPosiadaWypozyczoneKsiazki.tak;
                                sprawdzczyKsiazkaistnieje.CzyksiazkaWypozyczona = CzyksiazkaWypozyczona.tak;


                                context.WypozyczenieKsiazkis.Add(Rent);
                                context.SaveChanges();
                                MessageBox.Show("Przypisano ksiazke czytelnikowi", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Ksiazka  jest juz wypozyczona", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                            MessageBox.Show("Nie ma takiej ksiazki lub czytelnika w bazie", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                    MessageBox.Show("Niepoprawny format dni(czas wypozyczenia), moze zostac niewypelnione w przypadku bezterminowego wypozyczenia", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Pola nie moga pozostac puste", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
