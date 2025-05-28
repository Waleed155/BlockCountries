using BlockCountries.Dto;
using BlockCountries.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlockCountries.Service.IpService
{
    public interface IIPService
    {
        public  Task<IPInfoDto> GetCountry(string ip);
       


        public  Task<bool> check_block();
       
                  
    }
}
