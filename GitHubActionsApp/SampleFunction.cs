using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GitHubActionsApp
{
    public class SampleFunction
    {
        [FunctionName(nameof(SampleFunction))]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = string.IsNullOrEmpty(req.Query["name"])  ? "World" : req.Query["name"];
            string responseMessage = $"Hello {name}. Time(UTC): {DateTime.UtcNow}";

            return new OkObjectResult(responseMessage);
        }
    }
}
