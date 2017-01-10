using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayeredSolution.BusinessLayer;
using LayeredSolution.Models;

namespace LayeredSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public HomeController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        private OrderModel Basket
        {
            get
            {
                var basket = Session["Basket"] as OrderModel;
                if (basket == null)
                {
                    basket = new OrderModel
                    {
                        OrderItems = new List<OrderItemModel>()
                    };
                    Session["Basket"] = basket;
                }
                return basket;
            }
        }
        
        [HttpGet]
        public ActionResult Index(string search)
        {
            var products = _productService.GetAllProduct(null);
            ViewBag.Count = Basket.OrderItems.Count;
            ViewBag.Price = Basket.OrderItems.Sum(e => e.Price);
            return View(products);
        }

        [HttpPost]
        public ActionResult Index(BasketModel model)
        {
            var products = _productService.GetAllProduct(null);
            Basket.OrderItems.Add(new OrderItemModel
            {
                Order = Basket,
                Price = products.Where(e => e.Id == model.ProductId).Select(e => e.Price).FirstOrDefault(),
                Quantity = model.Quantity.GetValueOrDefault(1),
                ProductId = model.ProductId
            });
            ViewBag.Count = Basket.OrderItems.Count;
            ViewBag.Price = Basket.OrderItems.Sum(e => e.Price * e.Quantity);
            return View(products);
        }

        [HttpPost]
        public ActionResult SubmitOrder(SaveOrderModel model)
        {
            Basket.BuyerAddress = model.BuyerAddress;
            Basket.BuyerEmail = model.BuyerEmail;
            Basket.BuyerName = model.BuyerName;
            _orderService.CreateOrder(Basket);
            Session.Remove("Basket");
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}