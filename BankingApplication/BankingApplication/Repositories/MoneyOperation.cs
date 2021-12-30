using BankingApplication.Data;
using BankingApplication.Models;

namespace BankingApplication.Repositories
{
    public class MoneyOperation : CollectionStorageBase, IMoneyOperation
    {
        public void Credit()
        {
            var accountNumber = 0;
            var amount = 0;
            Guid customerId;

            TakeInput(out customerId, out accountNumber, out amount);

            //amount filtering should be multiple of 100 and less than 50k per transaction
            if (amount % 100 == 0)
            {
                //fetching Account using CustomerId and AccountNumber
                var AccountDetails = CustomerList.FirstOrDefault(x => x.CustomerId == customerId).Accounts.FirstOrDefault(y => y.AccountNumber == accountNumber);
                if (AccountDetails != null)
                {
                    //Checking if an Hour Exceed if then reset the limit for this account
                    if (DateTime.Now > AccountDetails.LastTransactionTime.AddHours(1))
                    {
                        AccountDetails.WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour;
                        AccountDetails.NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour;
                    }
                    //checking if withdrawl limit per hour and limit of number trasaction per hour exceed or not
                    if (AccountDetails.NumberOfTransactionPerHour > 0)
                    {

                        AccountDetails.CurrentBalance += amount;
                        AccountDetails.NumberOfTransactionPerHour--;
                        AccountDetails.LastTransactionTime = DateTime.Now;
                        AccountDetails.TransactionList.Add(new Transaction()
                        {
                            TransactionId = Guid.NewGuid(),
                            AmountTransfer = amount,
                            TransactionType = TransactionType.credit,
                            TransactionTime = DateTime.Now
                        });
                        Console.WriteLine($"{amount} Successfully Credited To Account {AccountDetails.AccountNumber}");
                        Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                    }
                    else
                    {
                        Console.WriteLine("You Have Exceeded Your Hourly Limit Please Try After Sometime");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Details");
                    return;
                }

            }
            else
            {
                Console.WriteLine("Please enter Amount in Multiple Of 100");
                return;
            }
        }

        public void Debit()
        {
            var accountNumber = 0;
            var amount = 0;
            Guid customerId;
            TakeInput(out customerId, out accountNumber, out amount);
            //amount filtering should be multiple of 100 and less than 50k per transaction
            if (amount % 100 == 0)
            {
                if (amount <= 50000)
                {
                    //fetching Account using CustomerId and AccountNumber
                    var AccountDetails = CustomerList.FirstOrDefault(x => x.CustomerId == customerId).Accounts.FirstOrDefault(y => y.AccountNumber == accountNumber);
                    if (AccountDetails != null)
                    {
                        //Checking if an Hour Exceed if then reset the limit for this account
                        if (DateTime.Now > AccountDetails.LastTransactionTime.AddHours(1))
                        {
                            AccountDetails.WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour;
                            AccountDetails.NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour;
                        }
                        //checking if withdrawl limit per hour and limit of number trasaction per hour exceed or not
                        if (AccountDetails.WithdrawalLimitPerHour > 0 && AccountDetails.NumberOfTransactionPerHour > 0)
                        {
                            // Checking Balance is there or Not
                            if (AccountDetails.CurrentBalance > 0)
                            {
                                if (amount > ConstantValueData.ChargeLimit)
                                {

                                    AccountDetails.CurrentBalance -= (amount + ConstantValueData.ChargeAmount);
                                    Console.WriteLine($"Extra charge of {ConstantValueData.ChargeAmount} is Deducted");
                                    Console.WriteLine($"{amount + ConstantValueData.ChargeAmount} Successfully Debited From Account {AccountDetails.AccountNumber}");
                                }
                                else
                                {
                                    AccountDetails.CurrentBalance -= amount;
                                    Console.WriteLine($"{amount} Successfully Debited From Account {AccountDetails.AccountNumber}");
                                }
                                AccountDetails.TransactionList.Add(new Transaction()
                                {
                                    TransactionId = Guid.NewGuid(),
                                    AmountTransfer = amount,
                                    TransactionType = TransactionType.Debit,
                                    TransactionTime = DateTime.Now
                                });
                                AccountDetails.WithdrawalLimitPerHour -= amount;
                                AccountDetails.NumberOfTransactionPerHour--;
                                AccountDetails.LastTransactionTime = DateTime.Now;
                                Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance");
                            }

                        }
                        else
                        {
                            Console.WriteLine("You Have Exceeded Your Hourly Limit");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Enter Correct Details");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("You exceed your per transaction limit of 50k please enter lower than limit");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Please enter Amount in Multiple Of 100");
                return;
            }
        }


        public static void TakeInput(out Guid Id,out int AC_Number,out int amount_value)
        {
            Console.WriteLine("Enter CustomerId :-");
            var customerIdStr = Console.ReadLine();
            while (!(Guid.TryParse(customerIdStr, out Id)))
            {
                Console.WriteLine("Please Enter CustomerId in Correct manner");
                customerIdStr = Console.ReadLine();
            }
            Console.WriteLine("Enter AccountNumber :-");
            var accountNumberStr = Console.ReadLine();
            while (!(int.TryParse(accountNumberStr, out AC_Number)))
            {
                Console.WriteLine("Please Enter Account Number In Correct Manner");
                accountNumberStr = Console.ReadLine();
            }

            Console.WriteLine("Enter amount to be withdraw");
            var amountStr = Console.ReadLine();
            while (!(int.TryParse(amountStr, out amount_value)))
            {
                Console.WriteLine("Please enter amount In numbers");
                amountStr = Console.ReadLine();
            }


        }
    }
}
