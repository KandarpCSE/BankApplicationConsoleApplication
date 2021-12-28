namespace BankingApplication.Models
{
    public enum AccType
    {
        Saving,
        Current
    }
    public class Account 
    {
        public Account()
        {
            TransactionList = new List<Transaction>();
        }

        public AccType AccountType { get; set; }
        public int AccountNumber { get; set; }
        public double CurrentBalance { get; set; }
        public double WithdrawalLimitPerHour { get; set; }
        public DateTime LastTransactionTime { get; set; }  
        public int NumberOfTransactionPerHour { get; set; }
        //public List<Guid> TransactionIds { get; set; }
        public List<Transaction> TransactionList { get; set; }

    }
}
