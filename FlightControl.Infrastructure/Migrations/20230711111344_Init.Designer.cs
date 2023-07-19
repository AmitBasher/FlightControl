﻿// <auto-generated />
using System;
using FlightControl.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightControl.Infrastructure.Migrations
{
    [DbContext(typeof(FlightControlDB))]
    [Migration("20230711111344_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightControl.Domain.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Airline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArriving")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightControl.Domain.Models.FlightHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FlightsHistory");
                });

            modelBuilder.Entity("FlightControl.Domain.Models.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTerminal")
                        .HasColumnType("bit");

                    b.Property<int>("NextArrivalStageId")
                        .HasColumnType("int");

                    b.Property<int>("NextDepartureStageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaitTime_ms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 2,
                            NextDepartureStageId = 0,
                            Title = "Landing Stage A",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 3,
                            NextDepartureStageId = 0,
                            Title = "Landing Stage B",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 4,
                            NextDepartureStageId = 0,
                            Title = "Landing Stage C",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 5,
                            NextDepartureStageId = 9,
                            Title = "Runaway",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 51,
                            NextDepartureStageId = 0,
                            Title = "Ready For Terminal",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 6,
                            IsAvailable = true,
                            IsTerminal = true,
                            NextArrivalStageId = 0,
                            NextDepartureStageId = 8,
                            Title = "Terminal A",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 7,
                            IsAvailable = true,
                            IsTerminal = true,
                            NextArrivalStageId = 0,
                            NextDepartureStageId = 8,
                            Title = "Terminal B",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 8,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 0,
                            NextDepartureStageId = 4,
                            Title = "Dispatching Ready",
                            WaitTime_ms = 3000
                        },
                        new
                        {
                            Id = 9,
                            IsAvailable = false,
                            IsTerminal = false,
                            NextArrivalStageId = 0,
                            NextDepartureStageId = 0,
                            Title = "Dispatched",
                            WaitTime_ms = 3000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
