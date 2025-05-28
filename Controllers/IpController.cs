using BlockCountries.Service.IpService;
using BlockCountries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockCountries.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IpController : ControllerBase
    {
        IIPService _IPService;
        public IpController(IIPService IPService) {
        _IPService = IPService;
        }
        [HttpGet]
        public ResultViewModel< IpInfoViewModel> GetIPInfo(string ip)
        {
            var country= _IPService.GetCountry(ip);
            return ResultViewModel<IpInfoViewModel>.
                Success( _IPService.GetCountry(ip).Result.ToipViewModel());
        }
        [HttpGet]
        public ResultViewModel<bool> Getuserinfo()
        {
            return ResultViewModel<bool>.Success(
                _IPService.check_block().Result);

        }




    }
}
