namespace WeatherForcast.Models
{
    public class WeatherForecastModel
    {
        public string ResolvedAddress { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Current? CurrentConditions { get; set; }
        public List<Days>? Days { get; set; }

    }
}
