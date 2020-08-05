using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Account.Repository.Data;

namespace MS.AFORO255.Account.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public AccountRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Model.Account> GetAll()
        {
            return _contextDatabase.Account.Include(x => x.Customer).AsNoTracking().ToList();
        }

        public bool Deposit(Model.Account account)
        {
            _contextDatabase.Account.Update(account);
            _contextDatabase.SaveChanges();
            return true;
        }

        public bool WithDrawal(Model.Account account)
        {
            _contextDatabase.Account.Update(account);
            _contextDatabase.SaveChanges();
            return true;
        }
    }
}