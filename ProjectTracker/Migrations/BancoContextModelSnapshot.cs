﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTracker.Data;

#nullable disable

namespace ProjectTracker.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectTracker.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ProjectTracker.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AreaTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AtvItv")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Lotes")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasMaxLength(2)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ProjectTracker.Models.LogArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<long?>("TempoDecorrido")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("LogAreas");
                });

            modelBuilder.Entity("ProjectTracker.Models.LogEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<long?>("TempoDecorrido")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("LogEmpresas");
                });

            modelBuilder.Entity("ProjectTracker.Models.LogProcesso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProcessoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<long?>("TempoDecorrido")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdProcessoUsuario");

                    b.ToTable("LogProcessos");
                });

            modelBuilder.Entity("ProjectTracker.Models.Processo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("ProjectTracker.Models.ProcessoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtvItv")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicioCronometro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataMovimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<int>("IdProcesso")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<long?>("TempoDecorrido")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.HasIndex("IdProcesso");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ProcessosUsuario");
                });

            modelBuilder.Entity("ProjectTracker.Models.UsrArea", b =>
                {
                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCad")
                        .HasColumnType("datetime2");

                    b.HasKey("IdArea", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsrAreas");
                });

            modelBuilder.Entity("ProjectTracker.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("Tipo")
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProjectTracker.Models.LogArea", b =>
                {
                    b.HasOne("ProjectTracker.Models.Area", "Area")
                        .WithMany("LogAreas")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTracker.Models.Empresa", "Empresa")
                        .WithMany("LogAreas")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ProjectTracker.Models.LogEmpresa", b =>
                {
                    b.HasOne("ProjectTracker.Models.Empresa", "Empresa")
                        .WithMany("LogEmpresas")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ProjectTracker.Models.LogProcesso", b =>
                {
                    b.HasOne("ProjectTracker.Models.ProcessoUsuario", "ProcessoUsuario")
                        .WithMany("LogsProcessos")
                        .HasForeignKey("IdProcessoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessoUsuario");
                });

            modelBuilder.Entity("ProjectTracker.Models.Processo", b =>
                {
                    b.HasOne("ProjectTracker.Models.Area", "Area")
                        .WithMany("Processos")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("ProjectTracker.Models.ProcessoUsuario", b =>
                {
                    b.HasOne("ProjectTracker.Models.Empresa", "Empresa")
                        .WithMany("ProcessosUsuario")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTracker.Models.Processo", "Processo")
                        .WithMany("ProcessosUsuario")
                        .HasForeignKey("IdProcesso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTracker.Models.Usuario", "Usuario")
                        .WithMany("ProcessosUsuario")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Processo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjectTracker.Models.UsrArea", b =>
                {
                    b.HasOne("ProjectTracker.Models.Area", "Area")
                        .WithMany("UsrAreas")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTracker.Models.Usuario", "Usuario")
                        .WithMany("UsrAreas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjectTracker.Models.Area", b =>
                {
                    b.Navigation("LogAreas");

                    b.Navigation("Processos");

                    b.Navigation("UsrAreas");
                });

            modelBuilder.Entity("ProjectTracker.Models.Empresa", b =>
                {
                    b.Navigation("LogAreas");

                    b.Navigation("LogEmpresas");

                    b.Navigation("ProcessosUsuario");
                });

            modelBuilder.Entity("ProjectTracker.Models.Processo", b =>
                {
                    b.Navigation("ProcessosUsuario");
                });

            modelBuilder.Entity("ProjectTracker.Models.ProcessoUsuario", b =>
                {
                    b.Navigation("LogsProcessos");
                });

            modelBuilder.Entity("ProjectTracker.Models.Usuario", b =>
                {
                    b.Navigation("ProcessosUsuario");

                    b.Navigation("UsrAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
