﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities.Concrete
{
    public class PriceListDetail
    {
        public int Id { get; set; }
        public int PriceListId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
