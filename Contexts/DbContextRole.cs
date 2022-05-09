using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
    public class DbContextRole : DbContext
    {
        public DbContextRole(DbContextOptions<DbContextRole> options) : base(options)
        {
        }
        public DbSet<Role> Role { get; set; }
    }
}
