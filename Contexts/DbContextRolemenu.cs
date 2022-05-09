using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextRolemenu : DbContext
{
public DbContextRolemenu(DbContextOptions<DbContextRolemenu> options) : base(options)
{
}
public DbSet<Rolemenu> Rolemenu { get; set; }
}
}
