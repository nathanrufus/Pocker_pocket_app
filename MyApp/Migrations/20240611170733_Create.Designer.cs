﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokerPocket.Data;

#nullable disable

namespace MyApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240611170733_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("PokerPocket.Models.CardModel", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerModelPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Suit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CardId");

                    b.HasIndex("PlayerModelPlayerId");

                    b.ToTable("CardModel");
                });

            modelBuilder.Entity("PokerPocket.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("PokerPocket.Models.GameModel", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            Name = "HOLD EM"
                        },
                        new
                        {
                            GameId = 2,
                            Name = "OMAHA"
                        },
                        new
                        {
                            GameId = 3,
                            Name = "TOURNAMENT"
                        },
                        new
                        {
                            GameId = 4,
                            Name = "FREE ROLL"
                        });
                });

            modelBuilder.Entity("PokerPocket.Models.PlayerModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameModelGameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.HasIndex("GameModelGameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PokerPocket.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PokerPocket.Models.CardModel", b =>
                {
                    b.HasOne("PokerPocket.Models.PlayerModel", null)
                        .WithMany("Cards")
                        .HasForeignKey("PlayerModelPlayerId");
                });

            modelBuilder.Entity("PokerPocket.Models.PlayerModel", b =>
                {
                    b.HasOne("PokerPocket.Models.GameModel", null)
                        .WithMany("Players")
                        .HasForeignKey("GameModelGameId");
                });

            modelBuilder.Entity("PokerPocket.Models.GameModel", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("PokerPocket.Models.PlayerModel", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
