using BlockCountries.Models;

namespace BlockCountries.Dto
{
    public class BlockedCountryDto
    {
        public string Code { get; set; }
        public string Name { get; set; }

        
    }
    public static class TransferbetweenBlockedCountryDtoAndCountryBlocked
    {
        public static BlockedCountryDto ToBlockedCountryDto(this BlockedCountry blockedCountry)
        {

            return new BlockedCountryDto
            { Code = blockedCountry.Code, Name = blockedCountry.Name };


        }
        public static IEnumerable<BlockedCountryDto>
                    ToBlockedCountryDtoList
                    (this IEnumerable<BlockedCountry> blockedCountryEntitylist)
        {
            List<BlockedCountryDto> blockedCountryDtolist =
                new List<BlockedCountryDto>();
            foreach (var item in blockedCountryEntitylist)
            {
                var blockedCountryDto =
                    new BlockedCountryDto { Code = item.Code, Name = item.Name };
                blockedCountryDtolist.Add(blockedCountryDto);
            }
            return blockedCountryDtolist;
        }

        public static BlockedCountry ToBlockedCountryentity(this BlockedCountryDto blockedCountrydto)
        {

            return new BlockedCountry
            { Code = blockedCountrydto.Code, Name = blockedCountrydto.Name };


        }
    }
    
}
