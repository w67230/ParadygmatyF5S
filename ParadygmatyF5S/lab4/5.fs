module lab4_5
open System;

type Znak() =
    let mutable znak = " ";

    member this.Znak = znak;

    member this.SetZnak(nowyZnak : string) = 
        znak <- nowyZnak;


let numeryPol = Map.empty.
                    Add("1", (0,0)).
                    Add("2", (0,1)).
                    Add("3", (0,2)).
                    Add("4", (1,0)).
                    Add("5", (1,1)).
                    Add("6", (1,2)).
                    Add("7", (2,0)).
                    Add("8", (2,1)).
                    Add("9", (2,2));

let plansza = [
    [new Znak(); new Znak(); new Znak()];
    [new Znak(); new Znak(); new Znak()];
    [new Znak(); new Znak(); new Znak()]
]

let ruchKomputera() = 
    let rand = new Random();
    let mutable bl = true;
    while(bl) do
        let a = rand.Next(3);
        let b = rand.Next(3);
        if(plansza.[a].[b].Znak = " ") then
            plansza.[a].[b].SetZnak("O");
            bl <- false;


let rec ruchGracza() = 
    printfn("Wybierz numer pola do którego chcesz wpisać krzyżyk");
    let wybor = Console.ReadLine();
    if(numeryPol.ContainsKey(wybor)) then
        if(plansza.[fst(numeryPol.[wybor])].[snd(numeryPol.[wybor])].Znak = " ") then
            plansza.[fst(numeryPol.[wybor])].[snd(numeryPol.[wybor])].SetZnak("X");    
        else ruchGracza();
    else ruchGracza();


let rysujPlansze() = 
    printfn("");
    let mutable i = 0;
    let mutable j = 0;
    for x in plansza do
        for y in x do
            printf("%s") y.Znak
            if(i < 2) then printf("|");
            i <- i + 1;
        i <- 0;
        printfn("");
        if(j < 2) then printfn("-----");
        j <- j + 1;
    printfn("");


let ktosWygral(turaGracza : bool) : bool = 
    let mutable wygrana = false;
    let znak = if(turaGracza) then "X" else "O";
    for x in plansza do
        if(not(wygrana)) then
            if(x[0].Znak = znak && x[1].Znak = znak && x[2].Znak = znak) then
                wygrana <- true;

    if(not(wygrana)) then
        if(plansza.[0].[0].Znak = znak && plansza.[1].[1].Znak = znak && plansza.[2].[2].Znak = znak) then
            wygrana <- true;
        else if(plansza.[0].[2].Znak = znak && plansza.[1].[1].Znak = znak && plansza.[2].[0].Znak = znak) then
            wygrana <- true;

    wygrana;

let czyscPlansze() = 
    for x in plansza do
        for y in x do
            y.SetZnak(" ");


let main() = 
    let mutable turaGracza = false;
    let mutable i = 1;
    while(not(ktosWygral(turaGracza))) do
        if(i > 9) then
            i <- 1;
            czyscPlansze();
        turaGracza <- not(turaGracza);
        if(turaGracza) then
            rysujPlansze();
            ruchGracza();
        else 
            ruchKomputera();
        i <- i + 1;

    rysujPlansze();
    let kto = if(turaGracza) then "gracz" else "komputer";
    printfn("Wygrywa %s") kto;


    0;

