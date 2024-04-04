using System;
using System.Collections.Generic;
using System.Text;

namespace News.Application.Options
{
    public class JwtOption
    {
        public string Secret { get; set; }

        public int ExpireIn { get; set; }
    }
}
