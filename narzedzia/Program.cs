using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

class Program
{
    static string filePath = "magazyn.json";
    static List<narzedzia> magazyn = new List<narzedzia>();
     public static void Main()
    {
        WczytajDane();
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" Witaj w menadżerze narzędzi  ");
            Console.WriteLine("1. Dodaj narzędzie ");
            Console.WriteLine("2. Aktualizuj narzędzie ");
            Console.WriteLine("3. Usuń narzędzie ");
            Console.WriteLine("4. Zapisz narzędzia ");
            Console.WriteLine("5. Wyświetl pojedyncze narzędzie ");
            Console.WriteLine("6. Wyświetl wszystkie narzędzia ");
            Console.WriteLine("7. Wyjdź ");
            Console.WriteLine(" Wybierz opcję : ");

            string opcja = Console.ReadLine();
            switch (opcja)
            {
                case "1":
                    DodajNarzedzie();
                    break;
                case "2":
                    AktualizujNarzedzia();
                    break;
                case "3":
                    UsunNarzedzia();
                    break;
                case "4":
                    ZapiszNarzedzia();
                    break;
                case "5":
                    Wyswietlpojedyncze();
                    break;
                case "6":
                    Wyswietlwszystkie();
                    break;
                case "7":
                    ZapiszDane();
                    Console.WriteLine("Zamykanie programu.");
                    return;
                default:
                    Console.WriteLine("Niepoprawna wybór, spróbuj ponownie.");
                    break;
            }
            Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
        }
    }
    public static void ZapiszDane()
        {
           string json = JsonSerializer.Serialize(magazyn, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    public static void WczytajDane()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                magazyn = JsonSerializer.Deserialize<List<narzedzia>>(json) ?? new List<narzedzia>();
            }
        }
    public static void DodajNarzedzie()
    {
        Console.WriteLine(" [Podaj  nazwę narzędzia :");
        string nazwa = Console.ReadLine();
        Console.Write("[Podaj  ilość narzędzi : ");
        if (!int.TryParse(Console.ReadLine(), out int ilosc) || ilosc <= 0)
        {
            Console.WriteLine("Niepoprawna ilość!");
            return;
        }
        Console.WriteLine("[Podaj  cenę narzędzia : ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal cena) || cena <= 0)
        {
            Console.WriteLine("Niepoprawna cena!");
            return;
        }
        int id = magazyn.Count > 0 ? magazyn[^1].Id + 1 : 1;
        magazyn.Add(new narzedzia { Id = id, nazwa = nazwa, Ilosc = ilosc, Cena = cena });
        Console.WriteLine($"Dodano narzędzie {nazwa}");
    }
    public static void AktualizujNarzedzia()
    {
        Console.WriteLine("[Podaj ID narzędzia : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Niepoprawne ID!");
            return;
        }
        narzedzia narzedzie = magazyn.Find(n => n.Id == id);
        if (narzedzie == null)
        {
            Console.WriteLine("Nie znaleziono narzędzia.");
            return;
        }
        Console.WriteLine("[Podaj nazwę narzędzia : ");
        narzedzie.nazwa = Console.ReadLine();
        Console.WriteLine("[Podaj ilość narzędzi : ");
        if (!int.TryParse(Console.ReadLine(), out int ilosc) || ilosc <= 0)
        {
            Console.WriteLine("Niepoprawna ilość!");
            return;
        }
            narzedzie.Ilosc = ilosc;
        Console.WriteLine("[Podaj cenę narzędzia : ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal cena) || cena <= 0)
        {
            Console.WriteLine("Niepoprawna cena!");
            return;
        }
        narzedzie.Cena = cena;
        ZapiszDane();
        Console.WriteLine("Narzędzie zaktualizowane!");
    }
    public static void UsunNarzedzia()
    {
        Console.WriteLine("[Podaj ID narzędzia : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Niepoprawne ID!");
            return;
        }
        narzedzia narzedzie = magazyn.Find(n => n.Id == id);
        if (narzedzie == null)
        {
            Console.WriteLine("Nie znaleziono narzędzia.");
            return;
        }
        magazyn.Remove(narzedzie);
        Console.WriteLine($"Usunięto narzędzie {narzedzie.nazwa}");
    }

    public static void ZapiszNarzedzia()
    {
        Console.WriteLine("Narzędzia zapisane.");
    }
    public static void Wyswietlpojedyncze()
    {
        Console.WriteLine("[Podaj ID narzędzia : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Niepoprawne ID!");
            return;
        }
        narzedzia narzedzie = magazyn.Find(n => n.Id == id);
        if (narzedzie == null)
        {
            Console.WriteLine("Nie znaleziono narzędzia.");
            return;
        }
        Console.WriteLine($"Id: {narzedzie.Id}, Nazwa: {narzedzie.nazwa}, Ilość: {narzedzie.Ilosc}, Cena: {narzedzie.Cena}");
    }
public static void Wyswietlwszystkie()
    {
        if (magazyn.Count == 0)
        {
            Console.WriteLine("Magazyn jest pusty.");
            return;
        }

        foreach (var narzedzie in magazyn)
        {
            Console.WriteLine($"Id: {narzedzie.Id}, Nazwa: {narzedzie.nazwa}, Ilość: {narzedzie.Ilosc}, Cena: {narzedzie.Cena}");
        }
    //Console.WriteLine("\nNaciśnij ENTER, aby wrócić do menu .");
         //   Console.ReadLine();
    }
    class narzedzia
    {
        public int Id { get; set; }
        public string nazwa { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }
    }
}


