using System;
using Classes;
using Classes.MappingClasses;
using Marketing_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestItem()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDItem = ItemId();
                    Item item = session.Get<Item>(IDItem);

                    //var item = new Item
                    //{
                    //    Code = "i1",
                    //    Name = "Laptop",
                    //    Unit = Unit.Kilo
                    //};
                    session.Save(item);
                    transaction.Commit();
                    var result1 = session.Get<Item>(item.Id);
                    Assert.IsNotNull(result1);
                    //Assert.AreEqual(item.Code, result1.Code);
                    //Assert.AreEqual(item.Name, result1.Name);
                    //Assert.AreEqual(item.Unit, result1.Unit);
                }
            }
        }



        public Guid ItemId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var item = new Item
                    {
                        Code = "i1",
                        Name = "Laptop",
                        Unit = Unit.Kilo
                    };
                    session.Save(item);
                    transaction.Commit();
                    var idItem = session.Get<Item>(item.Id);
                    return item.Id;
                }
            }
        }


        [TestMethod]
        public void TestRack()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDRack = RackId();
                    Rack rack = session.Get<Rack>(IDRack);
                    //var rack = new Rack
                    //{
                    //    Code = "r1",
                    //    Location = "row12",
                    //    Limit = "no",
                    //    Name = "electronic"
                    //};
                    rack.Racks.Add(rack);

                    session.Save(rack);
                    transaction.Commit();
                    var result2 = session.Get<Rack>(rack.Id);
                    Assert.IsNotNull(result2);
                    Assert.AreEqual(rack.Code, result2.Code);
                    //Assert.AreEqual(rack.Name, result2.Name);
                    //Assert.AreEqual(rack.Limit, result2.Limit);
                    //Assert.AreEqual(rack.Location, result2.Location);
                }
            }
        }



        public Guid RackId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var rack = new Rack
                    {
                        Code = "r1",
                        Location = "row12",
                        Limit = "no",
                        Name = "electronic"
                    };
                    session.Save(rack);
                    transaction.Commit();
                    var idRack = session.Get<Rack>(rack.Id);
                    return rack.Id;
                }
            }
        }



        [TestMethod]
        public void TestRackItemLevel()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDItem = ItemId();
                    Item item = session.Get<Item>(IDItem);

                    var IDRack = RackId();
                    Rack rack = session.Get<Rack>(IDItem);

                    var rackItemLevel = new RackItemLevel

                    {
                        CurrentQuantity = "o1",
                        InQuantity = "12/08/99",
                        OutQuantity = "orderOne",
                        Item = item,
                        Rack = rack
                    };
                    session.Save(rackItemLevel);
                    transaction.Commit();

                    var result3 = session.Get<RackItemLevel>(rackItemLevel.Id);
                    Assert.IsNotNull(session.Get<RackItemLevel>(rackItemLevel.Id));
                    Assert.AreEqual(rackItemLevel.Id, result3.Id);
                    Assert.AreEqual(rackItemLevel.CurrentQuantity, result3.CurrentQuantity);
                    Assert.AreEqual(rackItemLevel.InQuantity, result3.InQuantity);
                }
            }
        }


        [TestMethod]
        public Guid SaleOrderItemId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDItem = ItemId();
                    Item item = session.Get<Item>(IDItem);

                    var IDRack = RackId();
                    Rack rack = session.Get<Rack>(IDRack);

                    var saleOrderItem = new SaleOrderItem
                    {
                        NetPrice = "12",
                        Quantity = "43",
                        TotalPrice = "67",
                        UnitPrice = "67",
                        Rack = rack,
                        Item = item
                    };
                    session.Save(saleOrderItem);
                    transaction.Commit();
                    var idItem = session.Get<SaleOrderItem>(saleOrderItem.Id);
                    return saleOrderItem.Id;
                }
            }
        }

        [TestMethod]
        public void TestSaleOrder()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDItem = ItemId();
                    Item item = session.Get<Item>(IDItem);

                    var IDRack = RackId();
                    Rack rack = session.Get<Rack>(IDRack);

                    var IDSaleOrderItem = SaleOrderItemId();
                    SaleOrderItem saleorderitem = session.Get<SaleOrderItem>(IDSaleOrderItem);

                    var saleOrder = new SaleOrder
                    {
                        Code = "30",
                        CreationDate = DateTime.Now,
                        Title = "450"
                    };

                    saleOrder.saleOrderItems.Add(saleorderitem);
                    session.Save(saleOrder);
                    transaction.Commit();
                    var result4 = session.Get<SaleOrder>(saleOrder.Id);
                    Assert.AreEqual(saleOrder.Code, result4.Code);
                    Assert.AreEqual(saleOrder.CreationDate, result4.CreationDate);
                    Assert.AreEqual(saleOrder.Title, result4.Title);
                }
            }
        }


        [TestMethod]
        public Guid PurchaseOrderItemId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDItem = ItemId();
                    Item item = session.Get<Item>(IDItem);

                    var IDRack = RackId();
                    Rack rack = session.Get<Rack>(IDRack);

                    var purchaseOrderItem = new PurchaseOrderItem()
                    {
                        NetPrice = "12",
                        Quantity = "43",
                        TotalPrice = "67",
                        UnitPrice = "67",
                        Rack = rack,
                        Item = item
                    };
                    session.Save(purchaseOrderItem);
                    transaction.Commit();
                    var idItem = session.Get<PurchaseOrderItem>(purchaseOrderItem.Id);
                    return purchaseOrderItem.Id;
                }
            }
        }

        [TestMethod]
        public void TestPurchaseOrder()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //var IDItem = ItemId();
                    //Item item = session.Get<Item>(IDItem);

                    //var IDRack = RackId();
                    //Rack rack = session.Get<Rack>(IDRack);

                    var IDPurchaseOrderItem = PurchaseOrderItemId();
                    PurchaseOrderItem purchaseorderitem = session.Get<PurchaseOrderItem>(IDPurchaseOrderItem);

                    var purchaseOrder = new PurchaseOrder
                    {
                        Code = "30",
                        CreationDate = DateTime.Now,
                        Title = "450"
                    };

                    purchaseOrder.purchaseOrderItems.Add(purchaseorderitem);
                    session.Save(purchaseOrder);
                    transaction.Commit();
                    var result5 = session.Get<PurchaseOrder>(purchaseOrder.Id);
                    Assert.IsNotNull(result5);
                    //Assert.AreEqual(purchaseOrder.Code, result5.Code);
                    //Assert.AreEqual(purchaseOrder.CreationDate, result5.CreationDate);
                    //Assert.AreEqual(purchaseOrder.Title, result5.Title);
                }
            }
        }
    }
}

