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
    /// Logika interakcji dla klasy SamochodyWindow.xaml
    /// </summary>
    /// 
    //d:ItemsSource="{d:SampleData ItemCount=5}"
    public partial class SamochodyWindow : Window
    {
        Samochody auta;
        public SamochodyWindow()
        {
            auta = Samochody.OdczytajXml("samochody.xml");

            InitializeComponent();

            if (auta != null)
            {
                LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SamochodyLista);
            }
        }

        private void BtnSzukajRejestracja_Click(object sender, RoutedEventArgs e)
        {
            if (auta != null && !string.IsNullOrEmpty(TxtRejestracja.Text))
            {
                auta.SzukajRejestracja(TxtRejestracja.Text);
                LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SzukajRejestracja(TxtRejestracja.Text));
            }
        }

        private void BtnSzukajMarka_Click(object sender, RoutedEventArgs e)
        {
            /*if (auta != null && !string.IsNullOrEmpty(CmbMarka.Text))
            {
                auta.SzukajMarka(CmbMarka.Text);
                LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SzukajMarka(CmbMarka.Text));
            }*/
        }

        private void BtnSzukajNaped_Click(object sender, RoutedEventArgs e)
        {
           /* if (auta != null && !string.IsNullOrEmpty(CmbNaped.Text))
            {
                auta.SzukajNaped(CmbNaped.Text);
                LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SzukajNaped(CmbMarka.Text));
            }*/
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (auta != null && LstSamochody.SelectedIndex > -1)
            {
                Samochod samochod = LstSamochody.SelectedItem as Samochod;
                if (samochod != null)
                {
                    auta.UsunSamochod(samochod.NumerRejestracyjny);
                    LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SamochodyLista);
                }

            }
        }

        private void BtnUsunWszystko_Click(object sender, RoutedEventArgs e)
        {
            if (auta != null && LstSamochody.SelectedIndex > -1)
            {
                    auta.UsunWszystko();
                    LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SamochodyLista);

            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Samochod samochod = new();
            SamochodWindow sam = new(samochod);
            bool? result = sam.ShowDialog();
            if (result == true)
            {
                auta.Dodaj(samochod);
                LstSamochody.ItemsSource = new ObservableCollection<Samochod>(auta.SamochodyLista);
            }
        }

        private void BtnWyswietl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
