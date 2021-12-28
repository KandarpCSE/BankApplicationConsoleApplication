namespace BankingApplication.Models
{
    public enum TransactionType
    {
        Debit,
        credit
    }
    public class Transaction 
    {

        public Guid TransactionId { get; set; }    
        public TransactionType TransactionType { get; set;}
        public double AmountTransfer { get; set; }
        public DateTime TransactionTime { get; set; }
        public double Balance { get; set; }
    }
}
