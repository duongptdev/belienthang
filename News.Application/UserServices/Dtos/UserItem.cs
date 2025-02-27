﻿using News.Core.Entities;
using News.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.UserServices.Dtos
{
    public class UserItem
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public EnumRole Role { get; set; }

        public string Image { get; set; }

        public string Phone { get; set; }

        public UserItem(User user)
        {
            Username = user.Username;
            Role = user.Role;
            Name = user.Name;
            Id = user.Id;
            if (!string.IsNullOrEmpty(user.Image))
            {
                Image = user.Image;
            }
            else
            {
                Image = "images";
            }
        }
    }
}
