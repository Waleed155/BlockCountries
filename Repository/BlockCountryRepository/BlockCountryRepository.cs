using BlockCountries.Dto;
using BlockCountries.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Linq;

namespace BlockCountries.Repository.BlockCountryRepository
{
    public class BlockCountryRepository:IBlockCountryRepository
    {
        ConcurrentDictionary<string, BlockedCountry> BlockedList { get; set; } =
               new ConcurrentDictionary<string, BlockedCountry>();
     ConcurrentDictionary<string, DateTime > TemporalBlockedList { get; set; }=
               new ConcurrentDictionary<string, DateTime>();

        public BlockedCountry Add(BlockedCountry blockedCountry)
        {
            BlockedList.TryAdd(blockedCountry.Code, blockedCountry);
                return blockedCountry;
           

        }
        public BlockedCountry GetCountryByCode (string code)

        {
            try
            {
                var blockedcountryFound = BlockedList.FirstOrDefault(blok => blok.Value
                .Code == code).Value;
                if (blockedcountryFound.Code != null)
                {
                    return blockedcountryFound;
                }
                return new BlockedCountry() { Code = null, Name = null };

            }
            catch (Exception ex)
            {
                return new BlockedCountry() { Code = null, Name = null };

            }
        }
        public DateTime GetCountryByCodeFromTemporal(string code)
        {
            if (TemporalBlockedList.TryGetValue(code, out var blockedCountry))
            {
                return blockedCountry;
            }
            return DateTime.MinValue;
        }
        public bool Remove(string code)
        {
          return  BlockedList.TryRemove(code,out _);
        }


        public IEnumerable<BlockedCountry> 
            GetAll(EntitySearchCountry entitySearchCountry)
        {
            IQueryable<BlockedCountry> countries = BlockedList.Values.AsQueryable();
            if(string.IsNullOrEmpty(entitySearchCountry.searchTerm))
            {
                return countries .
                    Skip(entitySearchCountry.page* entitySearchCountry.pageSize)
                    .Take(entitySearchCountry.pageSize);
            }
            else
            {
                return countries.Where(country=>country.
                Name.Contains(entitySearchCountry.searchTerm.Trim())||
                country.Code.Contains(entitySearchCountry.searchTerm.Trim()));
            }

        }
   
        public TemporalEntity temporal_block(TemporalEntity temporalEntity)
        {
            TemporalBlockedList.
                 TryAdd(temporalEntity.Code,DateTime.UtcNow.AddMinutes
                 (temporalEntity.DurationMinutes));
        return temporalEntity;
        }
        
        public IEnumerable<string> GetAllTemporal()
        {
          return  TemporalBlockedList.Keys;
        }
        public bool RemoveTemporal(string code)
        {
            return TemporalBlockedList.TryRemove(code, out _);
        }
        public bool Check(string key) 
        {
            TemporalBlockedList.TryGetValue(key, out var expire);
            if (expire  <= DateTime.UtcNow)
                return true;
            else
                return false;
        }


    }
}
 