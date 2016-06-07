using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.DAL;
using SkiRental.Models;
using System.Data.Entity;
using System.Web.Mvc;
using SkiRental.ViewModels;

namespace SkiRental.Services
{
    public class OrderService : IDisposable
    {
        private SkiRentalContext _db = new SkiRentalContext();

        public List<Order> GetOrderItemsByUserId(int id)
        {
            var tmp = _db.Orders.ToList();

            var orders = _db.Orders.Include(c => c.Customer).Include(c => c.OrderItem).Where(c => c.Customer.Id == id).ToList();

            //if(null == orders)
                // Throw an exception

            return orders;
        }

        public List<Item> GetAllProduct()
        {
            return _db.Items.Where(i => i.isAvailable == true).ToList();
        } 

        public List<Item> GetProducts(string category)
        {
            return _db.Items.Where(i => i.ItemCategory.Name == category).ToList();
        }

        public List<SelectListItem> GetListOfCategories()
        {
            var categories = _db.ItemCategories.Select(p => new SelectListItem() { Value = p.Id.ToString(), Text = p.Name}).ToList();

            if(categories == null)
            {
                // Throw an exception
            }

            return categories;
        }

        public Order GetOrderByCode(string orderCode)
        {
            return _db.Orders.Single(o => o.OrderCode == orderCode);
        }

        public Payment GetPaymentByOrderCode(string orderCode)
        {
            return _db.Payments.Where(p => p.OrderCode == orderCode).SingleOrDefault();
        }

