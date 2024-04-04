using News.Application.SettingServices.Dtos;
using News.Core;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.SettingServices
{
    public class SettingService : ISettingService
    {
        private readonly IRepository _repository;

        public SettingService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            var data = await _repository.FindAllAsync<Setting>();
            return data;
        }

        public async Task UpdateAsync(SettingDto model)
        {
            var entity = await _repository.FindAsync<Setting>(model.Id);
            entity.Content = model.Content;
            if (!string.IsNullOrEmpty(model.Image))
            {
                entity.Image = model.Image;
            }

            entity.Title = model.Title;

            entity.TextFirst = model.TextFirst;
            entity.ValueFirst = decimal.Parse(string.IsNullOrEmpty(model.ValueFirst) ? "0" : model.ValueFirst);

            entity.TextSecond = model.TextSecond;
            entity.ValueSecond = decimal.Parse(string.IsNullOrEmpty(model.ValueSecond) ? "0" : model.ValueSecond);

            entity.TextThrid = model.TextThird;
            entity.ValueThrid = decimal.Parse(string.IsNullOrEmpty(model.ValueThird) ? "0" : model.ValueThird);

            await _repository.UpdateAsync(entity);

        }
    }
}
