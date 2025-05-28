using BlockCountries.Dto;
using BlockCountries.Models;

namespace BlockCountries.Repository.BlockCountryRepository
{
    public interface IBlockCountryRepository
    {
        public BlockedCountry Add(BlockedCountry blockedCountry);
        public BlockedCountry GetCountryByCode(string code);
        public bool Remove(string code);
       
        public IEnumerable<BlockedCountry>
            GetAll(EntitySearchCountry entitySearchCountry);
        public DateTime GetCountryByCodeFromTemporal(string code);
        public IEnumerable<string> GetAllTemporal();

        public TemporalEntity
            temporal_block(TemporalEntity temporalEntity);
       

        public bool RemoveTemporal(string code);

        public bool Check(string key);
      
    }
}
