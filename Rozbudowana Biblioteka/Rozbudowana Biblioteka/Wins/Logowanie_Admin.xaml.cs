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
    /// Interaction logic for Logowanie_Admin.xaml
    /// </summary>
    public partial class Logowanie_Admin : Window
    {
        public Logowanie_Admin()
        {
            InitializeComponent();
        }

        private void AdminLoginBTNClick(object sender, RoutedEventArgs e)
        {
            using (var context = new BibliotekaDBContext())
            {
                var user = context.UserLogowanies.Include(u => u.Czytelnik).Where(u => u.Login == AdminLoginTXTBox.Text).FirstOrDefault();



                if (user != null)
                {
                    if (user.Haslo == AdminLoginPSWDBox.Password)
                    {
                        if (user.Czytelnik.PelnionaFunkcja == PelnionaFunkcja.administrator)
                        {
                            MessageBox.Show("Password correct");
                            Panel_Administratora panel_Administratora = new Panel_Administratora();
                            panel_Administratora.Show();
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
       
        }
    }

