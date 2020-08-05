using MS.AFORO255.Withdrawal.Model;
using MS.AFORO255.Withdrawal.Repository;

namespace MS.AFORO255.Withdrawal.Service
{
    class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Deposit(Transaction transaction)
        {
            return _transactionRepository.Deposit(transaction);
        }

        public Transaction DepositReverse(Transaction transaction)
        {
            return _transactionRepository.DepositReverse(transaction);
        }
    }
}