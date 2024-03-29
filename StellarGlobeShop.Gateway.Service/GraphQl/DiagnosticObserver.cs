﻿using System;
using System.Text.RegularExpressions;
using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using Microsoft.Extensions.Logging;

namespace StellarGlobeShop.Gateway.Service.GraphQl
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