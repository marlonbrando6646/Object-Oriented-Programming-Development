using System;
using SplashKitSDK;

public class WithdrawTransaction : Transaction
{
    private Account _account;
    private bool _reversed;
    private bool _success = false;
    private bool _executed = false;

    public WithdrawTransaction ( Account account, decimal amount ) : base( amount )
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

            Console.WriteLine($" Your account's current balance is { _account.Balance }. ");

            Console.WriteLine($" Your account's withdrawal amount is { _amount }. ");

        }

    }

    public override void Execute ()
    {

        base.Execute ();

        _success = _account.Withdraw ( _amount );

    }

    public override void Rollback ()
    {

        base.Rollback ();

        _success = _account.Withdraw ( _amount ); 

    }

}