﻿// <auto-generated />
using System;
using ArenaQuest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArenaQuest.Migrations
{
    [DbContext(typeof(ArenaQuestContext))]
    partial class ArenaQuestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ArenaQuest.Models.Gamelog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Arena")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("League")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Team1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Team2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gamelog");
                });
#pragma warning restore 612, 618
        }
    }
}