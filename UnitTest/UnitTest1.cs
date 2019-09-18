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
        public void TestMethod1()
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
                    var result1 = session.Get<Item>(item.Id);
                    Assert.AreEqual(item.Code, result1.Code);
                    Assert.AreEqual(item.Name, result1.Name);
                    Assert.AreEqual(item.Unit, result1.Unit);
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
        public void TestMethod2()
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
                    rack.Racks.Add(rack);

                    session.Save(rack);
                    transaction.Commit();
                    var result2 = session.Get<Rack>(rack.Id);
                    Assert.AreEqual(rack.Code, result2.Code);
                    Assert.AreEqual(rack.Name, result2.Name);
                    Assert.AreEqual(rack.Limit, result2.Limit);
                    Assert.AreEqual(rack.Location, result2.Location);
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
                    var purchaseOrder = new PurchaseOrder
                    {
                        Code = "30",
                        CreationDate = "200",
                        Title = "450"
                    };
                    session.Save(purchaseOrder);
                    transaction.Commit();
                    var result3 = session.Get<Order>(purchaseOrder.Id);
                    Assert.AreEqual(purchaseOrder.Code, result3.Code);
                    Assert.AreEqual(purchaseOrder.CreationDate, result3.CreationDate);
                    Assert.AreEqual(purchaseOrder.Title, result3.Title);
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
                    Rack rack = session.Get<Rack>(IDItem);

                    var purchaseOrder = new PurchaseOrder

                    {
                        Code = "o1",
                        CreationDate = "12/08/99",
                        Title = "orderOne"
                    };
                    purchaseOrder.OrderItems.Add(orderItem);
                    session.Save(purchaseOrder);
                    transaction.Commit();

                    var result4 = session.Get<PurchaseOrder>(purchaseOrder.Id);
                    Assert.AreEqual(purchaseOrder.Id, result4.Id);
                    Assert.AreEqual(purchaseOrder.CreationDate, result4.CreationDate);
                    Assert.AreEqual(purchaseOrder.Title, result4.Title);
                }
            }

        }

        [TestMethod]
        public void TestMethod5()
        {

        }
    }
}





//var rack = new Rack
//{
//    Code = "r1",
//    Location = "row12",
//    Limit = "no",
//    Name = "electronic"
//};
//rack.Racks.Add(rack);

//var orderItem = new OrderItem
//{
//    NetPrice = "30",
//    Quantity = "200",
//    TotalPrice = "450",
//    UnitPrice = "90",
//    Rack = rack,
//    Item = item
//};

//var order = new Order

//{
//    Code = "o1",
//    CreationDate = "12/08/99",
//    Title = "orderOne"
//};
//order.OrderItems.Add(orderItem);

//var rackItemLevel = new RackItemLevel
//{
//    CurrentQuantity = "4",
//    InQuantity = "9",
//    OutQuantity = "5",
//    Item = item,
//    Rack = rack
//};


//session.Save(rack); /* save both(rack)*/
//session.Save(item);
// session.Save(rackItemLevel);
//session.Save(order); /* save both(order,orderitem)*/
//transaction.Commit();

//var result1 = session.Get<Item>(item.Id);
//Assert.AreEqual(item.Code, result1.Code);
//Assert.AreEqual(item.Name, result1.Name);
//Assert.AreEqual(item.Unit, result1.Unit);

//var result2 = session.Get<Rack>(rack.Id);
//Assert.AreEqual(rack.Code, result2.Code);
//Assert.AreEqual(rack.Name, result2.Name);
//Assert.AreEqual(rack.Limit, result2.Limit);
//Assert.AreEqual(rack.Location, result2.Location);

//var result3 = session.Get<OrderItem>(orderItem.Id);
//Assert.AreEqual(orderItem.NetPrice, result3.NetPrice);
//Assert.AreEqual(orderItem.Quantity, result3.Quantity);
//Assert.AreEqual(orderItem.TotalPrice, result3.TotalPrice);
//Assert.AreEqual(orderItem.UnitPrice, result3.UnitPrice);

//var result4 = session.Get<Order>(order.Id);
//Assert.AreEqual(order.Id, result4.Id);
//Assert.AreEqual(order.CreationDate, result4.CreationDate);
//Assert.AreEqual(order.Title, result4.Title);

//var result5 = session.Get<RackItemLevel>(rackItemLevel.Id);
//Assert.AreEqual(rackItemLevel.CurrentQuantity, result5.CurrentQuantity);
//Assert.AreEqual(rackItemLevel.InQuantity, result5.InQuantity);
//Assert.AreEqual(rackItemLevel.OutQuantity, result5.OutQuantity);

//                }
//            }
//        }
//        [TestMethod]
//        public void SavingRackTest()
//        {
//            using (var session = NHibernateHelper.OpenSession())
//            {
//                using (var transaction = session.BeginTransaction())
//                {
//                    var item = new Rack
//                    {
//                        Code = "i1",
//                        Name = "Laptop",
//                        Unit = Unit.Kilo
//                    };
//    }
//}
//var item = new Item
//{
//Code = "i1",
//Name = "Laptop",
//Unit = Unit.Kilo
//};
//session.Save(item);

//var rack = new Rack
//{
//Code = "r1",
//Location = "row12",
//Limit = "no",
//Name = "electronic"
//};
//rack.Racks.Add(rack);
//session.Save(rack);