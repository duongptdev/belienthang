using System;
using System.Collections.Generic;
using System.Text;

namespace News.Core.Entities
{
    public class UserProduct
    {
        public string UserID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public string ProductAmount { get; set; }
        public string DiscountPrice { get; set; }
        public string ListedPrice { get; set; }
        public string VolumnSending { get; set; }
    }
}
