module lab7_1
open System;
open System.Collections.Generic;


type Book(tytul : string, autor : string, liczbaStron : int) =
    let tytul = tytul;
    let autor = autor;
    let liczbaStron = liczbaStron;

    member this.getTytul() : string =
        tytul;

    member this.getAutor() : string =
        autor;

    member this.getLiczbaStron() : int =
        liczbaStron;

    member this.GetInfo() =
        printf("Ksiazka: %s autora: %s, liczba stron: %d") (this.getTytul()) (this.getAutor()) (this.getLiczbaStron());
    
   
type Library() =
    let mapaKsiazek = new Dictionary<Book, int>();

    member this.AddBook(book : Book) =
        if(mapaKsiazek.ContainsKey(book)) then
            mapaKsiazek.[book] <- mapaKsiazek.[book] + 1;
        else
            mapaKsiazek.Add(book, 1);

    member this.RemoveBook(book : Book) =
        if(mapaKsiazek.ContainsKey(book)) then
            if(mapaKsiazek.[book] > 0) then  
                mapaKsiazek.[book] <- mapaKsiazek.[book] - 1;


    member this.getKsiazka(tytul : string, autor : string) : Option<Book> =
        let mutable book = None;
        for x in mapaKsiazek.Keys do
            if(x.getTytul() = tytul && x.getAutor() = autor) then
                 book <- Some(x);
        
        book;

    member this.ListBooks() =
        for x in mapaKsiazek.Keys do
            x.GetInfo();
            printf(" Ilosc ksiazek: %d") mapaKsiazek.[x];
            printfn("");


type User(imie : string, nazwisko : string) =
    let imie = imie;
    let nazwisko = nazwisko;
    let pozyczoneKsiazki = new List<Book>();

    member this.BorrowBook(library : Library, book : Book) =
        pozyczoneKsiazki.Add(book);
        library.RemoveBook(book);

    member this.ReturnBook(library : Library, book : Book) =
        pozyczoneKsiazki.Remove(book);
        library.AddBook(book);



let main() = 
    let library = new Library();
    library.AddBook(new Book("Wladca Pirscieni", "Tolkien", 99999));
    library.AddBook(new Book("Hari Pota", "Rouling", 300));
    library.AddBook(new Book("Cos tam", "Kochanowski", 12));
    library.AddBook(new Book("Pan Kleks", "Nie wiem", 232));

    let pierscienie = library.getKsiazka("Wladca Pirscieni", "Tolkien");
    if(pierscienie.IsSome) then
        library.AddBook(pierscienie.Value);
        library.AddBook(pierscienie.Value);
        library.AddBook(pierscienie.Value);

    let user = new User("Ukasz", "Fryc");
    library.ListBooks();
    printfn("Ukasz Fryc pozycza ksiazke");
    user.BorrowBook(library, pierscienie.Value);
    library.ListBooks();

    

    

    0;
