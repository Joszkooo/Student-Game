﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_game.Server.Data;

#nullable disable

namespace Student_game.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student_game.Server.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Student_game.Server.Models.Armour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Armours");
                });

            modelBuilder.Entity("Student_game.Server.Models.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArmourId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("AttackPoints")
                        .HasColumnType("int");

                    b.Property<int>("DefensePoints")
                        .HasColumnType("int");

                    b.Property<int>("HealthPoints")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("LuckPoints")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmourId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("Student_game.Server.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoostAmount")
                        .HasColumnType("int");

                    b.Property<int>("BoostType")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Student_game.Server.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Defeats")
                        .HasColumnType("int");

                    b.Property<int>("Fights")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("AttackPoints")
                        .HasColumnType("int");

                    b.Property<int>("DefensePoints")
                        .HasColumnType("int");

                    b.Property<int>("Energy")
                        .HasColumnType("int");

                    b.Property<int?>("ArmourId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("HealthPoints")
                        .HasColumnType("int");

                    b.Property<int>("IntelligencePoints")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("LevelPoints")
                        .HasColumnType("int");

                    b.Property<int>("LuckPoints")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealth")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("ArmourId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student_Armour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmourId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmourId");

                    b.HasIndex("StudentId");

                    b.ToTable("Student_Armors");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student_Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("StudentId");

                    b.ToTable("Student_Foods");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student_Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Student_Weapons");
                });

            modelBuilder.Entity("Student_game.Server.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("HitChance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Student_game.Server.Models.Enemy", b =>
                {
                    b.HasOne("Student_game.Server.Models.Armour", "Armour")
                        .WithMany("Enemies")
                        .HasForeignKey("ArmourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_game.Server.Models.Weapon", "Weapon")
                        .WithMany("Enemies")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armour");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Student_game.Server.Models.Stat", b =>
                {
                    b.HasOne("Student_game.Server.Models.Student", "Student")
                        .WithOne("Stats")
                        .HasForeignKey("Student_game.Server.Models.Stat", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student", b =>
                {
                    b.HasOne("Student_game.Server.Models.Account", "Account")
                        .WithOne("Student")
                        .HasForeignKey("Student_game.Server.Models.Student", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_game.Server.Models.Armour", "Armour")
                        .WithMany()
                        .HasForeignKey("ArmourId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Student_game.Server.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("Armour");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student_Armour", b =>
                {
                    b.HasOne("Student_game.Server.Models.Armour", "Armour")
                        .WithMany("Student_Armours")
                        .HasForeignKey("ArmourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Student_game.Server.Models.Student", "Student")
                        .WithMany("Student_Armours")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Armour");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student_Food", b =>
                {
                    b.HasOne("Student_game.Server.Models.Food", "Food")
                        .WithMany("Student_Foods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_game.Server.Models.Student", "Student")
                        .WithMany("Student_Foods")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student_Weapon", b =>
                {
                    b.HasOne("Student_game.Server.Models.Student", "Student")
                        .WithMany("Student_Weapons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Student_game.Server.Models.Weapon", "Weapon")
                        .WithMany("Student_Weapons")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Student_game.Server.Models.Account", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student_game.Server.Models.Armour", b =>
                {
                    b.Navigation("Enemies");

                    b.Navigation("Student_Armours");
                });

            modelBuilder.Entity("Student_game.Server.Models.Food", b =>
                {
                    b.Navigation("Student_Foods");
                });

            modelBuilder.Entity("Student_game.Server.Models.Student", b =>
                {
                    b.Navigation("Stats");

                    b.Navigation("Student_Armours");

                    b.Navigation("Student_Foods");

                    b.Navigation("Student_Weapons");
                });

            modelBuilder.Entity("Student_game.Server.Models.Weapon", b =>
                {
                    b.Navigation("Enemies");

                    b.Navigation("Student_Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
