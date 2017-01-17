using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OilNewsWebApp.Models
{
  public class OilsAppContext : DbContext
  {
    public OilsAppContext(DbContextOptions<OilsAppContext> options) : base(options) { }

    public DbSet<Oil> Oils { get; set; }
  }
}
