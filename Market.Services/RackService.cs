using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Contracts;
using Classes.Interfaces;
using Classes.MappingClasses;

namespace Market.Services
{
    public class RackService
    {
        public IRackRepository IRackRepository { get; set; }

        public void CreateAndUpdateRack(RackContract rackContract)
        {
            var rack = IRackRepository.Get(rackContract.Id);
            if (rack != null)
            {
                rack.Location = rackContract.Location;
                rack.Code = rackContract.Code;
                rack.Limit = rackContract.Limit;
                rack.Name = rackContract.Name;
                rack.RacksRack = IRackRepository.Get(rackContract.RackId);

                IRackRepository.Update(rack);

            }
            else
            {
                rack = new Rack();
                rack.Location = rackContract.Location;
                rack.Code = rackContract.Code;
                rack.Limit = rackContract.Limit;
                rack.Name = rackContract.Name;

                IRackRepository.Insert(rack);
            }
        }

    }
}
