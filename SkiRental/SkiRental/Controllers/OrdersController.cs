using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkiRental.Models;
using SkiRental.ViewModels;
using SkiRental.Services;

namespace SkiRental.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService = new OrderService();

        public ActionResult ToPay(string orderCode)
        {
            var payment = _orderService.GetPaymentByOrderCode(orderCode);

            return PartialView(payment);
        }

        public ActionResult Pay(int id)
        {
            string code = ViewBag.tmp;
            _orderService.Pay(id);

            // Niech wróci do detali
            return RedirectToAction("ListOrders");
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.CustomerId = id;

            return View(new OrderViewModel());
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel orderModel)
        {
            var orderMapped = new Order()
            {   
                OrderCode = Guid.NewGuid().ToString(),
                CustomerId = orderModel.CustomerId,
                StartDate = orderModel.StartDate,
                EndDate = orderModel.EndDate,
                Opis = orderModel.Opis
            };

            _orderService.AddOrder(orderMapped);

            return RedirectToAction("AddItems", orderMapped);
        }

        public ActionResult AddItems(Order orderModel)
        {
            var listOfItem = _orderService.GetAllProduct();
            var orderInfo = _orderService.GetOrderByCode(orderModel.OrderCode);

            var orderModelWithItems = new OrderWithItemList()
            {
                CustomerId = orderModel.CustomerId,
                StartDate = orderModel.StartDate,
                EndDate = orderModel.EndDate,
                Opis = orderModel.Opis,
                Items = listOfItem,
                OrderCode = orderInfo.OrderCode
            };

            return View(orderModelWithItems);
        }

        [ChildActionOnly]
        public ActionResult GetCategory()
        {
            var categories = _orderService.GetListOfCategories();

            return PartialView(categories);
        }

        public ActionResult GetProducts(string category)
        {
            var products = _orderService.GetProducts(category);

            return PartialView(products);
        }

        public ActionResult CreateOrder(string pesel)
        {
            return View();
        }

        public ActionResult AddToOrder(int itemid, string ordercode)
        {

            var orderInfo = _orderService.GetOrderByCode(ordercode);

            var itemWithOrder = new OrderItem()
            {
                ItemId = itemid,
                OrderId = orderInfo.Id
            };

            _orderService.AddItemToOrder(itemWithOrder);
            _orderService.NotAvaliableItem(itemid);

            return RedirectToAction("AddItems", orderInfo);
        }

        //public ActionResult ListOrderItems()
        //{
        //    var items = _orderService.GetOrderItemsByOrderCode(ViewBag.orderCode);

        //    return View(items);
        //}

        public ActionResult ListOrders(string ordercode)
        {
            if (String.IsNullOrEmpty(ordercode))
            {
                var allOrders = _orderService.GetAllOrders();
                return View(allOrders);
            }

            return View(_orderService.GetOrderListByOrderCode(ordercode));
        }


        public ActionResult Details(int id)
        {
            var itemList = _orderService.GetItemsFromOrder(id);

            return View(itemList);
        }

        public ActionResult Delete(int id)
        {
            _orderService.RemoveOrder(id);
            
            return RedirectToAction("ListOrders");
        }

        public ActionResult Amount(int id)
        {
            var payment = _orderService.GetPaymentById(id);
            var order = _orderService.GetOrderByCode(payment.OrderCode);
            var suma = _orderService.Suma(order.Id);

            var amount = _orderService.ChangeAmount(payment.OrderCode, suma);

            ViewBag.Amount = amount;

            return PartialView();
            //return Content(suma.ToString());
        }

        //public ActionResult AddedItems(string ordercode)
        //{
        //    if(String.IsNullOrEmpty(ordercode))
        //    {
        //        return Content("String jest pusty");
        //    }

        //    var items = _orderService.GetAddedItems(ordercode);

        //    return Content("String nie jest pusty");

        //    //return PartialView();
        //}

        public ActionResult CreatePdf()
        {
            return View();
        }
    }
}