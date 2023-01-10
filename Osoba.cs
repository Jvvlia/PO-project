using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia
{
    public abstract class Osoba
    {
        string imie;
        string nazwisko;
        string pesel;
        DateTime dataUrodzenia;
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel
        {
            get => pesel; set
            {
                if (!WeryfikujPesel(value))
                {
                    throw new BlednyPeselException();
                }
                pesel = value;
            }
        }

        bool WeryfikujPesel(string pesel)
        {
            if (pesel == "00000000000") { return true; }
            int[] cyfry = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;
            for (int i = 0; i < cyfry.Length; i++)
            {
                suma = suma + cyfry[i] * int.Parse(pesel[i].ToString());
            }
            long cyfra = long.Parse(pesel) % 10;
            int reszta = suma % 10;
            if (reszta == 0 && cyfra == 0)
            {
                return true;
            }
            else if ((10 - reszta) == cyfra)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Osoba()
        {
            imie = String.Empty;
            nazwisko = String.Empty;
            Pesel = new string('0', 11);
        }

        public Osoba(string imie, string nazwisko) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel) : this(imie, nazwisko)
        {
            if (DateTime.TryParseExact(dataUrodzenia, new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None, out DateTime data))
            { DataUrodzenia = data; }
            Pesel = pesel;
        }
        public int Wiek()
        {
            DateTime data = new DateTime(0001, 01, 01);
            int wiek = DateTime.Today.Year - DataUrodzenia.Year;
            return wiek;
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} [{Wiek() + "lat"}], ur. {DataUrodzenia:yyyy-MM-dd} ({Pesel})";
        }
    }
    class BlednyPeselException : Exception
    {
        public BlednyPeselException()
        {
            Console.WriteLine("Niepoprawny PESEL");
        }
    }
}
