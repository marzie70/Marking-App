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
        public void TestMethod3()
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

                    var result4 = session.Get<RackItemLevel>(rackItemLevel.Id);
                    Assert.IsNotNull(session.Get<RackItemLevel>(rackItemLevel.Id));
                    Assert.AreEqual(rackItemLevel.Id, result4.Id);
                    Assert.AreEqual(rackItemLevel.CurrentQuantity, result4.CurrentQuantity);
                    Assert.AreEqual(rackItemLevel.InQuantity, result4.InQuantity);
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
        public void TestMethod4()
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
                        CreationDate = "200",
                        Title = "450"
                    };
                    //var purchaseOrderItem = new PurchaseOrderItem
                    //{
                    //    NetPrice = "12",
                    //    Quantity = "43",
                    //    TotalPrice = "67",
                    //    UnitPrice = "67",
                    //    Rack = rack,
                    //    Item = item
                    //};

                    saleOrder.saleOrderItems.Add(saleorderitem);
                    session.Save(saleOrder);
                    transaction.Commit();
                    var result3 = session.Get<SaleOrder>(saleOrder.Id);
                    Assert.AreEqual(saleOrder.Code, result3.Code);
                    Assert.AreEqual(saleOrder.CreationDate, result3.CreationDate);
                    Assert.AreEqual(saleOrder.Title, result3.Title);
                }
            }
        }

        public void TestMethod5()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var IDItem = ItemId();
                    Item item = session.Get<Item>(IDItem);

                    var IDRack = RackId();
                    Rack rack = session.Get<Rack>(IDItem);

                    var saleOrder = new SaleOrder
                    {
                        Code = "30",
                        CreationDate = "200",
                        Title = "450"
                    };
                    var saleOrderItem = new SaleOrderItem
                    {
                        NetPrice = "12",
                        Quantity = "43",
                        TotalPrice = "67",
                        UnitPrice = "67",
                        Rack = rack,
                        Item = item
                    };

                    saleOrder.saleOrderItems.Add(saleOrderItem);
                    session.Save(saleOrder);
                    transaction.Commit();
                    var result5 = session.Get<SaleOrder>(saleOrder.Id);
                    Assert.AreEqual(saleOrder.Code, result5.Code);
                    Assert.AreEqual(saleOrder.CreationDate, result5.CreationDate);
                    Assert.AreEqual(saleOrder.Title, result5.Title);
                }
            }
        }
    }
}

