using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextProduct : DbContext
{
public DbContextProduct(DbContextOptions<DbContextProduct> options) : base(options)
{
}
public DbSet<Product> Product { get; set; }
}
}
