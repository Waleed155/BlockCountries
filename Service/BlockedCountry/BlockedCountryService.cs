using BlockCountries.Dto;
using BlockCountries.Models;
using BlockCountries.Repository.BlockCountryRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlockCountries.Service.BlockedCountry
{
    public class BlockedCountryService:IBlockedCountryService
    {
          IBlockCountryRepository _blockCountryRepository;
        public BlockedCountryService(
            IBlockCountryRepository blockCountryRepository) 
        { 
        _blockCountryRepository = blockCountryRepository;
        
        }
       
            
    public BlockedCountryDto Add(BlockedCountryDto blockedCountryDto)
     {
            if (dublicatevalidate(blockedCountryDto.Code))
            {
                return _blockCountryRepository.
                           Add(blockedCountryDto.ToBlockedCountryentity()).
                           ToBlockedCountryDto();

            }
            else 
                return new BlockedCountryDto();
       }


        public bool Remove(string code) {
            if (RemoveBlockCountryValidate(code))
            {
                return _blockCountryRepository.Remove(code);
            }
            throw new DirectoryNotFoundException("the country is not blocked.");



        }


        public IEnumerable<BlockedCountryDto> GetAll([FromQuery] EntitySearchCountry entitySearchCountry) {

          return  _blockCountryRepository.
                GetAll(entitySearchCountry).ToBlockedCountryDtoList();
        }


        public TemporalEntity AddTemporal(TemporalEntity temporalEntity)
        {
            if (ValidateTemporal(temporalEntity))
            {
                return _blockCountryRepository.temporal_block(temporalEntity);

            }
            else
                throw new Exception("minutes must be in 1-1440");

        }


        bool ValidateTemporal(TemporalEntity temporalEntity) { 
        int minutes=temporalEntity.DurationMinutes;
            var temporalblockedentity = _blockCountryRepository
                .GetCountryByCodeFromTemporal(temporalEntity.Code);
            if (minutes > 0 && minutes < 1440 )
            {

                return true;

            }
            else  return false;
        
        }
        


        bool  dublicatevalidate( string code)
        {

            if (!string.IsNullOrEmpty(code) && code.Length >= 2)
            {
                var blockCountry = _blockCountryRepository.
                    GetCountryByCode(code);
                if (blockCountry.Code == null)
                {
                    return true;
                }
                return false;
            }
                return false;


        }
        bool RemoveBlockCountryValidate(string code)
        {
           var blockCountry= _blockCountryRepository.GetCountryByCode(code);
            if(!string.IsNullOrEmpty(blockCountry.Code))
            {
               return true;
            }
            return false;
        }
    
    }
}
