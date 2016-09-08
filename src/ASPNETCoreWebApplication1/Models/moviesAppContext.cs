using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebApplication1.Models
{
    public class MoviesAppContext : DbContext
    {
      public MoviesAppContext(DbContextOptions<MoviesAppContext> options) : base(options) { }
      
      public DbSet<Movie> Movies { get; set; }
    }
}
