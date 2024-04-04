using News.Application.NewServices.Dtos;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<CategoryNewModel> CategoryNews { get; set; }

        public IEnumerable<Setting> Settings { get; set; }

        public NewDto HomeNew { get; set; }
    }
}
