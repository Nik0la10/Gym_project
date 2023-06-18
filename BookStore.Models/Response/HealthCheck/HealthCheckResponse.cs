using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Response.HealthCheck
{
    public class HealthCheckResponse
    {
        public string? Status { get; set; }

        public IEnumerable<IndividualHealthCheckResponse>
            HealthChecks { get; set; } =
            Enumerable.Empty<IndividualHealthCheckResponse>();

        public TimeSpan HealthCheckDuration { get; set; }
    }
}
