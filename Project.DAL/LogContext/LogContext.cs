using Project.ENTITES.LogEntites;
using Project.MAP.LogEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.LogContext
{
    public class LogContext : DbContext
    {
        public LogContext() : base("MyConnectionLog")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DataLogMap());
            modelBuilder.Configurations.Add(new LogAppUserMap());
        }


        public DbSet<DataLog>  DataLogs { get; set; }
        public DbSet<LogAppUser> LogAppUsers   { get; set; }
    }
}
