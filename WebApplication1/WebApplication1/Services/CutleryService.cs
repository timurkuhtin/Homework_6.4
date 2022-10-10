using WebApplication1.Exceptions;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class CutleryService : ICutleryService
    {
        private readonly IDataProvider _dataProvider;

        public CutleryService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<List<Cutlery>> GetCutlerys()
        {
            var cutlerys = await _dataProvider.GetCutlerys();

            if (cutlerys.Capacity == 0)
            {
                throw new BusinessException("Db is empty!");
            }

            return cutlerys;
        }

        public async Task<Cutlery> GetCutleryById(Guid id)
        {
            var cutlery = await _dataProvider.GetCutleryById(id);

            if (cutlery == null)
            {
                throw new BusinessException("Cutlery with this id is absent!");
            }

            return cutlery;
        }

        public async Task AddCutlery(CutleryViewModel cutleryModel)
        {
            var cutlery = new Cutlery
            {
                Type = cutleryModel.Type,
                Material = cutleryModel.Material, 
                Price = cutleryModel.Price
            };

            await _dataProvider.AddCutlery(cutlery);
        }

        public async Task EditCutleryById(Guid id, CutleryViewModel cutleryModel)
        {
            var editedCutlery = await _dataProvider.GetCutleryById(id);

            if (editedCutlery == null)
            {
                throw new BusinessException("Cutlery with this id is absent!");
            }

            editedCutlery.Type = cutleryModel.Type;
            editedCutlery.Price = cutleryModel.Price;
            editedCutlery.Material = cutleryModel.Material;

            await _dataProvider.EditCutlery(editedCutlery);
        }

        public async Task DeleteCutleryById(Guid id)
        {
            var cutleryToDelete = await _dataProvider.GetCutleryById(id);

            if (cutleryToDelete == null)
            {
                throw new BusinessException("Cutlery with this id is absent!");
            }

            await _dataProvider.DeleteCutlery(cutleryToDelete);
        }
    }
}
