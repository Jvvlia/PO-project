﻿using System;
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
        public List<Wypozyczenie> WypozyczeniaLista { get => wypozyczenia; set => wypozyczenia = value; }
        public Wypozyczenia()
        {
            WypozyczeniaLista = new();
        }
        public void DodajWypozyczenie(Wypozyczenie wyp)
        {
            if (wyp is null) { return; }
            WypozyczeniaLista.Add(wyp);
        }
        public void SortujWypozyczenia()
        {
            WypozyczeniaLista.Sort(new ComparatorWyp());
        }
        public void UsunWypozyczenie(string numer)
        {
            WypozyczeniaLista.Remove(wypozyczenia.Find(p => p.NumerWypozyczenia == numer));
        }
        public void WyszukajWypozyczenieK(Klient k)
        {
            WypozyczeniaLista.FindAll(wyp => wyp.Klient == k);
        }
        public void WyszukajWypozyczenieS(Samochod s)
        {
            WypozyczeniaLista.FindAll(wyp => wyp.Samochod == s);
        }
        public void WyszukajWypozyczenieP(Pracownik p)
        {
            WypozyczeniaLista.FindAll(wyp => wyp.Pracownik == p);
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
            XmlSerializer serializer = new XmlSerializer(typeof(Wypozyczenia));
            serializer.Serialize(sw, this);
        }
        public static Wypozyczenia OdczytajXml(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            using StreamReader sr = new StreamReader(fname);
            XmlSerializer xs = new(typeof(Wypozyczenia));
            return xs.Deserialize(sr) as Wypozyczenia;
        }
    }
}
