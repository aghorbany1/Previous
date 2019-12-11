using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.Data.Entity;
using Started.Data.Entities;
#endregion

namespace StartedSystem.DAL
{
    internal class StartedContext : DbContext
    {
        public StartedContext() : base("StarTedDb")
        {

        }
        public DbSet<ClassOffering> ClassOfferings { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Course> Courses { get; set; }

    }
}
