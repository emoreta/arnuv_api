using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextTypeprovider : DbContext
{
public DbContextTypeprovider(DbContextOptions<DbContextTypeprovider> options) : base(options)
{
}
public DbSet<Typeprovider> Typeprovider { get; set; }
}
}
