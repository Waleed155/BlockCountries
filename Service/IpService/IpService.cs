using BlockCountries.Dto;
using Newtonsoft.Json;
using Microsoft.AspNetCore.HttpOverrides;
using System.Text.RegularExpressions;
using BlockCountries.Repository.Logs;
using BlockCountries.Models;
using BlockCountries.Repository.BlockCountryRepository;
using System.Net;

namespace BlockCountries.Service.IpService
{
    public class IpService:IIPService
    {
        IConfiguration _configuration;
        HttpClient _httpClient;
        IHttpContextAccessor _httpContextAccessor;
        IBlockCountryRepository _countryRepository;
        IlogRepository _logRepository;

        public IpService(IConfiguration configuration, 
            HttpClient httpClient,
                  IHttpContextAccessor httpContextAccessor,
            IBlockCountryRepository countryRepository,
        IlogRepository  logRepository)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _countryRepository = countryRepository;
            _logRepository = logRepository;
        }
        public async Task<IPInfoDto> GetCountry(string ip)
        {
            if (Validateip(ip))
            {
                var apiKey = _configuration.GetSection("ApiKey");
                var apiUrl = $"https://api.ipgeolocation.io/ipgeo?apiKey={apiKey.Value}&ip={ip}";
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var c= JsonConvert.DeserializeObject<IPInfoDto>(content.ToString());

                return JsonConvert.DeserializeObject<IPInfoDto>(content.ToString());
            }
            throw new Exception("ip is not valid");
        }


        public async Task<bool> check_block()
        {
            var Ip = _httpContextAccessor?.HttpContext?.
                Connection?.RemoteIpAddress?.ToString();

            






             var country = GetCountry(Ip.ToString());
            if (_countryRepository.Check(country.Result.country_code2))
            {
                var user = _httpContextAccessor.HttpContext.
                    Request.Headers["User-Agent"].ToString();

                LogEntity logEntity = new LogEntity()
                {
                    UserAgent = user,
                    IPAddress = Ip.ToString(),
                    CountryCode = country.Result.country_code2,
                    BlockedStatus = true,
                    Timestamp = DateTime.Now,
                };
                _logRepository.AddLog(logEntity);
                return true;
            }
            else
                return false;


        }



        bool Validateip(string ip)
        {
            char FullStop = '.';
            string[] ipcomponents = ip.Split(FullStop);
            if (ipcomponents.Length != 4)
            {
                return false;
            }
            foreach (var item in ipcomponents)
            {
                if (item.Length > 3)
                {
                    return false;
                }
                if (int.Parse(item) > 255 || int.Parse(item) < 0)
                {
                    return false;
                }

            }
            return true;







        }
    }
}
