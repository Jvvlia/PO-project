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
using Wypożyczalnia;

namespace WypozyczalniaSamochodowGUI
{
    /// <summary>
    /// Logika interakcji dla klasy WypozyczanieWindow.xaml
    /// </summary>
    public partial class WypozyczanieWindow : Window
    {
        Wypozyczenie wypozyczenie;
        Klient klient;
        public WypozyczanieWindow()
        {
            InitializeComponent();
        }

        public WypozyczanieWindow(Wypozyczenie wypozyczenie, Klient klient) : this()
        {
            this.wypozyczenie = wypozyczenie;
            this.klient = klient;
            TxtNumer.Text = wypozyczenie.NumerWypozyczenia; 
            TxtOd.Text = $"{wypozyczenie.DataWypozyczenia:dd/MM/yyyy}";
            TxtDo.Text = $"{wypozyczenie.DataZwrotu:dd/MM/yyyy}";
            // TxtSamochod.Text = wypozyczenie.Samochod;
            // TxtPracownik.Text = wypozyczenie.Pracownik;
            // TxtKwota.Text = wypozyczenie.ObliczKwote(wypozyczenie.LiczbaDni(), Samochod.Oplata);

            TxtImie.Text = klient.Imie;
            TxtNazwisko.Text = klient.Nazwisko;
            TxtPesel.Text = klient.Pesel;
            TxtTelefon.Text = klient.NumerTelefonu;
            TxtData.Text = $"{klient.DataUrodzenia:dd/MM/yyyy}";
            TxtNumerPrawaJazdy.Text = klient.NumerPrawaJazdy;

        }

        private void BtnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool? res = false;
            if (!string.IsNullOrEmpty(TxtImie.Text) && !string.IsNullOrEmpty(TxtNazwisko.Text)
                && !string.IsNullOrEmpty(TxtPesel.Text) && !string.IsNullOrEmpty(TxtData.Text)
                && !string.IsNullOrEmpty(TxtTelefon.Text) && !string.IsNullOrEmpty(TxtNumerPrawaJazdy.Text)
                && !string.IsNullOrEmpty(TxtOd.Text) && !string.IsNullOrEmpty(TxtDo.Text) && !string.IsNullOrEmpty(TxtNumer.Text))
            {
                klient.Imie = TxtImie.Text;
                klient.Nazwisko = TxtNazwisko.Text;
                klient.Pesel = TxtPesel.Text;
                klient.NumerTelefonu = TxtTelefon.Text;
                klient.NumerPrawaJazdy = TxtNumerPrawaJazdy.Text;
                if (DateTime.TryParseExact(TxtData.Text, new string[] { "dd-MM-yyyy", "dd/MM/yyyy" },
                    null, System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    klient.DataUrodzenia = data;
                }

                //wypozyczenie.NumerWypozyczenia = TxtNumer.Text;
                if (DateTime.TryParseExact(TxtOd.Text, new string[] { "dd-MM-yyyy", "dd/MM/yyyy" },
                    null, System.Globalization.DateTimeStyles.None, out DateTime data2))
                {
                    wypozyczenie.DataWypozyczenia = data2;
                }
                if (DateTime.TryParseExact(TxtDo.Text, new string[] { "dd-MM-yyyy", "dd/MM/yyyy" },
                    null, System.Globalization.DateTimeStyles.None, out DateTime data3))
                {
                    wypozyczenie.DataZwrotu = data3;
                }


                res = true;
            }
            DialogResult = res;
        }
    }
}
