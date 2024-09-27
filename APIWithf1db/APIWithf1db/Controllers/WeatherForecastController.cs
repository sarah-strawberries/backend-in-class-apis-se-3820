using APIWithf1db.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIWithf1db.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private ILogger<WeatherForecastController> _logger;
        private DbContext dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Circuit> Get(ILogger<WeatherForecastController logger, ClassSharedRoContext dbContext>)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
    }
}
