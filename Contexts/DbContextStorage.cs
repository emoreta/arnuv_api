using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextStorage : DbContext
{
public DbContextStorage(DbContextOptions<DbContextStorage> options) : base(options)
{
}
public DbSet<Storage> Storage { get; set; }
}
}
