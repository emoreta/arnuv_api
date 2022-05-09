using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextPurchases : DbContext
{
public DbContextPurchases(DbContextOptions<DbContextPurchases> options) : base(options)
{
}
public DbSet<Purchases> Purchases { get; set; }
}
}
