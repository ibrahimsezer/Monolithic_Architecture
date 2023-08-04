﻿// <auto-generated />
using DataAccess.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Layer.Migrations
{
    [DbContext(typeof(DataAccess))]
    partial class DataAccessModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Layer.Entity.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cengiz Aytmatov"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sabahattin Ali"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Oğuz Atay"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Orhan Pamuk"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Yakup Kadri Karaosmanoğlu"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Reşat Nuri Güntekin"
                        });
                });

            modelBuilder.Entity("DataAccess.Layer.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Name = "Gün olur asra bedel"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Name = "Kürk mantolu madonna"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Name = "Tutunamayanlar"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Name = "Kara Kitap"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            Name = "Yaban"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 3,
                            Name = "Tehlikeli Oyunlar"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 6,
                            Name = "Çalıkuşu"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 2,
                            Name = "Kuyucaklı Yusuf"
                        });
                });

            modelBuilder.Entity("DataAccess.Layer.Entity.Book", b =>
                {
                    b.HasOne("DataAccess.Layer.Entity.Author", "Authors")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");
                });

            modelBuilder.Entity("DataAccess.Layer.Entity.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
