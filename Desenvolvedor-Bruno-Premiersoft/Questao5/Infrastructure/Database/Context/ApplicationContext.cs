using Microsoft.EntityFrameworkCore;
using Questao5.Infrastructure.Database.Mapping;

namespace Questao5.Infrastructure.Database.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CheckingAccountMapping());
        }
    }
}
