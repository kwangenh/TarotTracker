﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ReadingType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }        
    }
}
