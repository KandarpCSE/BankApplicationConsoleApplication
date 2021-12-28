using BankingApplication.Models;
using BankingApplication.Data;

namespace BankingApplication.Repositories
{
    public  class InitialListData : CollectionStorageBase
    {
        public  void InitializeAllList()
        {
            Random randomNumber = new();
            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "kandarp",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Current,
                        CurrentBalance = 200000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    },

                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Saving,
                        CurrentBalance = 19000000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    },

                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Saving,
                        CurrentBalance = 89000000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    }


                }
            });

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Akshat",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Current,
                        CurrentBalance = 2900000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    },
                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Saving,
                        CurrentBalance = 89900000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    }
                }
            });

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Hardik",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Current,
                        CurrentBalance = 8300000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    },
                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Saving,
                        CurrentBalance = 780000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    }

                }
            });

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Divyesh",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = randomNumber.Next(111111111,999999999),
                        AccountType = AccType.Saving,
                        CurrentBalance = 98700000,
                        WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour,
                        LastTransactionTime = DateTime.Now,
                        NumberOfTransactionPerHour = ConstantValueData.NumberOfTransactionPerHour,
                    }
                }
            });

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Ram",
                
            });
        }
    }
}