        public void Pay(int id)
        {
            //var payment = _db.Payments.Where(p => p.OrderCode == orderCode).FirstOrDefault();
            var payment = _db.Payments.Where(p => p.Id == id).FirstOrDefault();

            if (payment != null)
            {
                payment.IsPaid = true;
            }

            _db.Entry(payment).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void AddOrder(Order orderMapped)
        {
            _db.Orders.Add(orderMapped);
            _db.SaveChanges();

            // Dodajemy powiązaną z zamówieniem płatność
            var payment = new Payment()
            {
                OrderCode = orderMapped.OrderCode,
                IsPaid = false,
                RentalTime = WorkingHours(orderMapped.StartDate, orderMapped.EndDate),
                Amount = 0
            };

            _db.Payments.Add(payment);
            _db.SaveChanges();
        }

        // Metoda licząca roboczogodziny (bez niedziel)
        // Godziny powinien pobierac z bazy danych
        public int WorkingHours(DateTime start, DateTime end)
        {
            int hours = 0;

            for(var i = start; i < end; i = i.AddHours(1))
            {
                if(i.DayOfWeek != DayOfWeek.Saturday)
                {
                    if (i.TimeOfDay.Hours >= 9 && i.TimeOfDay.Hours < 17)
                        hours++;
                }
            }

            return hours;
        }

        public void AddItemToOrder(OrderItem itemWithOrder)
        {
            _db.OrderItems.Add(itemWithOrder);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void NotAvaliableItem(int itemid)
        {
            var itemToEdit = _db.Items.Single(i => i.Id == itemid);

            itemToEdit.isAvailable = false;

            _db.Entry(itemToEdit).State = EntityState.Modified;
            _db.SaveChanges();
        }


        public List<Order> GetAllOrders()
        {
            return _db.Orders.ToList();
        }

        public OrderWithItems GetItemsFromOrder(int orderId)
        {
            var ItemList = from e in _db.OrderItems.Where(o => o.OrderId == orderId).ToList()
                join f in _db.Orders.ToList()
                    on e.OrderId equals f.Id
                join d in _db.Items.ToList()
                    on e.ItemId equals d.Id
                select new ItemsFromOrderViewModel()
                {
                    ItemId = d.Id,
                    Producer = d.Producer,
                    Model = d.Model,
                    Size = d.Size,
                    Level = d.Level,
                    Sex = d.Sex,
                    Description = d.Description,
                    isAvailable = d.isAvailable,
                    PhotoUrl = d.PhotoUrl
                };

            var ItemListToList = ItemList.ToList();

            var orderInfo = _db.Orders.Single(o => o.Id == orderId);

            var orderWithItems = new OrderWithItems()
            {
                CustomerId = orderInfo.CustomerId,
                StartDate = orderInfo.StartDate,
                EndDate = orderInfo.EndDate,
                Opis = orderInfo.Opis,
                OrderCode = orderInfo.OrderCode,
                Items = ItemListToList
            };

            return orderWithItems;
        }


        public void RemoveOrder(int orderId)
        {
            var ItemList = from e in _db.OrderItems.Where(o => o.OrderId == orderId).ToList()
                           join f in _db.Orders.ToList()
                               on e.OrderId equals f.Id
                           join d in _db.Items.ToList()
                               on e.ItemId equals d.Id
                           select new Item()
                           {
                               Id = d.Id,
                               Producer = d.Producer,
                               Model = d.Model,
                               Size = d.Size,
                               Level = d.Level,
                               Sex = d.Sex,
                               Description = d.Description,
                               isAvailable = d.isAvailable,
                               PhotoUrl = d.PhotoUrl
                           };

            var ItemListToList = ItemList.ToList();

            var orderToRemove = _db.Orders.Single(o => o.Id == orderId);
            _db.Orders.Remove(orderToRemove);
            _db.SaveChanges();


            foreach (var item in ItemListToList)
            {
                item.isAvailable = true;
            }

            foreach (var item in ItemListToList)
            {
                _db.Items.Attach(item);
                var entry = _db.Entry(item);
                entry.Property(e => e.isAvailable).IsModified = true;
            }

            _db.SaveChanges();
            
        }

        public decimal Suma(int id)
        {
            //var orderitems = fun1(id);
            var orderitems = _db.OrderItems.Where(o => o.OrderId == id).ToList();

            var order = _db.Orders.Where(o => o.Id == id).SingleOrDefault();
            var ordercode = order.OrderCode;

            var payment = _db.Payments.Where(p => p.OrderCode == ordercode).SingleOrDefault();
            var hours = payment.RentalTime;

            decimal suma = 0m;

            foreach(var item in orderitems)
            {
                suma += item.Item.ItemCategory.Cost;
            }

            return suma * hours;
        }

        public List<Order> GetOrderListByOrderCode(string ordercode)
        {
            return _db.Orders.Where(o => o.OrderCode == ordercode).ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return _db.Payments.Where(p => p.Id == id).SingleOrDefault();
        }

        public decimal ChangeAmount(string ordercode, decimal kwota)
        {
            var itemToEdit = _db.Payments.Single(i => i.OrderCode == ordercode);

            //itemToEdit.Amount = Suma(orderMapped.Id);
            itemToEdit.Amount = kwota;
            _db.Entry(itemToEdit).State = EntityState.Modified;
            _db.SaveChanges();

            return kwota;
        }

        //public List<Item> GetAddedItems(string ordercode)
        //{
        //    var order = _db.Orders.Where(o => o.OrderCode == ordercode).SingleOrDefault();

        //    var ItemList = from e in _db.OrderItems.Where(o => o.OrderId == order.Id).ToList()
        //                             join f in _db.Orders.ToList()
        //                                 on e.OrderId equals f.Id
        //                             join d in _db.Items.ToList()
        //                                 on e.ItemId equals d.Id
        //                             select new ItemsFromOrderViewModel()
        //                             {
        //                                 ItemId = d.Id,
        //                                 Producer = d.Producer,
        //                                 Model = d.Model,
        //                                 Size = d.Size,
        //                                 Level = d.Level,
        //                                 Sex = d.Sex,
        //                                 Description = d.Description,
        //                                 isAvailable = d.isAvailable,
        //                                 PhotoUrl = d.PhotoUrl
        //                             };

        //    var ItemListToList = ItemList.ToList();

        //}
    }
}
