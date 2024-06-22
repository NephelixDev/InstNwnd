using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Order_DetailsCrud;
using InstNwnd.Web.Data.Exceptions;

namespace InstNwnd.Web.Controllers
{
    public class Order_DetailsController : Controller
    {
        private readonly IOrder_DetailsDb orderdetailsService;

        public Order_DetailsController(IOrder_DetailsDb orderDetailsDb)
        {
            this.orderdetailsService = orderDetailsDb;
        }

        // GET: Order_DetailsController
        public ActionResult Index()
        {
            var orderDetails = orderdetailsService.GetOrder_Details();
            return View(orderDetails);
        }

        // GET: Order_DetailsController/Details/5
        public ActionResult Details(int orderId, int productId)
        {
            var orderDetail = orderdetailsService.GetOrder_Details(orderId, productId);
            return View(orderDetail);
        }

        // GET: Order_DetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_DetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order_DetailsSaveModels orderdetailssaveModel)
        {
            try
            {
                this.orderdetailsService.SaveOrderDetail(orderdetailssaveModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Order_DetailsDbException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: Order_DetailsController/Edit/5
        public ActionResult Edit(int orderId, int productId)
        {
            var orderDetails = orderdetailsService.GetOrder_Details(orderId, productId);
            var updateOrderDetailsModel = new Order_DetailsUpdateModels
            {
                OrderID = orderDetails.OrderID,
                ProductID = orderDetails.ProductID,
                UnitPrice = orderDetails.UnitPrice,
                Quantity = orderDetails.Quantity,
                Discount = orderDetails.Discount
            };
            return View(updateOrderDetailsModel);
        }

        // POST: Order_DetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order_DetailsUpdateModels updateModel)
        {
            try
            {
                this.orderdetailsService.UpdateOrderDetail(updateModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Order_DetailsDbException ex)
            {
                return View();
            }
        }

        // GET: Order_DetailsController/Delete/5
        public ActionResult Delete(int orderId, int productId)
        {
            var orderDetail = orderdetailsService.GetOrder_Details(orderId, productId);
            return View(orderDetail);
        }

        // POST: Order_DetailsController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int orderId, int productId)
        {
            try
            {
                var removeModel = new Order_DetailsRemoveModels { OrderID = orderId, ProductID = productId };
                this.orderdetailsService.RemoveOrderDetails(removeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var orderDetail = orderdetailsService.GetOrder_Details(orderId, productId);
                return View(orderDetail);
            }
        }
    }
}
