module lab4_4
open System;
open System.Collections.Generic;


type Konto private (id : string, imie : string) = 
    static let ids = new Dictionary<string, Konto>();
    let imie = imie;
    let id = id;
    let mutable kwota = 0.0;

    static member StworzKonto(id :string, imie : string) : Option<Konto> = 
        let noweKonto = 
            if(not(ids.ContainsKey(id))) then 
                Some(new Konto(id, imie));
            else 
                printfn("Nie mozna utworzyc konta bo istnieje juz konto z podanym id");
                None;

        if(noweKonto.IsSome) then
            ids.Add(id, noweKonto.Value);

        noweKonto;
  

    static member GetIds() = ids;

    static member GetKonto(id : string) : Konto = 
        ids.[id];

    member this.Wplac(ilosc : float) = 
        kwota <- kwota + ilosc;

    member this.Wyplac(ilosc : float) = 
        if(ilosc > kwota) then 
            printfn("Brak wystarczajacych srodkow");
        else
            kwota <- kwota - ilosc;

    member this.WyswietlIloscPieniedzy() =
        printfn("Ilosc pieniedzy na koncie: %f") kwota;

    member this.Imie = imie;
    member this.Id = id;


let rec wybierzKonto() : Konto = 
    printfn("Wybierz co chcesz zrobic:");
    printfn("1 - Wejdz na konto");
    printfn("2 - Stworz nowe konto");
    let wybor = Console.ReadLine();

    if(wybor = "1") then
        printfn("Wpisz id konta na które chcesz wejść");
        let id = Console.ReadLine();
        if(Konto.GetIds().ContainsKey(id)) then
            Konto.GetKonto(id);
        else
            printfn("Nie znaleziono podanego konta");
            wybierzKonto();
    else if(wybor = "2") then
        printfn("Wpisz id konta ktore chcesz utworzyc");
        let id = Console.ReadLine();
        printfn("Wpisz swoje imie");
        let imie = Console.ReadLine();
        let konto = Konto.StworzKonto(id, imie);
        if(konto.IsSome) then
            konto.Value;
        else
            wybierzKonto();
    else wybierzKonto();

let rec wybierzAkcje(konto : Konto) =
    printfn("Witaj %s. Wybierz co chcesz zrobic:") konto.Imie;
    printfn("1 - Wyswietl dostepne srodki");
    printfn("2 - Wplata");
    printfn("3 - Wyplata");
    let wybor = Console.ReadLine();

    if(wybor = "1") then
        konto.WyswietlIloscPieniedzy();
    else if(wybor = "2") then
        printfn("Podaj sume jaka chcesz wplacic");
        let kwota = (float)(Console.ReadLine());
        konto.Wplac(kwota);
    else if(wybor = "3") then
        printfn("Podaj sume jaka chcesz wyplacic");
        let kwota = (float)(Console.ReadLine());
        konto.Wyplac(kwota);

    wybierzAkcje(konto);



let main() = 
    let ktos = Konto.StworzKonto("cos", "tam");
    let tam = Konto.StworzKonto("nie", "nie");
    if(ktos.IsSome) then
        ktos.Value.Wplac(54);

    
    let konto = wybierzKonto();
    wybierzAkcje(konto);


    0;
