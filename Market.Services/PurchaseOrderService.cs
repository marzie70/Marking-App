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
    public class PurchaseOrderService
    {
        public IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }
        public IItemRepository IItemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }

        public void CreateAndUpdatePurchaseOrder(PurchaseOrderContract purchaseOrderContract)
        {
            var purchaseorder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);
            if (purchaseorder != null)
            {
                purchaseorder.Code = purchaseOrderContract.Code;
                //purchaseorder.CreationDate = purchaseOrderContract.CreationDate;
                purchaseorder.Title = purchaseOrderContract.Title;
                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItemContracts.Count; i++)
                {
                    var Temp = purchaseOrderContract.PurchaseOrderItemContracts[i];
                    if (purchaseorder.purchaseOrderItems.Any(s => s.Id == Temp.Id))
                    {
                        var Inpurchaseorderitem = purchaseorder.purchaseOrderItems.FirstOrDefault(s => s.Id == Temp.Id);
                        Inpurchaseorderitem.NetPrice = Temp.NetPrice;
                        Inpurchaseorderitem.Quantity = Temp.Quantity;
                        Inpurchaseorderitem.TotalPrice = Temp.TotalPrice;
                        Inpurchaseorderitem.UnitPrice = Temp.UnitPrice;
                        Inpurchaseorderitem.Rack = IRackRepository.Get(Temp.RackId);
                        Inpurchaseorderitem.Item = IItemRepository.Get(Temp.ItemId);
                    }
                    else
                    {
                        Inpurchaseorderitem = new PurchaseOrderItem();
                        Inpurchaseorderitem.NetPrice = Temp.NetPrice;
                        Inpurchaseorderitem.Quantity = Temp.Quantity;
                        Inpurchaseorderitem.TotalPrice = Temp.TotalPrice;
                        Inpurchaseorderitem.UnitPrice = Temp.UnitPrice;
                        Inpurchaseorderitem.Rack = IRackRepository.Get(Temp.RackId);
                        Inpurchaseorderitem.Item = IItemRepository.Get(Temp.ItemId);


                        purchaseorder.purchaseOrderItems.Add(Inpurchaseorderitem);
                    }
                }

                for (int i = 0; i < purchaseorder.purchaseOrderItems.Count; i++)
                {
                    var Temp = purchaseorder.purchaseOrderItems.ToArray()[i];
                    if (!purchaseOrderContract.PurchaseOrderItemContracts.Any(s => s.Id == Temp.Id))
                    {
                        purchaseorder.purchaseOrderItems.Remove(Temp);
                    }

                }

                IPurchaseOrderRepository.Update(purchaseorder);

            }
            else
            {
                purchaseorder = new PurchaseOrder();
                purchaseorder.Code = purchaseOrderContract.Code;
                purchaseorder.CreationDate = purchaseOrderContract.CreationDate;
                purchaseorder.Title = purchaseOrderContract.Title;
                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItemContracts.Count; i++)
                {
                    var Temp = purchaseOrderContract.PurchaseOrderItemContracts[i];
                    Inpurchaseorderitem = new PurchaseOrderItem();
                    Inpurchaseorderitem.NetPrice = Temp.NetPrice;
                    Inpurchaseorderitem.Quantity = Temp.Quantity;
                    Inpurchaseorderitem.TotalPrice = Temp.TotalPrice;
                    Inpurchaseorderitem.UnitPrice = Temp.UnitPrice;
                    Inpurchaseorderitem.Item = IItemRepository.Get(Temp.ItemId);
                    Inpurchaseorderitem.Rack = IRackRepository.Get(Temp.RackId);

                }
            }


            IPurchaseOrderRepository.Insert(purchaseorder);

        }

        public PurchaseOrderItem Inpurchaseorderitem { get; set; }
    }
}

