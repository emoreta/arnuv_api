using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextAccountbank : DbContext
{
public DbContextAccountbank(DbContextOptions<DbContextAccountbank> options) : base(options)
{
}
public DbSet<Accountbank> Accountbank { get; set; }
}
}
