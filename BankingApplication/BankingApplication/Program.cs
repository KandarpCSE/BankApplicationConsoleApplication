using BankingApplication.Models;
using BankingApplication.Repositories;

namespace BankingApplication
{
    public class Bank
    {
        public static void Main(string[] args)
        {
            InitialListData initializeList = new();
            MoneyOperation moneyOperation = new();
            BankOperation bankOperation = new();
            initializeList.InitializeAllList();
            bankOperation.ShowAllDetails();

            
            ConsoleKeyInfo Operation;
            Console.WriteLine("************************************************************************");
            Console.WriteLine("WELCOME TO ONLINE  APPLICATION                                         *");
            do
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine("* Press  1  to  Credit/debit using account number                      *");
                Console.WriteLine("* Press  2  to  Display balance using Account Number                   *");
                Console.WriteLine("* Press  3  to  Display balance for all the accounts using Customer ID *");
                Console.WriteLine("* Press  4  to  Display account statement using Account Number         *");
                Console.WriteLine("* Press the Escape (Esc) and (Enter) key to quit:                      *");
                Console.WriteLine("************************************************************************");
                Operation = Console.ReadKey();
                Console.WriteLine("\n************************************************************************");
                switch (Operation.KeyChar)
                {
                    case '1':
                        ConsoleKeyInfo MoneyOperation;
                        Console.WriteLine("CREDIT/DEBIT USING ACCOUNT NUMBER");
                        do
                        {
                            Console.WriteLine("************************************************************************");
                            Console.WriteLine("* Press D to Withdraw From your Account                                *");
                            Console.WriteLine("* Press C to Deposite To your Account                                  *");
                            Console.WriteLine("* Press F1 to go back                                                  *");
                            Console.WriteLine("************************************************************************");
                            MoneyOperation = Console.ReadKey();
                            Console.WriteLine("\n************************************************************************");
                            switch (MoneyOperation.KeyChar)
                            {
                                case 'D':
                                case 'd':
                                    moneyOperation.Debit();
                                    break;

                                case 'C':
                                case 'c':
                                    moneyOperation.Credit();
                                    break;

                                default :
                                    Console.WriteLine("Choose valid Option \n");
                                    break;
                            }
                        }
                        while (MoneyOperation.Key != ConsoleKey.F1);
                        Console.WriteLine("\n");
                        break;

                    case '2':
                        Console.WriteLine("Enter Account Number Here To View Current Balance");
                        var AccountNumber = Convert.ToInt32(Console.ReadLine());
                        bankOperation.DisplayBalance(AccountNumber);
                        break;

                    case '3':
                        Console.WriteLine("Enter Your Id Here To View All Account Details");
                        Guid CustomerId;
                        string customerIdStr = Console.ReadLine();
                        while(!(Guid.TryParse(customerIdStr,out CustomerId )))
                        {
                            Console.WriteLine("Please Enter Customer Id in Correct manner");
                            customerIdStr = Console.ReadLine();
                        }
                        bankOperation.DisplayBalance(CustomerId);
                        break;

                    case '4':
                        Console.WriteLine("Enter Account Number Here To View Statement");
                        var AccountNum = Convert.ToInt32(Console.ReadLine());
                        bankOperation.ShowAccountStatement(AccountNum);
                        break;

                    default:
                        Console.WriteLine("Wrong Choice please select again \n");
                        break;
                }

            }
            while (Operation.Key != ConsoleKey.Escape);
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Thanks For Using Our Application");
            Console.WriteLine("-----------------------------------------------------------------------");




            Console.ReadLine();
            
        }
    }
}