using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> Card { get; set; }
        public DbSet<Reading> Reading { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<ReadingCard> ReadingCard { get; set; }
        public DbSet<ReadingType> ReadingTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReadingType>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
