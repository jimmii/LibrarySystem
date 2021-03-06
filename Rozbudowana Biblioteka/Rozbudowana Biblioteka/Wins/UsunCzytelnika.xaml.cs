﻿using System;
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
    /// Interaction logic for UsunCzytelnika.xaml
    /// </summary>
    public partial class UsunCzytelnika : Window
    {
        public UsunCzytelnika()
        {
            InitializeComponent();
        }

        private void ConfirmRemoveACCBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ImieRemoveTxtBox.Text != "" && NazwiskoRemoveTxtBox.Text != "")
            {
                using (var context = new BibliotekaDBContext())
                {
                    var sprawdzczyosobaistnieje = context.Czytelniks.FirstOrDefault(s => s.Imie == ImieRemoveTxtBox.Text && s.Nazwisko == NazwiskoRemoveTxtBox.Text);

                    if (sprawdzczyosobaistnieje != null)
                    {
                        var result = MessageBox.Show("Czy na pewno chcesz usunac czytelnika?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            var osoba = context
                           .Czytelniks
                           .Where(c => c.Imie == ImieRemoveTxtBox.Text && c.Nazwisko == NazwiskoRemoveTxtBox.Text)
                           .First();

                            osoba.Status = Status.nieaktywny;
                            context.SaveChanges();

                            MessageBox.Show("Usunieto!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
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
