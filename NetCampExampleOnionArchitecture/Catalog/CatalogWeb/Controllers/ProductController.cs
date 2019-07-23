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
    public class ProductController : Controller
    {
        List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> kategoriler;
        List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> markalar;
        ProductService service;
        public ProductController(ProductService _service)
        {           
            service = _service;
        }
        public IActionResult List()
        {
            return View(service.GetList());
        }
        public IActionResult Insert()
        {
            kategoriler = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            markalar = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in service.GetCategory())
            {   
                kategoriler.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = item.Name, Value =    item.Id.ToString() });
            }
            foreach (var item in service.GetBrand())
            {   
                markalar.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;
            ViewBag.Markalar = markalar;

            return View(new Product());
        }
        [HttpPost]
        public IActionResult Insert(Product model)
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
                model = service.Add(model);
                return RedirectToAction("List"); // Controllerde list methoduna gider.
            }
        }

        public IActionResult Update(int id)
        {
            kategoriler = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            markalar = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in service.GetCategory())
            {   //Text = Görünen kısımdır. Kategori ismini yazdıyoruz
                //Value = Değer kısmıdır.ID değerini atıyoruz
                kategoriler.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            foreach (var item in service.GetBrand())
            {   //Text = Görünen kısımdır. Kategori ismini yazdıyoruz
                //Value = Değer kısmıdır.ID değerini atıyoruz
                markalar.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;
            ViewBag.Markalar = markalar;
            return View(service.GetList().SingleOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public IActionResult Update(Product model)
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