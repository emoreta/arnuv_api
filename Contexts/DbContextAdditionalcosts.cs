using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextAdditionalcosts : DbContext
{
public DbContextAdditionalcosts(DbContextOptions<DbContextAdditionalcosts> options) : base(options)
{
}
public DbSet<Additionalcosts> Additionalcosts { get; set; }
}
}
