using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextPettycash : DbContext
{
public DbContextPettycash(DbContextOptions<DbContextPettycash> options) : base(options)
{
}
public DbSet<Pettycash> Pettycash { get; set; }
}
}
