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
    public class RackItemLevelService
    {
        public IRackItemLevelRepository IRackItemLevelRepository { get; set; }
        public IRackRepository RackRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }

        public void CreateAndUpdateRackItemLevel(RackItemLevelContract rackItemLevelContract)
        {
            var rackeitemlevel = IRackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackeitemlevel != null)
            {
                //rackeitemlevel.Rack = rackItemLevelContract.RackId;
                rackeitemlevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackeitemlevel.InQuantity = rackItemLevelContract.InQuantity;
                rackeitemlevel.OutQuantity = rackItemLevelContract.OutQuantity;
                rackeitemlevel.Rack = RackRepository.Get(rackItemLevelContract.RackId);
                rackeitemlevel.Item = ItemRepository.Get(rackItemLevelContract.ItemId);

                IRackItemLevelRepository.Update(rackeitemlevel);

            }
            else
            {
                ///halallllllllllllllllllll boro bebnam
                rackeitemlevel = new RackItemLevel();
                rackeitemlevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackeitemlevel.InQuantity = rackItemLevelContract.InQuantity;
                rackeitemlevel.OutQuantity = rackItemLevelContract.OutQuantity;

                IRackItemLevelRepository.Insert(rackeitemlevel);
            }
        }
    }
}
