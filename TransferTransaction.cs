using System;
using SplashKitSDK;

public class TransferTransaction : Transaction
{

    private WithdrawTransaction _theWithdrawTransaction;
    private DepositTransaction _theDepositTransaction;

    private Account _fromAccount;
    private Account _toAccount;
    private bool _reversed;
    private bool _success = false;
    private bool _executed = false;


    public TransferTransaction ( Account toAccount, Account fromAccount, decimal amount ) : base( amount )
    {

        _fromAccount = fromAccount;

        _toAccount = toAccount;
        
        _theWithdrawTransaction = new WithdrawTransaction ( fromAccount, amount );

        _theDepositTransaction = new DepositTransaction ( toAccount, amount );
        
    }

    public override bool Success
    {

        get
        {
            {

                return ( _theDepositTransaction.Success && _theWithdrawTransaction.Success );

            }

        }

    }

    public override void Execute ()
    {
        base.Execute ();

        _theWithdrawTransaction.Execute ();

        if ( _theWithdrawTransaction.Success )
        {

            _theDepositTransaction.Execute ();

            if ( _theDepositTransaction.Success )
            { 

                _executed = true;

                _success = true;

            }

            else
            {

                _theDepositTransaction.Rollback ();

            }

        }

    }


    public override void Rollback ()
    {

        base.Rollback ();

        if ( _theWithdrawTransaction.Success )
        {

            _theWithdrawTransaction.Rollback ();

        }

    }
        public override void Print ()
    {
        if( _success )
        {

            Console.WriteLine ($" You have transferred the ${ _amount } from { _fromAccount.Name } to { _toAccount.Name }. ");
            
            Console.WriteLine ($" Marlon's account latest available balance is {  _fromAccount.Balance }. ");
            
            Console.WriteLine ($" Jake's account latest available balance is { _toAccount.Balance }. ");

        }

    }

}
