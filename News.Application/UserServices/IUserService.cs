using News.Application.UserServices.Dtos;
using News.Core.Entities;
using System;
using System.Threading.Tasks;

namespace News.Application.UserServices
{
    public interface IUserService
    {
        Task<UserItem> Authenticate(LoginModel model);
    }
}
