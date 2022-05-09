using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arnuv_api.Contexts
{
    public class DbContextArnuv: DbContext
    {
        public DbContextArnuv(DbContextOptions<DbContextArnuv> options) : base(options)
        {
        }
        public DbSet<Accountplan> Accountplan { get; set; }
        public DbSet<Purchases> Purchases { get; set; }

        public DbSet<Provider> Provider { get; set; }
        public DbSet<Typepayments> Typepayments { get; set; }
        public DbSet<Detailpurchases> Detailpurchases { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<Rolemenu> Rolemenu { get; set; }
        public DbSet<Menu> Menu { get; set; }

        public DbSet<Typeprovider> Typeprovider { get; set; }
    }
}
