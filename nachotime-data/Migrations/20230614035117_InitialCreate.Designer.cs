﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using nachotime_data;

#nullable disable

namespace nachotime_data.Migrations
{
    [DbContext(typeof(NachotimeDbContext))]
    [Migration("20230614035117_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("nachotime_data.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaybackAudioUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("nachotime_data.Models.Expression", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CardId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Definition")
                        .HasColumnType("text");

                    b.Property<bool>("IsKnown")
                        .HasColumnType("boolean");

                    b.Property<string>("Translation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("Expressions");
                });

            modelBuilder.Entity("nachotime_data.Models.Expression", b =>
                {
                    b.HasOne("nachotime_data.Models.Card", null)
                        .WithMany("Expressions")
                        .HasForeignKey("CardId");
                });

            modelBuilder.Entity("nachotime_data.Models.Card", b =>
                {
                    b.Navigation("Expressions");
                });
#pragma warning restore 612, 618
        }
    }
}
