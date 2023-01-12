using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Wypożyczalnia;

namespace WypozyczalniaSamochodowGUI
{
    /// <summary>
    /// Logika interakcji dla klasy PracownicyWindow.xaml
    /// </summary>

    public partial class PracownicyWindow : Window
    {
        Pracownicy zespol;
          
        public PracownicyWindow()
        {
            string fname = "pracownicy.xml";
            zespol = Pracownicy.OdczytajXml(fname);

            InitializeComponent();

            if (zespol != null)
            {
                LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(zespol.PracownicyLista);
            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
                Pracownik pracownik = new(); // dotyczy klasy
                PracownikWindow pr = new(pracownik);
                bool? result = pr.ShowDialog();
                if (result == true)
                {
                    zespol.DodajPracownika(pracownik);
                    LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(zespol.PracownicyLista);
                }
           
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (zespol != null && LstPracownicy.SelectedIndex > -1)
            {
                Pracownik pracownik = LstPracownicy.SelectedItem as Pracownik;
                if (pracownik != null)
                {
                    zespol.UsunPracownika(pracownik.Pesel);
                    LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(zespol.PracownicyLista);
                }

            }
        }

        private void BtnSortuj_Click(object sender, RoutedEventArgs e)
        {
            if (zespol != null)
            {
                zespol.SortujPracowników();
                LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(zespol.PracownicyLista);
            }
        }

        private void BtnWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            if (zespol != null && !string.IsNullOrEmpty(TxtWyszukaj.Text))
            {
                zespol.Wyszukaj(TxtWyszukaj.Text);
                LstPracownicy.ItemsSource = new ObservableCollection<Pracownik>(zespol.Wyszukaj(TxtWyszukaj.Text));
            }
        }
    }
}
