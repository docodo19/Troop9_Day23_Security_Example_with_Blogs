using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDog.Models
{
    public class Blog : AuditObj
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
