using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Account.Model;

namespace MS.AFORO255.Account.Repository.Data
{
    public class ContextDatabase :DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Model.Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbContext Instance => this;
    }
}