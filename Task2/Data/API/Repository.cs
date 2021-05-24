using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public class Repository : IRepository
    {
        public IBuyer Transform(Buyers Buyer)
        {
            return new Buyer(Buyer.name, Buyer.surname, Buyer.id, Buyer.phone);
        }
        public IProduct Transform(Products Product)
        {
            return new Product(Product.id, Product.name, Product.model, Product.price, Product.size, Product.producer, Product.season, Product.quantity);
        }
        public IOrder Transform(Orders Order)
        {
            return new Order(Order.id, Order.buyer_id, Order.product_id, Order.is_payed);
        }
        public IEvent Transform(Events Event)
        {
            return new Event(Event.id, Event.date, Event.order_id, Event.type, Event.description);
        }
        public IEnumerable<IBuyer> GetBuyers()
        {
            using (var context = new ShopDataContext())
            {
                List<IBuyer> list = new List<IBuyer>();
                context.Buyers.ToList();
                foreach (Buyers Buyer in context.Buyers.ToList())
                {
                    list.Add(Transform(Buyer));
                }
                return list;
            }
        }

        public IBuyer GetBuyer(string Phone)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Buyers Buyer in context.Buyers.ToList())
                {
                    if (Buyer.phone.Equals(Phone))
                    {
                        return Transform(Buyer);
                    }
                }
                return null;
            }
        }

        public bool AddBuyer(string Name, string Surname, string Phone)
        {
            using (var context = new ShopDataContext())
            {
                if (GetBuyer(Phone) == null && !Name.Equals(null) && !Surname.Equals(null) && !Phone.Equals(null))
                {
                    Buyers NewBuyer = new Buyers
                    {
                        name = Name,
                        surname = Surname,
                        phone = Phone
                    };
                    context.Buyers.InsertOnSubmit(NewBuyer);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBuyer(int id, string Name, string Surname, string Phone)
        {
            using (var context = new ShopDataContext())
            {
                Buyers Buyer = context.Buyers.SingleOrDefault(i => i.phone == Phone);
                if (GetBuyer(Phone) != null && !Name.Equals(null) && !Surname.Equals(null) && !Phone.Equals(null))
                {
                    Buyer.name = Name;
                    Buyer.surname = Surname;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteBuyer(string Phone)
        {
            using (var context = new ShopDataContext())
            {
                Buyers Buyer = context.Buyers.SingleOrDefault(i => i.phone == Phone);
                if (GetBuyer(Phone) != null && !Phone.Equals(null))
                {
                    context.Buyers.DeleteOnSubmit(Buyer);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public IEnumerable<IProduct> GetProducts()
        {
            using (var context = new ShopDataContext())
            {
                List<IProduct> list = new List<IProduct>();
                context.Products.ToList();
                foreach (Products Product in context.Products.ToList())
                {
                    list.Add(Transform(Product));
                }
                return list;
            }
        }

        public IProduct GetProductById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Products Product in context.Products.ToList())
                {
                    if (Product.id.Equals(id))
                    {
                        return Transform(Product);
                    }
                }
                return null;
            }
        }

        public IEnumerable<IProduct> GetProductByName(string name)
        {
            using (var context = new ShopDataContext())
            {
                List<IProduct> list = new List<IProduct>();
                context.Products.ToList();
                foreach (Products Product in context.Products.ToList())
                {
                    if (Product.name.Equals(name))
                    {
                        list.Add(Transform(Product));
                    }
                }
                return list;
            }
        }

        public IProduct GetProductByModel(string model)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Products Product in context.Products.ToList())
                {
                    if (Product.model.Equals(model))
                    {
                        return Transform(Product);
                    }
                }
                return null;
            }
        }
        public bool AddProduct(string name, string model, float price, int size, string producer, string season, int quantity)
        {
            using (var context = new ShopDataContext())
            {
                if (GetProductByModel(model) == null && !name.Equals(null) && !model.Equals(null) && !price.Equals(null) && !size.Equals(null) && !season.Equals(null) && !quantity.Equals(null))
                {
                    Products NewProduct = new Products
                    {
                        name = name,
                        model = model,
                        price = price,
                        size = size,
                        producer = producer,
                        season = season,
                        quantity = quantity,
                    };
                    context.Products.InsertOnSubmit(NewProduct);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateProduct(int id, string name, string model, float price, int size, string producer, string season, int quantity)
        {
            using (var context = new ShopDataContext())
            {
                Products Product = context.Products.SingleOrDefault(i => i.id == id);
                if (!name.Equals(null) && !model.Equals(null) && !price.Equals(null) && !size.Equals(null) && !producer.Equals(null) && !season.Equals(null) && !quantity.Equals(null))
                {
                    Product.name = name;
                    Product.model = model;
                    Product.price = price;
                    Product.size = size;
                    Product.producer = producer;
                    Product.season = season;
                    Product.quantity = quantity;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateProductQuantity(int id, int quantity)
        {
            using (var context = new ShopDataContext())
            {
                Products Product = context.Products.SingleOrDefault(i => i.id == id);
                if (!quantity.Equals(null))
                {
                    Product.quantity = quantity;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var context = new ShopDataContext())
            {
                Products Product = context.Products.SingleOrDefault(i => i.id == id);
                if (GetProductById(id) != null && !id.Equals(null))
                {
                    context.Products.DeleteOnSubmit(Product);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<IOrder> GetOrders()
        {
            using (var context = new ShopDataContext())
            {
                List<IOrder> list = new List<IOrder>();
                context.Orders.ToList();
                foreach (Orders Order in context.Orders.ToList())
                {
                    list.Add(Transform(Order));
                }
                return list;
            }
        }

        public IOrder GetOrderById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Orders Order in context.Orders.ToList())
                {
                    if (Order.id.Equals(id))
                    {
                        return Transform(Order);
                    }
                }
                return null;
            }
        }

        public IOrder GetLatestOrderByProductAndBuyer(int product_id, int buyer_id)
        {
            using (var context = new ShopDataContext())
            {

                foreach (Orders Order in context.Orders.ToList().OrderByDescending(p => p.id))
                {
                    if (Order.product_id.Equals(product_id) && Order.buyer_id.Equals(buyer_id))
                    {
                        return Transform(Order);
                    }
                }
                return null;
            }
        }

        public IEnumerable<IOrder> GetOrdersByProductId(int product_id)
        {
            using (var context = new ShopDataContext())
            {
                List<IOrder> result = new List<IOrder>();
                foreach (Orders Order in context.Orders.ToList())
                {
                    if (Order.product_id.Equals(product_id))
                    {
                        result.Add(Transform(Order));
                    }
                }
                return result;
            }
        }

        public bool AddOrder(int product_id, int buyer_id, bool is_payed, string event_description)
        {
            using (var context = new ShopDataContext())
            {
                if (!product_id.Equals(null) && !buyer_id.Equals(null) && !is_payed.Equals(null))
                {
                    Orders NewOrder = new Orders
                    {
                        product_id = product_id,
                        buyer_id = buyer_id,
                        is_payed = is_payed,
                    };
                    context.Orders.InsertOnSubmit(NewOrder);
                    context.SubmitChanges();


                    DateTime dateTime = DateTime.Now;

                    return AddEvent(dateTime, GetLatestOrderByProductAndBuyer(product_id, buyer_id).ID, "orderEvent", event_description);
                }
                return false;
            }
        }

        public bool UpdateOrder(int id, int buyer_id)
        {
            using (var context = new ShopDataContext())
            {
                Orders Order = context.Orders.SingleOrDefault(i => i.id == id);
                if (!buyer_id.Equals(null))
                {
                    Order.buyer_id = buyer_id;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            using (var context = new ShopDataContext())
            {
                Orders Order = context.Orders.SingleOrDefault(i => i.id == id);
                if (GetOrderById(id) != null && !id.Equals(null))
                {
                    context.Orders.DeleteOnSubmit(Order);
                    List<IEvent> events = (List<IEvent>) GetEventsByOrderId(id);
                    foreach (IEvent item in events)
                    {
                        DeleteEvent(item.ID);
                    }
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<IEvent> GetEvents()
        {
            using (var context = new ShopDataContext())
            {
                List<IEvent> list = new List<IEvent>();
                context.Events.ToList();
                foreach (Events Event in context.Events.ToList())
                {
                    list.Add(Transform(Event));
                }
                return list;
            }
        }

        public IEvent GetEventById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Events Event in context.Events.ToList())
                {
                    if (Event.id.Equals(id))
                    {
                        return Transform(Event);
                    }
                }
                return null;
            }
        }

        public IEnumerable<IEvent> GetEventsByOrderId(int order_id)
        {
            using (var context = new ShopDataContext())
            {
                List<IEvent> list = new List<IEvent>();
                foreach (Events Event in context.Events.ToList())
                {
                    if (Event.order_id.Equals(order_id))
                    {
                        list.Add(Transform(Event));
                    }
                }
                return list;
            }
        }

        public bool AddEvent(DateTime date, int order_id, string type, string description)
        {
            using (var context = new ShopDataContext())
            {
                if (!date.Equals(null) && !order_id.Equals(null) && !type.Equals(null) && !description.Equals(null))
                {
                    if (type == "orderEvent")
                    {
                        if (GetEventsByOrderId(order_id).Count() == 0)
                        {
                            Orders Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                            Products Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);
                            if (Product.quantity > 0)
                            {
                                Product.quantity -= 1;

                                Events NewEvent = new Events
                                {
                                    date = date,
                                    order_id = order_id,
                                    type = type,
                                    description = description,
                                };
                                context.Events.InsertOnSubmit(NewEvent);
                                context.SubmitChanges();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (type == "returnEvent")
                    {
                        Orders Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                        Products Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);

                        Product.quantity += 1;

                        Events NewEvent = new Events
                        {
                            date = date,
                            order_id = order_id,
                            type = type,
                            description = description,
                        };
                        context.Events.InsertOnSubmit(NewEvent);
                        context.SubmitChanges();
                        return true;
                    }
                    if (type == "complainEvent")
                    {
                        Orders Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                        Products Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);

                        Events NewEvent = new Events
                        {
                            date = date,
                            order_id = order_id,
                            type = type,
                            description = description,
                        };
                        context.Events.InsertOnSubmit(NewEvent);
                        context.SubmitChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        public bool UpdateEvent(int id, string description)
        {
            using (var context = new ShopDataContext())
            {
                Events Event = context.Events.SingleOrDefault(i => i.id == id);
                if (!description.Equals(null))
                {
                    Event.description = description;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteEvent(int id)
        {
            using (var context = new ShopDataContext())
            {
                Events Event = context.Events.SingleOrDefault(i => i.id == id);
                if (GetEventById(id) != null && !id.Equals(null))
                {
                    context.Events.DeleteOnSubmit(Event);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
