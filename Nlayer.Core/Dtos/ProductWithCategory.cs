﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Dtos
{
    public class ProductWithCategory:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}