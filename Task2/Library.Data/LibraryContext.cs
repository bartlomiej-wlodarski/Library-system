﻿using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<BookCatalog> BookCatalogs { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<RentEvent> RentEvents { get; set; }
        public virtual DbSet<ReturnEvent> ReturnEvents { get; set; }
        public virtual DbSet<DamagedEvent> DamagedEvents { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
