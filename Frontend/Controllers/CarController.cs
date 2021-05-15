using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Service;

namespace Frontend.Controllers
{
    public class CarController : Controller
    {
        private CarService service;

        public CarController()
        {
            this.service = new CarService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListCar()
        {

            var test = this.service.Test();
            return View("ListCar", test);
        }
    }
}
