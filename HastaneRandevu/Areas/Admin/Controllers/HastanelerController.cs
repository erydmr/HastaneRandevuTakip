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

    public class HastanelerController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            var hastane = Database.Session.Query<Hastaneler>().ToList();
            return View(new HastaneIndex() { Hastaneler = hastane });

            // return View();
        }



        public ActionResult Yeni()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Yeni(HastaneYeni form)
        {
            if (Database.Session.Query<Hastaneler>().Any(p => p.HastaneAdi == form.HastaneAdi))
            {
                ModelState.AddModelError("HastaneAdi", "Bu isimde hastane mevcut.");
            }

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }

            var hastane = new Hastaneler() //create a new user object
            {
                IlceID = Convert.ToInt32(form.IlceID),
                HastaneAdi = form.HastaneAdi,
            };

            Database.Session.Save(hastane); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult Duzenle(int id)
        {
            var hastane = Database.Session.Load<Hastaneler>(id);

            if (hastane == null)
            {
                return HttpNotFound();
            }

            return View(
                new HastaneDuzenle()
                {
                    IlceID = hastane.IlceID.ToString(),
                    HastaneAdi = hastane.HastaneAdi,
                }
            );
        }

        [HttpPost]
        public ActionResult Duzenle(int id, HastaneDuzenle form)
        {
            var hastane = Database.Session.Load<Hastaneler>(id);

            if (hastane == null)
            {
                return HttpNotFound();
            }

            if (Database.Session.Query<Hastaneler>().Any(p => p.HastaneAdi == form.HastaneAdi && p.Id != id))
            {
                ModelState.AddModelError("HastaneAdi", "Bu isimde hastane mevcut.");
            } //username control in database. 

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }


            hastane.IlceID = Convert.ToInt32(form.IlceID);
            hastane.HastaneAdi = form.HastaneAdi;

            Database.Session.Update(hastane); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult Sil(int id)
        {
            var hastane = Database.Session.Load<Hastaneler>(id);
            if (hastane == null)
                return HttpNotFound();

            Database.Session.Delete(hastane);
            Database.Session.Flush();
            return RedirectToAction("index");
        }



    }
}