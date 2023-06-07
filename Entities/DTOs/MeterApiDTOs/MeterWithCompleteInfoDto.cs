using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MeterApiDTOs
{
    public class MeterWithCompleteInfoDto:IDto
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string ModelName { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid ReadingTimeId { get; set; }
        public string ReadingTimeName { get; set; }
        public int SerialNo { get; set; }
    }
}
