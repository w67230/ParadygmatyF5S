module lab5_3
open System;
open System.Collections.Generic;


let rec permutuj(lista : List<int>, indeksZamiany : int) =
    let liczba = lista.[0];
    lista.[0] <- lista.[indeksZamiany];
    lista.[indeksZamiany] <- liczba;
    printfn("%A") lista;
    if(indeksZamiany > 1) then
        permutuj(lista, indeksZamiany - 1);

    ();

let wypiszPermutacje(lista : List<int>) = 
    if(lista.Count > 0) then
        let mutable i = 0;
        while(i < lista.Count) do
            permutuj(lista, lista.Count-1);
            i <- i + 1;
        
    ();
    
    


let main() = 

    let lista = new List<int>();
    lista.Add(3);
    lista.Add(5);
    lista.Add(7);
    //lista.Add(9); dziala tylko dla list ponizej 4 elementow
    wypiszPermutacje(lista);

    

    0;
