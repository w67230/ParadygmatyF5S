module lab5_4
open System;
open System.Collections.Generic;


let rec hanoi(liczbaKrazkow : int, A : Stack<int>, B : Stack<int>, C : Stack<int>) =
    if(liczbaKrazkow > 0) then
        hanoi(liczbaKrazkow - 1, A, C, B);
        C.Push(A.Pop());
        hanoi(liczbaKrazkow - 1, B, A, C);

    ();

let zacznijHanoi(liczbaKrazkow : int) = 
    if(liczbaKrazkow > 0) then
        let stack = new Stack<int>();
        for x in seq{liczbaKrazkow-1 .. -1 .. 0} do
            stack.Push(x);
        hanoi(liczbaKrazkow, stack, new Stack<int>(), new Stack<int>());

    ();

let sprawdzCzyKoniec(C : List<int>, liczbaKrazkow : int) = 
    let mutable wynik = false;
    if(C.Count = liczbaKrazkow) then
        wynik <- true;
        let mutable i = liczbaKrazkow - 1;
        for x in C do
            if(not(x = i)) then
                wynik <- false;
                // normalnie bym tu returna wstawil ale f# jest takim wspanialym jezykiem ze tu returna nie ma ani nawet breaka
            i <- i - 1;

    wynik;

let przeniesNajmniejszyKrazek(prawo : bool, A : List<int>, B : List<int>, C : List<int>) =
    if(A.Contains(0)) then
        A.RemoveAt(A.Count - 1);
        if(prawo) then
            B.Add(0);
        else
            C.Add(0);
    else if(B.Contains(0)) then
        B.RemoveAt(B.Count - 1);
        if(prawo) then
            C.Add(0);
        else
            A.Add(0);
    else if(C.Contains(0)) then
        C.RemoveAt(C.Count - 1);
        if(prawo) then
            A.Add(0);
        else
            B.Add(0);

    ();

let getLastElement(list : List<int>) = 
    list.[list.Count - 1];

let getKolejnosc(listaA : List<int>, listaB : List<int>) =
    if(listaA.Count < 1) then
        (listaB, listaA);
    else
        if(listaB.Count < 1) then
            (listaA, listaB);
        else
            if(getLastElement(listaA) < getLastElement(listaB)) then
                (listaA, listaB);
            else
                (listaB, listaA);


let przeniesInnyKrazek(A : List<int>, B : List<int>, C : List<int>) =
    let tuple =
        if(A.Contains(0)) then
            getKolejnosc(B, C);             
        else if(B.Contains(0)) then
            getKolejnosc(A, C);
        else
            getKolejnosc(A, B);

    if(fst(tuple).Count > 0) then
        snd(tuple).Add(getLastElement(fst(tuple)));
        fst(tuple).RemoveAt(fst(tuple).Count - 1);  

    ();


let rysujElement(lista : List<int>, nrElementu : int) =
    if(lista.Count > nrElementu) then
        printf("%d") lista.[nrElementu];
    else
        printf("|");

let rysujWieze(liczbaKrazkow : int, A : List<int>, B : List<int>, C : List<int>) =
    let mutable i = liczbaKrazkow - 1;
    printfn("");
    printfn("=============================================");
    printfn("");
    while(i > -1) do
        rysujElement(A, i);
        rysujElement(B, i);
        rysujElement(C, i);
        printfn("");
        i <- i - 1;
    ();
        

let normalneHanoi(liczbaKrazkow : int) =
    let A = new List<int>();
    let B = new List<int>();
    let C = new List<int>();
    let prawo = if liczbaKrazkow%2 = 0 then true else false;
    
    for x in seq{liczbaKrazkow - 1 .. -1 .. 0} do
        A.Add(x);

    rysujWieze(liczbaKrazkow, A, B, C);
    while(not(sprawdzCzyKoniec(C, liczbaKrazkow))) do
        przeniesNajmniejszyKrazek(prawo, A, B, C);
        rysujWieze(liczbaKrazkow, A, B, C);
        przeniesInnyKrazek(A, B, C);
        rysujWieze(liczbaKrazkow, A, B, C);

    ();


    
    


let main() = 

    zacznijHanoi(4);
    normalneHanoi(5);
    

    0;
