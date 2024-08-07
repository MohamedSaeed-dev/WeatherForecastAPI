using System.Text.Json.Serialization;

namespace WeatherForcast.Models
{
    public class Days
    {
        public DateOnly Datetime { get; set; }
        [JsonPropertyName("feelslikemax")]
        public double MaxTemp { get; set; }
        [JsonPropertyName("feelslikemin")]
        public double MinTemp { get; set; }
        [JsonPropertyName("feelslike")]
        public double Temp { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public TimeSpan Sunrise { get; set; }
        public TimeSpan Sunset { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Conditions { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
