using Serilog;
using Serilog.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serilog_azure_claims_sample.Enrichers
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers for <see cref="System.Environment"/>.
    /// capabilities.
    /// </summary>
    public static class SerilogExtensions
    {

        public static LoggerConfiguration WithRole(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<RoleEnricher>();
        }

    }
}
