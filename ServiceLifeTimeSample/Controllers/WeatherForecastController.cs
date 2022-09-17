using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLifeTimeSample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLifeTimeSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ITransientService transientService1;
        private readonly ITransientService transientService2;
        private readonly IScopedService scopedService1;
        private readonly IScopedService scopedService2;
        private readonly ISingletonService singletonService1;
        private readonly ISingletonService singletonService2;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2,
            ILogger<WeatherForecastController> logger)
        {
            this.transientService1 = transientService1;
            this.transientService2 = transientService2;
            this.scopedService1 = scopedService1;
            this.scopedService2 = scopedService2;
            this.singletonService1 = singletonService1;
            this.singletonService2 = singletonService2;
            _logger = logger;
        }
        [HttpGet]
        [Route("index2")]
        public IActionResult Index()
        {
            var TransientServiceGuid1 = transientService1.GetGuid();
            var TransientServiceGuid2 = transientService2.GetGuid();

            var ScopedServiceGuid1 = scopedService1.GetGuid();
            var ScopedServiceGuid2 = scopedService2.GetGuid();

            var SingletonServiceGuid1 = singletonService1.GetGuid();
            var SingletonServiceGuid2 = singletonService2.GetGuid();

            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient 1: {TransientServiceGuid1}\n");
            messages.Append($"Transient 2: {TransientServiceGuid2}\n\n");

            messages.Append($"Scoped 1: {ScopedServiceGuid1}\n");
            messages.Append($"Scoped 2: {ScopedServiceGuid2}\n\n");

            messages.Append($"Singleton 1: {SingletonServiceGuid1}\n");
            messages.Append($"Singleton 2: {SingletonServiceGuid2}");
            return Ok(messages.ToString());
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
