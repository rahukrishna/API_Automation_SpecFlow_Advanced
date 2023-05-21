﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_SpecFlow.Models
{
    public class ListUserResponse
    {
        public int? page { get; set; }

        public int? per_page { get; set; }

        public int? total { get; set; }

        public int? total_pages { get; set; }

        public Data[]? data { get; set; }

        public class Data
        {
            public int? id { get; set; }
            public string? email { get; set; }
            public string? first_name { get; set; }
            public string? last_name { get; set; }
            public string? avatar { get; set; }

        }
    }
}
