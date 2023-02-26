﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using desafio1_KriaTecnologia.DataBase;

namespace desafio1_KriaTecnologia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230224232551_fixedPrimitiveAttribute")]
    partial class fixedPrimitiveAttribute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("desafio1_KriaTecnologia.Models.DonoRepositorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomeDonoRepositorio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_DonoRepositorio");
                });

            modelBuilder.Entity("desafio1_KriaTecnologia.Models.Linguagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomeLinguagens")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_linguagens");
                });

            modelBuilder.Entity("desafio1_KriaTecnologia.Models.Repositorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataUltimaAtt")
                        .HasColumnType("datetime2");

                    b.Property<int>("idDonoRepositorio")
                        .HasColumnType("int");

                    b.Property<int>("idLinguagem")
                        .HasColumnType("int");

                    b.Property<string>("nomeRepositorio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("idDonoRepositorio");

                    b.HasIndex("idLinguagem");

                    b.ToTable("tb_Repositorios");
                });

            modelBuilder.Entity("desafio1_KriaTecnologia.Models.Repositorio", b =>
                {
                    b.HasOne("desafio1_KriaTecnologia.Models.DonoRepositorio", "DonoRepositorio")
                        .WithMany()
                        .HasForeignKey("idDonoRepositorio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("desafio1_KriaTecnologia.Models.Linguagens", "Linguagens")
                        .WithMany()
                        .HasForeignKey("idLinguagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonoRepositorio");

                    b.Navigation("Linguagens");
                });
#pragma warning restore 612, 618
        }
    }
}
