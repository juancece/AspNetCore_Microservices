using MS.AFORO255.Withdrawal.Model;

namespace MS.AFORO255.Withdrawal.Repository
{
    public interface ITransactionRepository
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}