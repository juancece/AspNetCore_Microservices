using System.Collections.Generic;

namespace MS.AFORO255.Account.Service
{
    public interface IAccountService
    {
        IEnumerable<Model.Account> GetAll();
        bool Deposit(Model.Account account);
        bool WithDrawal(Model.Account account);
    }
}