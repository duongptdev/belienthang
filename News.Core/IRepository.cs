using News.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace News.Core
{
    public interface IRepository
    {
        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : Entity;

        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity;

        Task DeleteRangeAsync<TEntity>(IEnumerable<Guid> ids) where TEntity : Entity;

        Task DeleteRangeAsync<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : Entity;

        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : Entity;

        Task DeleteAsync<TEntity>(Guid id) where TEntity : Entity;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, TEntity>> selector = null, IEnumerable<string> includes = null) where TEntity : Entity;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(IQueryable<TEntity> query, Expression<Func<TEntity, TEntity>> selector = null) where TEntity : Entity;

        Task<IEnumerable<TModel>> FindAllAsync<TEntity, TModel>(IQueryable<TEntity> query, Expression<Func<TEntity, TModel>> selector = null) where TEntity : Entity where TModel : class;

        Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> where = null, IEnumerable<string> includes = null) where TEntity : Entity;

        Task<TEntity> FindAsync<TEntity>(Guid id) where TEntity : Entity;

        Task<TModel> FindAsync<TEntity, TModel>(Guid id, Expression<Func<TEntity, TModel>> selector = null, IEnumerable<string> includes = null) where TEntity : Entity where TModel : class;

        Task<TEntity> FindAsync<TEntity>(Guid id, IEnumerable<string> includes = null) where TEntity : Entity;

        Task<TEntity> FindNewestAsync<TEntity>(IEnumerable<string> includes) where TEntity : Entity;

        Task<PagedResult<TEntity>> FindPagedAsync<TEntity>(IQueryable<TEntity> query, int? pageIndex = 1, int? pageSize = 20) where TEntity : Entity;

        Task<PagedResult<TModel>> FindPagedAsync<TEntity, TModel>(IQueryable<TEntity> query, Expression<Func<TEntity, TModel>> selector = null, int? pageIndex = 1, int? pageSize = 20) where TEntity : Entity where TModel : class;

        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : Entity;

        IQueryable<TEntity> GetQueryable<TEntity>(IEnumerable<string> includes) where TEntity : Entity;
        Task SaveChangeAsync();

        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity;

        Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entites) where TEntity : Entity;

        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : Entity;



    }
}
