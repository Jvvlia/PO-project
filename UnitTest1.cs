using System.Numerics;
using Wypo¿yczalnia;

namespace WypozyczalniaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod] 
        public void TestSilnik()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Silnik, "2996 cm3");
        }

        [TestMethod]
        public void TestModel()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Model, "G 300");
        }

        [TestMethod]
        public void TestLadownosc()
        {
            Samochod s = new("FGD67890", "bia³y", EnumMarka.Toyota, "PROACE", 120, EnumNaped.RWD, "1400kg", 230.00f);
            Assert.AreEqual(s.Ladownosc, "1400kg");
        }

        [TestMethod]
        public void TestWyci¹garka()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Wyciagarka, EnumWyciagarka.nie);
        }

        [TestMethod]
        public void TestKolor()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Kolor, "czarny");
        }

        [TestMethod]
        public void TestMoc()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Moc, 113);
        }

        [TestMethod]
        public void TestNaped()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Naped, EnumNaped.AWD);
        }

        [TestMethod]
        public void TestOplata()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Assert.AreEqual(s.Oplata, 300.00f);
        }

        [TestMethod] 
        public void TestKontsruktorSamochod()
        {
            Samochod s = new("ABC45789", "szary", EnumMarka.Opel, "Corsa", 87, EnumNaped.FWD, 5, 100.00f); 
            Assert.AreEqual(s.Marka, EnumMarka.Opel);
        }

        [TestMethod]
        public void TestKontsruktorSamochod2()
        {
            Samochod s = new("IDN56789", "czerwony", EnumMarka.Audi, "A 5", 170, EnumNaped.FWD, 200.0f, 200.0f); 
            Assert.AreEqual(s.OplataDodatkowa, 200.0f);
        }

        [TestMethod]
        public void TestKontsruktorSamochod3()
        {
            Samochod s = new("ABC45789", "zielony", EnumMarka.Dacia, "Daster", 112, EnumNaped.AWD);
            Assert.AreEqual(s.Status, EnumStatus.wolny);
        }

        [TestMethod]
        public void TestWyjatkuNrRejestracyjny()
        {
            Samochod s = new();
            Assert.ThrowsException<ZlyNumerException>(() =>  s.NumerRejestracyjny = "90ty");
        }

        [TestMethod]
        public void TestWeryfikujNumer()
        {
            Samochod s = new() { };
            Assert.IsTrue(s.WeryfikujNumer("12345678"));
        }

        [TestMethod]
        public void TestWyjatkuLiczbaDrzwi()
        {
            Samochod s = new();
            Assert.ThrowsException<BlednaLiczbaDrzwiException>(() => s.LiczbaDrzwi = 7);
        }

        [TestMethod]
        public void TestEqualsNumer()
        {
            Samochod s = new() { NumerRejestracyjny="12345678"};
            Samochod s2 = s.Clone() as Samochod;
            Assert.IsTrue(s.Equals(s2));
        }

        [TestMethod]
        public void TestCompareToSamochod()
        {
            Samochod s1 = new() { NumerRejestracyjny = "12345678" };
            Samochod s2 = new() { NumerRejestracyjny = "23456789" };
            Assert.IsTrue(s1.CompareTo(s2) < 0);
        }

        [TestMethod]
        public void TestCompareToSamochod2()
        {
            Samochod s1 = new() { NumerRejestracyjny = "12345678" };
            Samochod s2 = new() { };
            Assert.AreEqual(s1.CompareTo(s2), 1);
        }

        [TestMethod]
        public void TestKlonowanieSamochod()
        {
            Samochod s = new() { NumerRejestracyjny = "12345678", Marka=EnumMarka.Audi };
            Samochod s2=s.Clone() as Samochod;
            Assert.AreEqual(s.ToString(), s2.ToString());
        }

        [TestMethod]
        public void TestKontruktorWypozyczenie()
        {
            Samochod s = new();
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(p, w.Pracownik);
        }

        [TestMethod]
        public void TestLiczbaDni()
        {
            Samochod s = new();
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(1, w.LiczbaDni());
        }
        [TestMethod]
        public void TestLiczbaDni2()
        {
            Samochod s = new();
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-02-2023", k, p);
            Assert.AreEqual(32, w.LiczbaDni());
        }

        [TestMethod]
        public void TestObliczKwote()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(w.ObliczKwote(), 200.0f);
        }

        [TestMethod]
        public void TestObliczKwote2()
        {
            Samochod s = new("IDN56789", "czerwony", EnumMarka.Audi, "A 5", 170, EnumNaped.FWD, 200.0f, 200.0f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(w.ObliczKwote(), 400.0f);
        }

        [TestMethod]
        public void TestEqualsWypozyczenie()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Wypozyczenie w2 = w.Clone() as Wypozyczenie;
            Assert.IsTrue(w.Equals(w2));
        }

        [TestMethod]
        public void TestIComparableKlient()
        {
            Klient k1 = new() { Imie = "Marek", Nazwisko = "Kowalski" };
            Klient k2 = new() { Imie = "Marek", Nazwisko = "Towarek" };
            Assert.IsTrue(k1.CompareTo(k2) < 0);
        }

        [TestMethod]
        public void TestSamochodyDodaj()
        {
            Samochod s = new();
            Samochody samochody = new();
            samochody.Dodaj(s);
            Assert.IsTrue(samochody.SamochodyLista.Count == 1);
        }

        [TestMethod]
        public void TestSamochodyUsunWszystko()
        {
            Samochod s = new();
            Samochody samochody = new();
            samochody.Dodaj(s);
            samochody.UsunWszystko();
            Assert.IsTrue(samochody.SamochodyLista.Count == 0);
        }

        [TestMethod]
        public void TestSamochodyUsun()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Samochod s2 = new();
            Samochody samochody = new();
            samochody.Dodaj(s);
            samochody.Dodaj(s2);
            samochody.UsunSamochod("IDK12343");
            Assert.IsFalse(samochody.SamochodyLista.Contains(s));
        }

        [TestMethod]
        public void TestSamochodyUsunWszystko2()
        {
            Samochod s = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Samochod s2 = new();
            Samochody samochody = new();
            samochody.Dodaj(s);
            samochody.Dodaj(s2);
            samochody.UsunSamochod("IDK12343");
            samochody.UsunWszystko();
            Assert.IsTrue(samochody.SamochodyLista.Count == 0);
        }

        [TestMethod]
        public void TestSzukajMarka()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochody samochody = new();
            samochody.Dodaj(s);
            List<Samochod> samochodyszukane = samochody.SzukajMarka(EnumMarka.Renault);
            Assert.IsTrue(samochodyszukane.Contains(s));
        }

        [TestMethod]
        public void TestSzukajRejestracja()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochody samochody = new();
            samochody.Dodaj(s);
            List<Samochod> samochodyszukane = samochody.SzukajRejestracja("IDK23453");
            Assert.IsTrue(samochodyszukane.Contains(s));
        }

        [TestMethod]
        public void TestSzukajNaped()
        {
            Samochod s = new("ABC45789", "szary", EnumMarka.Opel, "Corsa", 87, EnumNaped.FWD, 5, 100.00f);
            Samochody samochody = new();
            samochody.Dodaj(s);
            List<Samochod> samochodyszukane = samochody.SzukajNaped(EnumNaped.FWD);
            Assert.IsTrue(samochodyszukane.Contains(s));
        }

        [TestMethod]
        public void TestCloneSamochody()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochod s2 = new("FGD67890", "bia³y", EnumMarka.Toyota, "PROACE", 120, EnumNaped.RWD, "1400kg", 230.00f);
            Samochody samochody = new();
            samochody.Dodaj(s);
            samochody.Dodaj(s2);
            Samochody samochody2 = samochody.Clone() as Samochody;
            Assert.AreEqual(samochody.SamochodyLista.ToString(), samochody2.SamochodyLista.ToString());
        }

        [TestMethod]
        public void TestSortujRejestracja()
        {
            Samochod s = new("23453234", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochod s2 = new() { NumerRejestracyjny = "12345678", Marka = EnumMarka.Audi };
            Samochody samochody = new();
            samochody.Dodaj(s);
            samochody.Dodaj(s2);
            samochody.SortujRejestracja();
            Assert.AreEqual(samochody.SamochodyLista[0] , s2);
        }

        [TestMethod]
        public void TestWypozyczenieNumerWyp()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(w.NumerWypozyczenia, $"W/{1}/{DateTime.Now.Year}-{DateTime.Now.Month}");
        }

        [TestMethod]
        public void TestWypozyczenieSamochod()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(w.Samochod, s);
        }

        [TestMethod]
        public void TestWypozyczenieZwrot()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            DateTime.TryParseExact("13-01-2023",
                new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None,
                out DateTime data);
            Assert.AreEqual(w.DataZwrotu, data);
        }

        [TestMethod]
        public void TestWypozyczenieZabranie()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            DateTime.TryParseExact("12-01-2023",
                new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None,
                out DateTime data);
            Assert.AreEqual(w.DataWypozyczenia, data);
        }

        [TestMethod]
        public void TestWypozyczeniePracownik()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(w.Pracownik, p);
        }

        [TestMethod]
        public void TestWypozyczenieKlient()
        {
            Samochod s = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Klient k = new();
            Pracownik p = new();
            Wypozyczenie w = new(s, "12-01-2023", "13-01-2023", k, p);
            Assert.AreEqual(w.Klient, k);
        }
    }
}