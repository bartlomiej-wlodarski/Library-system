using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\;Database=Pttask;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
