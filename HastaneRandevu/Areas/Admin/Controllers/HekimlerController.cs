using HastaneRandevu.Models;
using NHibernate.Linq;
using HastaneRandevu.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HastaneRandevu.Areas.Admin.Controllers
{
    public class HekimlerController : Controller
    {
        
        public ActionResult Index()
        {
            var hekim = Database.Session.Query<Hekimler>();
            return View(new HekimIndex() { Hekimler = hekim });

            // return View();
        }



        public ActionResult Yeni()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Yeni(HekimYeni form)
        {
            if (Database.Session.Query<Hekimler>().Any(p => p.hekimAdi == form.HekimAdi))
            {
                ModelState.AddModelError("Hekim Adi", "Bu isimde hastane mevcut.");
            }

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }

            var hekim = new Hekimler() //create a new user object
            {
                hekimAdi= form.HekimAdi,
                hastaneID = Convert.ToInt32(form.HastaneID),
                klinikID = Convert.ToInt32(form.KlinikID),
                Email = form.Email
            };
            hekim.SetPassword(form.Password);
            Database.Session.Save(hekim); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult Duzenle(int id)
        {
            var hekim = Database.Session.Load<Hekimler>(id);

            if (hekim == null)
            {
                return HttpNotFound();
            }

            return View(
                new HekimDuzenle()
                {
                    HastaneID = hekim.hastaneID.ToString(),
                    KlinikID = hekim.klinikID.ToString(),
                    HekimAdi = hekim.hekimAdi,
                    Email = hekim.Email
                }
            );
        }

        [HttpPost]
        public ActionResult Duzenle(int id, HekimDuzenle form)
        {
            var hekim = Database.Session.Load<Hekimler>(id);

            if (hekim == null)
            {
                return HttpNotFound();
            }

            if (Database.Session.Query<Hekimler>().Any(p => p.hekimAdi == form.HekimAdi && p.Id != id))
            {
                ModelState.AddModelError("HekimAdi", "Bu isimde hekim mevcut.");
            } //username control in database. 

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }


            hekim.hastaneID = Convert.ToInt32(form.HastaneID);
            hekim.klinikID = Convert.ToInt32(form.KlinikID);
            hekim.hekimAdi = form.HekimAdi;
            hekim.Email = form.Email;

            Database.Session.Update(hekim); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }


        public ActionResult Parola(int id)
        {
            var hekim = Database.Session.Load<Hekimler>(id);

            if (hekim == null)
            {
                return HttpNotFound();
            }

            return View(new HekimSifre()
            {
                Parola = hekim.PasswordHash
            }
            );
        }


        [HttpPost]
        public ActionResult Parola(int id, HekimSifre form)
        {
            var hekim = Database.Session.Load<Hekimler>(id);

            if (hekim == null)
            {
                return HttpNotFound();
            }

            hekim.SetPassword(form.Parola);


            Database.Session.Update(hekim); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult Sil(int id)
        {
            var hekim = Database.Session.Load<Hekimler>(id);
            if (hekim == null)
                return HttpNotFound();

            Database.Session.Delete(hekim);
            Database.Session.Flush();
            return RedirectToAction("index");
        }



    }
}