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
    /// Interaction logic for UsunKsiazke.xaml
    /// </summary>
    public partial class UsunKsiazke : Window
    {
        public UsunKsiazke()
        {
            InitializeComponent();
        }

        private void ConfirmRemoveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TytulKsiazkiRemoveTxtBox.Text != "" && AutorRemoveTxtBox.Text != "")
            {
                using (var context = new BibliotekaDBContext())
                {
                    var sprawdzczyKsiazkaistnieje = context.Ksiazkas.FirstOrDefault(k=>k.Tytul==TytulKsiazkiRemoveTxtBox.Text);
                    var sprawdzczyAutoristnieje = context.Ksiazkas.FirstOrDefault(a => a.AutorKsiazki.Nazwisko == AutorRemoveTxtBox.Text);

                    if (sprawdzczyKsiazkaistnieje != null && sprawdzczyAutoristnieje !=null)
                    {
                        var result = MessageBox.Show("Czy na pewno chcesz usunac ksiazke?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            var ksiazka = context
                           .Ksiazkas
                           .Where(k => k.Tytul == TytulKsiazkiRemoveTxtBox.Text && k.AutorKsiazki.Nazwisko == AutorRemoveTxtBox.Text)
                           .First();

                            ksiazka.Status = Status.nieaktywny;
                            context.SaveChanges();

                            MessageBox.Show("Usunieto!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
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
