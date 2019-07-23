using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Business;
using Catalog.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogWeb.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {

        BrandService service;
        public BrandController(BrandService _service)
        {
            service = _service;
        }
        public IActionResult List()
        {
            return View(service.GetList());
        }
        public IActionResult Insert()
        {
            return View(new Brand());
        }
        [HttpPost]
        public IActionResult Insert(Brand model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelstate in ModelState.Values)
                {
                    foreach (var error in modelstate.Errors)
                    {
                        ViewBag.Error = error.ErrorMessage;
                    }
                }
                return View(model);
            }
            else
            {
                model=service.Add(model);
                return RedirectToAction("List"); // Controllerde list methoduna gider.
            }
        }

        public IActionResult Update(int id)
        {
            return View(service.GetList().SingleOrDefault(x=>x.Id==id));
        }
        [HttpPost]
        public IActionResult Update(Brand model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelstate in ModelState.Values)
                {
                    foreach (var error in modelstate.Errors)
                    {
                        ViewBag.Error = error.ErrorMessage;
                    }
                }
                return View(model);
            }
            else
            {
                service.Update(model);
                return RedirectToAction("List"); // Controllerde list methoduna gider.
            }
        }
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return RedirectToAction("List");
        }
    }
}