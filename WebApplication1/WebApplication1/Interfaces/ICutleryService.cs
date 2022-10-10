using WebApplication1.Models;
using WebApplication1.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    public interface ICutleryService
    {
        public Task<List<Cutlery>> GetCutlerys();

        public Task<Cutlery> GetCutleryById(Guid id);

        public Task AddCutlery(CutleryViewModel cutleryModel);

        public Task EditCutleryById(Guid id, CutleryViewModel cutleryModel);

        public Task DeleteCutleryById(Guid id);
    }
}
