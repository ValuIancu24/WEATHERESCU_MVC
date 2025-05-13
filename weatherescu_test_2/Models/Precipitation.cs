namespace weatherescu_test_2.Models
{
    public class Precipitation
    {
        public int PrecipitationID { get; set; }
        public int CityID { get; set; }
        public int Value { get; set; }

       

        public City? City { get; set; }
    }

}
