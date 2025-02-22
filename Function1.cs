using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace swa_managed
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("GetTitle")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            IHeaderDictionary headers = req.Headers;
            if (!headers.TryGetValue("x-ms-client-principal", out Microsoft.Extensions.Primitives.StringValues headerValues))
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
