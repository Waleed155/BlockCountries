using BlockCountries.Models;

namespace BlockCountries.Dto
{
    public class LogDto
    {
        public string IPAddress { get; set; }

        public DateTime Timestamp { get; set; }
        public string CountryCode { get; set; }

        public bool BlockedStatus { get; set; }
        public string UserAgent { get; set; }
    }
    public static class TransferBetweenLogs
    {
        public static IEnumerable<LogDto> toLogDtoList(this IEnumerable<LogEntity> logEntity)
        {
            List<LogDto> logDtos = new List<LogDto>();
            foreach (var item in logEntity)
            {

                var logdto = new LogDto
                {
                    IPAddress = item.IPAddress,
                    Timestamp = item.Timestamp,
                    CountryCode = item.CountryCode,
                    BlockedStatus = item.BlockedStatus,
                    UserAgent = item.UserAgent,
                };
                logDtos.Add(logdto);
            }
            return logDtos;
        }
        public static IEnumerable<LogEntity> toLogEntityList(this IEnumerable<LogDto> logDto)
        {
            {
                List<LogEntity> logEntities = new List<LogEntity>();

                foreach (var item in logDto)
                {
                    var logEntity = new LogEntity
                    {
                        IPAddress = item.IPAddress,
                        Timestamp = item.Timestamp,
                        CountryCode = item.CountryCode,
                        BlockedStatus = item.BlockedStatus,
                        UserAgent = item.UserAgent,

                    };
                    logEntities.Add(logEntity);
                }
                return logEntities;
            }
        }
    }
}
