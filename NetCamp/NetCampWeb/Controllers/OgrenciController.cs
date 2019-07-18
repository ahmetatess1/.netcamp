using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCampWeb.Models.Entities;
using NetCampWeb.Models.Services;

namespace NetCampWeb.Controllers
{
    [Authorize]
    public class OgrenciController : Controller
    {
        OgrenciService service;
        public OgrenciController(OgrenciService _service)
        {
            service=_service;
        }
        public IActionResult List()
        {        
            return View(service.GetList());
        }
        public IActionResult Insert()
        {
            return View(new Ogrenci());
        }
        [HttpPost]
        public IActionResult Insert(Ogrenci model)
        {
            if(!ModelState.IsValid)
            {
                foreach(var modelstate in ModelState.Values)
                {
                    foreach(var error in modelstate.Errors)
                    {
                        ViewBag.Error = error.ErrorMessage;
                    }
                }
                return View(model);
            }
            else
            {                
                model=service.Insert(model);
                return RedirectToAction("List"); // Controllerde list methoduna gider.
            }
         
        }
        //Action üzerinde route tanımı yaparken aynı isme sahip diğer actionlarda etkilenir.
        /*[Route("/ogrenci-guncelle/{ogrenciId}")] url parametresini değiştirmek için */
        public IActionResult Update(long id)
        {         
            return View(service.Get(id));
        }
        /*[Route("/ogrenci-guncelle/{ogrenciId}")] url parametresini değiştirmek için */
        [HttpPost]
        public IActionResult Update(Ogrenci model)
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

        public IActionResult Delete(long id)
        {
            service.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(Ogrenci model)
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
                if (service.GetList().FirstOrDefault(k => k.KullaniciAdi == model.KullaniciAdi && k.Parola == model.Parola) != null)
                {
                    return RedirectToAction("List"); // Controllerde list methoduna gider.
                }
                else
                {
                    return View();
                }
            }
        }
    }
}