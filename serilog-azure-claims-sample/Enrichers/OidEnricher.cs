using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace serilog_azure_claims_sample.Enrichers
{
    public class OidEnricher : ILogEventEnricher
    {
        private readonly ClaimsPrincipal _User;

        public const string PropertyName = "Oid";


        public OidEnricher(ClaimsPrincipal User)
        {
            this._User = User;

        }

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var Oid = (_User.FindFirst(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
            logEvent.AddPropertyIfAbsent(new LogEventProperty(PropertyName, new ScalarValue(Oid)));
        }

    }
}
