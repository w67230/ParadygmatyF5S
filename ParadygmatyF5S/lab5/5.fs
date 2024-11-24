module lab5_5
open System;
open System.Collections.Generic;


let podmien(lista : List<int>, i : int, j : int) =
    if(i = j) then
        ();
    else
        let temp = lista.[i];
        lista.[i] <- lista.[j];
        lista.[j] <- temp;
        ();


let podzielListe(lista : List<int>, lewo : int, prawo : int) : int = 
    let punkt : int = lewo + (prawo - lewo)/2;
    let srodkowyElement = lista.[punkt];
    podmien(lista, punkt, prawo);
    let mutable pozycja = lewo;
    let mutable i = lewo;
    while(i < prawo) do
        if(lista.[i] < srodkowyElement) then
            podmien(lista, i, pozycja);
            pozycja <- pozycja + 1;
        i <- i + 1;

    podmien(lista, pozycja, prawo);

    pozycja;

let rec szybkieSortowanie(lista : List<int>, lewo : int, prawo : int) =
    if(lewo < prawo) then
        let i = podzielListe(lista, lewo, prawo);
        szybkieSortowanie(lista, lewo, i - 1);
        szybkieSortowanie(lista, i + 1, prawo);


let main() = 

    let lista = new List<int>();
    lista.Add(5);
    lista.Add(1);
    lista.Add(6);
    lista.Add(2);
    lista.Add(3);
    lista.Add(9);
    lista.Add(5);
    szybkieSortowanie(lista, 0, lista.Count - 1);
    for x in lista do
        printf("%d") x;
    

    0;
