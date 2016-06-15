using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDog.Models
{
    abstract public class AuditObj
    {
        public bool IsActive { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
