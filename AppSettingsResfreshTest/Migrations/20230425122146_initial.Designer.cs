﻿// <auto-generated />
using System;
using AppSettingsResfreshTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppSettingsResfreshTest.Migrations
{
    [DbContext(typeof(SampleDB))]
    [Migration("20230425122146_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppSettingsResfreshTest.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PK")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(500);

                    b.Property<string>("SK1")
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("SK2")
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<DateTime>("SK20")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SK21")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SK22")
                        .HasColumnType("datetime2");

                    b.Property<string>("SK3")
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("SK4")
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("SK5")
                        .HasColumnType("NVARCHAR(1000)");

                    b.HasKey("ID");

                    b.HasIndex("PK");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
