using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Withdrawal.Model;

namespace MS.AFORO255.Withdrawal.Repository.Data
{
    public class ContextDatabase :DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }
    }
}