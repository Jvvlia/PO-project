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
                
                if (CmbMarka.Text == "Audi")
                { sam.Marka = EnumMarka.Audi; }
                else{if (CmbMarka.Text == "BMW"){ sam.Marka = EnumMarka.BMW; }
                    else {if (CmbMarka.Text == "Citroen") { sam.Marka = EnumMarka.Citroen; }
                        else {if (CmbMarka.Text == "Dacia") { sam.Marka = EnumMarka.Dacia; }
                            else {if (CmbMarka.Text == "Fiat") { sam.Marka = EnumMarka.Fiat; }
                                else { if (CmbMarka.Text == "Ford") { sam.Marka = EnumMarka.Ford; }
                                    else {if (CmbMarka.Text == "Hyundai") { sam.Marka = EnumMarka.Hyundai; }
                                        else {if (CmbMarka.Text == "Kia") { sam.Marka = EnumMarka.Kia; }
                                            else {if (CmbMarka.Text == "Mercedes") { sam.Marka = EnumMarka.Mercedes; }
                                                else {if (CmbMarka.Text == "Nissa") { sam.Marka = EnumMarka.Nissan; }
                                                    else {if (CmbMarka.Text == "Opel") { sam.Marka = EnumMarka.Opel; }
                                                        else { if (CmbMarka.Text == "Peugeot") { sam.Marka = EnumMarka.Peugeot; }
                                                            else { if (CmbMarka.Text == "Renault") { sam.Marka = EnumMarka.Renault; }
                                                                else {if (CmbMarka.Text == "SEAT") { sam.Marka = EnumMarka.SEAT; }
                                                                    else { if (CmbMarka.Text == "Skoda") { sam.Marka = EnumMarka.Skoda; }
                                                                        else {if (CmbMarka.Text == "Toyota") { sam.Marka = EnumMarka.Toyota; }
                                                                            else {if (CmbMarka.Text == "Volkswagen") { sam.Marka = EnumMarka.Volkswagen; }
                                                                                else { if (CmbMarka.Text == "Volvo") { sam.Marka = EnumMarka.Volvo; } }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                /*switch (CmbMarka)
                {
                    case CmbMarka.Text == "Audi": sam.Marka = EnumMarka.Audi; break;
                    case CmbMarka.Text == "BMW":sam.Marka = EnumMarka.BMW; break;
                }*/

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
