using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia
{
    public interface ILista
    {
        void DodajPracownika(Pracownik pr);
        void UsunPracownika(string pesel);
        void SortujPracowników();
        void Wyszukaj(string imie);

    }
    public class Pracownicy : ILista
    {
        int liczbaPracowników = 0;
        List<Pracownik> pracownicy;
        public Pracownicy()
        {
            pracownicy = new();
        }
        public void DodajPracownika(Pracownik pr)
        {
            if (pr is null) { return; }
            pracownicy.Add(pr);
            ++liczbaPracowników;
        }
        public void UsunPracownika(string pesel)
        {
            --liczbaPracowników;
            pracownicy.Remove(pracownicy.Find(p => p.Pesel == pesel));
        }
        public void SortujPracowników()
        {
            pracownicy.Sort(new Comparator());
        }
        public void Wyszukaj(string imie)
        {
            pracownicy.FindAll(p => p.Imie == imie);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Lista pracowników: ");
            foreach (Pracownik pr in pracownicy)
            {
                sb.AppendLine(pr.ToString());
            }
            return sb.ToString();
        }
    }
}
