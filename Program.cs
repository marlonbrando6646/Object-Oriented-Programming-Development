using System;
using SplashKitSDK;
public enum MenuOption
    {
        Withdraw, Deposit, Transfer, Print, NewAccount, PrintTransactionHistory, Quit
    }

public class Program
{
   
    public static void Main ()
    {
        
        Account account = new Account ( "Marlon's Account", 1000 );

        Account account1 = new Account ( "Jake's Account", 1000 );

        Bank bank = new Bank ();

        bank.AddAccount ( account );
        
        bank.AddAccount ( account1 );
        

        MenuOption userSelection;

        do
        {
            userSelection = ReadUserOption ();
            Console.WriteLine ( userSelection );
           
            
            switch ( userSelection )
            {
                
                case MenuOption.Deposit:
                    DoDeposit ( bank );
                    break;
                case MenuOption.Withdraw:
                    DoWithdraw ( bank );
                    break;
                case MenuOption.Transfer:
                    DoTransfer ( bank );
                    break;
                case MenuOption.Print:
                    DoPrint ( bank );
                    break;
                case MenuOption.NewAccount:
                    DoNewAccount ( bank );
                    break;
                case MenuOption.PrintTransactionHistory:
                    DoPrintTransactionHistory( bank );
                    break;
                case MenuOption.Quit:
                    Console.WriteLine ();
                    break;
            }
        } while ( userSelection != MenuOption.Quit );

    }
    private static MenuOption ReadUserOption ()
    {
        int option = 1 - 7;
   
        Console.WriteLine ("====================================");
        Console.WriteLine (" 1 Going to Withdraw ");
        Console.WriteLine (" 2 Going to Deposit ");
        Console.WriteLine (" 3 Going to Transfer ");
        Console.WriteLine (" 4 Going to Print ");
        Console.WriteLine (" 5 Going to NewAccount ");
        Console.WriteLine (" 6 Going to PrintTransactionHistory ");
        Console.WriteLine (" 7 Going to Quit ");
        Console.WriteLine ("====================================");    
       
       try
        {
            do
            {

            Console.Write (" Choose an option [1-7]: ");
            
            option = Convert.ToInt32 ( Console.ReadLine () );

            } while ( option < 1 || option > 7 );
           
            return ( MenuOption ) ( option - 1 ); 

        }

        catch ( System.Exception )
        {           
            Console.WriteLine(" You've entered an invalid input ");     
        } 
        return ( MenuOption ) ( option - 1 );
    }
    private static void DoDeposit( Bank toBank )
    {

        decimal amount;
        do
        {
            try
            {
                Account toAccount = FindAccount ( toBank );

                if ( toAccount == null ) return;

                Console.WriteLine (" Enter amount to deposit: ");

                amount = Convert.ToDecimal ( Console.ReadLine () );
                
                DepositTransaction deposit = new DepositTransaction( toAccount, amount );
        
                toBank.ExecuteTransaction( deposit );
    
            }
            catch ( System.Exception )
            {
                Console.Error.WriteLine (" You have entered an invalid value! ");

                amount = -1;
            }

        }  while( amount < 1 );

    }
    private static void DoWithdraw ( Bank toBank )
    {
        decimal amount;
        do
        {
            try
            {

                Account toAccount = FindAccount ( toBank );

                if ( toAccount == null ) return;

                Console.WriteLine (" Enter amount to withdraw: ");

                amount = Convert.ToDecimal ( Console.ReadLine () );
                
                WithdrawTransaction withdraw = new WithdrawTransaction ( toAccount, amount );

                toBank.ExecuteTransaction ( withdraw );
                
            
            }

            catch ( System.Exception )
            {

                Console.Error.WriteLine (" You have entered an invalid value! ");

                amount = -1;

            }

        }  while( amount < 1 );
    }

    private static void DoTransfer ( Bank toBank )
    {

        decimal amount;

        do
        {
            try
            {

                Account toAccount = FindAccount ( toBank );

                Account fromAccount = FindAccount( toBank );

                if ( toAccount == null ) return;
               

                Console.WriteLine (" Enter amount to transfer: ");

                amount = Convert.ToDecimal ( Console.ReadLine () );
                
                TransferTransaction transfer = new TransferTransaction ( fromAccount, toAccount, amount );

                toBank.ExecuteTransaction ( transfer );
            
            
            }

            catch ( System.Exception )
            {

                Console.Error.WriteLine (" You have entered an invalid value! ");

                amount = -1;

            }

        }  while ( amount < 1 );
    }
    
    private static void DoNewAccount ( Bank toBank )
    {
       
        Console.WriteLine (" Enter your account name: ");

        String name = Console.ReadLine ();

        Console.WriteLine (" What is your starting balance? ");
        
        decimal amount = Convert.ToDecimal ( Console.ReadLine () );
        
        Account account = new Account ( name, amount );

        toBank.AddAccount ( account );

    }
    private static void DoPrint ( Bank toBank )
    {

        Account toAccount = FindAccount ( toBank );

        if ( toAccount == null )
        {

            Console.WriteLine (" Account not found! ");

        }

        else
        {

            toAccount.Print ();

        }
       
    }

    private static Account FindAccount( Bank fromBank )
    {
        Console.Write (" Enter account name: ");

        String name = Console.ReadLine ();

        Account result = fromBank.GetAccount ( name );

        if ( result == null )
        {

            Console.WriteLine($" No account found with name { name }. ");
            
        }

        return result;
    }
    
    public static void DoPrintTransactionHistory ( Bank bank )
    {

        bank.PrintTransactionHistory ();

    }

}