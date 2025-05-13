namespace weatherescu_test_2.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public Temperature? Temperature { get; set; }
        public Humidity? Humidity { get; set; }
        public Precipitation? Precipitation { get; set; }
        public Pressure? Pressure { get; set; }
        public WeatherCondition? WeatherCondition { get; set; }
    }
}
