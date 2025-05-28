using BlockCountries.Dto;
using BlockCountries.Models;

namespace BlockCountries.Service.LogService
{
    public interface IlogService
    {
        public IEnumerable<LogDto> GetAll(int pageNumber);



    }
}
