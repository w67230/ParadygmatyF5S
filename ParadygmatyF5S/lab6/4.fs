module lab6_4
open System;


let przeksztalcWListeSlow(text : string) =
    List.ofArray(text.Split(';'));

let wyswietlWedlugSchematu(textList : List<string>) = 
    let mutable imie = "";
    let mutable nazwisko = "";
    let mutable wiek = "";
    let mutable licznik = 0;
    for x in textList do
        if(licznik = 0) then
            imie <- x;
        else if(licznik = 1) then
            nazwisko <- x;
        else if(licznik = 2) then
            wiek <- x;
            printfn("%s %s %s lat") nazwisko imie wiek;
        licznik <- licznik + 1;
        if(licznik = 3) then
            licznik <- 0;
    
    


let main() = 
    printfn("Podaj imiona, nazwiska i wiek w nastepujacej formie: Imie;Nazwisko;Wiek");
    let text = Console.ReadLine();
    
    wyswietlWedlugSchematu(przeksztalcWListeSlow(text));
    

    

    0;


