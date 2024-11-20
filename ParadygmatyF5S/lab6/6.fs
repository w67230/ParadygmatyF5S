module lab6_6
open System;


let przeksztalcWListeSlow(text : string) =
    List.ofArray(text.Split(' '));


let przeksztalcWSlowoIZamien(textList : List<string>, slowoDoZamiany : string, zamiennik : string, ileWystapienZamienic : int) =
    let mutable slowo = "";
    let mutable pierwszy = true;
    let mutable i = if ileWystapienZamienic < 1 then -textList.Length else 0;
    for x in textList do
        if(pierwszy) then
            if(x = slowoDoZamiany && ileWystapienZamienic > i) then
                slowo <- zamiennik;
                i <- i + 1;
            else
                slowo <- x;
            pierwszy <- false;
        else
            if(x = slowoDoZamiany && ileWystapienZamienic > i) then
                slowo <- slowo + " " + zamiennik;
                i <- i + 1;
            else
                slowo <- slowo + " " + x;

    slowo;

    
    


let main() = 
    printfn("Podaj tekst");
    let text = Console.ReadLine();
    printfn("Podaj slowo do zamiany w podanym wczesniej tekscie");
    let zamiana = Console.ReadLine();
    printfn("Podaj na jakie slowo ma sie zamienic");
    let zamiennik = Console.ReadLine();
    printfn("Podaj ile wystapien ma zostac zamienionych (wpisz liczbe mniejsza od 1 aby zamienic wszystkie wystapienia)");
    let ile = (int)(Console.ReadLine());
    let slowo = 
        przeksztalcWSlowoIZamien(przeksztalcWListeSlow(text), zamiana, zamiennik, ile);

    printfn("Zdanie z przekształconymi słowami: %s") slowo;
    

    

    0;
