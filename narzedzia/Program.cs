using System;
using System.Collections.Generic;
using System.Linq;

class Program
{


    public static void Main(string[] args)
    {

        Console.WriteLine(" Witaj w menadżerze narzędzi  ");
        Console.WriteLine("1. Dodaj narzędzie ");
        Console.WriteLine("2. Aktualizuj narzędzie ");
        Console.WriteLine("3. Usuń narzędzie ");
        Console.WriteLine("4. Zapisz narzędzia ");
        Console.WriteLine("5. Wyświetl pojedyncze narzędzie ");
        Console.WriteLine("6. Wyświetl wszystkie narzędzia ");
        Console.WriteLine("7.  Wyjdź ");
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
                Console.WriteLine("Zamykanie programu.");
                return;
            default:
                Console.WriteLine("Nieprawidłowy wybór");
                break;


        }
    }


    public static void DodajNarzedzie() { 
    Console.WriteLine(" Podaj nazwę narzędzia :");
    string nazwa = Console.ReadLine();
    Console.Write("Podaj ilość narzędzi : ");
    if (!int.TryParse(Console.ReadLine(), out int ilosc) || ilosc <= 0)
    {
        Console.WriteLine("Niepoprawna ilość!");
        return;

    }
        Console.WriteLine("Podaj cenę narzędzia : ");


}

    public static void AktualizujNarzedzia() { 

    }

    public static void UsunNarzedzia()
    {

    }
    public static void ZapiszNarzedzia()
    {

    }
    public static void Wyswietlpojedyncze()
    {

    }
    public static void Wyswietlwszystkie()
    {

    }
   


}