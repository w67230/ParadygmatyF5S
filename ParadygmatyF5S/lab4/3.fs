module lab4_3
open System;


// musze takie cos robic bo mapy w f# to jakis niesmieszny zart
type Liczba() = 
    let mutable liczba = 1;

    member this.Increment() = liczba <- liczba + 1;

    member this.GetLiczba() = liczba;



let liczLiczbeSlow(text : string) = 
    let x = text.Split(' ');
    x.Length;

let liczLiczbeZnakow(text : string) = 
    let mutable i = 0;
    for x in text do
        if(not(x = ' ')) then i <- i + 1;

    i;

let czesteSlowo(text : string) = 
    let slowa = text.Split(' ');
    let mutable mapaSlow = Map.empty<string, Liczba>;
    for x in slowa do
        if(mapaSlow.ContainsKey(x)) then mapaSlow.[x].Increment();
        else mapaSlow <- mapaSlow.Add(x, new Liczba());

    let mutable i = 0;
    let mutable slowo = "";
    for x in mapaSlow do
        if(x.Value.GetLiczba() > i) then 
            i <- x.Value.GetLiczba();
            slowo <- x.Key;
    // wlasnie po skonczeniu tego zadania sie dowiedzialem ze 
    //f# ma Dictionary ktore jest po prostu mutowalna mapa 
    //ale nie chce mi sie juz zmieniac bo dziala
    slowo;
    


let main() = 
    printfn("Podaj tekst");
    let text = Console.ReadLine();

    printfn("Liczba slow: %d") (liczLiczbeSlow(text));
    printfn("Liczba znakow: %d") (liczLiczbeZnakow(text));
    printfn("Najczesciej wystepujace slowo: %s") (czesteSlowo(text));
    

    0;