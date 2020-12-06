using System;
using SplashKitSDK;

public class Account
{
    private string _name;

    private decimal _balance;
    
    public Account(string name, decimal startingBalance)
    {
        
        _balance = startingBalance;

        _name = name;

    }

    public decimal Balance
    {
        get { return _balance; }
    }

    public string Name
    {
        get { return _name; }
    }

    public bool Deposit ( decimal amountToDeposit )
    {
        if ( amountToDeposit > 0 )
        {

            _balance += amountToDeposit;

            return true;

        }

        return false;

    }

    public bool Withdraw ( decimal amountToWithDraw )
    {
        if ( amountToWithDraw > 0 && amountToWithDraw < Balance )
        {

            _balance = _balance - amountToWithDraw;

            return true;

        }

        return false;

    }

    public void Print ()
    {
        Console.WriteLine ( _name );

        Console.WriteLine ( _balance );
    }
}

