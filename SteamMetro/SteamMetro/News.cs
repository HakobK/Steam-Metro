﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamMetro
{
    class News
    {
        public class Newsitem
        {
            public string gid { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public bool is_external_url { get; set; }
            public string author { get; set; }
            public string contents { get; set; }
            public string feedlabel { get; set; }
            public int date { get; set; }
            public string feedname { get; set; }
        }

        public class Appnews
        {
            public int appid { get; set; }
            public List<Newsitem> newsitems { get; set; }
        }
        public class rootClass
        {
            public Appnews appnews { get; set; }
        }

    }
}
