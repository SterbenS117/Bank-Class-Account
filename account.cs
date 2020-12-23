using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Bank_Class_Account
{
    public class Account
    {
        // field variable
        private double balance;
        private string name;
        bool isDouble;

        public string Name {
            get {
                return name;            
            }
            set {
                name = value;
            }
        
        }

        public double Balance {
            get {
                return balance;
            }
            set {
                balance = value; 
            }
        
        }

        
        public void Deposit(double n)
        {
            if (n >= 0)
            {
                balance = balance + n;
            }
            else
            {
                Console.WriteLine("Deposit amount has to be postive");
            }

        }
        public void Withdraw(double n)
        {
            if (balance >= n)
            {
                balance = balance - n;
            }
            else
            {
                Console.WriteLine("Withdraw amount exceeded account balance");
            }

        }
        

        public Account(double bal, string in_name)
        {
            balance = bal;
            name = in_name;
        }

       
    }
    


}
