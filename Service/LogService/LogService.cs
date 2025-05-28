using BlockCountries.Dto;
using BlockCountries.Models;
using BlockCountries.Repository.Logs;

namespace BlockCountries.Service.LogService
{
    public class LogService:IlogService
    {
        IlogRepository _repo;
        public LogService(IlogRepository repo) {
        
        _repo = repo;
        }
            
        public IEnumerable<LogDto> GetAll(int pageNumber = 1)
        {try
            {
                return _repo.GetAll(pageNumber).toLogDtoList();
            }
            catch (Exception ex)
            {
                return new List<LogDto>();
            }
        }

           
    }
}
