using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Contracts
{
    public class RackContract
    {
        public Guid Id { get; set; }
        public Guid RackId { get; set; }
        public string Code { get; set; }
        public string Limit { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
    }
}
