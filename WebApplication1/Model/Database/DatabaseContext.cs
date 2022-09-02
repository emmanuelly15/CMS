using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Database
{
    public class DatabaseContext : DbContext
    {
        //gets data from db
        public DbSet<DbNotification> Notifications { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbAdminUser> AdminUsers { get; set; }
        public DbSet<DbDevice> Devices { get; set; }
        public DbSet<DbGroup> Groups { get; set; }
<<<<<<< HEAD
        public DbSet<DbMailingList> ML { get; set; }
=======
        public DbSet<DbDocument> Documents { get; set; }
>>>>>>> Alpha-branch

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            
        }
    }
}