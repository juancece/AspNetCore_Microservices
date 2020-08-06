using MongoDB.Driver;
using MS.AFORO255.History.Model;

namespace MS.AFORO255.History.Repository
{
    public interface IRepositoryHistory
    {
        IMongoCollection<HistoryTransaction> HistoryCredit { get; }
    }
}