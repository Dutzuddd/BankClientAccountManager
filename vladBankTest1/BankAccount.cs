using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vladBankTest1
{
    internal class BankAccount
    {
        private int AccountNumber ;
        private string Type;
        private double Ammount;

        public BankAccount() { }

        public BankAccount(int accNumber,string type, double ammount)
        {
            this.AccountNumber = accNumber;
            this.Type = type;
            this.Ammount = ammount;
        }
        public int GetAccountNumber() 
        {
            return AccountNumber;
        }
        public string GetAccountType()
        {
            return Type;
        }
        public double GetAmmount() 
        {
            return Ammount;
        }
        public void AddMoney(int accNumber, double ammount)
        {
            if (this.GetAccountNumber() == accNumber)
            {
                Ammount += ammount;
            }
            else
                Console.WriteLine("Error 3.1 - You have entered the wrong account number!");
        }
        public void WithdrawMoney(int accNumber, double ammount)
        {
            if (this.GetAccountNumber() == accNumber)
            {
                if (GetAmmount() >= ammount) { Ammount -= ammount; }
                else
                    Console.WriteLine("Error 3.2 - Innsuficient funds!");
            }
            else
                Console.WriteLine("Error 3.1 - You have entered the wrong account number!");
        }
        public void GetInfo()
        {
            if(this.GetAccountType().Equals("RON") == true)
            {
                Console.WriteLine("Account number: " + AccountNumber + ", currency: " + Type + " has " + Ammount + " RON");
            }
            else
                Console.WriteLine("Account number: " + AccountNumber + ", currency: " + Type + " has " + Ammount*4.9 + " RON");
        }
        public double GetInterestRate(int days)
        {
            if(this.GetAccountType().Equals("EURO") == true)
            {
                if (Ammount  >= 500)
                {
                    double interestRate = (Ammount / 100) * days;
                    return interestRate;
                }
                else
                    return -1;
            }
            else

            return 0;
        }
    }
}
