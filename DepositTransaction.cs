using System;
using SplashKitSDK;

public class DepositTransaction : Transaction
{
    private Account _account;
    private bool _reversed;
    private bool _success = false;
    private bool _executed = false;

    public DepositTransaction ( Account account, decimal amount ) : base ( amount )
    {
        
        _account = account;
        
    }

    public override bool Success
    {
        get;
    }

    public override void Print ()
    {
        if(_success)
        {

            Console.WriteLine ($" Your account's new balance is { _account.Balance }. ");

            Console.WriteLine ($" Your account's deposit amount is { _amount }. ");

        }

    }

    public override void Execute ()
    {

        base.Execute ();

        _success = _account.Deposit ( _amount );

    }

    public override void Rollback ()
    {

        base.Rollback ();

        _success = _account.Deposit ( _amount );

    }
    

}