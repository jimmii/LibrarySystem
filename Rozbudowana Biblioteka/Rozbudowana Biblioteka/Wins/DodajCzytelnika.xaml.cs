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
    /// Interaction logic for DodajCzytelnika.xaml
    /// </summary>
    public partial class DodajCzytelnika : Window
    {
        public DodajCzytelnika()
        {
            InitializeComponent();
        }

        private void ConfirmCRTACCBTN_Click(object sender, RoutedEventArgs e)
        {
            
                int rokUrodzenia;
                int nrMieszkan;
                int nrTLF;

            if (ImieCRTACCTxtBox.Text != "" && NazwiskoCRTACCTxtBox.Text != "" && DataUrCRTACCTxtBox.Text != "" && PlecCRTACCTxtBox.Text != "" && UlicaCRTACCTxtBox.Text != "" &&
                NrUlicyCRTACCTxtBox.Text != "" && KodPocztowyCRTACCTxtBox.Text != "" && MiastoCRTACCTxtBox.Text != "" && NrTLFCRTACCTxtBox.Text != "" &&
                EmailCRTACCTxtBox.Text != "")
            {

                if (Int32.TryParse(DataUrCRTACCTxtBox.Text, out rokUrodzenia) && Int32.TryParse(NrMieszkaniaCRTACCTxtBox.Text, out nrMieszkan) && Int32.TryParse(NrTLFCRTACCTxtBox.Text, out nrTLF))
                {
                    if (PlecCRTACCTxtBox.Text == "K" || PlecCRTACCTxtBox.Text == "M")
                    {
                        if (rokUrodzenia > 1920 || rokUrodzenia < 2017)
                        {
                            var result = MessageBox.Show("Czy wszystkie dane sa wprowadzone poprawnie i chcesz dodac osobe?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {

                                var nowyCzytelnik = new Czytelnik
                                {
                                    Imie = ImieCRTACCTxtBox.Text,
                                    Nazwisko = NazwiskoCRTACCTxtBox.Text,
                                    DataUrodzenia = new DateTime(rokUrodzenia, 10, 10, 1, 1, 1),
                                    Plec = PlecCRTACCTxtBox.Text,
                                    Status = Status.aktywny,
                                    DataDodania = DateTime.Now,
                                    PelnionaFunkcja = PelnionaFunkcja.czytelnik,
                                    CzytelnikPosiadaWypozyczoneKsiazki = CzyCzytelnikPosiadaWypozyczoneKsiazki.nie,
                                    DaneKontaktoweOsob = new DaneKontaktoweOsob
                                    {
                                        Ulica = UlicaCRTACCTxtBox.Text,
                                        NrUlicy = NrUlicyCRTACCTxtBox.Text,
                                        NrMieszkania = Int32.Parse(NrMieszkaniaCRTACCTxtBox.Text),
                                        KodPocztowy = KodPocztowyCRTACCTxtBox.Text,
                                        Miasto = MiastoCRTACCTxtBox.Text,
                                        NrTelefonu = Int32.Parse(NrTLFCRTACCTxtBox.Text),
                                        Email = EmailCRTACCTxtBox.Text
                                    }
                                };

                                using (var context = new BibliotekaDBContext())
                                {
                                    context.Czytelniks.Add(nowyCzytelnik);

                                    context.SaveChanges();
                                }
                                MessageBox.Show("Osoba zostala dodana", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();

                            }
                        }
                        else
                            MessageBox.Show("Za mala albo zbyt duza liczba w date urodzenia", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Niepoprawny format pola plec", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Niepoprawny format Daty urodzenia lub numeru mieszkania lub numeru telefonu", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Pola nie moga zostac niewypelnione", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
