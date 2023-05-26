using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult EditIndexPage()
        {
            return View();
        }
        public IActionResult EditProjectsPAge()
        {
            return View();
        }
        public IActionResult EditServicesPage()
        {
            return View();
        }
        public IActionResult EditBlogPage()
        {
            return View();
        }
        public IActionResult EditContactsPAge()
        {
            return View();
        }
        [HttpPost]
        public void SaveChanged()
        {

        }
    }
}
