﻿// <auto-generated />
using LicenseProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LicenseProject.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200501185731_ALL")]
    partial class ALL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LicenseProject.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LicenseProject.Models.DeveloperTeam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("PeopleQuantity");

                    b.Property<int>("SoftID");

                    b.HasKey("ID");

                    b.ToTable("DeveloperTeams");
                });

            modelBuilder.Entity("LicenseProject.Models.Discount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountName");

                    b.Property<double>("Percantage");

                    b.HasKey("ID");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("LicenseProject.Models.LicenseType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("LicenseTypes");
                });

            modelBuilder.Entity("LicenseProject.Models.Module", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SoftID");

                    b.HasKey("ID");

                    b.HasIndex("SoftID");

                    b.ToTable("Moduls");
                });

            modelBuilder.Entity("LicenseProject.Models.Selling", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<int>("DiscountID");

                    b.Property<int>("InvoiceNumber");

                    b.Property<int>("LicenseTypeID");

                    b.Property<double>("Price");

                    b.Property<int>("SoftID");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("DiscountID");

                    b.HasIndex("LicenseTypeID");

                    b.HasIndex("SoftID");

                    b.ToTable("Sellings");
                });

            modelBuilder.Entity("LicenseProject.Models.Soft", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DevTeamID");

                    b.Property<string>("Direction");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("DevTeamID");

                    b.ToTable("Softs");
                });

            modelBuilder.Entity("LicenseProject.Models.Module", b =>
                {
                    b.HasOne("LicenseProject.Models.Soft", "Soft")
                        .WithMany()
                        .HasForeignKey("SoftID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LicenseProject.Models.Selling", b =>
                {
                    b.HasOne("LicenseProject.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LicenseProject.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LicenseProject.Models.LicenseType", "LicenseType")
                        .WithMany()
                        .HasForeignKey("LicenseTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LicenseProject.Models.Soft", "Soft")
                        .WithMany()
                        .HasForeignKey("SoftID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LicenseProject.Models.Soft", b =>
                {
                    b.HasOne("LicenseProject.Models.DeveloperTeam", "DeveloperTeam")
                        .WithMany()
                        .HasForeignKey("DevTeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}