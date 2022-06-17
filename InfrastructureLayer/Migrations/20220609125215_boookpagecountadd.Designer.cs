﻿// <auto-generated />
using System;
using InfrastructureLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220609125215_boookpagecountadd")]
    partial class boookpagecountadd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<int>("ReadBooksBookId")
                        .HasColumnType("int");

                    b.Property<int>("ReadersId")
                        .HasColumnType("int");

                    b.HasKey("ReadBooksBookId", "ReadersId");

                    b.HasIndex("ReadersId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("BookType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LibraryLibId")
                        .HasColumnType("int");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int?>("SimilaryBookId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("LibraryLibId");

                    b.HasIndex("SimilaryBookId")
                        .IsUnique()
                        .HasFilter("[SimilaryBookId] IS NOT NULL");

                    b.ToTable("Books");

                    b.HasDiscriminator<string>("BookType").HasValue("Book");
                });

            modelBuilder.Entity("Entities.Library", b =>
                {
                    b.Property<int>("LibId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibId"), 1L, 1);

                    b.Property<string>("LibName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.GraphicBook", b =>
                {
                    b.HasBaseType("Entities.Book");

                    b.Property<string>("MainColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Books");

                    b.HasDiscriminator().HasValue("Graphic");
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("ReadBooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("ReadersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Book", b =>
                {
                    b.HasOne("Entities.Library", null)
                        .WithMany("LibBooks")
                        .HasForeignKey("LibraryLibId");

                    b.HasOne("Entities.Book", "SimilaryBook")
                        .WithOne()
                        .HasForeignKey("Entities.Book", "SimilaryBookId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SimilaryBook");
                });

            modelBuilder.Entity("Entities.Library", b =>
                {
                    b.Navigation("LibBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
