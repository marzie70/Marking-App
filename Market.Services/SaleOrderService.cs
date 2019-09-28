using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Contracts;
using Classes.Interfaces;

namespace Market.Services
{
    public class SaleOrderService
    {
        public ISaleOrderRepository ISaleOrderRepository { get; set; }


        public void CreateAndUpdateSaleOrder(SaleOrderContract saleOrderContract)
        {
            var saleorder = ISaleOrderRepository.Get(saleOrderContract.Id);
            if (saleorder != null)
            {

            }
            else
            {

            }
        }
    }
}
