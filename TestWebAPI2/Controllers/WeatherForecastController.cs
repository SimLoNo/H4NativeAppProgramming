using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace TestWebAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            System.Drawing.Image img1 = new Bitmap("C:\\Users\\dwaf\\OneDrive\\Pictures\\19575318_10155551004415805_3569276242911725937_o.jpg");
            System.Drawing.Image img2 = new Bitmap("C:\\Users\\dwaf\\OneDrive\\Pictures\\28168511_10155551010860805_7488729591438926678_n.jpg");
            System.Drawing.Image img3 = new Bitmap("C:\\Users\\dwaf\\OneDrive\\Pictures\\28238773_10155551004485805_1850028587489487561_o.jpg");
            using (MemoryStream ms = new MemoryStream())
            {
                img1.Save(ms, img1.RawFormat);
                string img1Base64String= Convert.ToBase64String(ms.ToArray());
                img1.Save(ms, img2.RawFormat);
                string img2Base64String = Convert.ToBase64String(ms.ToArray());
                img1.Save(ms, img3.RawFormat);
                string img3Base64String = Convert.ToBase64String(ms.ToArray());
                Summaries[0] = img1Base64String;
                Summaries[1] = img2Base64String;
                Summaries[2] = img3Base64String;
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}