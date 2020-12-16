using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElasticKibanaLoggingVerify.Controllers
{
    [Route("api/[controller]")]
    public class ElasticSearchController : Controller
    {

        private readonly ILogger<ElasticSearchController> _logger;

        public ElasticSearchController(ILogger<ElasticSearchController> logger)
        {
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public int GetRandomvalue()
        {
            var random = new Random();
            var randomValue=random.Next(0, 100);
            _logger.LogInformation($"Random Value is {randomValue}");
            return randomValue;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string ThrowErrorMessage(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception($"id cannot be less than or equal to o. value passed is {id}");
                return id.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return string.Empty;
        }

       
    }
}
