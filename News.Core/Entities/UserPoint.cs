using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core.Entities
{
    public class UserPoint
    {
        public string UserID { get; set; }
        public int AvailabilityPoint { get; set; }
        public int BlockPoint { get; set; }
        public string Status { get; set; }
    }
}
