using HastaneRandevu.Areas.Doktor.ViewModels;
using HastaneRandevu.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HastaneRandevu.Areas.Doktor.Controllers
{
    public class AuthController : Controller
    {
        // GET: Doktor/Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DoktorLogin form, string returnUrl)
        {

            var doktor = Database.Session.Query<Hekimler>().FirstOrDefault(u => u.Email == form.Email);

            if (doktor == null)
            {
                HastaneRandevu.Models.Hekimler.FakeHash();
            }

            Response.Cookies["DoktorID"].Value = doktor.Id.ToString();
            Response.Cookies["DoktorID"].Expires = DateTime.Now.AddDays(1);

            if (doktor == null || !doktor.CheckPassword(form.Sifre))
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
                return RedirectToAction("randevu");
            }
        }

        public ActionResult Randevu()
        {
            int DoktorID =Convert.ToInt32(Request.Cookies["DoktorID"].Value);

            var tarih = DateTime.Now.ToString("MM/dd/yyyy");
            tarih = tarih.Replace(".", "/");
            var randevu = Database.Session.Query<Randevular>().Where(x=> x.hekimId == DoktorID && x.Tarih== tarih);

            return View(new DoktorRandevu() { Randevular = randevu });

            //return Content(tarih);
        }
    }
}