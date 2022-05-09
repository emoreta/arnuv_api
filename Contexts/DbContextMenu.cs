using arnuv_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Contexts
{
    public class DbContextMenu : DbContext
    {
        public DbContextMenu(DbContextOptions<DbContextMenu> options) : base(options)
        {
        }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuSimple> MenuSimple { get; set; }
        public DbSet<Rolemenu> RolMenu { get; set; }
    }
}
