using MS.AFORO255.Withdrawal.Model;

namespace MS.AFORO255.Withdrawal.Service
{
    public interface ITransactionService
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}