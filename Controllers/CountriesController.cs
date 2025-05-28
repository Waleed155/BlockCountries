using BlockCountries.Dto;
using BlockCountries.Service.BlockedCountry;
using BlockCountries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockCountries.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        IBlockedCountryService _countryService;
        public CountriesController(
            IBlockedCountryService countryService) { 
        _countryService=countryService;
        }

        [HttpPost]
        public ResultViewModel<CountryViewModel>
            AddBlockCountry(CountryViewModel countryViewModel)
        {
            var blockedCountry= _countryService.Add(countryViewModel.ToBlockCountrydto()).
                ToBlockCountryViewModel();
            return ResultViewModel<CountryViewModel>.Success(blockedCountry);
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<CountryViewModel>>
            GetAll([FromQuery]EntitySearchCountry entitySearchCountry) {
           var blockedCountries= _countryService.GetAll(entitySearchCountry).ToBlockedCountryViewModelList();
            return ResultViewModel<IEnumerable<CountryViewModel>>.
                Success(blockedCountries);
        }

        [HttpDelete]
        public ResultViewModel<bool> RemoveBlockedCountry(string code) {
        return ResultViewModel<bool>.Success(_countryService.Remove(code));
        
        
        }
        [HttpPost]
        public ResultViewModel<TemporalEntity> AddTemporal(TemporalEntity temporalEntity)
        {
            var temporalentity=_countryService.AddTemporal(temporalEntity);
            return ResultViewModel<TemporalEntity>.Success(temporalentity);
        }


    }
}
