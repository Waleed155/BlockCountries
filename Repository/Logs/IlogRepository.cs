using BlockCountries.Models;

namespace BlockCountries.Repository.Logs
{
    public interface IlogRepository
    {
        public IEnumerable<LogEntity> GetAll(int pageNumber);


        public LogEntity AddLog(LogEntity logEntity);
       
    }
}
