using CommonModels.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Api.Model.Database;
using System.Threading.Tasks;

namespace Api.Model.Database
{
    public class DatabaseContext : DbContext
    {
        //gets data from db
        
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbAdminUser> AdminUsers { get; set; }
        public DbSet<DbDevice> Devices { get; set; }
        public DbSet<DbGroup> Groups { get; set; }
        public DbSet<DbMailingList> ML { get; set; }
        public DbSet<DbImageuploads> Documents { get; set; }
        public DbSet<Imageupload> Imageuploads { get; set; }
       // public DbSet<DbDashboard> Dashboards { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            
        }
    }
}