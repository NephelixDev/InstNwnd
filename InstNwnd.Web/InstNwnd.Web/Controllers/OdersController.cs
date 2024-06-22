using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.OrdersCrud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstNwnd.Web.Controllers
{
    public class OrdersController : Controller
    {
        
        private readonly IOrdersDb ordersService;

        public OrdersController(IOrdersDb ordersDb)
        {
            this.ordersService = ordersDb;
        }
        // GET: OrdersController
        public ActionResult Index()
        {
            var Orders = ordersService.GetOrders(); 
            return View(Orders); 
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            var Order = this.ordersService.GetOrder(id); 
            return View(Order);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersSaveModels save)
        {
            try
            {
                save.OrderDate = DateTime.Now;
                ordersService.SaveOrder(save);
                return RedirectToAction(nameof(Index));
            }
            catch (OrdersDbException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            var orders = ordersService.GetOrder(id);
            var updateOders = new OrdersUpdateModels
            {
                OrderId = orders.OrderId,
                CustomerId = orders.CustomerId,
                EmployeeID = orders.EmployeeID,
                OrderDate = orders.OrderDate,
                RequiredDate = orders.RequiredDate,
                ShippedDate = orders.ShippedDate,
                ShipVia = orders.ShipVia,
                Freight = orders.Freight,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipPostalCode = orders.ShipPostalCode,
                ShipCountry = orders.ShipCountry
            };
            return View(updateOders);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersUpdateModels ordersUpdate)
        {
            try
            {
                ordersService.UpdateOrder(ordersUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = ordersService.GetOrder(id);
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var removeModel = new OrdersRemoveModels {OrderId = id};
                ordersService.RemoveOrder(removeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var order = ordersService.GetOrder(id);
                return View(order);
            }
        }
    }
}
