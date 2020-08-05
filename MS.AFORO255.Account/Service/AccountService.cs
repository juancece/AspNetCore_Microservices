using System.Collections.Generic;
using MS.AFORO255.Account.Repository;

namespace MS.AFORO255.Account.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Model.Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public bool Deposit(Model.Account account)
        {
            return _accountRepository.Deposit(account);
        }

        public bool WithDrawal(Model.Account account)
        {
            return _accountRepository.WithDrawal(account);
        }
    }
}