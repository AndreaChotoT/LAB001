using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LAB001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<LabController> _logger;

        public LabController(ILogger<LabController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("AddHistory")]
        public string AddHistory()
        {
            _logger.LogInformation("AddHistory");
            try {
                var path = "/var/Lab/logs";

                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }

                var file = $"{path}/{DateTime.Now.ToString("dd+Myyyy_HH_mm_ss")}.log";
                System.IO.File.WriteAllText(file,"Log de pruebas");
                return "ok";
            }
            catch (Exception ex){
                _logger.LogError(ex,"Error en AddHistory");
                return "Error";
            }
            
        }




    }
}