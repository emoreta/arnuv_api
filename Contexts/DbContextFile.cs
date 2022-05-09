using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
    public class DbContextFile : DbContext
    {
        public DbContextFile(DbContextOptions<DbContextFile> options) : base(options)
        {
        }
        public DbSet<File> File { get; set; }
    }
}
