﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

namespace WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210121135938_newuser")]
    partial class newuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApp.Models.Aturan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("KriteriaId")
                        .HasColumnType("int");

                    b.Property<string>("NamaAturan")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KriteriaId");

                    b.ToTable("Aturans");
                });

            modelBuilder.Entity("WebApp.Models.HasilKeuntungan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Hasil")
                        .HasColumnType("double");

                    b.Property<int>("VariableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VariableId");

                    b.ToTable("Hasils");
                });

            modelBuilder.Entity("WebApp.Models.JenisKayu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("KriteriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KriteriaId");

                    b.ToTable("JenisKayu");
                });

            modelBuilder.Entity("WebApp.Models.Kriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("NamaKriteria")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kriteria");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApp.Models.Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("NamaVariable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Variables");
                });

            modelBuilder.Entity("WebApp.Models.Aturan", b =>
                {
                    b.HasOne("WebApp.Models.Kriteria", null)
                        .WithMany("Aturan")
                        .HasForeignKey("KriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.HasilKeuntungan", b =>
                {
                    b.HasOne("WebApp.Models.Variable", null)
                        .WithMany("HasilKeuntungan")
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.JenisKayu", b =>
                {
                    b.HasOne("WebApp.Models.Kriteria", null)
                        .WithMany("JenisKayu")
                        .HasForeignKey("KriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
