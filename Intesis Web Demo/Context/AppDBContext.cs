using Intesis_Web_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intesis_Web_Demo.Context
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
              
        }
        public DbSet<Trabajadores_BD> Trabajador { get; set; }
    }
}
