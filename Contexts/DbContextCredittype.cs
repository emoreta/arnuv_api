using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextCredittype : DbContext
{
public DbContextCredittype(DbContextOptions<DbContextCredittype> options) : base(options)
{
}
public DbSet<Credittype> Credittype { get; set; }
}
}
