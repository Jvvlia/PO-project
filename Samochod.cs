using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wypożyczalnia
{
    public enum EnumMarka { Audi, BMW, Citroen, Dacia, Fiat, Forf, Hyundai, Kia, Mercedes, Nissan, 
    Opel, Peugeot, Renault, SEAT, Skoda, Toyota, Volkswagen, Volvo}
    public enum EnumNaped { FWD, RWD, AWD}
    public enum EnumStatus { wypożyczony, wolny}
    public enum EnumWyciagarka { tak, nie}
    public class Samochod:ICloneable, IEquatable<Samochod>, IComparable<Samochod>
    {
        string numerRejestracyjny;
        string kolor;
        EnumMarka marka;
        string model;
        int moc;
        EnumNaped naped;
        EnumStatus status;
        float oplata; 
        //terenowy
        string silnik;
        EnumWyciagarka wyciagarka;
        //dostawczy
        string ladownosc;
        //osobowy
        int liczbaDrzwi;
        //premium
        float oplataDodatkowa;

        public string Ladownosc { get => ladownosc; set => ladownosc = value; }

        public string Silnik { get => silnik; set => silnik = value; }
        public EnumWyciagarka Wyciagarka { get => wyciagarka; set => wyciagarka = value; }

        public string NumerRejestracyjny
        {
            get => numerRejestracyjny; init
            {
                if (!WeryfikujNumer(numerRejestracyjny)) { throw new ZlyNumerException(); }
                else { numerRejestracyjny = value; };
            }
        }
        public string Kolor { get => kolor; set => kolor = value; }
        public EnumMarka Marka { get => marka; set => marka = value; }
        public int Moc { get => moc; set => moc = value; }
        public EnumNaped Naped { get => naped; set => naped = value; }
        public EnumStatus Status { get => status; set => status = value; }
        public float Oplata { get => oplata; set => oplata = value; }
        public int LiczbaDrzwi { get => liczbaDrzwi; set => liczbaDrzwi = value; }
        public float OplataDodatkowa { get => oplataDodatkowa; set => oplataDodatkowa = value; }
        public string Model { get => model; set => model = value; }

        public Samochod() { }
        public Samochod(string numer, string kolor, EnumMarka marka,string model, int moc, EnumNaped naped) 
        {
            NumerRejestracyjny = numer;
            Kolor = kolor;
            Marka = marka;
            Moc = moc;
            Naped = naped;
            Status = status;
            Oplata = 0;
            Model = model;
            OplataDodatkowa = 0.00f;
            Status = EnumStatus.wolny;
        }
        //terenowy
        public Samochod(string numer, string kolor, EnumMarka marka, string model, int moc, EnumNaped naped, string silnik, EnumWyciagarka wyciagarka, float oplata):
            this(numer, kolor, marka,model, moc, naped)
        {
            Silnik = silnik;
            Wyciagarka = wyciagarka;
            Oplata = oplata;
            OplataDodatkowa = 0.00f;
        }
        //dostawczy
        public Samochod(string numer, string kolor, EnumMarka marka, string model, int moc, EnumNaped naped, string lodownosc, float oplata) :
           this(numer, kolor, marka, model, moc, naped)
        {
            Ladownosc = lodownosc;
            Oplata = oplata;
            OplataDodatkowa = 0.00f;
        }
        //osobowy
        public Samochod(string numer, string kolor, EnumMarka marka, string model, int moc, EnumNaped naped, int liczba, float oplata) :
           this(numer, kolor, marka, model, moc, naped)
        {
            if (liczba < 2 && liczba > 5)
            {
                throw new BlednaLiczbaDrzwiException();
            }
            else { LiczbaDrzwi = liczba; }
            Oplata = oplata;
            OplataDodatkowa = 0.00f;
        }
        //premium
        public Samochod(string numer, string kolor, EnumMarka marka, string model, int moc, EnumNaped naped, float oplata) :
           this(numer, kolor, marka, model, moc, naped)
        {
            OplataDodatkowa = 200.00f;
            Oplata = oplata;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public bool WeryfikujNumer(string numer)
        {
            if (numer ==null)
            {
                return true;
            }
            else { return numer.Length == 8; }
        }
        public bool Equals(Samochod? other) => numerRejestracyjny.Equals(other.numerRejestracyjny);

        public override string ToString()
        {
            return $"{NumerRejestracyjny}, {Marka}, {Kolor}, {Naped}, {Status}";
        }

        public int CompareTo(Samochod? other)
        {
            if(other is null) { return 1; }
            int cmprejestr = NumerRejestracyjny.CompareTo(other.NumerRejestracyjny);
            return cmprejestr;
        }
    }
    public class ZlyNumerException : Exception
    {
        public ZlyNumerException()
        {
            Console.WriteLine("zły numer!");
        }

    }
    public class BlednaLiczbaDrzwiException : Exception
    {
        public BlednaLiczbaDrzwiException()
        {
            Console.WriteLine("Niepoprawna liczba drzwi");
        }
    }
}
