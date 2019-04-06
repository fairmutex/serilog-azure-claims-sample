using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serilog_azure_claims_sample.Enrichers
{
    public class RoleEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            try
            {
                logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("ApplicationCode", "serilog-azure-claims-sample"));
            }
            catch
            {
                // ignored
            }
        }
    }
}
