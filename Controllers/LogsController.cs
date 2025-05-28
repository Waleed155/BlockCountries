using BlockCountries.Service.LogService;
using BlockCountries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockCountries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        IlogService _logService;
        public LogsController(IlogService logService)
        {
            _logService = logService;
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<LogViewModel>> BlockedAttemps(int pageNumber)
        {
         var logsViewModel=_logService.GetAll(pageNumber).
                ToLogViewModeList();
            return ResultViewModel<IEnumerable<LogViewModel>>.
                Success(logsViewModel);
        }
        

    }
}
