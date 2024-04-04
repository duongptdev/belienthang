using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.SettingServices.Dtos
{
    public class SettingDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string ValueFirst { get; set; }

        public string TextFirst { get; set; }

        public string ValueSecond { get; set; }

        public string TextSecond { get; set; }

        public string ValueThird { get; set; }

        public string TextThird { get; set; }
    }
}
