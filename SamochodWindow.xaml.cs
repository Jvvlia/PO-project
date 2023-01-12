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
    /// Logika interakcji dla klasy SamochodWindow.xaml
    /// </summary>
    public partial class SamochodWindow : Window
    {
        Samochod sam;
        
        public SamochodWindow()
        {
            InitializeComponent();
        }
        public SamochodWindow(Samochod sam) : this()
        {
            this.sam = sam;
            TxtModel.Text = sam.Model;
            TxtNrRejestracyjny.Text = sam.NumerRejestracyjny;
            TxtMoc.Text = sam.Moc.ToString();
            TxtKolor.Text = sam.Kolor;
            TxtOplata.Text = sam.Oplata.ToString();
            TxtSilnik.Text = sam.Silnik;
            TxtLadownosc.Text = sam.Ladownosc;
            TxtLiczbaDrzwi.Text = sam.LiczbaDrzwi.ToString();
            TxtOplataDod.Text = sam.OplataDodatkowa.ToString();
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool? res = false;
            if (!string.IsNullOrEmpty(TxtModel.Text) && !string.IsNullOrEmpty(TxtNrRejestracyjny.Text)
                && !string.IsNullOrEmpty(TxtMoc.Text) && !string.IsNullOrEmpty(TxtKolor.Text)
                && !string.IsNullOrEmpty(TxtOplata.Text) && !string.IsNullOrEmpty(TxtSilnik.Text)
                && !string.IsNullOrEmpty(TxtLadownosc.Text) && !string.IsNullOrEmpty(TxtLiczbaDrzwi.Text)
                && !string.IsNullOrEmpty(TxtOplataDod.Text))
            {
                if (CmbNaped.Text == "FWD")
                { sam.Naped = EnumNaped.FWD; }
                else
                {
                    if (CmbNaped.Text == "RWD")
                    { sam.Naped = EnumNaped.RWD; }
                    else { sam.Naped = EnumNaped.AWD; }
                }

                if(CmbStatus.Text == "wypożyczony")
                { sam.Status = EnumStatus.wypożyczony; }
                else { sam.Status = EnumStatus.wolny; }

                if(CmbWyciagarka.Text == "tak")
                { sam.Wyciagarka = EnumWyciagarka.tak; }
                else { sam.Wyciagarka = EnumWyciagarka.nie; }

                // czy z marka tez tak wypisywac ??

                sam.Model = TxtModel.Text;
                sam.NumerRejestracyjny = TxtNrRejestracyjny.Text;
                //sam.Moc = TxtMoc.Text;
                sam.Kolor = TxtKolor.Text;
               // sam.Oplata = TxtOplata.Text;
                sam.Silnik = TxtSilnik.Text;
                sam.Ladownosc = TxtLadownosc.Text;
                //sam.LiczbaDrzwi = TxtLiczbaDrzwi.Text;
                //sam.OplataDodatkowa = TxtOplataDod.Text;



                res = true;
            }
            DialogResult = res;
        }

        private void BtnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
