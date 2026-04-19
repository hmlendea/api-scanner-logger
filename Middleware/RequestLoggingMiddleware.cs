using System.Threading.Tasks;
using System.Text;

using Microsoft.AspNetCore.Http;

using NuciAPI.Middleware;
using NuciLog.Core;

using ApiScannerLogger.Logging;

namespace ApiScannerLogger.Middleware
{
    internal sealed class RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger logger) : NuciApiMiddleware(next)
    {
        public override async Task InvokeAsync(HttpContext context)
        {
            logger.Info(
                MyOperation.HttpRequest,
                new LogInfo(MyLogInfoKey.IpAddress, GetClientIpAddress(context)),
                new LogInfo(MyLogInfoKey.Method, context.Request.Method),
                new LogInfo(MyLogInfoKey.Path, context.Request.Path),
                new LogInfo(MyLogInfoKey.QueryString, context.Request.QueryString.ToString()),
                new LogInfo(MyLogInfoKey.Headers, FormatHeaders(context.Request.Headers)));

            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }

        static string FormatHeaders(IHeaderDictionary headers)
        {
            var builder = new StringBuilder();

            foreach (var header in headers)
            {
                builder.Append(header.Key);
                builder.Append(':');
                builder.Append(header.Value.ToString());
                builder.Append(';');
            }

            return builder.ToString();
        }
    }
}