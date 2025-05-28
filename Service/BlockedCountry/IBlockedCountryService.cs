using BlockCountries.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlockCountries.Service.BlockedCountry
{
    public interface IBlockedCountryService
    {
        public BlockedCountryDto Add(BlockedCountryDto blockedCountryDto);
       


        public bool Remove(string code);
      


        public IEnumerable<BlockedCountryDto> GetAll([FromQuery] EntitySearchCountry entitySearchCountry);



        public TemporalEntity AddTemporal(TemporalEntity temporalEntity);







    }
}
