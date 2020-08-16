using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MS.AFORO255.History.Model;

namespace MS.AFORO255.History.Repository
{
    public class RepositoryHistory : IRepositoryHistory
    {
        private readonly IMongoDatabase _database = null;

        public RepositoryHistory(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["mongo:cn"]);
            if (client != null)
                _database = client.GetDatabase(configuration["mongo:database"]);
        }

        public IMongoCollection<HistoryTransaction> HistoryCredit 
        {
            get
            {
                return _database.GetCollection<HistoryTransaction>("HistoryTransaction");
            }
        }
    }
}