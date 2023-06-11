using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.CustomerApi
{
    public class Customer : IEntity
    {
        public Guid Id { get; set; }
        public Guid? TransformerId { get; set; }
        public String Adress { get; set; }
        public int MeterId { get; set; }
        public String InstallReason { get; set; }
        public DateTime Date { get; set; }
        public String? GroupInfo { get; set; }
        public bool Status { get; set; }



    }
}
