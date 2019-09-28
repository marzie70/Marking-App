using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Contracts
{
    public class RackItemLevelContract
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }
        //todo other property
        public string CurrentQuantity { get; set; }
        public string InQuantity { get; set; }
        public string OutQuantity { get; set; }

    }
}
