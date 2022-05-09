using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextProvider : DbContext
{
public DbContextProvider(DbContextOptions<DbContextProvider> options) : base(options)
{
}
public DbSet<Provider> Provider { get; set; }
}
}
