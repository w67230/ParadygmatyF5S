module lab6_1
open System;


let liczLiczbeSlow(text : string) = 
    let x = text.Split(' ');
    x.Length;

let liczLiczbeZnakow(text : string) = 
    let mutable i = 0;
    for x in text do
        if(not(x = ' ')) then i <- i + 1;

    i;

    


let main() = 
    printfn("Podaj tekst");
    let text = Console.ReadLine();

    printfn("Liczba slow: %d") (liczLiczbeSlow(text));
    printfn("Liczba znakow: %d") (liczLiczbeZnakow(text));
    

    0;



