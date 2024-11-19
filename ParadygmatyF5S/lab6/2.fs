module lab6_2
open System;




let sprawdzPalindrom(text : string) = 
    let mutable odwrocony = "";
    let mutable i = text.Length-1;
    while(i > -1) do
        odwrocony <- odwrocony + text.[i].ToString();
        i <- i - 1;

    text = odwrocony;
    
    


let main() = 
    printfn("Podaj tekst");
    let text = Console.ReadLine();

    if(sprawdzPalindrom(text)) then  
        printfn("Podany tekst jest palindromem");
    else
        printfn("Podany tekst nie jest palindromem");

    0;

