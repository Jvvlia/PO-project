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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wypożyczalnia;

namespace WypozyczalniaSamochodowGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnWyswietlPracownikow_Click(object sender, RoutedEventArgs e)
        {
            PracownicyWindow window1 = new PracownicyWindow();
            window1.ShowDialog();
        }

        private void BtnWypozyczSamochodButton_Click(object sender, RoutedEventArgs e)
        {
            WypozyczanieWindow window2 = new WypozyczanieWindow();
            window2.ShowDialog();
            /*Wypozyczenie wypozyczenie = new(); 
             WypozyczanieWindow wyp = new(wypozyczenie);
             bool? result = wyp.ShowDialog();
             if (result == true)
             {
                 wypozyczenia.DodajWypozyczenie(wypozyczenie);
                 LstWypozyczenia.ItemsSource = new ObservableCollection<Pracownik>(wypozyczenia.WypozyczeniaLista);
             }*/
        }

        private void BtnWyswietlSamochody_Click(object sender, RoutedEventArgs e)
        {
            SamochodyWindow window3 = new SamochodyWindow();
            window3.ShowDialog();
        }

        private void BtnWyswietlWypozyczeniaButton_Click(object sender, RoutedEventArgs e)
        {
            WypozyczeniaWindow window4 = new WypozyczeniaWindow();
            window4.ShowDialog();
        }
    }
}
