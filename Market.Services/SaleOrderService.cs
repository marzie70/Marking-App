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
    public class SaleOrderService
    {
        public ISaleOrderRepository ISaleOrderRepository { get; set; }
        public IItemRepository IItemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }

        public void CreateAndUpdateSaleOrder(SaleOrderContract saleOrderContract)
        {
            var saleorder = ISaleOrderRepository.Get(saleOrderContract.Id);

            if (saleorder != null)
            {
                saleorder.Code = saleOrderContract.Code;
                //saleorder.CreationDate = saleOrderContract.CreationDate; lazem nist moghe sakht object bevojode amede mesl Id
                saleorder.Title = saleOrderContract.Title;
                for (int i = 0; i < saleOrderContract.SaleOrderItemContracts.Count; i++)
                {
                    var Temp = saleOrderContract.SaleOrderItemContracts[i];
                    if (saleorder.saleOrderItems.Any(s => s.Id == Temp.Id))
                    {
                        var Insaleorderitem = saleorder.saleOrderItems.FirstOrDefault(s => s.Id == Temp.Id);
                        Insaleorderitem.NetPrice = Temp.NetPrice;
                        Insaleorderitem.Quantity = Temp.Quantity;
                        Insaleorderitem.TotalPrice = Temp.TotalPrice;
                        Insaleorderitem.UnitPrice = Temp.UnitPrice;
                        Insaleorderitem.Rack = IRackRepository.Get(Temp.RackId);
                        Insaleorderitem.Item = IItemRepository.Get(Temp.ItemId);
                    }
                    else
                    {
                        Insaleorderitem = new SaleOrderItem();
                        Insaleorderitem.NetPrice = Temp.NetPrice;
                        Insaleorderitem.Quantity = Temp.Quantity;
                        Insaleorderitem.TotalPrice = Temp.TotalPrice;
                        Insaleorderitem.UnitPrice = Temp.UnitPrice;
                        Insaleorderitem.Rack = IRackRepository.Get(Temp.RackId);
                        Insaleorderitem.Item = IItemRepository.Get(Temp.ItemId);


                        saleorder.saleOrderItems.Add(Insaleorderitem);

                    }

                }
                //var DeleteOrderItem = saleorder.saleOrderItems.Where(x =>
                //    !saleOrderContract.SaleOrderItemContracts.Any(y => y.Id == x.Id));
                for (int i = 0; i < saleorder.saleOrderItems.Count; i++)
                {

                    var Temp = saleorder.saleOrderItems.ToArray()[i];
                    if (!saleOrderContract.SaleOrderItemContracts.Any(s => s.Id == Temp.Id))
                    {
                        saleorder.saleOrderItems.Remove(Temp);
                        //var temp = ISaleOrderRepository.Get(Temp.Id);
                        //ISaleOrderRepository.Delete(temp);
                    }

                }

                ISaleOrderRepository.Update(saleorder);
            }
            else
            {
                saleorder = new SaleOrder();
                saleorder.Code = saleOrderContract.Code;
                saleorder.CreationDate = saleOrderContract.CreationDate;
                saleorder.Title = saleOrderContract.Title;
                for (int i = 0; i < saleOrderContract.SaleOrderItemContracts.Count; i++)
                {
                    var Temp = saleOrderContract.SaleOrderItemContracts[i];
                    Insaleorderitem = new SaleOrderItem();
                    Insaleorderitem.NetPrice = Temp.NetPrice;
                    Insaleorderitem.Quantity = Temp.Quantity;
                    Insaleorderitem.TotalPrice = Temp.TotalPrice;
                    Insaleorderitem.UnitPrice = Temp.UnitPrice;
                    Insaleorderitem.Rack = IRackRepository.Get(Temp.RackId);
                    Insaleorderitem.Item = IItemRepository.Get(Temp.ItemId);


                    saleorder.saleOrderItems.Add(Insaleorderitem);
                }



                ISaleOrderRepository.Insert(saleorder);

            }
        }

        public void DeleteSaleOrder(SaleOrderContract saleOrderContract)
        {
            var saleorder = ISaleOrderRepository.Get(saleOrderContract.Id);
            ISaleOrderRepository.Delete(saleorder);
        }

        public SaleOrderItem Insaleorderitem { get; set; }
    }
}
