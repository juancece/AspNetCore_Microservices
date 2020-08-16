using System.Collections.Generic;

namespace MS.AFORO255.Account.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Model.Account> GetAll();
        bool Deposit(Model.Account account);
        bool Withdrawal(Model.Account account);
    }
}