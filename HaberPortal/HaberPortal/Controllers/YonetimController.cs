using HaberPortal.Authorize;
using HaberPortal.Entity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaberPortal.Controllers
{
    public class YonetimController : Controller
    {
       

        ModelHaber1 veritabani = new ModelHaber1();


        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return RedirectToAction("Login");

           
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici)
        {

            Kullanicilar _kullanici = (from k in veritabani.Kullanicilar where k.username == kullanici.username && k.password==kullanici.password select k).FirstOrDefault();
            if (_kullanici!=null) {
                FormsAuthentication.SetAuthCookie(kullanici.username, false);
                return RedirectToAction("Panel");
        }
            else
            {
                ModelState.AddModelError("", "Kullanici adi veya şifre hatalı!");
            }
            return View(kullanici);
        }

        [_SessionControl]
        public ActionResult Panel()
        {
            return View();
        }

       
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [_SessionControl]
        public ActionResult KategorileriListele()
        {
            List<Kategori> kategoriler = veritabani.Kategori.ToList();
            return View(kategoriler);
        }

        [_SessionControl]
        public ActionResult HaberGetir(int id)
        {
            List<Haber> haberler = (from h in veritabani.Haber where h.kategori_id == id select h).ToList();
            return View(haberler);
        }


    }
}