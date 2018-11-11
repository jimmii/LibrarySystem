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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rozbudowana_biblioteka.Wins;
using Rozbudowana_biblioteka.Model;
using System.Data.Entity;

namespace Rozbudowana_biblioteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
       

        }

        private void LoginBTNClick(object sender, RoutedEventArgs e)
        {
            using (var context = new BibliotekaDBContext())
            {

                var user = context.UserLogowanies.Include(u=>u.Czytelnik).Where(u => u.Login == LogWindowLoginTXTBox.Text).FirstOrDefault();
               
               

                if (user != null)
                {
                    if (user.Haslo == LogwindowPSWDBox.Password)
                    {
                        if (user.Czytelnik.PelnionaFunkcja != PelnionaFunkcja.czytelnik)
                        {
                            user.Log = Log.zalogowany;
                            context.SaveChanges();

                            MessageBox.Show("Password correct");
                            BibliotekaMain bibliotekaMain = new BibliotekaMain();
                            bibliotekaMain.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nie masz dostepu", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                        MessageBox.Show("Wrong password", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("User not found.\n Jesli nie masz konta zglos to administratorowi", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void PanelAdministratoratBTNClick(object sender, RoutedEventArgs e)
        {


            
                        Logowanie_Admin logowanie_Admin = new Logowanie_Admin();
                        logowanie_Admin.Show();
                   

        }

        private void testbuttonclick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tworzona jest baza danych i admin. Po pierwszym wlaczeniu moze to chwile potrwac", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

            var testowyadmin1 = new UserLogowanie
            {
                Login = "admin",
                Haslo = "admin",
                Log = Log.niezalogowany,
                Czytelnik = new Czytelnik
                {
                    Imie = "usun",
                    Nazwisko = "mnie",
                    DataUrodzenia = new DateTime(2000, 10, 10, 1, 1, 1),
                    Plec = "M",
                    Status = Status.aktywny,
                    DataDodania = DateTime.Now,
                    CzytelnikPosiadaWypozyczoneKsiazki=CzyCzytelnikPosiadaWypozyczoneKsiazki.nie,
                    PelnionaFunkcja=PelnionaFunkcja.administrator,
                    DaneKontaktoweOsob = new DaneKontaktoweOsob
                    {
                        Ulica = "",
                        NrUlicy = "",
                        NrMieszkania = 1,
                        KodPocztowy = "",
                        Miasto = "",
                        NrTelefonu = 1,
                        Email=""
                    }
                    
                    
                }
            };
           
            using (var context = new BibliotekaDBContext())
            {
                context.UserLogowanies.Add(testowyadmin1);

                context.SaveChanges();
                MessageBox.Show("Stworzon admina. Login:admin haslo:admin Mozesz go usunac i stworzyc nowego admina w panelu administratora", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            x.IsEnabled = false;
        }

       
       
    }
}
