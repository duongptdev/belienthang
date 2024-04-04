using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.ViewModels
{
    public class SettingViewModel
    {
        public Setting Header { get; set; }

        public Setting Summary { get; set; }

        public Setting Footer { get; set; }
    }
}
