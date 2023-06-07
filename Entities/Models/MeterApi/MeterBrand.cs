﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.MeterApi
{
    public class MeterBrand : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
