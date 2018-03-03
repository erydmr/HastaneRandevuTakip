using HastaneRandevu.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HastaneRandevu.ViewModels;
using System.Web.Helpers;

namespace HastaneRandevu.Controllers
{
    public class HastaController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View(new HastaLogin());
        }

        public ActionResult KayitForm()
        {
            return View();
        }





        public ActionResult Randevu()
        {
           
            var iller = Database.Session.Query<Iller>().ToList();
            ViewData["drpil"] = new SelectList(iller, "Id", "IlAdi");

            var klinikler = Database.Session.Query<Klinikler>().ToList();
            ViewData["drpklinik"] = new SelectList(klinikler, "Id", "klinikadi");
            return View();
        }

        [HttpPost]
        public ActionResult Randevu(HastaRandevu form)
        {
            var iller = Database.Session.Query<Iller>().ToList();
            ViewData["drpil"] = new SelectList(iller, "Id", "IlAdi");

            var klinikler = Database.Session.Query<Klinikler>().ToList();
            ViewData["drpklinik"] = new SelectList(klinikler, "Id", "klinikadi");

            int hastaIDcookie = Convert.ToInt32(Request.Cookies["HastaID"].Value);
            var randevu = new Randevular()
            {
                hekimId = Convert.ToInt32(form.drphekim),
                klinikId = Convert.ToInt32(form.drpklinik),
                hastaId = hastaIDcookie,
                Saat = form.drpsaat,
                Tarih = form.Tarih

            };


            Database.Session.Save(randevu);
            Database.Session.Flush();


            return RedirectToRoute("Randevu");
        }



        public ActionResult Ilceler(string il_id)
        {
            List<SelectListItem> item = new List<SelectListItem>();

            int id = Convert.ToInt32(il_id);
            List<Ilceler> ilceler = Database.Session.Query<Ilceler>().Where(x => x.IlId == id).ToList();
            foreach (var list in ilceler)
            {
                item.Add(new SelectListItem() { Value = list.Id.ToString(), Text = list.IlceAdi });
            }
            return Json(new SelectList(item, "Value", "Text"));
        }

        public ActionResult Hastaneler(string ilce_id)
        {
            List<SelectListItem> item = new List<SelectListItem>();

            int id = Convert.ToInt32(ilce_id);
            List<Hastaneler> hastaneler = Database.Session.Query<Hastaneler>().Where(x => x.IlceID == id).ToList();
            foreach (var list in hastaneler)
            {
                item.Add(new SelectListItem() { Value = list.Id.ToString(), Text = list.HastaneAdi });
            }
            return Json(new SelectList(item, "Value", "Text"));
        }

        public ActionResult Hekimler(string hastane_id, string klinik_id)
        {
            List<SelectListItem> item = new List<SelectListItem>();

            int? id = Convert.ToInt32(hastane_id);
            int? id2 = Convert.ToInt32(klinik_id);
            List<Hekimler> hekimler = Database.Session.Query<Hekimler>().Where(x => x.hastaneID == id && x.klinikID==id2 ).ToList();
            foreach (var list in hekimler)
            {
                item.Add(new SelectListItem() { Value = list.Id.ToString(), Text = list.hekimAdi });
            }
            return Json(new SelectList(item, "Value", "Text"));
        }

        public ActionResult Saatler(string hekim_id)
        {
            List<SelectListItem> item = new List<SelectListItem>();

            int? id = Convert.ToInt32(hekim_id);
            List<Randevular> hekimler = Database.Session.Query<Randevular>().Where(x => x.hekimId == id).ToList();

            List<string> TumSaatler = new List<string>();
            TumSaatler.Add("10:00");
            TumSaatler.Add("10:20");
            TumSaatler.Add("10:40");
            TumSaatler.Add("11:00");
            TumSaatler.Add("11:20");
            TumSaatler.Add("11:40");
            TumSaatler.Add("13:00");
            TumSaatler.Add("13:20");
            TumSaatler.Add("13:40");
            TumSaatler.Add("14:00");
            TumSaatler.Add("14:20");
            TumSaatler.Add("14:40");
            TumSaatler.Add("15:00");
            TumSaatler.Add("15:20");
            TumSaatler.Add("15:40");

            foreach (var liste in hekimler)
            {
                TumSaatler.Remove(liste.Saat);
            }

            foreach (var list in TumSaatler)
            {
                item.Add(new SelectListItem() { Value = list, Text = list });
            }
            return Json(new SelectList(item, "Value", "Text"));
        }




        [HttpPost]
        public ActionResult Index(HastaLogin form, string returnUrl)
        {
        
            var hasta = Database.Session.Query<Hastalar>().FirstOrDefault(u => u.TcKimlik == form.TcKimlik);
           
            if (hasta == null)
                Hastalar.FakeHash();

            if (hasta == null || !hasta.CheckPassword(form.Sifre))
                ModelState.AddModelError("TC Kimlik", "TC Kimlik veya Sifre gecersiz!");

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            Response.Cookies["HastaID"].Value = hasta.Id.ToString();
            Response.Cookies["HastaID"].Expires = DateTime.Now.AddDays(1);

            FormsAuthentication.SetAuthCookie(form.TcKimlik, true);

            if (!String.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);


            return RedirectToAction("randevu");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("index");
        }

        [HttpPost]
        public ActionResult KayitForm(HastaKayit form)
        {
            if (Database.Session.Query<Hastalar>().Any(u => u.TcKimlik == form.TcKimlik))
                ModelState.AddModelError("TC Kimlik", "Bu TC Kimlik numarasıyla kayıtlı kullanıcı var");

            if (!ModelState.IsValid)
                return View(form);

            var hasta = new Hastalar()
            {
                AdSoyad = form.AdSoyad,
                TcKimlik = form.TcKimlik,
                DogumTarihi = form.DogumTarihi,
                Email = form.Email,
                Tel = form.Tel,
                Cinsiyet = form.Cinsiyet,
                Adres = form.Adres
            };

            hasta.SetPassword(form.Sifre);

            Database.Session.Save(hasta);
            Database.Session.Flush();

            var ileti = "Ad Soyad: " + form.AdSoyad + "<br>" + "TC Kimlik No: " + form.TcKimlik + "<br>" + "Doğum Tarihi: " + form.DogumTarihi + "<br>" + "Tel No: " + form.Tel + "<br>" + "Adres: " + form.Adres + "<br>" + "Sifreniz: " + form.Sifre;

            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mailgonderir@gmail.com";
                WebMail.Password = "741852963_a";
                WebMail.SmtpPort = 587;
                WebMail.Send(
                        form.Email,
                        "Hastane Randevu Sistemine Ait Kayıt Bilgileriniz",
                        ileti
                    );

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_HATA", ex.Message);
            }

            return RedirectToAction("index");
        }


    }
}