
using InventarioApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Inventario> Inventario { get; set; }  //creando una prob DbSet<modelo> plural
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
