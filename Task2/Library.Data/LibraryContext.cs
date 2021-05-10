using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        //public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
