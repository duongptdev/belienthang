using Microsoft.AspNetCore.Http;
using News.Core.Entities;
using System;
using System.Collections.Generic;

namespace News.Application.NewServices.Dtos
{
    public class NewDto
    {
        public Guid? Id { get; set; }

        public Guid CategoryId { get; set; }

        public DateTime? Date { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string? Category { get; set; }
    }

    public class EditNewViewModel : NewDto
    {
        public IEnumerable<Category> Categories { get; set; }
    }

    public class CategoryNewModel
    {
        public string Selector { get; set; } = string.Empty;

        public Category Category { get; set; }

        public IEnumerable<NewDto> News { get; set; }
    }

    public class CategoryDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}
