using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace vladBankTest1
{
    internal class Client
    {
        private string CNP;
        private string Name;
        private string Address;
        private List<BankAccount> BankAccountList;

        public Client() { }

        public Client(string CNP, string Name, string Address)
        {
            this.CNP = CNP;
            this.Name = Name;
            this.Address = Address;
            BankAccountList = new List<BankAccount>(5);
        }        
    
        public string GetClientCNP() { return this.CNP; }
        public void AddBankAccount(BankAccount bankAccount) 
        {
            BankAccountList.Add(bankAccount);
        }
        public void RemoveBankAccount(BankAccount bankAccount)
        {
            BankAccountList.Remove(bankAccount);
        }
        public void GetBankAccountList()
        {
            foreach(BankAccount acc in BankAccountList)
            {
                acc.GetInfo();
                Console.WriteLine("--------------------------------");
            }
                 
        }
        //getting a single account number
        public void GetClientBankAccountNumber(int accountNumber)
        {
            
            foreach (BankAccount acc in BankAccountList)
            {
                int tempNumber = acc.GetAccountNumber();
                if (tempNumber == accountNumber)
                    acc.GetAccountNumber();
                else
                    Console.WriteLine("Error 3.1 - You have entered the wrong account number!");
            }
            
        }        
        
        //method for client information
        public void ShowClientInformation()
        {
            Console.WriteLine("Client " + Name);
            Console.WriteLine("With " + CNP);
            Console.WriteLine("Address " + Address);
            Console.WriteLine("Has the following accounts: ");
            GetBankAccountList();
        }

        public BankAccount GetBankAccountByNumber(int accNumber)
        {
            foreach (BankAccount contBanca in BankAccountList)
            {
                if(contBanca.GetAccountNumber().Equals(accNumber))
                    return contBanca;
            }
            return null;
        }


    }
}
