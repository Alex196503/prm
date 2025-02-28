﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectMediiBun.Data;

#nullable disable

namespace ProiectMediiBun.Migrations
{
    [DbContext(typeof(ProiectMediiBunContext))]
    [Migration("20241216192833_asfgad")]
    partial class asfgad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProiectMediiBun.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MembershipID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MembershipID");

                    b.HasIndex("TrainerID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Membership", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("Data_Expirare")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_Start")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("MembershipName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Membership");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Data_Rezervarii")
                        .HasColumnType("datetime2");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<int?>("TerenID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.HasIndex("TerenID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Data_Review")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TrainerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TrainerID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Teren", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Dimensiune")
                        .HasColumnType("float");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Teren");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Trainer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specializare")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Member", b =>
                {
                    b.HasOne("ProiectMediiBun.Models.Membership", "Membership")
                        .WithMany("Members")
                        .HasForeignKey("MembershipID");

                    b.HasOne("ProiectMediiBun.Models.Trainer", "Trainer")
                        .WithMany("Members")
                        .HasForeignKey("TrainerID");

                    b.Navigation("Membership");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Reservation", b =>
                {
                    b.HasOne("ProiectMediiBun.Models.Member", "Member")
                        .WithMany("Reservations")
                        .HasForeignKey("MemberID");

                    b.HasOne("ProiectMediiBun.Models.Teren", "Teren")
                        .WithMany("Reservations")
                        .HasForeignKey("TerenID");

                    b.Navigation("Member");

                    b.Navigation("Teren");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Review", b =>
                {
                    b.HasOne("ProiectMediiBun.Models.Trainer", "Trainer")
                        .WithMany("Reviews")
                        .HasForeignKey("TrainerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Member", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Membership", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Teren", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ProiectMediiBun.Models.Trainer", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
