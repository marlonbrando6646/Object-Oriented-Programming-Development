using System;
using SplashKitSDK;

public abstract class Transaction
{

    private DateTime _dateStamp; 
    protected decimal _amount;
    private bool _reversed;
    private bool _executed;

   

    public Transaction ( decimal amount )
    {

        _amount = amount;

    }
  

    public DateTime DateStamp
    {

        get;

    }

    public bool Executed
    {
        get
        {
            return _executed;
        }
    }
    public abstract bool Success
    {
    
        get;

    }
    public bool Reversed
    {

        get
        {
            return _reversed;
        }

    }
   

    public virtual void Execute ()
    {
        if( _executed )
        {

            throw new Exception(" It has already been executed! ");
            
        }

        _dateStamp = DateTime.Now;

        _executed = true;
        
    }
    public virtual void Rollback ()
    {
        if ( !_executed )
        {

            throw new Exception(" The transaction execution is unsuccessful! ");

        }

        else
        {
            if ( _reversed )
            { 

                throw new Exception(" The transaction has been rollback! ");

            }

            _dateStamp = DateTime.Now;

            _executed = false;

            _reversed = true;
            
        }
    }
    public abstract void Print();

}