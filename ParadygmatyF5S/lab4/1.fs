module lab4_1
open System;


let liczBmi(waga : float, wzrost : float) : float = 
    waga/(wzrost*wzrost);


let getKategoria(bmi : float) : string = 
    if(bmi < 18.5) then "Niedowaga";
    else if(bmi < 25) then "Wartosc prawidlowa";
    else if(bmi < 30) then "Nadwaga";
    else if(bmi < 35) then "Otylosc I stopnia";
    else if(bmi < 40) then "Otylosc II stopnia";
    else "Otylosc III stopnia";



let main() = 
    printfn("Podaj mase ciala w kilogramach");
    let w = (float) (Console.ReadLine());
    
    printfn("Podaj wzrost w metrach");
    let h = (float) (Console.ReadLine());

    let bmi = liczBmi(w, h);
    let kategoria = getKategoria(bmi);

    printfn("Twoje BMI to %f, co oznacza %s") bmi kategoria;

    0;

