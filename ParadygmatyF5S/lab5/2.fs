module lab5_2
open System;
open System.Collections.Generic;


type Wezel(wartosc : int, lewySyn : Option<Wezel>, prawySyn : Option<Wezel>) =
    let wartosc = wartosc;
    let lewySyn = lewySyn;
    let prawySyn = prawySyn;


    member this.getWartosc() = wartosc;
    member this.getLewySyn() = lewySyn.Value;
    member this.getPrawySyn() = prawySyn.Value;

    member this.hasLewySyn() = lewySyn.IsSome;
    member this.hasPrawySyn() = prawySyn.IsSome;
    
    

let rec szukajWartosci(drzewo : Wezel, wartosc : int) =
    if(drzewo.getWartosc() = wartosc) then
        printfn("Znaleziono podana wartosc w drzewie");
    else
        if(drzewo.hasLewySyn()) then
            szukajWartosci(drzewo.getLewySyn(), wartosc);
        if(drzewo.hasPrawySyn()) then
            szukajWartosci(drzewo.getPrawySyn(), wartosc);

    ();

let szukajWartosciIteracyjnie(drzewo : Wezel, wartosc : int) =
    let listaWezlow = new List<Wezel>();
    let mutable znaleziono = false;
    listaWezlow.Add(drzewo);
    while(listaWezlow.Count > 0 && not(znaleziono)) do
        let wezel = listaWezlow.[listaWezlow.Count - 1];
        if(wezel.getWartosc() = wartosc) then
            znaleziono <- true;
        listaWezlow.RemoveAt(listaWezlow.Count - 1);
        if(wezel.hasLewySyn()) then
            listaWezlow.Add(wezel.getLewySyn());
        if(wezel.hasPrawySyn()) then
            listaWezlow.Add(wezel.getPrawySyn());

    if(znaleziono) then
        printfn("Znaleziono podana wartosc w drzewie");
    else
        printfn("Wartosc nie zostala odnaleziona");

    ();

        

let main() = 
    let drzewo = new Wezel(2, 
                        Some(new Wezel(
                                    5, 
                                    Some(new Wezel(
                                                4, 
                                                None, 
                                                Some(new Wezel(
                                                            7, 
                                                            None, 
                                                            None
                                                            ))
                                                )), 
                                    None
                                    )), 
                        Some(new Wezel(
                                    8, 
                                    Some(new Wezel(
                                                11, 
                                                None, 
                                                None
                                                )), 
                                    Some(new Wezel(
                                                9, 
                                                None, 
                                                None
                                                ))
                                    ))
                        );

    szukajWartosci(drzewo, 4);
    szukajWartosciIteracyjnie(drzewo, 9);
    szukajWartosciIteracyjnie(drzewo, 18);
    

    

    0;
