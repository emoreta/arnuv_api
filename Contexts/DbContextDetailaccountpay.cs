using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
public class DbContextDetailaccountpay : DbContext
{
public DbContextDetailaccountpay(DbContextOptions<DbContextDetailaccountpay> options) : base(options)
{
}
public DbSet<Detailaccountpay> Detailaccountpay { get; set; }
}
}
