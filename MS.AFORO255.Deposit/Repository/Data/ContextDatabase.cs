using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Deposit.Model;

namespace MS.AFORO255.Deposit.Repository.Data
{
    public class ContextDatabase :DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
    }
}