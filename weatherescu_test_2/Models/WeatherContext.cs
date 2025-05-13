using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using weatherescu_test_2.Models;
namespace weatherescu_test_2.Models; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class WeatherContext : IdentityDbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherCondition> WeatherConditions { get; set; }
        public DbSet<Pressure> Pressures { get; set; }
        public DbSet<Precipitation> Precipitations { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(
                new City { CityID = 1, Name = "Craiova", Country = "Romania" },
                new City { CityID = 2, Name = "Bucuresti", Country = "Romania" },
                new City { CityID = 3, Name = "Braila", Country = "Romania" },
                new City { CityID = 4, Name = "Cluj-Napoca", Country = "Romania" },
                new City { CityID = 5, Name = "Iasi", Country = "Romania" }
            );

            modelBuilder.Entity<Temperature>().HasData(
           new Temperature { TemperatureID = 1, CityID = 1, Value = 6 },
           new Temperature { TemperatureID = 2, CityID = 2, Value = 10 },
           new Temperature { TemperatureID = 3, CityID = 3, Value = 8 },
           new Temperature { TemperatureID = 4, CityID = 4, Value = 5 },
           new Temperature { TemperatureID = 5, CityID = 5, Value = 7 }
            );


            modelBuilder.Entity<Humidity>().HasData(
                new Humidity { HumidityID = 1, CityID = 1, Value = 70 },
                new Humidity { HumidityID = 2, CityID = 2, Value = 80 },
                new Humidity { HumidityID = 3, CityID = 3, Value = 75 },
                new Humidity { HumidityID = 4, CityID = 4, Value = 65 },
                new Humidity { HumidityID = 5, CityID = 5, Value = 85 }
                );

            modelBuilder.Entity<Precipitation>().HasData(
                new Precipitation { PrecipitationID = 1, CityID = 1, Value = 10 },
                new Precipitation { PrecipitationID = 2, CityID = 2, Value = 20 },
                new Precipitation { PrecipitationID = 3, CityID = 3, Value = 30 },
                new Precipitation { PrecipitationID = 4, CityID = 4, Value = 40 },
                new Precipitation { PrecipitationID = 5, CityID = 5, Value = 50 }
                );

            modelBuilder.Entity<Pressure>().HasData(
                new Pressure { PressureID = 1, CityID = 1, Value = 1000 },
                new Pressure { PressureID = 2, CityID = 2, Value = 1010 },
                new Pressure { PressureID = 3, CityID = 3, Value = 1020 },
                new Pressure { PressureID = 4, CityID = 4, Value = 1030 },
                new Pressure { PressureID = 5, CityID = 5, Value = 1040 }
                );

            modelBuilder.Entity<WeatherCondition>().HasData(
                new WeatherCondition { WeatherConditionID = 1, CityID = 1, Description = "Sunny" },
                new WeatherCondition { WeatherConditionID = 2, CityID = 2, Description = "Rainy" },
                new WeatherCondition { WeatherConditionID = 3, CityID = 3, Description = "Cloudy" },
                new WeatherCondition { WeatherConditionID = 4, CityID = 4, Description = "Snowy" },
                new WeatherCondition { WeatherConditionID = 5, CityID = 5, Description = "Windy" }
                );
        }
    }
