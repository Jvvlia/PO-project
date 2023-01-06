using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wypożyczalnia
{
    public class Klient : Osoba, IComparable<Klient>
    {
        string numerPrawaJazdy;
        string numerTelefonu;
        public string NumerPrawaJazdy
        {
            get => numerPrawaJazdy; init
            {
                if (!WeryfikujNumerPrawaJazdy(value))
                {
                    throw new NrPrawaJazdyException();

                }
                numerPrawaJazdy = value;
            }
        }
        public string NumerTelefonu
        {
            get => numerTelefonu; init
            {
                if (!WeryfikujNumerTelefonu(value))
                {
                    throw new NrTelefonuException();

                }
                numerTelefonu = value;
            }
        }

        bool WeryfikujNumerPrawaJazdy(string numerPrawaJazdy)
        {
            return Regex.IsMatch(numerPrawaJazdy, @"\d{5}/\d{2}/\d{4}");
        }
        bool WeryfikujNumerTelefonu(string numerTelefonu)
        {
            return numerTelefonu.Length == 9;
        }
        public Klient(string imie, string nazwisko, string dataUrodzenia, string pesel, string numerPrawaJazdy, string numerTelefonu) : base(imie, nazwisko, dataUrodzenia, pesel)
        {
            this.numerPrawaJazdy = numerPrawaJazdy;
            this.numerTelefonu = numerTelefonu;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, numer telefonu: {numerTelefonu}, numer prawa jazdy: {numerPrawaJazdy}";
        }
        public int CompareTo(Klient? other)
        {
            int cmpnazw = Nazwisko.CompareTo(other.Nazwisko);
            if (cmpnazw != 0) { return cmpnazw; }
            return Imie.CompareTo(other.Imie);
        }
        class NrPrawaJazdyException : Exception
        {
            public NrPrawaJazdyException()
            {
                Console.WriteLine("Niepoprawny numer prawa jazdy");
            }
        }
        class NrTelefonuException : Exception
        {
            public NrTelefonuException()
            {
                Console.WriteLine("Niepoprawny numer telefonu");
            }
        }
    }
}
