using News.Application.Options;
using News.Application.UserServices.Dtos;
using News.Common;
using News.Core;
using News.Core.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace News.Application.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly AppOptions _options;
        private readonly IDistributedCache _cache;

        public UserService(IRepository repository,
            IDistributedCache cache,
            IOptions<AppOptions> options)
        {
            _cache = cache;
            _repository = repository;
            _options = options.Value;
        }

        public async Task<UserItem> Authenticate(LoginModel model)
        {
            string hashed = model.Password.ToHashedString(_options.Secret);
            Expression<Func<User, bool>> where = c => c.Username.Equals(model.UserName) && c.PasswordHash.Equals(hashed);
            var user = await _repository.FindAsync(where);
            if (user == null)
            {
                return default;
            }

            return new UserItem(user);
        }
    }
}
