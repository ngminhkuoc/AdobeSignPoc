using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class WebhookFunction
    {
        [FunctionName("WebhookFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string clientId = req.Headers["x-adobesign-clientid"];

            var strBuilder = new StringBuilder();
            foreach (System.Collections.Generic.KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> item in req.Headers)
            {
                strBuilder.AppendLine(item.Key + ": " + item.Value);
            }
            log.LogInformation(strBuilder.ToString());

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation("Body: " + requestBody);

            //if (clientId != ClientID)
            //    return new BadRequestObjectResult("Opps!! Illegitimate Call identified");

            return new OkObjectResult(new { xAdobeSignClientId = clientId });
        }
    }
}
