using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Models.ModemApi
{
    public class ModemModel:IEntity
    {
        public Guid Id { get;  set; }
        public Guid BrandId { get;  set; }
        public String Name { get;  set; }
    }
}
