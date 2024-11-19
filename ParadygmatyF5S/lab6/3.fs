module lab6_3
open System;


let przeksztalcWListeSlow(text : string) =
    List.ofArray(text.Split(' '));
    

let usunDuplikaty(textList : List<string>) = 
    let mutable secik = Set.ofList(textList);
    let mutable nowyTekst = "";
    for x in textList do
        if(secik.Contains(x)) then
            secik <- secik.Remove(x);
            if(nowyTekst = "") then
                nowyTekst <- nowyTekst + x;
            else
                nowyTekst <- nowyTekst + " " + x;

    przeksztalcWListeSlow(nowyTekst);
    
    


let main() = 
    printfn("Podaj tekst oddzielony spacjami");
    let text = Console.ReadLine();

    let bezDuplikatow = usunDuplikaty(przeksztalcWListeSlow(text));
    printfn("%A") (bezDuplikatow);

    

    0;


