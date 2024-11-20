module lab6_5
open System;


let przeksztalcWListeSlow(text : string) =
    List.ofArray(text.Split(' '));

let getNajdluzszeSlowo(textList : List<string>) : string = 
    let mutable i = -1;
    let mutable slowo = "";
    for x in textList do
        if(x.Length > i) then
            slowo <- x;
            i <- slowo.Length;

    slowo;
    
    


let main() = 
    printfn("Podaj tekst");
    let text = Console.ReadLine();
    let slowo = 
        getNajdluzszeSlowo(przeksztalcWListeSlow(text));

    printfn("Najdluzsze slowo to: %s") slowo;
    printfn("Jego dlugosc wynosi: %d") (slowo.Length);
    

    

    0;

