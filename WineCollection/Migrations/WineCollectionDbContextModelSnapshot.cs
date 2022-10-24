﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WineCollection.Entities;

#nullable disable

namespace WineCollection.Migrations
{
    [DbContext(typeof(WineCollectionDbContext))]
    partial class WineCollectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WineCollection.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Color");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorName = "Red"
                        },
                        new
                        {
                            Id = 2,
                            ColorName = "White"
                        },
                        new
                        {
                            Id = 3,
                            ColorName = "Rose"
                        });
                });

            modelBuilder.Entity("WineCollection.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WineCollection.Entities.GrapeVariety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GrapeVarietyName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("unknown")
                        .HasColumnName("GrapeVarietyName");

                    b.HasKey("Id");

                    b.ToTable("GrapeVarieties");
                });

            modelBuilder.Entity("WineCollection.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WineCollection.Entities.Vineyard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Region")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Vineyards");
                });

            modelBuilder.Entity("WineCollection.Entities.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GrapeVarietyId")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("ServingTemperature")
                        .HasMaxLength(20)
                        .HasColumnType("decimal(3,1)")
                        .HasColumnName("ServingTemp_(C)");

                    b.Property<string>("Style")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TasteDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VineyardId")
                        .HasColumnType("int");

                    b.Property<int>("WineCellarId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("GrapeVarietyId");

                    b.HasIndex("UserId");

                    b.HasIndex("VineyardId");

                    b.HasIndex("WineCellarId");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("WineCollection.Entities.WineCellar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WineCellars");
                });

            modelBuilder.Entity("WineCollection.Entities.Vineyard", b =>
                {
                    b.HasOne("WineCollection.Entities.Country", "Country")
                        .WithMany("Vineyards")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WineCollection.Entities.Wine", b =>
                {
                    b.HasOne("WineCollection.Entities.Color", "Color")
                        .WithMany("Wines")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineCollection.Entities.GrapeVariety", "GrapeVariety")
                        .WithMany("Wines")
                        .HasForeignKey("GrapeVarietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineCollection.Entities.User", "User")
                        .WithMany("Wines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineCollection.Entities.Vineyard", "Vineyard")
                        .WithMany("Wines")
                        .HasForeignKey("VineyardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineCollection.Entities.WineCellar", "WineCellar")
                        .WithMany("Wines")
                        .HasForeignKey("WineCellarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("GrapeVariety");

                    b.Navigation("User");

                    b.Navigation("Vineyard");

                    b.Navigation("WineCellar");
                });

            modelBuilder.Entity("WineCollection.Entities.WineCellar", b =>
                {
                    b.HasOne("WineCollection.Entities.User", "User")
                        .WithMany("WineCellars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WineCollection.Entities.Color", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WineCollection.Entities.Country", b =>
                {
                    b.Navigation("Vineyards");
                });

            modelBuilder.Entity("WineCollection.Entities.GrapeVariety", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WineCollection.Entities.User", b =>
                {
                    b.Navigation("WineCellars");

                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WineCollection.Entities.Vineyard", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WineCollection.Entities.WineCellar", b =>
                {
                    b.Navigation("Wines");
                });
#pragma warning restore 612, 618
        }
    }
}
