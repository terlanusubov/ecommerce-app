﻿// <auto-generated />
using System;
using EcommerceApp.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceApp.MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EcommerceApp.MVC.Models.Avenue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RegionId" }, "Avenues_fk0");

                    b.ToTable("Avenues");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("BrandStatusId")
                        .HasColumnType("int");

                    b.Property<int>("Created")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("Updated")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int?>("Updated")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("HasStock")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MainCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ProductStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ShortDesc")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("StockCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CategoryId" }, "Products_fk0");

                    b.HasIndex(new[] { "BrandId" }, "Products_fk1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "ProductColors_fk0");

                    b.HasIndex(new[] { "ColorId" }, "ProductColors_fk1");

                    b.ToTable("ProductColors");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "ProductPhotos_fk0");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductReviewStatusId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "ProductReviews_fk0");

                    b.HasIndex(new[] { "UserId" }, "ProductReviews_fk1");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "ProductSizes_fk0");

                    b.HasIndex(new[] { "SizeId" }, "ProductSizes_fk1");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CityId" }, "Regions_fk0");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Created")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int?>("Updated")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BottomImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TopImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varbinary(32)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserRoleId" }, "Users_fk0");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("AvenueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsMain")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserAddresses_fk0");

                    b.HasIndex(new[] { "AvenueId" }, "UserAddresses_fk1");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Avenue", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Region", "Region")
                        .WithMany("Avenues")
                        .HasForeignKey("RegionId")
                        .IsRequired()
                        .HasConstraintName("Avenues_fk0");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Product", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .IsRequired()
                        .HasConstraintName("Products_fk1");

                    b.HasOne("EcommerceApp.MVC.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("Products_fk0");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductColor", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Color", "Color")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorId")
                        .IsRequired()
                        .HasConstraintName("ProductColors_fk1");

                    b.HasOne("EcommerceApp.MVC.Models.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductColors_fk0");

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductPhoto", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductPhotos_fk0");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductReview", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductReviews_fk0");

                    b.HasOne("EcommerceApp.MVC.Models.User", "User")
                        .WithMany("ProductReviews")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("ProductReviews_fk1");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.ProductSize", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("ProductSizes_fk0");

                    b.HasOne("EcommerceApp.MVC.Models.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizeId")
                        .IsRequired()
                        .HasConstraintName("ProductSizes_fk1");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Region", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.City", "City")
                        .WithMany("Regions")
                        .HasForeignKey("CityId")
                        .IsRequired()
                        .HasConstraintName("Regions_fk0");

                    b.Navigation("City");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Slider", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.User", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .IsRequired()
                        .HasConstraintName("Users_fk0");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.UserAddress", b =>
                {
                    b.HasOne("EcommerceApp.MVC.Models.Avenue", "Avenue")
                        .WithMany("UserAddresses")
                        .HasForeignKey("AvenueId")
                        .IsRequired()
                        .HasConstraintName("UserAddresses_fk1");

                    b.HasOne("EcommerceApp.MVC.Models.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("UserAddresses_fk0");

                    b.Navigation("Avenue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Avenue", b =>
                {
                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.City", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Color", b =>
                {
                    b.Navigation("ProductColors");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Product", b =>
                {
                    b.Navigation("ProductColors");

                    b.Navigation("ProductPhotos");

                    b.Navigation("ProductReviews");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Region", b =>
                {
                    b.Navigation("Avenues");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.Size", b =>
                {
                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.User", b =>
                {
                    b.Navigation("ProductReviews");

                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("EcommerceApp.MVC.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
