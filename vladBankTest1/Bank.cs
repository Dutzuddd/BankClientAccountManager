using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vladBankTest1
{
    internal class Bank
    {
        private int BankCode;
        private List<Client> clientsList;

        public Bank() { }

        public Bank(int BankCode)
        {
            this.BankCode = BankCode;
            clientsList = new List<Client>();
        }
        public int GetBankCode()
        {
            return this.BankCode;
        }

        public void AddClient(Client client)
        {
            clientsList.Add(client);
        }
        public void RemoveClient(Client client) 
        {
            clientsList.Remove(client);
        }
        public void getBankClients() 
        {
            Console.WriteLine("Bank with code " + BankCode + " has the following clients:");
            foreach(Client client in clientsList)
            {
                client.ShowClientInformation();
               
            }
        }
        public Client getClientCNP(string cnp)
        {
            foreach (Client client in clientsList)
            {
                if(client.GetClientCNP().Equals(cnp))
                    return client;
            }
            return null;
        }
    }
}
