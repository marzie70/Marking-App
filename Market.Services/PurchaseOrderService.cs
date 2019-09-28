using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Contracts;
using Classes.Interfaces;

namespace Market.Services
{
    public class PurchaseOrderService
    {
        public IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }

        public void CreateAndUpdatePurchaseOrder(PurchaseOrderContract purchaseOrderContract)
        {
            var purchaseorder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);
            if (purchaseorder != null)
            {

            }
            else
            {

            }
        }
    }
}
