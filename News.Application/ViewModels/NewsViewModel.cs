using News.Application.NewServices.Dtos;
using News.Common;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public PagedResult<NewDto> News { get; set; }
    }
}
