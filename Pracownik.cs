using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypożyczalnia
{
    public enum EnumPlec { K, M }
    public class Pracownik : Osoba
    {
        EnumPlec plec;
        // int liczbaZrealizowanychWypozyczen;

        public Pracownik(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec) : base(imie, nazwisko, dataUrodzenia, pesel)
        {
            this.plec = plec;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, ({plec})";
        }
    }
    class Comparator : IComparer<Pracownik>
    {
        public int Compare(Pracownik? x, Pracownik? y)
        {
            return (x.Nazwisko.CompareTo(y.Nazwisko));
        }
    }
}
