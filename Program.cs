using System;
using System.Collections.Generic; //uzywamy kolekcji generycznych (slownik par)

class Program
{
    static void Main() //glowna regula
    {
        Console.WriteLine("Podaj liczbę rzymską - zakres I do MMMM (1-4000):");
        string liczbaRzymska = Console.ReadLine(); // pobranie liczby od usera
        int arabska = DekodujLiczbeRzymska(liczbaRzymska); // dekodowanie na arabska
        Console.WriteLine("Liczba arabska: " + arabska);
  
    }

    // funkcja dekodowania
    static int DekodujLiczbeRzymska(string rzymska)
    {
        // slownik par rzymska-arabska
        Dictionary<char, int> wartosci = new Dictionary<char, int>
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int wynik = 0;
        int poprzedniaWartosc = 0;

        // iteracja ciagu od konca (zapis rzymski jest odrwotny do arabskiego)
        for (int i = rzymska.Length - 1; i >= 0; i--)
        {
            int aktualnaWartosc = wartosci[rzymska[i]];
            if (aktualnaWartosc < poprzedniaWartosc)
            {
                wynik -= aktualnaWartosc;
            }
            else
            {
                wynik += aktualnaWartosc;
            }
            poprzedniaWartosc = aktualnaWartosc;
        }
        // zwracanie wyniku
        return wynik;
    }
}
