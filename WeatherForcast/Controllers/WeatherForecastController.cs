using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherForcast.Models;
namespace WeatherForcast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public WeatherForecastController(HttpClient httpClient, IConfiguration config)
        {
            _config = config;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline");
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> Get(string city, [FromQuery] DateOnly? startDate, [FromQuery] DateOnly? endDate, [FromQuery] string? include)
        {
            try
            {
                string date = "";
                if (startDate.HasValue && endDate.HasValue)
                {
                    // Format DateOnly to yyyy-MM-dd
                    date = $"{startDate.Value:yyyy-MM-dd}/{endDate.Value:yyyy-MM-dd}";
                }

                Console.WriteLine(date);
                var uri = $"{_httpClient.BaseAddress}/{city}/{date}?unitGroup=metric&contentType=json&key={_config["APIKey"]}&include={include}";
                Console.WriteLine(uri);

                var message = new HttpRequestMessage(HttpMethod.Get, new Uri(uri));
                var send = await _httpClient.SendAsync(message);
                if (!send.IsSuccessStatusCode) return BadRequest(new { message = "Error" });

                var response = await send.Content.ReadAsStringAsync();
                var jsonOption = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                    WriteIndented = true,
                };
                var json = JsonSerializer.Deserialize<WeatherForecastModel>(response, jsonOption);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Something went wrong", error = ex.Message });
            }
        }

    }
}
