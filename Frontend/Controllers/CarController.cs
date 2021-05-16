using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Service;
using Backend.Controller;
using Microsoft.AspNetCore.Http;

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

            var cars = this.service.List();
            return View("ListCar", cars);
        }

        public ActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                var car = new Backend.Controller.CarController(
                    collection["Name"], 
                    collection["Model"], 
                    collection["FactoryYear"], 
                    collection["Color"]
                    );

                car.Save();

                return RedirectToAction(nameof(ListCar));
            }
            catch
            {
                return View("New");
            }
        }
    }
}
