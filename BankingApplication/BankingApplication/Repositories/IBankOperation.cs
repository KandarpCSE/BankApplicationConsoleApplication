
namespace BankingApplication.Repositories
{
    public interface IBankOperation
    {
        void DisplayBalance(Guid CustomerId);
        void DisplayBalance(int AccountNumber);
        void ShowAccountStatement(int AccountNumber);
        void ShowAllDetails();
    }
}