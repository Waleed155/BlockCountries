using BlockCountries.Dto;
using BlockCountries.Models;

namespace BlockCountries.ViewModels
{
    public class LogViewModel
    {
        public string IPAddress { get; set; }

        public DateTime Timestamp { get; set; }
        public string CountryCode { get; set; }

        public bool BlockedStatus { get; set; }
        public string UserAgent { get; set; }
    }
    public static class TransferBetweenLogViewModelAndLogDto
    {
        public static IEnumerable<LogViewModel> ToLogViewModeList
            (this IEnumerable<LogDto> logDtosIn)
        {

            List<LogViewModel> logViewModels = new List<LogViewModel>();

            foreach (var item in logDtosIn)
            {
                var logViewModel = new LogViewModel
                {
                    IPAddress = item.IPAddress,
                    Timestamp = item.Timestamp,
                    CountryCode = item.CountryCode,
                    BlockedStatus = item.BlockedStatus,
                    UserAgent = item.UserAgent,

                };
                logViewModels.Add(logViewModel);
            }
            return logViewModels;
        }
        public static IEnumerable<LogDto> ToLogDtoList
            (this IEnumerable<LogViewModel> logViewModesIn)
        {

            List<LogDto> logDtos = new List<LogDto>();

            foreach (var item in logViewModesIn)
            {
                var logDto = new LogDto
                {
                    IPAddress = item.IPAddress,
                    Timestamp = item.Timestamp,
                    CountryCode = item.CountryCode,
                    BlockedStatus = item.BlockedStatus,
                    UserAgent = item.UserAgent,

                };
                logDtos.Add(logDto);
            }
            return logDtos;
        }
    }
}
