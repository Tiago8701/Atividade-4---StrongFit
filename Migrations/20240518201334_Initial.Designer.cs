﻿// <auto-generated />
using System;
using Atividade3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Atividade3.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240518201334_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Atividade3.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoID"));

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalID")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoID");

                    b.HasIndex("PersonalID");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Atividade3.Models.Exercicio", b =>
                {
                    b.Property<int>("ExercicioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExercicioID"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExercicioID");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("Atividade3.Models.Personal", b =>
                {
                    b.Property<int>("PersonalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalID"));

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalID");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("Atividade3.Models.Treino", b =>
                {
                    b.Property<int>("TreinoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreinoID"));

                    b.Property<int>("AlunoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonalID")
                        .HasColumnType("int");

                    b.HasKey("TreinoID");

                    b.HasIndex("AlunoID");

                    b.HasIndex("PersonalID");

                    b.ToTable("Treinos");
                });

            modelBuilder.Entity("Atividade3.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("ExercicioTreino", b =>
                {
                    b.Property<int>("ExerciciosExercicioID")
                        .HasColumnType("int");

                    b.Property<int>("TreinosTreinoID")
                        .HasColumnType("int");

                    b.HasKey("ExerciciosExercicioID", "TreinosTreinoID");

                    b.HasIndex("TreinosTreinoID");

                    b.ToTable("ExercicioTreino", (string)null);
                });

            modelBuilder.Entity("Atividade3.Models.Aluno", b =>
                {
                    b.HasOne("Atividade3.Models.Personal", "Personals")
                        .WithMany("Alunos")
                        .HasForeignKey("PersonalID");

                    b.Navigation("Personals");
                });

            modelBuilder.Entity("Atividade3.Models.Treino", b =>
                {
                    b.HasOne("Atividade3.Models.Aluno", "Aluno")
                        .WithMany("Treinos")
                        .HasForeignKey("AlunoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atividade3.Models.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("ExercicioTreino", b =>
                {
                    b.HasOne("Atividade3.Models.Exercicio", null)
                        .WithMany()
                        .HasForeignKey("ExerciciosExercicioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atividade3.Models.Treino", null)
                        .WithMany()
                        .HasForeignKey("TreinosTreinoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Atividade3.Models.Aluno", b =>
                {
                    b.Navigation("Treinos");
                });

            modelBuilder.Entity("Atividade3.Models.Personal", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
