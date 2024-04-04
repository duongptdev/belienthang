using News.Core.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using News.Common;

namespace News.Core
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Set<TEntity>().Add(entity);
            await SaveChangeAsync();

            return entity;
        }

        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            _context.Set<TEntity>().AddRange(entities);
            await SaveChangeAsync();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Set<TEntity>().Remove(entity);
            await SaveChangeAsync();
        }

        public async Task DeleteAsync<TEntity>(Guid id) where TEntity : Entity
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(c => c.Id.Equals(id));
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await SaveChangeAsync();
            }
        }

        public async Task DeleteRangeAsync<TEntity>(IEnumerable<Guid> ids) where TEntity : Entity
        {
            var entities = _context.Set<TEntity>().Where(c => ids.Contains(c.Id));
            _context.RemoveRange(entities);
            await SaveChangeAsync();
        }


        public async Task DeleteRangeAsync<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : Entity
        {
            var entities = _context.Set<TEntity>().Where(where);
            _context.RemoveRange(entities);
            await SaveChangeAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, TEntity>> selector = null, IEnumerable<string> includes = null) where TEntity : Entity
        {
            var query = AsQueryable<TEntity>(includes).AsNoTracking();
            if (where != null)
            {
                query = query.Where(where);
            }

            if (selector is null)
            {
                return await query.ToListAsync();
            }

            return await query.Select(selector).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(IQueryable<TEntity> query, Expression<Func<TEntity, TEntity>> selector = null) where TEntity : Entity
        {
            if (selector is null)
            {
                return await query.ToListAsync();
            }
            return await query.Select(selector).ToListAsync();
        }

        public async Task<IEnumerable<TModel>> FindAllAsync<TEntity, TModel>(IQueryable<TEntity> query, Expression<Func<TEntity, TModel>> selector = null)
            where TEntity : Entity
            where TModel : class
        {
            return await query.Select(selector).ToListAsync();
        }

        public async Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> where = null, IEnumerable<string> includes = null) where TEntity : Entity
        {
            var query = AsQueryable<TEntity>(includes);
            return await query.Where(where).FirstOrDefaultAsync();
        }

        public async Task<TEntity> FindAsync<TEntity>(Guid id) where TEntity : Entity
        {
            return await AsQueryable<TEntity>().AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<TEntity> FindNewestAsync<TEntity>(IEnumerable<string> includes) where TEntity : Entity
        {
            var query = GetQueryable<TEntity>(includes);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FindAsync<TEntity>(Guid id, IEnumerable<string> includes = null) where TEntity : Entity
        {
            return await AsQueryable<TEntity>(includes).AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : Entity
        {
            return AsQueryable<TEntity>();
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChangeAsync();
        }

        public async Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entites) where TEntity : Entity
        {
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task<PagedResult<TEntity>> FindPagedAsync<TEntity>(IQueryable<TEntity> query, int? pageIndex = 1, int? pageSize = 20) where TEntity : Entity
        {
            query = query.AsNoTracking();

            pageIndex = pageIndex.Value <= 0 ? 1 : pageIndex;
            pageSize = pageSize.Value <= 0 ? 20 : pageSize;

            var total = await query.CountAsync();

            query = query.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            var data = await query.ToListAsync();
            return new PagedResult<TEntity>()
            {
                Items = data,
                PageIndex = pageIndex.Value,
                PageSize = pageSize.Value,
                TotalCount = total
            };
        }

        private IQueryable<TEntity> AsQueryable<TEntity>(IEnumerable<string> includes = null) where TEntity : Entity
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes?.Any() != true)
            {
                return query;
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public IQueryable<TEntity> GetQueryable<TEntity>(IEnumerable<string> includes) where TEntity : Entity
        {
            var query = GetQueryable<TEntity>();
            if (includes?.FirstOrDefault() != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : Entity
        {
            var query = GetQueryable<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.CountAsync();
        }

        public async Task<PagedResult<TModel>> FindPagedAsync<TEntity, TModel>(IQueryable<TEntity> query, Expression<Func<TEntity, TModel>> selector = null, int? pageIndex = 1, int? pageSize = 20)
            where TEntity : Entity
            where TModel : class
        {
            query = query.AsNoTracking();

            pageIndex = pageIndex.Value <= 0 ? 1 : pageIndex;
            pageSize = pageSize.Value <= 0 ? 20 : pageSize;

            var total = await query.CountAsync();

            query = query.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            var data = await query.Select(selector).ToListAsync();

            return new PagedResult<TModel>()
            {
                Items = data,
                PageIndex = pageIndex.Value,
                PageSize = pageSize.Value,
                TotalCount = total
            };
        }

        public async Task<TModel> FindAsync<TEntity, TModel>(Guid id, Expression<Func<TEntity, TModel>> selector = null, IEnumerable<string> includes = null)
            where TEntity : Entity
            where TModel : class
        {
            return await GetQueryable<TEntity>(includes).Where(x => x.Id.Equals(id))
                .Select(selector).FirstOrDefaultAsync();
        }
    }
}
