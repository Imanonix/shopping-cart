﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TopProducts
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
