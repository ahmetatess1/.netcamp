using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCampWeb.Models.Entities;

namespace NetCampWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
 
            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
            return View(new Ogrenci());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Ogrenci model)
        {
            if (model.KullaniciAdi == "Admin" && model.Parola == "123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.KullaniciAdi)
                };

                var userIdentity = new ClaimsIdentity(claims, "Index");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("List", "Ogrenci");
            }
            else
            {
                ViewBag.Error = "Bilgileri kontrol ediniz";
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Erisilemez()
        {
            return View(new Ogrenci());
        }
    }
}