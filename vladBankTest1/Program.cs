using System.Net;
using System.Xml.Linq;
using vladBankTest1;

Client client = new Client("1880827665331", "Andrei", "Timisoara");
Client client1 = new Client("2980827665331", "Simona", "Arad");

Console.WriteLine("Enter bank code:");
int bankCode = int.Parse(Console.ReadLine());
if (bankCode > 0)
{
    Console.WriteLine("Code OK - creating bank; ");
}
else
{
    throw new Error1("Error 01 - Invalid number!");
}
Bank newBank = new Bank(bankCode);
Console.WriteLine("You have succesfully created a bank with the number " + newBank.GetBankCode());

string option;
for (; ; )
{
    Console.WriteLine("-----------------------------Bank " + newBank.GetBankCode() + " Meniu-----------------------------");
    Console.WriteLine("1.Add New Client\t2.See Bank Clients\t3.Add Client Bank Account\t4.Withdraw\t5.Transfer\t6.Exit");
    Console.WriteLine("----------------------------------------------------------------------");
    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            string newCNP = "", newName = "", newAddress = "";
            try
            {
                Console.Write("Enter The CNP:\t");
                newCNP = Console.ReadLine();
                if (newCNP == null)
                    throw new Error1("Invalid CNP!");
                if (newCNP.Length != 13)
                    throw new Error1("Invalid CNP!");
                Console.Write("Enter The Customer Name:\t");
                newName = Console.ReadLine();
                if (newName == null)
                    throw new Error1("You must enter the Name!");

                Console.Write("Enter The Address:\t\t");
                newAddress = Console.ReadLine();
                if (newAddress == null)
                    throw new Error1("You must enter the Address!");

                Client client2 = new Client(newCNP, newName, newAddress);

                newBank.AddClient(client2);

                

            }
            catch (Error1 e)
            {
                Console.Write(e.Message);
            } 

            break;

        case "2":
            newBank.getBankClients();
           
            break;

        case "3":
            int accountNumber = 0;
            string accountType = "";
            double accountBalance = 0;
            try
            { 
            Client cl = new Client();
            Console.Write("Enter The CNP:\t");
            string searchCNP = Console.ReadLine();

            cl = newBank.getClientCNP(searchCNP);
                if (cl == null)
                    throw new Error1("Invalid CNP");

            Console.Write("Enter The Account Number:\t");
            accountNumber = int.Parse(Console.ReadLine());
                if (accountNumber <= 0)
                    throw new Error1("Invalid CNP!");

            Console.Write("Enter The Account Type:\t");
                 accountType = Console.ReadLine();
                 if(accountType == null)
                    throw new Error1("Invalid Option!");             

            Console.Write("Enter The accountBalance:\t\t");
                accountBalance = double.Parse(Console.ReadLine());
                if (accountBalance <= 0)
                    throw new Error1("Invalid balance!");

                BankAccount bankAccount = new BankAccount(accountNumber, accountType, accountBalance);

                cl.AddBankAccount(bankAccount);

            }
            catch (Error1 e)
            {
                Console.Write(e.Message);
            }


            break;

        case "4":
            try
            {
                Client clTemp = new Client();
                Console.Write("Enter The CNP:\t");
                string searchCNP = Console.ReadLine();

                clTemp = newBank.getClientCNP(searchCNP);
                if (clTemp == null)
                    throw new Error1("Invalid CNP");

                BankAccount cont = new BankAccount();
                Console.Write("Enter The Bank Account:\t");
                int searchByNumber = int.Parse(Console.ReadLine());
                if (searchByNumber < 0)
                    throw new Error1("Invalid bank account number!");
                
                cont = clTemp.GetBankAccountByNumber(searchByNumber);
                if(cont.GetAccountType().Equals("EURO") == true)
                {
                    Console.Write("Enter The Number of days for interest rate:\t");
                    int days = int.Parse(Console.ReadLine());
                    Console.WriteLine("Account " + cont.GetAccountNumber() + " has interest rate " +
                        cont.GetInterestRate(days));
                }
            }
            catch (Error1 e)
            {
                Console.Write(e.Message);
            }




            break;

        case "5":
            try
            {
                Console.Write("Enter The First Bank Account:\t");
                int accNr1 = int.Parse(Console.ReadLine());
                if (accNr1 <= 0)
                    throw new Error1("invalid account nummber!");
                Console.Write("Enter The Second Bank Account:\t");
                int accNr2 = int.Parse(Console.ReadLine());
                if (accNr2 <= 0)
                    throw new Error1("invalid account nummber!");

                Console.Write("Enter The Ammount to be transfered to 2nd Account from 1st Account:\t");
                double transferAmmount = double.Parse(Console.ReadLine());
                if (accNr2 <= 0)
                    throw new Error1("invalid account nummber!");

                BankAccount contTransfer1 = new BankAccount();
                BankAccount contTransfer2 = new BankAccount();

                Client clTemp1 = new Client();
                Console.Write("Enter The CNP:\t");
                string searchCNP1 = Console.ReadLine();

                clTemp1 = newBank.getClientCNP(searchCNP1);
                if (clTemp1 == null)
                    throw new Error1("Invalid CNP");

                Client clTemp2 = new Client();
                Console.Write("Enter The CNP:\t");
                string searchCNP2 = Console.ReadLine();

                clTemp2 = newBank.getClientCNP(searchCNP2);
                if (clTemp2 == null)
                    throw new Error1("Invalid CNP");

                contTransfer1 = clTemp1.GetBankAccountByNumber(accNr1);
                contTransfer2 = clTemp2.GetBankAccountByNumber(accNr2);

                if ((contTransfer1.GetType().Equals("RON") == true) && (contTransfer2.GetType().Equals("RON") == true))
                {
                    contTransfer1.WithdrawMoney(accNr1, transferAmmount);
                    contTransfer2.AddMoney(accNr2, transferAmmount);
                }
                else
                    throw new Error1("Error - 1 account is in EURO");

            }
            catch(Error1 e)
            {
                Console.Write(e.Message);
            }
            break;

        case "6":

            System.Environment.Exit(0);
            break;


        default:

            
            break;
    }
}

