using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serilog_azure_claims_sample.Enrichers
{
    public class OidMiddleware
    {
        private readonly RequestDelegate _next;

        public OidMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            // With Enricher
            using (LogContext.Push(new OidEnricher(httpContext.User)))
            {
                await _next(httpContext);
            }

            // Without enricher works also
            //if (httpContext.User.Identity.IsAuthenticated)
            //{
            //    var Oid = (httpContext.User.FindFirst(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
            //    using (LogContext.PushProperty("Oid", Oid))
            //    {
            //        await _next(httpContext);
            //    }
            //}
            //else
            //{
            //    await _next(httpContext);
            //}
        }
    }
}
