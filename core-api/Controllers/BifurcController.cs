using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BifurcController : ControllerBase
    {
        private static readonly Random generator = new Random();

        // GET api/values/3.5/10/100
        [HttpGet("{r}")]
        public ActionResult<float[]> Get(
            float r,
            [FromQuery] 
            int skip,
            [FromQuery] 
            int iterations)
        {
            Console.WriteLine($"{r}, {skip}, {iterations}");
            if (iterations <= 0)
            {
                return BadRequest("Iterations must be a positive integer.");
            }
            if (skip > iterations)
            {
                return BadRequest("Skip must be less than iterations.");
            }
            var x = 0.5f;
            var result = new List<float>();
            for (var i = 0; i < iterations; i += 1) {
                x = r * x * (1.0f - x);
                if (i >= skip) 
                {
                    result.Add(x);
                }
            }
            return Ok(result.ToArray());
        }
    }
}
