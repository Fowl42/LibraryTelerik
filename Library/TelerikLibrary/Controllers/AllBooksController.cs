using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikLibrary.Models;

namespace TelerikLibrary.Controllers
{
    public class AllBooksController : Controller
    {

        // GET: AllBooks
        public ActionResult Index()
        {
            return View();
        }

        private BooksService productService;

        public AllBooksController()
        {
            productService = new BooksService();
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}