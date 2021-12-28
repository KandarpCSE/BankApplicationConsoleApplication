using BankingApplication.Models;

namespace BankingApplication.Repositories
{
    public class CollectionStorageBase
    {
        protected static List<Customer> CustomerList = new List<Customer>();

        //protected static IDictionary<Guid,Customer> CustomerMap = new Dictionary<Guid,Customer>();
        //protected static IDictionary<int,Account> AccountMap = new Dictionary<int,Account>();
        //protected static IDictionary<Guid,Transaction> TransactionMap = new Dictionary<Guid,Transaction>();
    }
}