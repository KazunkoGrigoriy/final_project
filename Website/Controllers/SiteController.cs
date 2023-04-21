using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Data;
using Website.Interfaces;
using Website.Models;

namespace Website.Controllers
{
    public class SiteController : Controller
    {
        private IRequestsData _requestsData;
        public SiteController(IRequestsData requestsData)
        {
            _requestsData = requestsData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Sb()
        {
            return View();
        }

        public IActionResult Mr()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult C_page1()
        {
            return View();
        }

        public IActionResult C_page2()
        {
            return View();
        }

        public IActionResult C_page3()
        {
            return View();
        }

        public IActionResult C_page4()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(string name, string email, string message)
        {
            
            var request = new Request()
            {
                Name = name,
                Email = email,
                status = new Status().Received,
                DateTime = DateTime.Now,
                Message = message
            };
            _requestsData.AddRequest(request);
            return Redirect("Index");
        }
    }
}
