using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Service;
using Backend.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public ActionResult Edit(Guid id)
        {
            var car = this.service.GetById(id);

            return View("Edit", car);
        }

        [HttpPost]
        public ActionResult Update(IFormCollection collection)
        {
            try
            {
                var car = new Backend.Controller.CarController(
                    collection["Name"],
                    collection["Model"],
                    collection["FactoryYear"],
                    collection["Color"]
                    );

                car.Update(collection["Id"]);

                return RedirectToAction(nameof(ListCar));
            }
            catch
            {
                return View("New");
            }
        }

        public ActionResult Delete(Guid id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(ListCar));
        }

        public ActionResult Search(IFormCollection collection)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Filter(IFormCollection collection)
        {
            List<string> Types = new List<string>();
            Types.Add("Placa");
            Types.Add("Fabricante");

            ViewBag.Types = new SelectList(Types);

            if (collection["type"] == "Fabricante")
            {
                //GetByManufacturer

                //ViewBag.Cars = 
                this.service.GetByManufacturer(collection["inputSearch"]);

                return View("Search");
            }

            return View("Search");
        }
    }
}
