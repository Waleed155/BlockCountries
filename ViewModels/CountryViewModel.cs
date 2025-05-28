using BlockCountries.Dto;
using BlockCountries.Models;

namespace BlockCountries.ViewModels
{
    public class CountryViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
    public static class TransferBetweenCountryViewModelAndCountryDto
    {
        public static CountryViewModel ToBlockCountryViewModel
           (this BlockedCountryDto blockedCountryDto)
        {
            return new CountryViewModel
            { Code = blockedCountryDto.Code, Name = blockedCountryDto.Name };
        }
        public static IEnumerable<CountryViewModel>
                    ToBlockedCountryViewModelList
                    (this IEnumerable<BlockedCountryDto> blockedCountryDtolist)
        {
            List<CountryViewModel> blockedCountryViewModellist =
                new List<CountryViewModel>();
            foreach (var item in blockedCountryDtolist)
            {
                var blockedCountryviewmodel =
                    new CountryViewModel { Code = item.Code, Name = item.Name };
                blockedCountryViewModellist.Add(blockedCountryviewmodel);
            }
            return blockedCountryViewModellist;
        }
        public static BlockedCountryDto ToBlockCountrydto
           (this CountryViewModel blockedCountryviewmodel)
        {
            return new BlockedCountryDto
            { Code = blockedCountryviewmodel.Code, Name = blockedCountryviewmodel.Name };
        }
    }
}
