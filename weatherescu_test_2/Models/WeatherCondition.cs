namespace weatherescu_test_2.Models
{
    public class WeatherCondition
    {
        public int WeatherConditionID { get; set; }
        public int CityID { get; set; }
        public string Description { get; set; } = string.Empty;
       

        public City? City { get; set; }
    }

}
