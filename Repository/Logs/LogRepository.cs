using BlockCountries.Models;

namespace BlockCountries.Repository.Logs
{
    public class LogRepository:IlogRepository
    {

        List<LogEntity> LogFailedBlockedAttempts;

        public IEnumerable<LogEntity> GetAll(int pageNumber=1)
        {
            int sizePage = 10;
   return   LogFailedBlockedAttempts.AsQueryable().Skip(pageNumber * sizePage)
                .Take(sizePage).ToList();
        }
          
        public LogEntity AddLog (LogEntity logEntity) 
        {
            LogFailedBlockedAttempts.Add(logEntity);
            return logEntity;
        }

    }
}
