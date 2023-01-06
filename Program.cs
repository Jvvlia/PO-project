using Wypożyczalnia;

void TestSamochody()
{
    Samochod sam1=new("IDK23453", "niebieski", EnumMarka.Renault, "Trafic", 101, EnumNaped.RWD, "2 palety", 200.00f);
    Samochod sam2 = new("IDK12343", "czarny", EnumMarka.Mercedes, "G 300", 113, EnumNaped.AWD, "2996 cm3", EnumWyciagarka.nie, 300.00f);
    Samochod sam3 = new("IDN56789", "czerwony", EnumMarka.Audi, "A 5", 170, EnumNaped.FWD, 400.00f);
    Samochod sam4 = new("IDM23490", "srebrny", EnumMarka.Nissan, "Patrol", 116, EnumNaped.AWD, "2 826 cm3", EnumWyciagarka.tak, 350.00f);
    Samochod sam5 = new("ABC45789", "szary", EnumMarka.Opel, "Corsa", 87, EnumNaped.FWD, 5, 100.00f);
    Samochod sam6 = new("FGD67890", "biały", EnumMarka.Toyota, "PROACE", 120, EnumNaped.RWD, "1400kg", 230.00f);
    Samochody auta = new();
    auta.Dodaj(sam1);
    auta.Dodaj(sam2);
    auta.Dodaj(sam3);
    auta.Dodaj(sam4);
    auta.Dodaj(sam5);
    auta.Dodaj(sam6);
    Pracownik prac1 = new("Mateusz", "Kowalski", "12-03-1998", "00000000000", EnumPlec.M);
    Klient kli1 = new("Kasia", "Jarosz", "12-09-1999", "00000000000", "42222/12/0118", "123456789");
    Console.WriteLine(auta.ToString());
    Wypozyczenie wyp1 = new(sam1, "12-03-2004", "13-03-2004", kli1, prac1);
    Console.WriteLine(wyp1.ToString());
    Console.WriteLine(sam1.ToString());
    auta.ZapiszXml("auta");
}
TestSamochody();
