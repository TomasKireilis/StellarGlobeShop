using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution.Serialization;
using Microsoft.Extensions.DiagnosticAdapter;
using Microsoft.Extensions.Logging;

namespace StellarGlobeShopUI.Service.GraphQl
{
    public class DiagnosticObserver
        : DiagnosticEventListener
    {
        private readonly ILogger<DiagnosticObserver> _logger;

        public DiagnosticObserver(ILogger<DiagnosticObserver> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override IActivityScope ExecuteRequest(IRequestContext context)
        {
            if (context.Request.Query != null)
            {
                var queryString = Regex.Replace(context.Request.Query.ToString(), @"\s+", " ");
                _logger.LogInformation($"Processing query: {queryString}");
            }

            return EmptyScope;
        }
    }
}