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
    /// Interaction logic for Wiadomosc.xaml
    /// </summary>
    public partial class Wiadomosc : Window
    {
        public Wiadomosc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new BibliotekaDBContext())
            {
                var prac = context.UserLogowanies.Include(p=>p.Czytelnik).Where(p => p.Log == Log.zalogowany).First();

                

                var msg = new Wiadomosci
                {
                    Tresc = MSGTXTBox.Text,
                    Status = Status.aktywny,
                    ImieNadawcy=prac.Czytelnik.Imie,
                    NazwiskoNadawcy=prac.Czytelnik.Nazwisko,
                    Datawyslania=DateTime.Now
                    
                };

                context.Wiadomoscis.Add(msg);
                context.SaveChanges();
                MessageBox.Show("Wyslano!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
