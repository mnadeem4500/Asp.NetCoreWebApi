using Newtonsoft.Json;
using System.Net;

namespace ExtremeClassified.WebApi.Services
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {

                await Task.Run(() =>
                   {
                       _logger.LogError($"{ex.Message}");
                   }).ConfigureAwait(false);

                var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = HttpStatusCode.InternalServerError.ToString() });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(errorMessage);
            }


        }
    }
}
