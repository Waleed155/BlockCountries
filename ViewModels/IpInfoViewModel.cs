using BlockCountries.Dto;

namespace BlockCountries.ViewModels
{
    public class IpInfoViewModel
    {
        public string Isp { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
    public static class TransferBetweenipViewModelAndIpDto
    {
        public static IpInfoViewModel ToipViewModel(this IPInfoDto iPInfoDto)
        {
            return new IpInfoViewModel
            {
                CountryCode = iPInfoDto.country_code2,
                CountryName = iPInfoDto.country_name,
                Isp = iPInfoDto.isp
            };
        }
        public static IPInfoDto ToipInfoDto(this IpInfoViewModel ipInfoViewModel)
        {
            return new IPInfoDto
            {
                country_code2 = ipInfoViewModel.CountryCode,
                country_name = ipInfoViewModel.CountryName,
                isp = ipInfoViewModel.Isp
            };
        }
    }
}
