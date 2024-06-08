﻿// <auto-generated />
using System;
using Final_project_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_project_2.Migrations
{
    [DbContext(typeof(Tourism))]
    [Migration("20240608053508_new_fk")]
    partial class new_fk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Final_project_2.Models.Active_Tours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("End_time")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Start_time")
                        .HasColumnType("date");

                    b.Property<int>("fk_Tour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fk_Tour");

                    b.ToTable("Active_Tours");
                });

            modelBuilder.Entity("Final_project_2.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Is_Actived")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fk_Person")
                        .HasColumnType("int");

                    b.Property<int>("fk_Tour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fk_Person");

                    b.HasIndex("fk_Tour");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Final_project_2.Models.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fk_Tour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fk_Tour");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Final_project_2.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City_And_Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Favorit_food")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Favorit_sport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Actived")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Joined_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telegram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Final_project_2.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Is_Actived")
                        .HasColumnType("bit");

                    b.Property<int>("Reserved_Count")
                        .HasColumnType("int");

                    b.Property<int>("fk_Active_Tour")
                        .HasColumnType("int");

                    b.Property<int>("fk_Person")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fk_Active_Tour");

                    b.HasIndex("fk_Person");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Final_project_2.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_bg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Acive")
                        .HasColumnType("bit");

                    b.Property<string>("Price_per_person")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quality_level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status_limit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tour_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Touring_area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("Final_project_2.Models.Active_Tours", b =>
                {
                    b.HasOne("Final_project_2.Models.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("fk_Tour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Final_project_2.Models.Comments", b =>
                {
                    b.HasOne("Final_project_2.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("fk_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_project_2.Models.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("fk_Tour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Final_project_2.Models.Images", b =>
                {
                    b.HasOne("Final_project_2.Models.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("fk_Tour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Final_project_2.Models.Reservation", b =>
                {
                    b.HasOne("Final_project_2.Models.Active_Tours", "Active_Tour")
                        .WithMany()
                        .HasForeignKey("fk_Active_Tour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_project_2.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("fk_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Active_Tour");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
