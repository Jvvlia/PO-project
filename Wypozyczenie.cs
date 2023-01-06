using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia
{
    public class Wypozyczenie:ICloneable, IEquatable<Wypozyczenie>
    {
        string numerWypozyczenia;
        static int aktualnyNumer;
        Klient klient;
        Pracownik pracownik;
        Samochod samochod;
        DateTime dataWypozyczenia;
        DateTime dataZwrotu;
        public string NumerWypozyczenia { get => numerWypozyczenia; }
        public Samochod Samochod { get => samochod; set => samochod = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public DateTime DataZwrotu { get => dataZwrotu; set => dataZwrotu = value; }
        public Klient Klient { get => klient; set => klient = value; }
        public Pracownik Pracownik { get => pracownik; set => pracownik = value; }

        static Wypozyczenie()
        {
            aktualnyNumer = 1;
        }
        public Wypozyczenie(Samochod samochod, string wypozyczenie, string oddanie, Klient klient, Pracownik pracownik)
        {
            numerWypozyczenia = $"W/{aktualnyNumer++}/{DateTime.Now.Year}-{DateTime.Now.Month}";
            Samochod = samochod;
            if (DateTime.TryParseExact(wypozyczenie,
                new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None,
                out DateTime data))
            { DataWypozyczenia = data; }
            if (DateTime.TryParseExact(oddanie,
                new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None,
                out DateTime data2))
            { DataZwrotu = data2; }
            samochod.Status = EnumStatus.wypożyczony;
            Klient = klient;
            Pracownik = pracownik;
        }
        public int LiczbaDni()
        {
            return DataZwrotu.Date.Day - DataWypozyczenia.Date.Day;
        }
        public delegate float KwotaDoZaplaty(int lDni, float oplata, float oplataDodatkowa);
        public float Kwota(int lDni, float oplata, float oplataDodatkowa) { return lDni * oplata + oplataDodatkowa; }
        public float ObliczKwote()
        {
            KwotaDoZaplaty suma = Kwota;
            return suma(LiczbaDni(), Samochod.Oplata, Samochod.OplataDodatkowa);
        }

        /*public float DoZaplaty()
        {
            return LiczbaDni() * Samochod.Oplata+Samochod.OplataDodatkowa;
        }*/
        public override string ToString()
        {
            return $"{NumerWypozyczenia}, {Samochod}, {DataZwrotu:d}";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool Equals(Wypozyczenie? other) => numerWypozyczenia.Equals(other.numerWypozyczenia);

    }
    public class ComparatorWyp : IComparer<Wypozyczenie>
    {
        public int Compare(Wypozyczenie? x, Wypozyczenie? y)
        {
            return (x.NumerWypozyczenia.CompareTo(y.NumerWypozyczenia));
        }
    }
}
