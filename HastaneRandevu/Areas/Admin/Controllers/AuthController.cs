using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaneRandevu.Models;
using HastaneRandevu.Areas.Admin.ViewModels;
using NHibernate.Linq;
using System.Web.Security;

namespace HastaneRandevu.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yonetim()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(AdminLogin form, string returnUrl)
        {

            var yntc = Database.Session.Query<Yoneticiler>().FirstOrDefault(u => u.Email == form.Email);

            if (yntc == null)
            {
                HastaneRandevu.Models.Yoneticiler.FakeHash();
            }

            if (yntc == null || !yntc.CheckPassword(form.Sifre))
            {
                ModelState.AddModelError("Email", "Email veya Şifre Hatalı!");
            }


            if (!ModelState.IsValid)
            {
                return View(form);
            }


            FormsAuthentication.SetAuthCookie(form.Email, true);


            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Yonetim");
            }

        }
    }
}