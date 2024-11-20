module lab5_3
open System;
open System.Collections.Generic;


let rec permutuj(lista : List<int>, indeksZamiany : int) =
    if(indeksZamiany = 1) then
        printfn("%A") lista;
    else   
        permutuj(lista, indeksZamiany - 1);
        
        let mutable i = 0;
        while(i < indeksZamiany - 1) do
            if(i%2 = 0) then
                let liczba = lista.[i];
                lista.[i] <- lista.[indeksZamiany - 1];
                lista.[indeksZamiany - 1] <- liczba;
            else
                let liczba = lista.[0];
                lista.[0] <- lista.[indeksZamiany - 1];
                lista.[indeksZamiany - 1] <- liczba;
            permutuj(lista, indeksZamiany - 1);
            i <- i + 1;

    ();
    
    


let main() = 

    let lista = new List<int>();
    lista.Add(1);
    lista.Add(3);
    lista.Add(5);
    lista.Add(7);
    lista.Add(9);
    permutuj(lista, lista.Count);

    

    0;
