using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace News.Core.Entities
{
    public class Category : Entity
    {
        [StringLength(400)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Thumbnail { get; set; }
        public string Status { get; set; }
    }
}
