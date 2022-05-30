﻿// <auto-generated />
using System;
using ChallengeAlkemy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChallengeAlkemy.Migrations
{
    [DbContext(typeof(DisneyDbContext))]
    [Migration("20220529225552_v9")]
    partial class v9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChallengeAlkemy.Entities.Genero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("generos");
                });

            modelBuilder.Entity("ChallengeAlkemy.Entities.Pelicula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clasificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("generoId")
                        .HasColumnType("int");

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("generoId");

                    b.ToTable("peliculas");
                });

            modelBuilder.Entity("ChallengeAlkemy.Entities.Personaje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("peliculaId")
                        .HasColumnType("int");

                    b.Property<float>("peso")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("peliculaId");

                    b.ToTable("personajes");
                });

            modelBuilder.Entity("ChallengeAlkemy.Entities.Pelicula", b =>
                {
                    b.HasOne("ChallengeAlkemy.Entities.Genero", null)
                        .WithMany("Peliculas")
                        .HasForeignKey("generoId");
                });

            modelBuilder.Entity("ChallengeAlkemy.Entities.Personaje", b =>
                {
                    b.HasOne("ChallengeAlkemy.Entities.Pelicula", null)
                        .WithMany("Personajes")
                        .HasForeignKey("peliculaId");
                });

            modelBuilder.Entity("ChallengeAlkemy.Entities.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("ChallengeAlkemy.Entities.Pelicula", b =>
                {
                    b.Navigation("Personajes");
                });
#pragma warning restore 612, 618
        }
    }
}
