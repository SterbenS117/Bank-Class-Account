using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Class_Account
{
    class CheckingAccount : Account
    {
        
        double accountFee;
        public CheckingAccount(double bal, string in_name, double fee) : base(bal, in_name)
        {
            accountFee = fee;
        }

        public double AccountFee
        {
            get
            {
                return accountFee;
            }
            set
            {
                accountFee = value;
            }
        }
        public new void Deposit(double n)
        {
            if (n >= 0)
            {
                Balance = Balance + n - AccountFee;
            }
            else
            {
                Console.WriteLine("Deposit amount has to be postive");
            }

        }

        public new void Withdraw(double n)
        {
            if (Balance >= n)
            {
                Balance = Balance - n - AccountFee;
            }
            else
            {
                Console.WriteLine("Withdraw amount exceeded account balance");
            }

        }
    }
}
