using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Interfaces;
using Classes.Contracts;
using Classes.MappingClasses;

namespace Market.Services
{
    public class ItemService
    {
        public IItemRepository IItemRepository { get; set; }


        public void SaveCreateOrUpdate(ItemContract itemContract)
        {
            var item = IItemRepository.Get(itemContract.Id);
            if (item != null)
            {
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                IItemRepository.Update(item);
            }
            else
            {
                //hamatun iq hastin koshtin mano be bagiam bnegu chon momken koshte farzi bedin
                item = new Item();
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                IItemRepository.Insert(item);
            }

        }
    }
}
