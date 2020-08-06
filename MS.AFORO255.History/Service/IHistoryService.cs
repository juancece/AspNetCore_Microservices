using System.Collections.Generic;
using System.Threading.Tasks;
using MS.AFORO255.History.DTO;
using MS.AFORO255.History.Model;

namespace MS.AFORO255.History.Service
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryResponse>> GetAll();
        Task<bool> Add(HistoryTransaction historyTransaction);
    }
}