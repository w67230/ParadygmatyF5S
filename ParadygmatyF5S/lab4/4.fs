module lab4_4
open System;
open System.Collections.Generic;


type Konto private (id : string, imie : string) = 
    static let ids = new Dictionary<string, Konto>();
    let imie = imie;
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


let main() = 
    // TODO dac tu menu zeby sie klikalo i mozna bylo se tworzyc itp
    let ktos = Konto.StworzKonto("cos", "tam");
    let tam = Konto.StworzKonto("cos", "nie");
    if(ktos.IsSome) then
        ktos.Value.Wplac(54);
        ktos.Value.WyswietlIloscPieniedzy();
        ktos.Value.Wyplac(60);
        ktos.Value.WyswietlIloscPieniedzy();
        ktos.Value.Wyplac(25);
        ktos.Value.WyswietlIloscPieniedzy();

    0;
