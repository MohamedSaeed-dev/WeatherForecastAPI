using System.Text.Json.Serialization;

namespace WeatherForcast.Models
{
    public class Current
    {
        [JsonPropertyName("datetime")]
        public TimeSpan Time { get; set; }
        [JsonPropertyName("feelslike")]
        public double Temp { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public TimeSpan Sunrise { get; set; }
        public TimeSpan Sunset { get; set; }
        public string Conditions { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;

    }
}
