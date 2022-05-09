using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
    public class DbContextAccountpay : DbContext
    {
        public DbContextAccountpay(DbContextOptions<DbContextAccountpay> options) : base(options)
        {
        }
        public DbSet<Accountpay> Accountpay { get; set; }
    }
}
