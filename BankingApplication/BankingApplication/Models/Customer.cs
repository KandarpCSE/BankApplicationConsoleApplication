namespace BankingApplication.Models
{
    public class Customer
    {
        public Customer()
        {
            Accounts = new List<Account>();
        }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }    

        //public List<int> AccountNumber { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
