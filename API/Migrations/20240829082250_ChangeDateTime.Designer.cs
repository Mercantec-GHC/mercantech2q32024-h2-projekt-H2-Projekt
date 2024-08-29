﻿// <auto-generated />
using System;
using System.Collections.Generic;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20240829082250_ChangeDateTime")]
    partial class ChangeDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DomainModels.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("booking_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingId"));

                    b.Property<List<DateTime>>("BookingDates")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone[]")
                        .HasColumnName("booking_dates");

                    b.Property<string>("GuestEmail")
                        .HasColumnType("text")
                        .HasColumnName("guest_email");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("guest_name");

                    b.Property<string>("GuestPhoneNr")
                        .HasColumnType("text")
                        .HasColumnName("guest_phone_nr");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("DomainModels.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoomId"));

                    b.Property<List<DateTime>>("BookedDays")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone[]")
                        .HasColumnName("booked_days");

                    b.Property<int?>("BookingId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("RoomId");

                    b.HasIndex("BookingId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("DomainModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("text")
                        .HasColumnName("user_phone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DomainModels.Employee", b =>
                {
                    b.HasBaseType("DomainModels.User");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("DomainModels.Guest", b =>
                {
                    b.HasBaseType("DomainModels.User");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("Guest");
                });

            modelBuilder.Entity("DomainModels.Cleaning", b =>
                {
                    b.HasBaseType("DomainModels.Employee");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("Cleaning");
                });

            modelBuilder.Entity("DomainModels.Receptionist", b =>
                {
                    b.HasBaseType("DomainModels.Employee");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("Receptionist");
                });

            modelBuilder.Entity("DomainModels.Administrator", b =>
                {
                    b.HasBaseType("DomainModels.Receptionist");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("DomainModels.Booking", b =>
                {
                    b.HasOne("DomainModels.User", null)
                        .WithMany("Bookings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DomainModels.Room", b =>
                {
                    b.HasOne("DomainModels.Booking", null)
                        .WithMany("Rooms")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("DomainModels.Booking", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DomainModels.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
