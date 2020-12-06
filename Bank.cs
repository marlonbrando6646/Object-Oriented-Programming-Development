using System;
using System.Collections.Generic;


public class Bank
{

    private List < Transaction > _transactions = new List < Transaction > ();
    private List < Account > _accounts = new List < Account > ();
    
   

    public void AddAccount ( Account account )
    {

        _accounts.Add ( account );

    }

    public Account GetAccount ( string name )
    {

        foreach ( Account account in _accounts )
        {
            if ( account.Name == name )
            {

                return account;

            }
        }

        return null;
    }

    public void ExecuteTransaction ( Transaction transaction )
    {
        _transactions.Add ( transaction );

        transaction.Execute ();
        
        transaction.Print ();
        
    }

    public void PrintTransactionHistory ()
    {

        foreach (Transaction transaction in _transactions)
        {

            transaction.Print ();

        }
    }
    

}


