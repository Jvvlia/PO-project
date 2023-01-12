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
    /// Logika interakcji dla klasy WypozyczeniaWindow.xaml
    /// </summary>
    public partial class WypozyczeniaWindow : Window
    {
        Wypozyczenia wypozyczenia;
        public WypozyczeniaWindow()
        {
            wypozyczenia = Wypozyczenia.OdczytajXml("wypozyczenia.xml");
            InitializeComponent();

            if (wypozyczenia != null)
            {
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WypozyczeniaLista);
            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Wypozyczenie wypozyczenie = new(); // dotyczy klasy
           /* WypozyczanieWindow wyp = new(wypozyczenie);
            bool? result = wyp.ShowDialog();
            if (result == true)
            {
                wypozyczenia.DodajWypozyczenie(wypozyczenie);
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WypozyczeniaLista);
            }*/
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczenia != null && LstWypozyczenia.SelectedIndex > -1)
            {
                Wypozyczenie wyp = LstWypozyczenia.SelectedItem as Wypozyczenie;
                if (wyp != null)
                {
                    wypozyczenia.UsunWypozyczenie(wyp.NumerWypozyczenia);
                    LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WypozyczeniaLista);
                }

            }
        }

        private void BtnSortuj_Click(object sender, RoutedEventArgs e)
        {
            if (wypozyczenia != null)
            {
                wypozyczenia.SortujWypozyczenia();
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WypozyczeniaLista);
            }
        }

        private void SzukajKlient_Click(object sender, RoutedEventArgs e)
        {
           /* if (wypozyczenia != null && !string.IsNullOrEmpty(TxtWyszukajKlient.Text))
            {
                wypozyczenia.WyszukajWypozyczenieK(TxtWyszukajKlient.Text);
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WyszukajWypozyczenieK(TxtWyszukajKlient.Text));
            }*/
        }

        private void SzukajSamochod_Click(object sender, RoutedEventArgs e)
        {
           /* if (wypozyczenia != null && !string.IsNullOrEmpty(TxtWyszukajSamochod.Text))
            {
                wypozyczenia.WyszukajWypozyczenieS(TxtWyszukajSamochod.Text);
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WyszukajWypozyczenieS(TxtWyszukajSamochod.Text));
            }*/
        }

        private void SzukajPracownik_Click(object sender, RoutedEventArgs e)
        {
           /* if (wypozyczenia != null && !string.IsNullOrEmpty(TxtWyszukajPracownik.Text))
            {
                wypozyczenia.WyszukajWypozyczenieP(TxtWyszukajPracownik.Text);
                LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczenia.WyszukajWypozyczenieP(TxtWyszukajPracownik.Text));
            }*/
        }
    }
}
