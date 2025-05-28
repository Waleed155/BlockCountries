using System.Diagnostics.Metrics;

namespace BlockCountries.Models
{
    public class LogEntity
    {
        public string IPAddress { get; set; }

        public DateTime Timestamp { get; set; }
     = DateTime.UtcNow;
        public string CountryCode { get; set; }

        public bool BlockedStatus { get; set; } = true;
        public string UserAgent { get; set; }


    }
}
