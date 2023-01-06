using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wypożyczalnia
{
    public interface IWypozyczenia
    {
        void DodajWypozyczenie(Wypozyczenie wyp);
        void SortujWypozyczenia();
        void UsunWypozyczenie(string numerWypozyczenia);
        void WyszukajWypozyczenieK(Klient k);
        void WyszukajWypozyczenieS(Samochod s);
        void WyszukajWypozyczenieP(Pracownik p);
    }
    internal class Wypozyczenia : IWypozyczenia
    {
        List<Wypozyczenie> wypozyczenia;
        public Wypozyczenia()
        {
            wypozyczenia = new();
        }
        public void DodajWypozyczenie(Wypozyczenie wyp)
        {
            if (wyp is null) { return; }
            wypozyczenia.Add(wyp);
        }
        public void SortujWypozyczenia()
        {
            wypozyczenia.Sort(new ComparatorWyp());
        }
        public void UsunWypozyczenie(string numer)
        {
            wypozyczenia.Remove(wypozyczenia.Find(p => p.NumerWypozyczenia == numer));
        }
        public void WyszukajWypozyczenieK(Klient k)
        {
            wypozyczenia.FindAll(wyp => wyp.Klient == k);
        }
        public void WyszukajWypozyczenieS(Samochod s)
        {
            wypozyczenia.FindAll(wyp => wyp.Samochod == s);
        }
        public void WyszukajWypozyczenieP(Pracownik p)
        {
            wypozyczenia.FindAll(wyp => wyp.Pracownik == p);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Lista wypożyczeń: ");
            foreach (Wypozyczenie wyp in wypozyczenia)
            {
                sb.AppendLine(wyp.ToString());
            }
            return sb.ToString();
        }
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
