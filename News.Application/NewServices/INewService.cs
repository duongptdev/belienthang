using News.Application.NewServices.Dtos;
using News.Common;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Application.NewServices
{
    public interface INewService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task CreateAsync(NewDto dto);

        Task UpdateAsync(NewDto dto);

        Task<PagedResult<NewDto>> GetPagingAsync(int? page = 1, int? pageSize = 15, Guid? categoryId = null);

        Task<NewDto> GetById(Guid id);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<CategoryNewModel>> GetTopNews();

        Task CreateCategoryAsync(CategoryDto model);

        Task DeleteCategoryAsync(Guid id);

        Task UpdateCategory(CategoryDto model);

        Task SetHomeAsync(Guid id);

        Task<Category> GetCategoryById(Guid id);

        Task<NewDto> GetHomeNewsAsync();
    }
}
