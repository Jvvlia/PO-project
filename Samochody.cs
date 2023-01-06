using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wypożyczalnia
{
    public interface IWyszukiwanie
    {
        public List<Samochod> SzukajMarka(EnumMarka marka);
        public List<Samochod> SzukajRejestracja(string rejestracja);
        public List<Samochod> SzukajNaped(EnumNaped naped);
    }

    public class Samochody:IWyszukiwanie, ICloneable
    {
        List<Samochod> samochody;

        public List<Samochod> SamochodyLista { get => samochody; set => samochody = value; }

        public Samochody()
        {
            SamochodyLista = new List<Samochod>();
        }
        public void Dodaj(Samochod sam)
        {
            if(sam is null) { return; }
            SamochodyLista.Add(sam);
        }
        public void UsunWszystko()
        {
            SamochodyLista.Clear();
        }
        public void UsunSamochod(string numer)
        {
            SamochodyLista.RemoveAll(sam => sam.NumerRejestracyjny == numer);
        }
        public List<Samochod> SzukajMarka(EnumMarka marka)
        {
            return SamochodyLista.FindAll(sam => sam.Marka == marka);
        }
        public List<Samochod> SzukajRejestracja(string rejestracja)
        {
            return SamochodyLista.FindAll(sam => sam.NumerRejestracyjny == rejestracja);
        }

        public List<Samochod> SzukajNaped(EnumNaped naped)
        {
            return SamochodyLista.FindAll(sam => sam.Naped == naped);
        }

        public object Clone()
        {
            Samochody samochody = Clone() as Samochody;
            samochody.SamochodyLista = new();
            SamochodyLista.ForEach(sam => samochody.SamochodyLista.Add(sam.Clone() as Samochod));
            return SamochodyLista;
        }
        public void SortujRejestracja()
        {
            SamochodyLista.Sort();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            SamochodyLista.ForEach(sam => sb.AppendLine(sam.ToString()));
            return sb.ToString();
        }
        // konstruktor nieparametryczny do Samochod
        public void ZapiszXml(string fname)
        {
            using StreamWriter sw = new(fname);
            XmlSerializer serializer = new XmlSerializer(typeof(Samochody));
            serializer.Serialize(sw, this);
        }
        public static Samochody OdczytajXml(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            using StreamReader sr = new StreamReader(fname);
            XmlSerializer xs = new(typeof(Samochody));
            return xs.Deserialize(sr) as Samochody;
        }
    }
}
