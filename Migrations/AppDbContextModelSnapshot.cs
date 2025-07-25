﻿// <auto-generated />
using System;
using Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.Entity.Infracoes", b =>
                {
                    b.Property<Guid>("infracaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MotoristaId")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("entradaInfracao")
                        .HasColumnType("date");

                    b.Property<bool>("grandeMonta")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("multa")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("pequenaMonta")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("reclamacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("saidaInfracao")
                        .HasColumnType("date");

                    b.Property<bool>("velocidade")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("infracaoId");

                    b.HasIndex("MotoristaId");

                    b.ToTable("infracoes");
                });

            modelBuilder.Entity("Api.Models.Entity.Jornada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("JornadaData")
                        .HasColumnType("date");

                    b.Property<string>("JornadaLocalidade")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("Km")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("MotoristaID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaID");

                    b.ToTable("Jornada");
                });

            modelBuilder.Entity("Api.Models.Entity.Motorista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateOnly>("admissao")
                        .HasColumnType("date");

                    b.Property<string>("celularId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("perfilAcesso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("Api.Models.Entity.Infracoes", b =>
                {
                    b.HasOne("Api.Models.Entity.Motorista", "Motorista")
                        .WithMany("Infracoes")
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("Api.Models.Entity.Jornada", b =>
                {
                    b.HasOne("Api.Models.Entity.Motorista", "Motorista")
                        .WithMany("Jornadas")
                        .HasForeignKey("MotoristaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("Api.Models.Entity.Motorista", b =>
                {
                    b.Navigation("Infracoes");

                    b.Navigation("Jornadas");
                });
#pragma warning restore 612, 618
        }
    }
}
