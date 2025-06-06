﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using weatherescu_test_2.Models;

#nullable disable

namespace weatherescu_test_2.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20250326205413_CreateWeatherTables")]
    partial class CreateWeatherTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("weatherescu_test_2.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            Country = "Romania",
                            Name = "Craiova"
                        },
                        new
                        {
                            CityID = 2,
                            Country = "Romania",
                            Name = "Bucuresti"
                        },
                        new
                        {
                            CityID = 3,
                            Country = "Romania",
                            Name = "Braila"
                        },
                        new
                        {
                            CityID = 4,
                            Country = "Romania",
                            Name = "Cluj-Napoca"
                        },
                        new
                        {
                            CityID = 5,
                            Country = "Romania",
                            Name = "Iasi"
                        });
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Humidity", b =>
                {
                    b.Property<int>("HumidityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HumidityID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("HumidityID");

                    b.HasIndex("CityID")
                        .IsUnique();

                    b.ToTable("Humidities");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Precipitation", b =>
                {
                    b.Property<int>("PrecipitationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrecipitationID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("PrecipitationID");

                    b.HasIndex("CityID")
                        .IsUnique();

                    b.ToTable("Precipitations");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Pressure", b =>
                {
                    b.Property<int>("PressureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PressureID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("PressureID");

                    b.HasIndex("CityID")
                        .IsUnique();

                    b.ToTable("Pressures");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Temperature", b =>
                {
                    b.Property<int>("TemperatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemperatureID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("TemperatureID");

                    b.HasIndex("CityID")
                        .IsUnique();

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.WeatherCondition", b =>
                {
                    b.Property<int>("WeatherConditionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeatherConditionID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeatherConditionID");

                    b.HasIndex("CityID")
                        .IsUnique();

                    b.ToTable("WeatherConditions");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Humidity", b =>
                {
                    b.HasOne("weatherescu_test_2.Models.City", "City")
                        .WithOne("Humidity")
                        .HasForeignKey("weatherescu_test_2.Models.Humidity", "CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Precipitation", b =>
                {
                    b.HasOne("weatherescu_test_2.Models.City", "City")
                        .WithOne("Precipitation")
                        .HasForeignKey("weatherescu_test_2.Models.Precipitation", "CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Pressure", b =>
                {
                    b.HasOne("weatherescu_test_2.Models.City", "City")
                        .WithOne("Pressure")
                        .HasForeignKey("weatherescu_test_2.Models.Pressure", "CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.Temperature", b =>
                {
                    b.HasOne("weatherescu_test_2.Models.City", "City")
                        .WithOne("Temperature")
                        .HasForeignKey("weatherescu_test_2.Models.Temperature", "CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.WeatherCondition", b =>
                {
                    b.HasOne("weatherescu_test_2.Models.City", "City")
                        .WithOne("WeatherCondition")
                        .HasForeignKey("weatherescu_test_2.Models.WeatherCondition", "CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("weatherescu_test_2.Models.City", b =>
                {
                    b.Navigation("Humidity");

                    b.Navigation("Precipitation");

                    b.Navigation("Pressure");

                    b.Navigation("Temperature");

                    b.Navigation("WeatherCondition");
                });
#pragma warning restore 612, 618
        }
    }
}
