module lab5_1
open System;


let rec fib(ktoryWyraz : int) : int =
    if(ktoryWyraz < 2) then
        0;
    else if(ktoryWyraz = 2) then
        1;
    else
        fib(ktoryWyraz - 1) + fib(ktoryWyraz - 2);



let rec liczFibOgon(ktoryWyraz : int, pierwszy : int, drugi : int) : int =
    if(ktoryWyraz < 2) then
        pierwszy;
    else
        liczFibOgon(ktoryWyraz - 1, drugi, pierwszy+drugi);



let fibOgon(ktoryWyraz : int) : int =
    liczFibOgon(ktoryWyraz, 0, 1);
    
    


let main() = 
    printfn("Podaj ktory element ciagu fibonnaciego obliczyc");
    let ktory = (int)(Console.ReadLine());
    printfn("%d wyraz ciagu wynosi: %d") ktory (fib(ktory));
    printfn("%d wyraz ciagu wynosi: %d (obliczone ogonowo)") ktory (fibOgon(ktory));
    
    

    

    0;
