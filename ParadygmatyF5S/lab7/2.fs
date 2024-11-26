module lab7_2
open System;
open System.Collections.Generic;


type BankAccount(accountNumber : int) =
    let accountNumber = accountNumber;
    let mutable balance = 0.0;

    member this.Deposit(amount : float) =
        if(amount > 0) then
            balance <- balance + amount;
        ();

    member this.Withdraw(amount : float) =
        if(amount <= balance) then
            balance <- balance - amount;
        ();

    member this.getBalance() = balance;


type Bank() =
    let konta = new Dictionary<int, BankAccount>();

    member this.CreateAccount(accountNumber : int) =
        if(not(konta.ContainsKey(accountNumber))) then 
            konta.Add(accountNumber, new BankAccount(accountNumber));

    member this.GetAccount(accountNumber : int) : Option<BankAccount> =
        if(konta.ContainsKey(accountNumber)) then
            Some(konta.[accountNumber]);
        else
            None;

    member this.UpdateAccount(accountNumber : int, zmianaSalda : float) =
        let konto = this.GetAccount(accountNumber);
        if(konto.IsSome) then
            if(zmianaSalda > 0) then
                konto.Value.Deposit(zmianaSalda);
            else
                konto.Value.Withdraw(zmianaSalda);

    member this.DeleteAccount(accountNumber : int) =
        konta.Remove(accountNumber);



let main() = 
    let bank = new Bank();
    bank.CreateAccount(1234);
    bank.CreateAccount(123);
    bank.CreateAccount(12);
    bank.CreateAccount(1);

    let pierwszeKonto = bank.GetAccount(1234);
    if(pierwszeKonto.IsSome) then
        let p = pierwszeKonto.Value;
        printfn("Stan konta 1234: %f") (p.getBalance());
        p.Deposit(200);
        printfn("Stan konta 1234: %f") (p.getBalance());
        p.Withdraw(100);
        printfn("Stan konta 1234: %f") (p.getBalance());
        bank.UpdateAccount(1234, -40);
        printfn("Stan konta 1234: %f") (p.getBalance());

    bank.DeleteAccount(1234);
    let czyJest = bank.GetAccount(1234);
    printfn("Konto 1234 zostalo usuniete: %b") czyJest.IsNone;

    

    

    0;

