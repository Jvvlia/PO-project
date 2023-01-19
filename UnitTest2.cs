using Wypożyczalnia;

namespace TestKlasyGlowa
{
    [TestClass]
    public class UnitTest2
    {
        
        //Pracownik
        [TestMethod]
        public void TestKonstruktorPracownik()
        {
            string pierwszeImie = "Kasia";
            Pracownik pr = new(pierwszeImie, "Klucz", "21.02.1988", "00000000000", EnumPlec.K);
            Assert.AreEqual(pierwszeImie, pr.Imie);

        }
        [TestMethod]
        public void TestKonstruktorPracownik2()
        {
            Pracownik pr = new();
            Assert.IsNotNull(pr);
        }
        [TestMethod]
        public void TestPracownik()
        {
            Pracownik pr = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Assert.AreEqual(pr.Imie, "Jan");
        }
        [TestMethod]
        public void TestPracownik2()
        {
            Pracownik pr = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Assert.AreEqual(pr.Nazwisko, "Nowak");
        }
        [TestMethod]
        public void TestPracownik3()
        {
            Pracownik pr = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Assert.AreEqual(pr.Pesel, "70082186174");
        }
        [TestMethod]
        public void TestPracownik4()
        {
            Pracownik pr = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Assert.AreEqual(pr.Plec, EnumPlec.M);
        }

        [TestMethod]
        public void TestComparator()
        {
            Pracownik p1 = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Pracownik p2 = new("Katarzyna", "Kowalska", "19/07/2000", "00000000000", EnumPlec.K);
            Comparator.ReferenceEquals(p1, p2);
            Assert.IsFalse(p1.Equals(p2));
        }
        //Klient 

        [TestMethod]
        public void TestKonstruktorKlient()
        {
            Klient kl = new();
            Assert.IsNotNull(kl);
        }

        [TestMethod]
        public void TestKonstruktorKlient2()
        {
            Klient kl = new();
            Assert.AreEqual(kl.Pesel,"00000000000");
        }
        [TestMethod]
        public void TestKlient()
        {
            Klient kl = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Assert.AreEqual(kl.Imie,"Miłosz");
        }
        [TestMethod]
        public void TestKlient2()
        {
            Klient kl = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Assert.AreEqual(kl.Nazwisko, "Pilch");
        }
        
        [TestMethod]
        public void TestKlient3()
        {
            Klient kl = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Assert.AreEqual(kl.Pesel, "97102103360");
        }
        [TestMethod]
        public void TestKlient4()
        {
            Klient kl = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Assert.AreEqual(kl.NumerPrawaJazdy, "43434/12/1444");
        }
        [TestMethod]
        public void TestKlient5()
        {
            Klient kl = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Assert.AreEqual(kl.NumerTelefonu, "333444555");
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Klient k1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", "22222/33/5555", "020202020");
            Klient k2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Assert.AreEqual(k2.CompareTo(k1), 1);
        }
        [TestMethod]
        public void TestWyjatkuDlaPesela()
        {
            Klient kl = new();
            Assert.ThrowsException<BlednyPeselException>(()=>kl.Pesel="2333");
        }

        [TestMethod]
        public void TestWyjatekPrawoJazdy()
        {
            Klient kl = new();
            Assert.ThrowsException<NrPrawaJazdyException>(() => kl.NumerPrawaJazdy="22/333");
        }

        [TestMethod]
        public void TestWyjatekNrTel()
        {
            Klient kl = new();
            Assert.ThrowsException<NrTelefonuException>(() => kl.NumerTelefonu="010101");
        }


        //Osoba 

        [TestMethod]
        public void TestWiek()
        {
            DateTime data = new DateTime(2000, 05, 21);
            Klient kl = new() { DataUrodzenia=data};
            System.TimeSpan diff = DateTime.Now.Subtract(data);
            Assert.AreEqual(kl.Wiek(), System.Math.Ceiling(diff.Days / 365.25));            
        }

