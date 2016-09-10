using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASPNETCoreWebApplication1.Models;

namespace ASPNETCoreWebApplication1.Migrations
{
    [DbContext(typeof(OilsAppContext))]
    partial class OilsAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNETCoreWebApplication1.Models.Oil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Raw");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Oils");
                });
        }
    }
}
