using MS.AFORO255.Withdrawal.DTO;
using MS.AFORO255.Withdrawal.Model;
using System.Threading.Tasks;

namespace MS.AFORO255.Withdrawal.Service
{
    public interface IAccountService
    {
        Task<bool> WithdrawalAccount(AccountRequest request);
        bool WithdrawalReverse(Transaction request);
        bool Execute(Transaction request);
    }
}