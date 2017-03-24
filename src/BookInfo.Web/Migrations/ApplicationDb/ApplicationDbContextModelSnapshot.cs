﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BookInfo.Repositories;

namespace BookInfo.Web.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookInfo.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<int?>("BookId");

                    b.Property<string>("Name");

                    b.HasKey("AuthorID");

                    b.HasIndex("BookId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookInfo.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Genre");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookInfo.Models.Reader", b =>
                {
                    b.Property<int>("ReaderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityReaderId");

                    b.Property<string>("UserName");

                    b.HasKey("ReaderId");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("BookInfo.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int?>("BookId");

                    b.Property<int>("BookReaderReaderId");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewID");

                    b.HasIndex("BookId");

                    b.HasIndex("BookReaderReaderId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("BookInfo.Models.Author", b =>
                {
                    b.HasOne("BookInfo.Models.Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookInfo.Models.Review", b =>
                {
                    b.HasOne("BookInfo.Models.Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId");

                    b.HasOne("BookInfo.Models.Reader", "BookReader")
                        .WithMany()
                        .HasForeignKey("BookReaderReaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
