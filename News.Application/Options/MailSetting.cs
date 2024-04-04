using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.Options
{
    public class MailSetting
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string From { get; set; }
    }
}
