class Account:
    # This is for defined Function that can be reused for associated action, in python we can create our own function. 
    # The __init__ is equivalent to constructor term used in OOD.  
    def __init__(self, name, startingBalance):
        self.name = name
        self.balance = startingBalance

    # This is a Menu Selection Option that will be displayed when we run the program. 
    def read_menu_option(self):

        print ("-----------------------------------------------")
        print ("-----------------------------------------------")
        print (" 1: DEPOSIT | 2: WITHDRAW | 3: PRINT | 4: QUIT ")
        print ("-----------------------------------------------")
        print ("-----------------------------------------------")

        line = input ( " Choose on menu option: " )
        num = int ( line )
        return num

    # This is for the Print Function, it prints current balance of the account.
    def print_account ( self ): 
        # % is an operator used to format a set of variables within parenthesis in a "tuple",
        #together with a format string, which contains normal text together with "argument specifiers", 
        # special symbols like "%s" and "%d"

        print ( "%s $%.2f" % ( self.name, self.balance ) )
        #"%.2f" print("%.2f" % total) 9 votes. "print" treats the % as a special character you need to add, 
        # so it can know, that when you type "f", the number (result) that will be printed will be a floating point type, 
        # and the ".2" tells your "print" to print only the first 2 digits after the point.

    # This is for the Deposit Function - it deposits a valid amount to the account.
    def deposit_account ( self, amount ):

        if ( amount>0 ):
            self.balance += amount
            print ( " Your current balance is %.2f " % ( self.balance ) )

    # This is for the Withdraw Function - it withdraws a valid amount to the account.
    def withdraw_account ( self, amount ):

        if ( amount>0 ):
            self.balance -= amount
            print ( " Your current balance is %.2f " % ( self.balance ) )

# This python syntax is equivalent to Account account = new Account("Marlon", 1000.0) in C#
test = Account ( " Marlon ", 201000.0 )
test.print_account ()
second_account = Account ( " Jake ", 150000.0 )
second_account.print_account ()

# Control flow in python executes the program codes in sequential order through if else statements, while loop and calls defined functions. 
num = 0
while num == 0:
    user_selection = test.read_menu_option ()
    
    if user_selection == 1:
        amount = input ( " Please enter amount to deposit: " )
        test.deposit_account ( amount )
    elif user_selection == 2:
        amount = input ( " Please enter amount tp withdraw: " )
        test.withdraw_account ( amount )
    elif user_selection == 3:
        test.print_account ()
    elif user_selection == 4:
        print ( " Quit " )
        break
