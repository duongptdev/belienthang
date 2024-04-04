using Microsoft.EntityFrameworkCore;
using News.Application.NewServices.Dtos;
using News.Common;
using News.Core;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace News.Application.NewServices
{
    public class NewService : INewService
    {
        private readonly IRepository _repository;

        public NewService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(NewDto dto)
        {
            var entity = new New()
            {
                CateogoryId = dto.CategoryId,
                Content = dto.Content,
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                Title = dto.Title,
                SearchParams = null,
                Image = dto.Image,
                UpdatedAt = DateTime.Now
            };

            await _repository.AddAsync(entity);
        }

        public async Task CreateCategoryAsync(CategoryDto model)
        {
            var entity = new Category()
            {
                Id = Guid.NewGuid(),
                Code = model.Code,
                Name = model.Name,
                IsDeleted = false
            };

            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync<New>(id);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _repository.FindAsync<Category>(id);
            if (category is null) return;
            category.IsDeleted = true;

            await _repository.UpdateAsync(category);
        }

        public async Task<NewDto> GetById(Guid id)
        {
            var data = await _repository.FindAsync<New>(id, new string[] { "Category" });

            return new NewDto()
            {
                Id = data.Id,
                CategoryId = data.CateogoryId,
                Content = data.Content,
                Image = data.Image,
                Title = data.Title,
                Date = data.CreatedAt,
                Category = data.Category.Name
            };

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _repository.FindAllAsync<Category>(x => !x.IsDeleted);
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            var data = await _repository.FindAsync<Category>(id);

            return data;
        }

        public async Task<NewDto> GetHomeNewsAsync()
        {
            var entity = await _repository.FindAsync<New>(x => x.IsHeaderNews != null && x.IsHeaderNews.Value, new string[] { "Category" });
            return new NewDto()
            {
                Id = entity.Id,
                CategoryId = entity.CateogoryId,
                Content = entity.Content,
                Title = entity.Title,
                Date = entity.CreatedAt,
                Image = entity.Image,
                Category = entity.Category.Name
            };
        }

        public async Task<PagedResult<NewDto>> GetPagingAsync(int? page = 1, int? pageSize = 15, Guid? categoryId = null)
        {
            var query = _repository.GetQueryable<New>(new string[] { "Category" })
                .OrderByDescending(x => x.CreatedAt).AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CateogoryId.Equals(categoryId.Value));
            }

            Expression<Func<New, NewDto>> selector = x => new NewDto()
            {
                Id = x.Id,
                CategoryId = x.CateogoryId,
                Content = x.Content,
                Image = x.Image,
                Title = x.Title,
                Category = x.Category.Name,
                Date = x.CreatedAt
            };

            var data = await _repository.FindPagedAsync(query, selector, page, pageSize);

            return data;
        }

        public async Task<IEnumerable<CategoryNewModel>> GetTopNews()
        {
            var query = _repository.GetQueryable<Category>(new string[] { "News" }).Where(x => !x.IsDeleted)
                .Select(x => new CategoryNewModel()
                {
                    Category = new Category()
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                    },
                    News = x.News.OrderByDescending(x => x.CreatedAt).Take(6).Select(d => new NewDto()
                    {
                        CategoryId = d.CateogoryId,
                        Title = d.Title,
                        Date = d.CreatedAt,
                        Image = d.Image,
                        Id = d.Id,
                    })
                });

            return await query.ToListAsync();
        }

        public async Task SetHomeAsync(Guid id)
        {
            var current = await _repository.FindAsync<New>(x => x.IsHeaderNews.HasValue && x.IsHeaderNews.Value);
            if (current != null)
            {
                current.IsHeaderNews = false;
                await _repository.UpdateAsync(current);
            }
            var entity = await _repository.FindAsync<New>(id);
            entity.IsHeaderNews = true;


            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateAsync(NewDto dto)
        {
            var entity = await _repository.FindAsync<New>(dto.Id.Value);
            entity.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Image))
            {
                entity.Image = dto.Image;
            }
            entity.Content = dto.Content;
            entity.CateogoryId = dto.CategoryId;

            await _repository.UpdateAsync(entity);

            return;
        }

        public async Task UpdateCategory(CategoryDto model)
        {
            var entity = await _repository.FindAsync<Category>(model.Id.Value);
            entity.Name = model.Name;
            entity.Code = model.Code;
            await _repository.UpdateAsync(entity);
        }
    }
}
