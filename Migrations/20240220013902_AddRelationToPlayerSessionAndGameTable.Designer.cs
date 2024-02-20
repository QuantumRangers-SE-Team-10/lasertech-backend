﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using lasertech_backend.Model;

#nullable disable

namespace lasertech_backend.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20240220013902_AddRelationToPlayerSessionAndGameTable")]
    partial class AddRelationToPlayerSessionAndGameTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("lasertech_backend.Model.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GameID"));

                    b.Property<int>("BlueScore")
                        .HasColumnType("integer");

                    b.Property<int>("RedScore")
                        .HasColumnType("integer");

                    b.HasKey("GameID");

                    b.ToTable("games");
                });

            modelBuilder.Entity("lasertech_backend.Model.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlayerID"));

                    b.Property<string>("Codename")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PlayerID");

                    b.ToTable("players");
                });

            modelBuilder.Entity("lasertech_backend.Model.PlayerSession", b =>
                {
                    b.Property<int>("PlayerSessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlayerSessionID"));

                    b.Property<int>("EquipmentID")
                        .HasColumnType("integer");

                    b.Property<int>("GameID")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerID")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerScore")
                        .HasColumnType("integer");

                    b.Property<int>("Team")
                        .HasColumnType("integer");

                    b.HasKey("PlayerSessionID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlayerID");

                    b.ToTable("playerSessions");
                });

            modelBuilder.Entity("lasertech_backend.Model.PlayerSession", b =>
                {
                    b.HasOne("lasertech_backend.Model.Game", "Game")
                        .WithMany("PlayerSessions")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lasertech_backend.Model.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("lasertech_backend.Model.Game", b =>
                {
                    b.Navigation("PlayerSessions");
                });
#pragma warning restore 612, 618
        }
    }
}