using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IBreed
    {
        Task<Breed> GetBreed(string breed);
        Task<List<Breed>> GetBreeds();



    }
}
