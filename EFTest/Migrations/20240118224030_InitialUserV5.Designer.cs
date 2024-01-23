﻿// <auto-generated />
using System;
using EFTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFTest.Migrations
{
    [DbContext(typeof(PopsCarsContext))]
    [Migration("20240118224030_InitialUserV5")]
    partial class InitialUserV5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFTest.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Blue",
                            Make = "Chevy",
                            Model = "Biscayne",
                            UserId = 1,
                            Year = 1968
                        },
                        new
                        {
                            Id = 2,
                            Color = "Blue",
                            Make = "Ford",
                            Model = "Fairlane",
                            UserId = 1,
                            Year = 1967
                        },
                        new
                        {
                            Id = 3,
                            Color = "Turquoise Blue/Green",
                            Make = "Volkswagen",
                            Model = "Beetle",
                            UserId = 1,
                            Year = 1965
                        },
                        new
                        {
                            Id = 4,
                            Color = "Green",
                            Make = "Chevy",
                            Model = "Impala",
                            UserId = 1,
                            Year = 1966
                        },
                        new
                        {
                            Id = 5,
                            Color = "Green",
                            Make = "Ford",
                            Model = "Pinto",
                            UserId = 1,
                            Year = 1972
                        },
                        new
                        {
                            Id = 6,
                            Color = "Beige",
                            Make = "Volkswagen",
                            Model = "Beetle",
                            UserId = 1,
                            Year = 1964
                        },
                        new
                        {
                            Id = 7,
                            Color = "Beige",
                            Make = "Nissan",
                            Model = "Datsun",
                            UserId = 1,
                            Year = 1967
                        },
                        new
                        {
                            Id = 8,
                            Color = "Maroon",
                            Make = "Ford",
                            Model = "Fairlane",
                            UserId = 1,
                            Year = 1963
                        },
                        new
                        {
                            Id = 9,
                            Color = "Light Blue",
                            Make = "Dodge",
                            Model = "Monaco",
                            UserId = 1,
                            Year = 1975
                        },
                        new
                        {
                            Id = 10,
                            Color = "Blue",
                            Make = "Ford",
                            Model = "Van E100",
                            UserId = 1,
                            Year = 1976
                        },
                        new
                        {
                            Id = 11,
                            Color = "Maroon",
                            Make = "Ford",
                            Model = "LTD",
                            UserId = 1,
                            Year = 1979
                        },
                        new
                        {
                            Id = 12,
                            Color = "Silver",
                            Make = "Toyota",
                            Model = "Celica",
                            UserId = 1,
                            Year = 1983
                        },
                        new
                        {
                            Id = 13,
                            Color = "Brown",
                            Make = "Volkswagen",
                            Model = "Beetle",
                            UserId = 1,
                            Year = 1965
                        },
                        new
                        {
                            Id = 14,
                            Color = "Brown/Red Stolen",
                            Make = "Toyota",
                            Model = "Corolla",
                            UserId = 1,
                            Year = 1977
                        },
                        new
                        {
                            Id = 15,
                            Color = "White",
                            Make = "Chevy",
                            Model = "Monte Carlo",
                            UserId = 1,
                            Year = 1973
                        },
                        new
                        {
                            Id = 16,
                            Color = "Blue",
                            Make = "Chevy",
                            Model = "Chevette",
                            UserId = 1,
                            Year = 1976
                        },
                        new
                        {
                            Id = 17,
                            Color = "Brown",
                            Make = "Chevy",
                            Model = "Malibu",
                            UserId = 1,
                            Year = 1975
                        },
                        new
                        {
                            Id = 18,
                            Color = "Blue",
                            Make = "Pontiac",
                            Model = "Firebird",
                            UserId = 1,
                            Year = 1976
                        },
                        new
                        {
                            Id = 19,
                            Color = "Red",
                            Make = "Oldsmobile",
                            Model = "Omega",
                            UserId = 1,
                            Year = 1974
                        },
                        new
                        {
                            Id = 20,
                            Color = "Silver/BlackGold",
                            Make = "Nissan",
                            Model = "Datsun 2 Plus 2",
                            UserId = 1,
                            Year = 1977
                        },
                        new
                        {
                            Id = 21,
                            Color = "Brown",
                            Make = "Ford",
                            Model = "Grenada",
                            UserId = 1,
                            Year = 1975
                        },
                        new
                        {
                            Id = 22,
                            Color = "Silver/Blue",
                            Make = "Toyota",
                            Model = "Celica",
                            UserId = 1,
                            Year = 1985
                        },
                        new
                        {
                            Id = 23,
                            Color = "Brown",
                            Make = "Jeep",
                            Model = "Wagoneer",
                            UserId = 1,
                            Year = 1975
                        },
                        new
                        {
                            Id = 24,
                            Color = "Blue",
                            Make = "Oldsmobile",
                            Model = "Delta 88",
                            UserId = 1,
                            Year = 1985
                        },
                        new
                        {
                            Id = 25,
                            Color = "Beige",
                            Make = "Chevy",
                            Model = "Chevelle Wagon",
                            UserId = 1,
                            Year = 1967
                        },
                        new
                        {
                            Id = 26,
                            Color = "White",
                            Make = "Chevy",
                            Model = "Malibu",
                            UserId = 1,
                            Year = 1981
                        },
                        new
                        {
                            Id = 27,
                            Color = "Red",
                            Make = "Jeep",
                            Model = "Wrangler",
                            UserId = 1,
                            Year = 1990
                        },
                        new
                        {
                            Id = 28,
                            Color = "Blue",
                            Make = "Oldsmobile",
                            Model = "Aurora",
                            UserId = 1,
                            Year = 1996
                        },
                        new
                        {
                            Id = 29,
                            Color = "Grey",
                            Make = "Oldsmobile",
                            Model = "Cutlass",
                            UserId = 1,
                            Year = 1975
                        },
                        new
                        {
                            Id = 30,
                            Color = "Silver",
                            Make = "Mazda",
                            Model = "926",
                            UserId = 1,
                            Year = 1993
                        },
                        new
                        {
                            Id = 31,
                            Color = "Blue/Off White Blueish",
                            Make = "Austin",
                            Model = "Healey",
                            UserId = 1,
                            Year = 1971
                        },
                        new
                        {
                            Id = 32,
                            Color = "Black",
                            Make = "Toyota",
                            Model = "Camry",
                            UserId = 1,
                            Year = 2000
                        },
                        new
                        {
                            Id = 33,
                            Color = "Blue",
                            Make = "Toyota",
                            Model = "Tacoma",
                            UserId = 1,
                            Year = 2008
                        },
                        new
                        {
                            Id = 34,
                            Color = "Black",
                            Make = "Ford",
                            Model = "Mustang",
                            UserId = 1,
                            Year = 1965
                        },
                        new
                        {
                            Id = 35,
                            Color = "Green",
                            Make = "Chevy",
                            Model = "210/Belair",
                            UserId = 1,
                            Year = 1954
                        });
                });

            modelBuilder.Entity("EFTest.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Note");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            Comments = "this car should be a Chevy Biscayne",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("EFTest.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            UserName = "Pop"
                        },
                        new
                        {
                            ID = 2,
                            UserName = "AJ"
                        },
                        new
                        {
                            ID = 3,
                            UserName = "Michael"
                        });
                });

            modelBuilder.Entity("EFTest.Models.Car", b =>
                {
                    b.HasOne("EFTest.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFTest.Models.User", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}