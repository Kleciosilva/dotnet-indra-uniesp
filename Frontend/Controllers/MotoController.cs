using Backend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class MotoController : Controller
    {
        private MotoService service;

        public MotoController()
        {
            this.service = new MotoService();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listmoto()
        {
            var motos = this.service.List();
            return View("Listmoto", motos);
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
                var moto = new Backend.Controller.MotoController(
                    collection["Name"],
                    collection["Model"],
                    collection["FactoryYear"],
                    collection["Color"]
                    );

                moto.Save();

                return RedirectToAction(nameof(Listmoto));
            }
            catch
            {
                return View("New");
            }
        }

        public ActionResult Edit(Guid id)
        {
            var moto = this.service.GetById(id);

            return View("Edit", moto);
        }

        [HttpPost]
        public ActionResult Update(IFormCollection collection)
        {
            try
            {
                var moto = new Backend.Controller.MotoController(
                    collection["Name"],
                    collection["Model"],
                    collection["FactoryYear"],
                    collection["Color"]
                    );

                moto.Update(collection["Id"]);

                return RedirectToAction(nameof(Listmoto));
            }
            catch
            {
                return View("New");
            }
        }

        public ActionResult Delete(Guid id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(Listmoto));
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

                //ViewBag.motos = 
                this.service.GetByManufacturer(collection["inputSearch"]);

                return View("Search");
            }

            return View("Search");
        }
    }
}
