﻿// <auto-generated />
using System;
using Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250305152656_camposenha")]
    partial class camposenha
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.Jornada", b =>
                {
                    b.Property<Guid>("QuilometragemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("JornadaData")
                        .HasColumnType("date");

                    b.Property<DateTime>("JornadaHora")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Km")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("MotoristaID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("QuilometragemId");

                    b.HasIndex("MotoristaID");

                    b.ToTable("Jornada");
                });

            modelBuilder.Entity("Api.Models.Motorista", b =>
                {
                    b.Property<Guid>("MotoristaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("MotoristaID");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("Api.Models.Jornada", b =>
                {
                    b.HasOne("Api.Models.Motorista", "Motorista")
                        .WithMany("Jornadas")
                        .HasForeignKey("MotoristaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("Api.Models.Motorista", b =>
                {
                    b.Navigation("Jornadas");
                });
#pragma warning restore 612, 618
        }
    }
}
