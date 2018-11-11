using Rozbudowana_biblioteka.Model;
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
    /// Interaction logic for DodajKsiazke.xaml
    /// </summary>
    public partial class DodajKsiazke : Window
    {
        public DodajKsiazke()
        {
            InitializeComponent();
        }

        private void ConfirmCRTACCBTN_Click(object sender, RoutedEventArgs e)
        {
            int rokWydania;

            if (TytulKsiazkiCRTACCTxtBox.Text != "" && NrSeryjnyCRTACCTxtBox.Text != "" && RokWydaniaCRTACCTxtBox.Text != "" && ImieAutorCRTACCTxtBox.Text != "" && NazwiskoAutorCRTACCTxtBox.Text != "")
            {
                if (Int32.TryParse(RokWydaniaCRTACCTxtBox.Text, out rokWydania))
                {
                    if (rokWydania > 1920 || rokWydania < 2017)
                    {
                        var result = MessageBox.Show("Czy wszystkie dane sa wprowadzone poprawnie i chcesz dodac ksiazke?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            var dodajksiazke = new Ksiazka
                            {
                                Tytul = TytulKsiazkiCRTACCTxtBox.Text,
                                Numer_Seryjny = NrSeryjnyCRTACCTxtBox.Text,
                                RokWydania = new DateTime(rokWydania, 10, 10, 1, 1, 1),
                                Status = Status.aktywny,
                                DataDodania = DateTime.Now,
                                CzyksiazkaWypozyczona = CzyksiazkaWypozyczona.nie,
                                AutorKsiazki = new AutorKsiazki
                                {
                                    Imie = ImieAutorCRTACCTxtBox.Text,
                                    Nazwisko = NazwiskoAutorCRTACCTxtBox.Text
                                }

                            };

                            using (var context = new BibliotekaDBContext())
                            {
                                context.Ksiazkas.Add(dodajksiazke);
                                context.SaveChanges();
                            }

                            MessageBox.Show("Ksiazka zostala dodana", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Niepoprawny rok Wydania za duzy albo za maly", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                    MessageBox.Show("Niepoprawny format Roku Wadania", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Pola nie moga zostac niewypelnione", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