        //Pracownicy
        [TestMethod]
        public void TestPracownicyLista()
        {
            Pracownicy prLista = new();
            Assert.IsNotNull(prLista.PracownicyLista);                     
        }
        [TestMethod]
        public void TestPracownicyListaDodawanie()
        {
            Pracownicy prLista = new();
            Pracownik pr = new();
            prLista.DodajPracownika(pr);
            Assert.IsTrue(prLista.PracownicyLista.Contains(pr));
        }
        [TestMethod]
        public void TestPracownicyListaUsuwanie()
        {
            Pracownicy prLista = new();
            Pracownik pr = new() { Pesel="00000000000"};
            prLista.DodajPracownika(pr);
            prLista.UsunPracownika("00000000000");
            Assert.IsFalse(prLista.PracownicyLista.Contains(pr));
        }
        [TestMethod]
        public void TestPracownicyListaSortuj()
        {
            Pracownicy prLista=new();
            Pracownik p1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", EnumPlec.K);
            Pracownik p2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", EnumPlec.M);
            prLista.DodajPracownika(p1);
            prLista.DodajPracownika(p2);
            prLista.SortujPracowników();
            Assert.AreEqual(prLista.PracownicyLista[0], p1);
        }
        [TestMethod]
        public void TestPracownicyListaWyszukaj()
        {
            Pracownicy prLista = new();
            Pracownik p1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", EnumPlec.K);
            Pracownik p2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", EnumPlec.M);
            prLista.DodajPracownika(p1);
            prLista.DodajPracownika(p2);
            prLista.Wyszukaj("Karolina");
            Assert.AreEqual(p1.Imie, "Karolina");
        }
        [TestMethod]
        public void TestPracownicyListaLiczba()
        {
            Pracownicy prLista = new();
            Pracownik p1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", EnumPlec.K);
            Pracownik p2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", EnumPlec.M);
            prLista.DodajPracownika(p1);
            prLista.DodajPracownika(p2);
            Assert.AreEqual(prLista.LiczbaPracowników, 2);
        }
        [TestMethod]
        public void TestPracownicyListaLiczba2()
        {
            Pracownicy prLista = new();
            Pracownik p1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", EnumPlec.K);
            Pracownik p2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", EnumPlec.M);
            prLista.DodajPracownika(p1);
            prLista.DodajPracownika(p2);
            prLista.UsunPracownika("00000000000");
            Assert.AreEqual(prLista.LiczbaPracowników, 1);
        }
        // Wypożyczenia
        [TestMethod]
        public void TestWypozyczenia()
        {

            Wypozyczenia wypLista=new();
            Assert.IsNotNull(wypLista);
        }
        [TestMethod]
        public void TestWypozyczeniaDodaj()
        {

            Wypozyczenia wypLista = new();
            Klient k1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", "22222/33/5555", "020202020");
            Pracownik p1 = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Samochod sam1 = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Wypozyczenie wyp1 = new(sam1, "12-03-2004", "13-03-2004", k1, p1);
            wypLista.DodajWypozyczenie(wyp1);
            Assert.IsTrue(wypLista.WypozyczeniaLista.Contains(wyp1));
        }
        [TestMethod]
        public void TestWypozyczeniaUsun()
        {

            Wypozyczenia wypLista = new();
            Klient k1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", "22222/33/5555", "020202020");
            Klient k2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Pracownik p1 = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Pracownik p2 = new("Katarzyna", "Kowalska", "19/07/2000", "00000000000", EnumPlec.K);
            Samochod sam1 = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochod sam2 = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Wypozyczenie wyp1 = new(sam1, "12-03-2004", "13-03-2004", k1, p1);
            Wypozyczenie wyp2 = new(sam2, "19-12-2022", "28-12-2022", k2, p2);
            wypLista.DodajWypozyczenie(wyp1);
            wypLista.DodajWypozyczenie(wyp2);
            wypLista.UsunWypozyczenie(wyp1.NumerWypozyczenia);
            Assert.IsFalse(wypLista.WypozyczeniaLista.Contains(wyp1));
        }
        [TestMethod]
        public void TestWypozyczeniaSortuj()
        {

            Wypozyczenia wypLista = new();
            Klient k1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", "22222/33/5555", "020202020");
            Klient k2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Pracownik p1 = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Pracownik p2 = new("Katarzyna", "Kowalska", "19/07/2000", "00000000000", EnumPlec.K);
            Samochod sam1 = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochod sam2 = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Wypozyczenie wyp1 = new(sam1, "12-03-2004", "13-03-2004", k1, p1);
            Wypozyczenie wyp2 = new(sam2, "19-12-2022", "28-12-2022", k2, p2);
            wypLista.DodajWypozyczenie(wyp1);
            wypLista.DodajWypozyczenie(wyp2);
            wypLista.SortujWypozyczenia();
            Assert.AreEqual(wypLista.WypozyczeniaLista[0], wyp1);
        }
        [TestMethod]
        public void TestWypozyczeniaWyszukajS()
        {

            Wypozyczenia wypLista = new();
            Klient k1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", "22222/33/5555", "020202020");
            Klient k2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Pracownik p1 = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Pracownik p2 = new("Katarzyna", "Kowalska", "19/07/2000", "00000000000", EnumPlec.K);
            Samochod sam1 = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochod sam2 = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Wypozyczenie wyp1 = new(sam1, "12-03-2004", "13-03-2004", k1, p1);
            Wypozyczenie wyp2 = new(sam2, "19-12-2022", "28-12-2022", k2, p2);
            wypLista.DodajWypozyczenie(wyp1);
            wypLista.DodajWypozyczenie(wyp2);
            List<Wypozyczenie> wypozyczeniaSzukaj = wypLista.WyszukajWypozyczenieS("IDK12343");
            Assert.IsTrue(wypozyczeniaSzukaj.Contains(wyp2));
        }
        [TestMethod]
        public void TestWypozyczeniaWyszukajP()
        {

            Wypozyczenia wypLista = new();
            Klient k1 = new("Karolina", "Adamek", "03/12/1991", "00000000000", "22222/33/5555", "020202020");
            Klient k2 = new("Miłosz", "Pilch", "21/04/1960", "97102103360", "43434/12/1444", "333444555");
            Pracownik p1 = new("Jan", "Nowak", "20/06/1977", "70082186174", EnumPlec.M);
            Pracownik p2 = new("Katarzyna", "Kowalska", "19/07/2000", "00000000000", EnumPlec.K);
            Samochod sam1 = new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
            Samochod sam2 = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
            Wypozyczenie wyp1 = new(sam1, "12-03-2004", "13-03-2004", k1, p1);
            Wypozyczenie wyp2 = new(sam2, "19-12-2022", "28-12-2022", k2, p2);
            wypLista.DodajWypozyczenie(wyp1);
            wypLista.DodajWypozyczenie(wyp2);
            List<Wypozyczenie> wypozyczeniaSzukaj = wypLista.WyszukajWypozyczenieP("70082186174");
            Assert.IsTrue(wypozyczeniaSzukaj.Contains(wyp1));
        }

    }
}