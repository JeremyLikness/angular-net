
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ngfunction
{
    public static class AngularFunctionHost
    {
        [FunctionName("Bifurc")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Bifurc/{rValue}")]HttpRequest req,
            float rValue, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string skip = req.Query["skip"];
            string iterations = req.Query["iterations"];
            string badRequest = string.Empty;

            log.LogInformation($"r={rValue},skip={skip},iterations={iterations}");

            if (!int.TryParse(skip, out int s))
            {
                return new BadRequestObjectResult("Skip parameter is required.");
            }

            if (!int.TryParse(iterations, out int i))
            {
                return new BadRequestObjectResult("Iterations parameter is required.");
            }

            if (s > i)
            {
                return new BadRequestObjectResult("Skip cannot exceed iterations.");
            }

            var x = 0.5f;
            var result = new List<float>();
            for (var iter = 0; iter < i; iter += 1)
            {
                x = rValue * x * (1.0f - x);
                if (iter >= s)
                {
                    result.Add(x);
                }
            }
            return new OkObjectResult(result.ToArray());
        }
    }
}
