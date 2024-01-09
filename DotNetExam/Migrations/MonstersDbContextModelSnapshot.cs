﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessLogicDataBase.Migrations
{
    [DbContext(typeof(MonstersDbContext))]
    partial class MonstersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("int");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("int");

                    b.Property<string>("Damage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 12,
                            AttackModifier = 10,
                            AttackPerRound = 2,
                            Damage = "1d6",
                            DamageModifier = 3,
                            HitPoints = 50,
                            Name = "Raven"
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 9,
                            AttackModifier = 10,
                            AttackPerRound = 1,
                            Damage = "2d8",
                            DamageModifier = 1,
                            HitPoints = 10,
                            Name = "AwakenedShrub"
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 18,
                            AttackModifier = 10,
                            AttackPerRound = 1,
                            Damage = "27d20",
                            DamageModifier = 1,
                            HitPoints = 472,
                            Name = "Kraken"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
