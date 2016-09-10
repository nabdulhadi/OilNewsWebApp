using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASPNETCoreWebApplication1.Models;

namespace ASPNETCoreWebApplication1.Migrations
{
    [DbContext(typeof(OilsAppContext))]
    [Migration("20160909165136_add_oils")]
    partial class add_oils
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNETCoreWebApplication1.Models.Oil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Oils");
                });
        }
    }
}
