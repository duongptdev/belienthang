using News.Core.Entities;
using News.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace News.Application.UserServices.Dtos
{
    public class CreateUserModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }

    public class UpdateUserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public Guid? CityId { get; set; }

        public string? IdentityFront { get; set; }

        public string? IdentityBack { get; set; }
    }
}
