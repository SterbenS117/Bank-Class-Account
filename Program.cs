using System;
using System.Data;

namespace Bank_Class_Account
{

    class Program
    {
        static void Main(string[] args)
        {
            
            double input2;
            /*
            double yourgain;
            double savinggain;
            double checkinggain;
            */
            double accountbalance;
            double accountmod;
            int numclient;
            bool loop = true;
            bool isDouble;
            bool isNum;
            int answer;
            do
            {
                Console.WriteLine("Please enter the amount of accounts you wish to create.");
                var input = Console.ReadLine();
                isNum = int.TryParse(input.ToString(), out numclient);

            } while (isNum == false);

            Account[] clientaccounts = new Account[numclient];
            for (int i = 0; i <= numclient-1; i++)
            {
                do
                {
                    Console.WriteLine("Please enter 1 for checking 2 for saving");
                    var input = Console.ReadLine();
                    isNum = int.TryParse(input.ToString(), out answer);
                } while (isNum == false);
                switch (answer)
                {
                    case 2:
                        clientaccounts[i] = new SavingAccount(0, "dup dup", 0.0);
                        Console.WriteLine("Please enter the name of the account:");
                        clientaccounts[i].Name = Console.ReadLine();
                        
                        Console.WriteLine("Please enter the inital balance:");
                        do
                        {
                            var input = Console.ReadLine();
                            isDouble = double.TryParse(input.ToString(), out accountbalance);
                            if (isDouble == false)
                            {
                                Console.WriteLine("Please enter a valid account balance:");
                            }
                        } while (isDouble == false);
                        clientaccounts[i].Balance = accountbalance;


                        Console.WriteLine("Please enter the interest rate of this account:");
                        do
                        {
                            var input = Console.ReadLine();
                            isDouble = double.TryParse(input.ToString(), out accountmod);
                            if (isDouble == false)
                            {
                                Console.WriteLine("Please enter a valid account interest rate:");
                            }
                        } while (isDouble == false);
                        ((SavingAccount)clientaccounts[i]).Interset_Rate = accountmod;
                        
                        Console.WriteLine("    ");
                        Console.WriteLine("    ");
                        break;
                    case 1:
                        clientaccounts[i] = new CheckingAccount(0, "dup dup", 0.0);
                        Console.WriteLine("Please enter the name of the account:");
                        clientaccounts[i].Name = Console.ReadLine();

                        Console.WriteLine("Please enter the inital balance:");
                        do
                        {
                            var input = Console.ReadLine();
                            isDouble = double.TryParse(input.ToString(), out accountbalance);
                            if (isDouble == false)
                            {
                                Console.WriteLine("Please enter a valid account balance:");
                            }
                        } while (isDouble == false);
                        clientaccounts[i].Balance = accountbalance;

                        Console.WriteLine("Please enter the transaction fee of this account:");
                        do
                        {
                            var input = Console.ReadLine();
                            isDouble = double.TryParse(input.ToString(), out accountmod);
                            if (isDouble == false)
                            {
                                Console.WriteLine("Please enter a valid account transaction fee:");
                            }
                        } while (isDouble == false);
                        ((CheckingAccount)clientaccounts[i]).AccountFee = accountmod;

                        Console.WriteLine("    ");
                        Console.WriteLine("    ");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input, s or c. Input is cap sensentive.");
                        i = i - 1;
                        Console.WriteLine("    ");
                        Console.WriteLine("    ");
                        break;

                }
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("Processing all account:");
            Console.WriteLine("=====================================");

            for (int j = 0; j <= numclient-1; j++)
            {
                Console.WriteLine("Account[" + j + "]");
                Console.WriteLine("Bank client: " + clientaccounts[j].Name + " has $" + clientaccounts[j].Balance);
                //loop is for error checking
                do
                {
                    Console.WriteLine("Enter the amount to withdraw into Account[" + j + "]");
                    var input = Console.ReadLine();
                    isDouble = double.TryParse(input.ToString(), out input2);
                    if (isDouble == true)
                    {
                        //checks subclass
                        if (clientaccounts[j] is CheckingAccount)
                        {
                            ((CheckingAccount)clientaccounts[j]).Withdraw(input2);
                        }
                        else if (clientaccounts[j] is SavingAccount)
                        {
                            ((SavingAccount)clientaccounts[j]).Withdraw(input2);
                        }
                    }
                    
                    if (isDouble == false)
                    {
                        Console.WriteLine("Please enter a valid Withdarw");
                    }

                } while (isDouble == false);

                //loop is for error checking
                do
                {
                    Console.WriteLine("Enter the amount to deposit into Account[" + j + "]");
                    var input = Console.ReadLine();
                    isDouble = double.TryParse(input.ToString(), out input2);
                    if (isDouble == true)
                    {
                        //checks subclass
                        if (clientaccounts[j] is CheckingAccount)
                        {
                            ((CheckingAccount)clientaccounts[j]).Deposit(input2);
                        }
                        else if(clientaccounts[j] is SavingAccount)
                        {
                            ((SavingAccount)clientaccounts[j]).Deposit(input2);
                        }

                    }

                    if (isDouble == false)
                    {
                        Console.WriteLine("Please enter a valid Deposit:");
                    }

                } while (isDouble == false);

                if (clientaccounts[j] is SavingAccount) {
                    //Console.WriteLine("is savings");
                    Console.WriteLine("Adding $" + ((SavingAccount)clientaccounts[j]).cal_interset() + " interest to Account " + j + " (a SavingsAccount)");
                   
                }
                
                Console.WriteLine("Updated Account(" + j + ") Name: " + clientaccounts[j].Name + " balance: $" + clientaccounts[j].Balance);
                Console.WriteLine("    ");
                Console.WriteLine("    ");
            }


        }
    }
}




/*
            Account yourAccount = new Account(500000000, "Mustafa Al Lail");
            Account myAccount = new Account(500, "Aaron Sanchez");

            SavingAccount mySavings = new SavingAccount(500, "Aaron Sanchez", 0.01);
            CheckingAccount myChecking = new CheckingAccount(500, "Aaron Sanchez", 1.75);
            Console.WriteLine("Would your like to Deposit into the saving, checking, or debit account.");

            
            do
            {
                Console.WriteLine("Enter S for saving, C for checking, or D for debit. Is cap sensitive");
                answer = Convert.ToChar(Console.ReadLine());
                switch (answer)
                {
                    case 'S':
                        Console.WriteLine("The mySaving account balance is " + mySavings.Balance);

                        Console.WriteLine("Please enter your deposit for mySavings");
                        savinggain = Convert.ToDouble(Console.ReadLine());
                        mySavings.deposit(savinggain);
                        Console.WriteLine("The mySaving account balance now is " + mySavings.Balance);
                        Console.WriteLine("With an interset of gain of " + mySavings.cal_interset());
                        loop = false;
                        break;
                    case 'C':
                        Console.WriteLine("The myChecking account balance is " + myChecking.Balance);
                        Console.WriteLine("Please enter your deposit for my Checking");
                        checkinggain = Convert.ToDouble(Console.ReadLine());
                       
                        myChecking.deposit(checkinggain);
                        Console.WriteLine("The myChecking account balance now is " + myChecking.Balance);
                        Console.WriteLine("You paid " + myChecking.AccountFee + " for prossessing fee.");
                        loop = false;
                        break;
                    case 'D':
                        Console.WriteLine("Account name is " + yourAccount.Name + " and the account balance is " + yourAccount.Balance + ".");

                        Console.WriteLine("Enter you deposit for yourAccount.");
                        yourgain = Convert.ToDouble(Console.ReadLine());
                        yourAccount.deposit(yourgain);

                        Console.WriteLine("Account name is " + yourAccount.Name + " and the account balance is " + yourAccount.Balance + ".");
                        Console.WriteLine("Account name is " + myAccount.Name + " and the account balance is " + myAccount.Balance + ".");

                        Console.WriteLine("Enter you deposit for myAccount.");
                        mygain = Convert.ToDouble(Console.ReadLine());
                        myAccount.deposit(mygain);

                        Console.WriteLine(yourAccount.Name + " you have deposit " + yourgain + " into your account.");
                        Console.WriteLine(myAccount.Name + " you have deposit " + mygain + " into your account.");
                        Console.WriteLine(" ");
                        Console.WriteLine("Account name is " + yourAccount.Name + " and the account balance is " + yourAccount.Balance + ".");
                        Console.WriteLine("Account name is " + myAccount.Name + " and the account balance is " + myAccount.Balance + ".");

                        Console.WriteLine("Enter you deposit for myAccount.");
                        mygain = Convert.ToDouble(Console.ReadLine());
                        myAccount.deposit(mygain);

                        Console.WriteLine("Account name is " + yourAccount.Name + " and the account balance is " + yourAccount.Balance + ".");
                        Console.WriteLine("Account name is " + myAccount.Name + " and the account balance is " + myAccount.Balance + ".");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid answer");

                        break;
                }
            } while (loop);
          */