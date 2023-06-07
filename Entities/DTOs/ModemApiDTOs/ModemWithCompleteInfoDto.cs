using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.ModemApiDTOs
{
    public class ModemWithCompleteInfoDto:IDto
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public String ModelName { get; set; }
        public Guid BrandId { get; set; }
        public String BrandName { get; set; }
        public int SerialNo { get; set; }
    }
}
