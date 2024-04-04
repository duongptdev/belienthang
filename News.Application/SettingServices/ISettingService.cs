using News.Application.SettingServices.Dtos;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.SettingServices
{
    public interface ISettingService
    {
        Task<IEnumerable<Setting>> GetAllAsync();

        Task UpdateAsync(SettingDto model);
    }
}
