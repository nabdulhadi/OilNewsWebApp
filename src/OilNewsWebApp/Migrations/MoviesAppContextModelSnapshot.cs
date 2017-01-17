using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OilNewsWebApp.Models;

namespace OilNewsWebApp.Migrations
{
  [DbContext(typeof(MoviesAppContext))]
  partial class MoviesAppContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
      modelBuilder
          .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("OilNewsWebApp.Models.Movie", b =>
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
