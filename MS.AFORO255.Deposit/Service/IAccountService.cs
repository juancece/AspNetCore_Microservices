using MS.AFORO255.Deposit.DTO;
using MS.AFORO255.Deposit.Model;
using System.Threading.Tasks;

namespace MS.AFORO255.Deposit.Service
{
    public interface IAccountService
    {
        Task<bool> DepositAccount(AccountRequest request);
        bool DepositReverse(Transaction request);
        bool Execute(Transaction request);
    }
}