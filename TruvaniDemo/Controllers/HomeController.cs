using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruvaniDemo.Controllers
{
    public class HomeController : Controller
    {
        ProductAPIController _api;
        public HomeController()
        {
            _api = new ProductAPIController();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var products = _api.Get();

            return View(products);
        }


        [HttpGet]
        public ActionResult Recommended(int id, double cartTotal)
        {
            var products = _api.GetRecommended(id, cartTotal);

            return PartialView(products);
        }



    }
}
