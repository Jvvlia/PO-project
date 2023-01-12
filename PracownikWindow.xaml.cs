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
    /// Logika interakcji dla klasy PracownikWindow.xaml
    /// </summary>
    public partial class PracownikWindow : Window
    {
        Pracownik prac;
        
        public PracownikWindow()
        {
            InitializeComponent();
        }

        public PracownikWindow(Pracownik prac) : this()
        {
            this.prac = prac;
            TxtImie.Text = prac.Imie; 
            TxtNazwisko.Text = prac.Nazwisko;
            TxtPesel.Text = prac.Pesel;
            TxtData.Text = $"{prac.DataUrodzenia:dd/MM/yyyy}";
        }


        private void BtnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool? res = false;
            if (!string.IsNullOrEmpty(TxtImie.Text) && !string.IsNullOrEmpty(TxtNazwisko.Text)
                && !string.IsNullOrEmpty(TxtPesel.Text) && !string.IsNullOrEmpty(TxtData.Text))
            {
                if(CmbPlec.Text == "Kobieta")
                { prac.Plec = EnumPlec.K;}
                else { prac.Plec = EnumPlec.M; }

                prac.Imie = TxtImie.Text;
                prac.Nazwisko = TxtNazwisko.Text;
                prac.Pesel = TxtPesel.Text;
                if (DateTime.TryParseExact(TxtData.Text, new string[] { "dd-MM-yyyy", "dd/MM/yyyy" },
                    null, System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    prac.DataUrodzenia = data;
                }


                res = true;
            }
            DialogResult = res; // jesli nie spelnia warunkow to rezultat false
        }

    }
}
