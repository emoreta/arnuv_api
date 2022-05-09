using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arnuv_api.Contexts
{
    public class DbContextIva : DbContext
    {
        public DbContextIva(DbContextOptions<DbContextIva> options) : base(options)
        {
        }
        public DbSet<Iva> Iva { get; set; }
    }
}
