using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class ReadingConsumptionDto:IDto
    {
        public int Obis000 { get; set; }
        public List<ReadingConsumption> Consumptions { get; set; }
    }
    public class ReadingConsumption
    {
        public DateTime Date { get; set; }
        public decimal TotalConsumption { get; set; }
    }
}
