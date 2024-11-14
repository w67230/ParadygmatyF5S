module lab4_2
open System;


let mnozniki = Map.empty.
                Add("EUR", Map.empty.
                            Add("USD", 1.05).
                            Add("PLN", 4.34)
                ).
                Add("PLN", Map.empty.
                            Add("USD", 0.24).
                            Add("EUR", 0.23)
                ).
                Add("USD", Map.empty.
                            Add("PLN", 4.13).
                            Add("EUR", 0.95)
                );

let obslugiwaneWaluty = Set.ofList(["USD";"PLN";"EUR"]);

let main() = 
    printfn("Podaj kwote do przeliczenia");
    let kwota = (float)(Console.ReadLine());

    printfn("Podaj walute zrodlowa (PLN, USD, EUR)");
    let mutable zrodlo = Console.ReadLine().ToUpper();
    while(not(obslugiwaneWaluty.Contains(zrodlo))) do
        printfn("Podana waluta nie jest obslugiwana");
        zrodlo <- Console.ReadLine().ToUpper();
    
    printfn("Podaj walute docelowa (PLN, USD, EUR)");
    let mutable cel = Console.ReadLine().ToUpper();
    while(not(obslugiwaneWaluty.Contains(cel)) || cel = zrodlo) do
        if(cel = zrodlo) then printfn("Podaj walute inna od waluty zrodlowej");
        else printfn("Podana waluta nie jest obslugiwana");
        cel <- Console.ReadLine().ToUpper();

    let wynik = mnozniki.[zrodlo].[cel] * kwota;

    printfn("%f %s = %f %s") kwota zrodlo wynik cel;
    

    0;

