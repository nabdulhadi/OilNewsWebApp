using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASPNETCoreWebApplication1.Models;

namespace ASPNETCoreWebApplication1.Migrations
{
  [DbContext(typeof(MoviesAppContext))]
  partial class MoviesAppContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
      modelBuilder
          .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("ASPNETCoreWebApplication1.Models.Movie", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd();

            b.Property<string>("Director");

            b.Property<string>("Title");

            b.HasKey("Id");

            b.ToTable("Movies");
          });
    }
  }
}
