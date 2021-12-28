namespace BankingApplication.Repositories
{
    public class BankOperation : CollectionStorageBase,IBankOperation
    {
        //Display Balance using Customer Id
        public void DisplayBalance(Guid CustomerId)
        {
            //Fetching All Accounts that this Customer have
            var allAccount = CustomerList.FirstOrDefault(x => x.CustomerId == CustomerId);
            if (allAccount != null)
            {
                if(allAccount.Accounts.Capacity > 0)
                {
                    foreach (var account in allAccount.Accounts)
                    {
                        Console.WriteLine($"Account Number : {account.AccountNumber} has Current Balance : {account.CurrentBalance}");
                    }
                }
                else
                {
                    Console.WriteLine("Please Create Account First");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Please Enter Correct Details");
                return;
            }
            
        }

        // Fetching Balance using Account Number
        public void DisplayBalance(int AccountNumber)
        {
            
            

            var accountDetail = CustomerList.Select(x => x.Accounts.FirstOrDefault(x=>x.AccountNumber == AccountNumber));
            if (accountDetail != null)
            {
                foreach (var account in accountDetail)
                {
                    if(account != null)
                    {
                        Console.WriteLine($"Account Number : {AccountNumber} Has Current Balance : {account.CurrentBalance}");
                        Console.WriteLine($" LastTransactionTime : {account.LastTransactionTime}");
                    }  
                }
            }
            else
            {
                Console.WriteLine("Please Enter Correct Details");
                return;
            }
        }

        // Show All trnsaction of the account using AccountNumber
        public void ShowAccountStatement(int AccountNumber)
        {
            var accountDetail = CustomerList.Select(x => x.Accounts.FirstOrDefault(y => y.AccountNumber == AccountNumber));

            

            if (accountDetail != null)
            {
                foreach (var account in accountDetail)
                {
                    if (account != null)
                    {
                        Console.WriteLine($"Account Number : {AccountNumber} Has Current Balance : {account.CurrentBalance}");
                        foreach (var AllTransaction in account.TransactionList)
                        {
                            Console.WriteLine($"Transaction Type : {AllTransaction.TransactionType} \t TransactionId : {AllTransaction.TransactionId} \t Transaction Amount : {AllTransaction.AmountTransfer} \t Transaction Time : {AllTransaction.TransactionTime}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Please Enter Correct Details");
                return;
            }
        }

        public void ShowAllDetails()
        {
            foreach (var customer in CustomerList)
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine($"    CustomerName = {customer.CustomerName}");
                Console.WriteLine($"    CustomerId = {customer.CustomerId}");
                Console.WriteLine("\n");
                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine($"    AccountNumber - {account.AccountNumber}");
                    Console.WriteLine($"    AccountBalance - {account.CurrentBalance}");
                    Console.WriteLine($"    AccountType - {account.AccountType}");
                    Console.WriteLine("\n");
                }
                Console.WriteLine("************************************************************************");
            }
        }


    }
}
