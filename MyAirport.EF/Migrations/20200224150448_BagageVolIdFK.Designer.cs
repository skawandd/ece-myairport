﻿// <auto-generated />
using System;
using FLS.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FLS.MyAirport.EF.Migrations
{
    [DbContext(typeof(MyAirportContext))]
    [Migration("20200224150448_BagageVolIdFK")]
    partial class BagageVolIdFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FLS.MyAirport.EF.Bagage", b =>
                {
                    b.Property<int>("BagageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Classe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeIata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Prioritaire")
                        .HasColumnType("bit");

                    b.Property<string>("SSUR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VolID")
                        .HasColumnType("int");

                    b.HasKey("BagageID");

                    b.HasIndex("VolID");

                    b.ToTable("Bagages");
                });

            modelBuilder.Entity("FLS.MyAirport.EF.Vol", b =>
                {
                    b.Property<int>("VolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CIE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DHC")
                        .HasColumnType("datetime2");

                    b.Property<string>("IMM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LIG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("PAX")
                        .HasColumnType("smallint");

                    b.Property<string>("PKG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolId");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("FLS.MyAirport.EF.Bagage", b =>
                {
                    b.HasOne("FLS.MyAirport.EF.Vol", null)
                        .WithMany("Bagages")
                        .HasForeignKey("VolID");
                });
#pragma warning restore 612, 618
        }
    }
}
