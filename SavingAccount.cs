using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Class_Account
{
    class SavingAccount : Account
    {
        bool isDouble;
        double interset_Rate;
        double interestadd;
        public double Interset_Rate
        {
            get
            {
                return interset_Rate;
            }
            set
            {
                interset_Rate = value;
            }
        }
        public double cal_interset()
        {
            interestadd = Balance * interset_Rate;
            Balance = Balance + interestadd;
            return interestadd;
        }


        public SavingAccount(double bal, string in_name, double interest) : base(bal, in_name)
        {
            interset_Rate = interest;
        }
    }
}
