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

    public class HesaplarController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = Database.Session.Query<Yoneticiler>().ToList(); 
            return View(new UsersIndex() { Users = users });

           // return View();
        }



        public ActionResult New()
        {
            return View();
                
        }

        [HttpPost]
        public ActionResult New(UsersNew form)
        {
            if (Database.Session.Query<Yoneticiler>().Any(p => p.Email == form.Email))
            {
                ModelState.AddModelError("Username", "Username must be unique");
            } //username control in database. 

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }

            var user = new Yoneticiler() //create a new user object
            {
                AdSoyad = form.AdSoyad,
                Email = form.Email,
                Rol = form.Rol,
            };

           
            user.SetPassword(form.Password); //set passwordhash property of this user object

            Database.Session.Save(user); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<Yoneticiler>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(
                new UsersEdit()
                {
                    AdSoyad = user.AdSoyad,
                    Email = user.Email,
                    Rol = user.Rol,
                    
                }
            );
        }

        [HttpPost]
        public ActionResult Edit(int id, UsersEdit form)
        {
            var user = Database.Session.Load<Yoneticiler>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            if (Database.Session.Query<Yoneticiler>().Any(p => p.Email == form.Email && p.Id != id))
            {
                ModelState.AddModelError("Username", "Username must be unique");
            } //username control in database. 

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }


            user.Email = form.Email;
            user.AdSoyad = form.AdSoyad;
            user.Rol = form.Rol;


            
            Database.Session.Update(user); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult ResetPassword(int id)
        {
            var user = Database.Session.Load<Yoneticiler>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new UsersResetPassword()
            {
                AdSoyad = user.AdSoyad
            }
            );
        }


        [HttpPost]
        public ActionResult ResetPassword(int id, UsersResetPassword form)
        {
            var user = Database.Session.Load<Yoneticiler>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            user.SetPassword(form.Password);


            Database.Session.Update(user); //save user object to database
            Database.Session.Flush();
            return RedirectToAction("index");
        }

        public ActionResult Sil(int id)
        {
            var hesap = Database.Session.Load<Yoneticiler>(id);
            if (hesap == null)
                return HttpNotFound();

            Database.Session.Delete(hesap);
            Database.Session.Flush();
            return RedirectToAction("index");
        }

    }
}