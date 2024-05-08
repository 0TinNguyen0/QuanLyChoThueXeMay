﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SV20T1080053.DataLayers.EFCore;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240508033206_createdatabase")]
    partial class createdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SV20T1080053.DomainModels.Invoice", b =>
                {
                    b.Property<int>("Invoice_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Invoice_ID"));

                    b.Property<DateTime>("Invoice_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MotocycleStatusSatatus_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Payment_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rental_ID")
                        .HasColumnType("int");

                    b.Property<int>("Rental_ID1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total_Amount")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Invoice_ID");

                    b.HasIndex("MotocycleStatusSatatus_ID");

                    b.HasIndex("Rental_ID1");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.MotocycleBrand", b =>
                {
                    b.Property<int>("Brand_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Brand_ID"));

                    b.Property<int>("Brand_Name")
                        .HasColumnType("int");

                    b.HasKey("Brand_ID");

                    b.ToTable("MotocycleBrands");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.MotocycleStatus", b =>
                {
                    b.Property<int>("Satatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Satatus_ID"));

                    b.Property<int>("Status_Name")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Satatus_ID");

                    b.ToTable("MotocycleStatus");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.MotocycleType", b =>
                {
                    b.Property<int>("Type_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Type_ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Type_ID");

                    b.ToTable("MotocycleType");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Motorcycle", b =>
                {
                    b.Property<int>("Motorcycle_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Motorcycle_ID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MotocycleBrandBrand_ID")
                        .HasColumnType("int");

                    b.Property<int>("MotocycleTypeType_ID")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Rental_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<int>("User_ID1")
                        .HasColumnType("int");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Motorcycle_ID");

                    b.HasIndex("MotocycleBrandBrand_ID");

                    b.HasIndex("MotocycleTypeType_ID");

                    b.HasIndex("User_ID1");

                    b.ToTable("Motorcycles");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Payment", b =>
                {
                    b.Property<int>("Payment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payment_ID"));

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentMethodMethods_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Payment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment_Method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rental_ID")
                        .HasColumnType("int");

                    b.Property<int>("Rental_ID1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Payment_ID");

                    b.HasIndex("PaymentMethodMethods_ID");

                    b.HasIndex("Rental_ID1");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.PaymentMethod", b =>
                {
                    b.Property<int>("Methods_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Methods_ID"));

                    b.Property<int>("Method_Name")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Methods_ID");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Rental", b =>
                {
                    b.Property<int>("Rental_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rental_ID"));

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Motorcycle_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Total_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<int>("User_ID1")
                        .HasColumnType("int");

                    b.HasKey("Rental_ID");

                    b.HasIndex("User_ID1");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("Birth_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Invoice", b =>
                {
                    b.HasOne("SV20T1080053.DomainModels.MotocycleStatus", "MotocycleStatus")
                        .WithMany("Invoices")
                        .HasForeignKey("MotocycleStatusSatatus_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SV20T1080053.DomainModels.Rental", "Rental")
                        .WithMany("Invoices")
                        .HasForeignKey("Rental_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MotocycleStatus");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Motorcycle", b =>
                {
                    b.HasOne("SV20T1080053.DomainModels.MotocycleBrand", null)
                        .WithMany("Motorcycles")
                        .HasForeignKey("MotocycleBrandBrand_ID");

                    b.HasOne("SV20T1080053.DomainModels.MotocycleType", "MotocycleType")
                        .WithMany("Motorcycles")
                        .HasForeignKey("MotocycleTypeType_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SV20T1080053.DomainModels.User", "User")
                        .WithMany("Motorcycles")
                        .HasForeignKey("User_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MotocycleType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Payment", b =>
                {
                    b.HasOne("SV20T1080053.DomainModels.PaymentMethod", "PaymentMethod")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethodMethods_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SV20T1080053.DomainModels.Rental", "Rental")
                        .WithMany("Payments")
                        .HasForeignKey("Rental_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Rental", b =>
                {
                    b.HasOne("SV20T1080053.DomainModels.User", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("User_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.MotocycleBrand", b =>
                {
                    b.Navigation("Motorcycles");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.MotocycleStatus", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.MotocycleType", b =>
                {
                    b.Navigation("Motorcycles");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.PaymentMethod", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.Rental", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("SV20T1080053.DomainModels.User", b =>
                {
                    b.Navigation("Motorcycles");

                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
