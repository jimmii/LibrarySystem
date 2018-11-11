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
    /// Interaction logic for DodajPracownika.xaml
    /// </summary>
    public partial class DodajPracownika : Window
    {
        public DodajPracownika()
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
                EmailCRTACCTxtBox.Text != "" && LoginCRTACCTxtBox.Text!="" && HasloCRTACCTxtBox.Text!="" && StanowiskoCmbBox.Text!="")
            {

                if (Int32.TryParse(DataUrCRTACCTxtBox.Text, out rokUrodzenia) && Int32.TryParse(NrMieszkaniaCRTACCTxtBox.Text, out nrMieszkan) && Int32.TryParse(NrTLFCRTACCTxtBox.Text, out nrTLF))
                {
                    if (PlecCRTACCTxtBox.Text == "K" || PlecCRTACCTxtBox.Text == "M")
                    {
                        if (rokUrodzenia > 1920 || rokUrodzenia < 2017)
                        {
                            PelnionaFunkcja tmp;
                            if (StanowiskoCmbBox.Text == "Pracownik")
                                tmp = PelnionaFunkcja.pracownik;
                            else
                                tmp = PelnionaFunkcja.administrator;

                            var result = MessageBox.Show("Czy wszystkie dane sa wprowadzone poprawnie i chcesz dodac osobe?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                var nowypracownik = new UserLogowanie
                                {
                                    Login = LoginCRTACCTxtBox.Text,
                                    Haslo = HasloCRTACCTxtBox.Text,
                                    Log = Log.niezalogowany,
                                    Czytelnik = new Czytelnik
                                    {
                                        Imie = ImieCRTACCTxtBox.Text,
                                        Nazwisko = NazwiskoCRTACCTxtBox.Text,
                                        DataUrodzenia = new DateTime(rokUrodzenia, 10, 10, 1, 1, 1),
                                        Plec = PlecCRTACCTxtBox.Text,
                                        Status = Status.aktywny,
                                        DataDodania = DateTime.Now,
                                        CzytelnikPosiadaWypozyczoneKsiazki = null,
                                        
                                        PelnionaFunkcja = tmp,
                                        DaneKontaktoweOsob = new DaneKontaktoweOsob
                                        {
                                            Ulica = UlicaCRTACCTxtBox.Text,
                                            NrUlicy = NrUlicyCRTACCTxtBox.Text,
                                            NrMieszkania = nrMieszkan,
                                            KodPocztowy = KodPocztowyCRTACCTxtBox.Text,
                                            Miasto = MiastoCRTACCTxtBox.Text,
                                            NrTelefonu = nrTLF,
                                            Email = EmailCRTACCTxtBox.Text
                                        }
                                    }
                                };

                                using (var context = new BibliotekaDBContext())
                                {
                                    context.UserLogowanies.Add(nowypracownik);
                                    context.SaveChanges();
                                    MessageBox.Show("Dodano", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                                    this.Close();
                                }
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
