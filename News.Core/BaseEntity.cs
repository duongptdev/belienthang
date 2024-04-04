using System;
using System.Collections.Generic;
using System.Text;

namespace News.Core
{
    public class Entity
    {
        public Guid Id { get; set; }

        public string SearchParams { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
