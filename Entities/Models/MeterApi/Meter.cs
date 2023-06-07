using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.MeterApi
{
    public class Meter : IEntity
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public Guid ReadingTimeId { get; set; }

        public int SerialNo { get; set; }

    }
}
