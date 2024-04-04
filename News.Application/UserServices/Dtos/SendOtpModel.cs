using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.UserServices.Dtos
{
    public class SendOtpModel
    {
        public string Email { get; set; }

        public string? Password { get; set; }

        public string Phone { get; set; }
    }
}
