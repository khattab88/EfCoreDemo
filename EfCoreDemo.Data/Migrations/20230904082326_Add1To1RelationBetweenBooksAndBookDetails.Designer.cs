﻿// <auto-generated />
using System;
using EfCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreDemo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230904082326_Add1To1RelationBetweenBooksAndBookDetails")]
    partial class Add1To1RelationBetweenBooksAndBookDetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreDemo.Model.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EfCoreDemo.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ISBN = "77VG",
                            Price = 99.5m,
                            Title = "Conan The Barbarian"
                        },
                        new
                        {
                            Id = 2,
                            ISBN = "43TY",
                            Price = 50.25m,
                            Title = "Beautiful Worl"
                        },
                        new
                        {
                            Id = 3,
                            ISBN = "93BH",
                            Price = 17.15m,
                            Title = "Its Complicated"
                        });
                });

            modelBuilder.Entity("EfCoreDemo.Model.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfChapters")
                        .HasColumnType("int");

                    b.Property<int>("NumOfPages")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("EfCoreDemo.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EfCoreDemo.Model.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("EfCoreDemo.Model.SubCategory", b =>
                {
                    b.Property<int>("SubCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategory_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubCategory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EfCoreDemo.Model.BookDetail", b =>
                {
                    b.HasOne("EfCoreDemo.Model.Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("EfCoreDemo.Model.BookDetail", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EfCoreDemo.Model.Book", b =>
                {
                    b.Navigation("BookDetail");
                });
#pragma warning restore 612, 618
        }
    }
}