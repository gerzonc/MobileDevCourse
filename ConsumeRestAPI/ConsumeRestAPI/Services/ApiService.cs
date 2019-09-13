using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsumeRestAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace ConsumeRestAPI.Services
{
    public class ApiService : IApiService
    {
        public ApiService()
        {

        }
        public async Task<List<Heroes>> GetHeroes()
        {
            var dotaAPI = RestService.For<IApiService>("https://api.opendota.com");
            var hero = await dotaAPI.GetHeroes();

            return hero;
        }
    }
}
