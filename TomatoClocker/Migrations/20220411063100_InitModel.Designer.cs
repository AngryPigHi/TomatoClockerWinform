﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TomatoClocker;

#nullable disable

namespace TomatoClocker.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220411063100_InitModel")]
    partial class InitModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TomatoClocker.Models.DayCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_DayCount", (string)null);
                });

            modelBuilder.Entity("TomatoClocker.Models.FailedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("ContinuousTime")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayCountId")
                        .HasColumnType("int");

                    b.Property<string>("EndDateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DayCountId");

                    b.ToTable("T_FailedItems", (string)null);
                });

            modelBuilder.Entity("TomatoClocker.Models.SuccessItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("ContinuousTime")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayCountId")
                        .HasColumnType("int");

                    b.Property<string>("DoContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DayCountId");

                    b.ToTable("T_SuccessItems", (string)null);
                });

            modelBuilder.Entity("TomatoClocker.Models.FailedItem", b =>
                {
                    b.HasOne("TomatoClocker.Models.DayCount", "DayCount")
                        .WithMany("FailedItems")
                        .HasForeignKey("DayCountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayCount");
                });

            modelBuilder.Entity("TomatoClocker.Models.SuccessItem", b =>
                {
                    b.HasOne("TomatoClocker.Models.DayCount", "DayCount")
                        .WithMany("SuccessItems")
                        .HasForeignKey("DayCountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayCount");
                });

            modelBuilder.Entity("TomatoClocker.Models.DayCount", b =>
                {
                    b.Navigation("FailedItems");

                    b.Navigation("SuccessItems");
                });
#pragma warning restore 612, 618
        }
    }
}