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

        public DbSet<Card> Cards { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
