using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web2Api.Controllers
{
    [Route("[controller]")]
    public class WeatherForecastController : MainController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Obtervalores")]
        public IEnumerable<WeatherForecast> Obtervalores()
        {
            var rng = new Random();

            var valores = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            if (valores.Length <= 50000)
                return null;

            return valores;
        }

        [HttpGet]
        public ActionResult ObterResultado()
        {
            var rng = new Random();

            var valores = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            if (valores.Length <= 50000)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> ObterTodos()
        {
            var rng = new Random();
            var valor =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(valor);
        }


        [HttpPost]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ObterTodos(WeatherForecast value)
        {
            var rng = new Random();
            var valor = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();

            valor.Add(value);


            if (!valor.Contains(value))
                return BadRequest();

            return CreatedAtAction("Post",valor);
        }
    }

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        
    }
}
