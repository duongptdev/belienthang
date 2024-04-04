using News.Application.NewServices.Dtos;
using News.Core.Entities;
using System.Collections.Generic;

namespace News.Application.ViewModels
{
    public class DetailViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public NewDto News { get; set; }
    }
}
