using ConsumeRestAPI.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeRestAPI.Services
{
    public interface IApiService
    {
        [Get("/api/heroes")]
        Task<List<Heroes>> GetHeroes();


    }
}
