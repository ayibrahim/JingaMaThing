using JMT.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMT.DataLayer
{
    public class DeveloperdbContext : DbContext
    {

        public DeveloperdbContext(DbContextOptions<DeveloperdbContext> options) : base(options)
        { 
        }

        public DbSet<TCustomerInbox> TCustomerInbox { get; set; }

        public DbSet<TCustomerPending> TCustomerPending { get; set; }

        public DbSet<TCustomers> TCustomers { get; set; }

        public DbSet<TDeveloperDeclined> TDeveloperDeclined { get; set; }

        public DbSet<TDeveloperInbox> TDeveloperInbox { get; set; }

        public DbSet<TDeveloperLinks> TDeveloperLinks { get; set; }

        public DbSet<TDeveloperNotes> TDeveloperNotes { get; set; }

        public DbSet<TDeveloperPending> TDeveloperPending { get; set; }

        public DbSet<TDeveloperProjects> TDeveloperProjects { get; set; }

        public DbSet<TDevelopers> TDevelopers { get; set; }

        public DbSet<TDeveloperTasks> TDeveloperTasks { get; set; }

        public DbSet<TOrders> TOrders { get; set; }

        public DbSet<TResourceManagerLinks> TResourceManagerLinks { get; set; }

        public DbSet<TResourceManagerNotes> TResourceManagerNotes { get; set; }

        public DbSet<TResourceManagers> TResourceManagers { get; set; }

        public DbSet<TRMDeveloper> TRMDeveloper { get; set; }

        public DbSet<TRMInbox> TRMInbox { get; set; }

        public DbSet<TRoles> TRoles { get; set; }


    }
}
