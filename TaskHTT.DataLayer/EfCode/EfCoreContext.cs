using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHTT.DataLayer.EfClasses;

namespace TaskHTT.DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<State> States { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
