using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Security.Model;

namespace MS.AFORO255.Security.Repository.Data
{
    public class ContextDatabase :DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Access> Access { get; set; }
    }
}