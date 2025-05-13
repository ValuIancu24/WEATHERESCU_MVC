namespace weatherescu_test_2.Models
{
    public class Humidity
    {
        public int HumidityID { get; set; }
        public int CityID { get; set; }
        public int Value { get; set; }
        

        public City? City { get; set; }
    }

}
