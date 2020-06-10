using HaberPortal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortal.Controllers
{
    public class AnasayfaController : Controller
    {

        ModelHaber1 veritabani = new ModelHaber1();

        // GET: Anasayfa
        public ActionResult Anasayfa()
        {
            List<Haber> sonEklenenler = veritabani.Haber.OrderByDescending(x => x.tarih).Take(5).ToList();
            return View(sonEklenenler);
        }

        public ActionResult MagazinCarouselGetir()
        {
            List<Haber> sonEklenenMagazinHaberleri = veritabani.Haber.Where(x => x.kategori_id == 5).
                OrderByDescending(x => x.tarih).Take(5).ToList();
            return View(sonEklenenMagazinHaberleri);
        }


        public ActionResult SporCarouselGetir()
        {
            List<Haber> sonEklenenMagazinHaberleri = veritabani.Haber.Where(x => x.kategori_id == 4).
                OrderByDescending(x => x.tarih).Take(5).ToList();
            return View(sonEklenenMagazinHaberleri);
        }

        public ActionResult Son20HaberGetir()
        {
            List<Haber> son20Haber = veritabani.Haber.OrderByDescending(x => x.tarih).Take(20).ToList();
            return View(son20Haber);
        }

        public ActionResult HaberDetay(int id)
        {
            Haber haber = (from h in veritabani.Haber where h.id==id select h).FirstOrDefault();
            return View(haber);
        }

        public ActionResult KategoriSon5(int kategori_id)
        {
            List<Haber> haberler = (from h in veritabani.Haber where h.kategori_id == kategori_id select h).OrderByDescending(x => x.tarih).Take(5).ToList();
            return View(haberler);
        }

        public ActionResult Gundem()
        {
            List<Haber> liste = (from haber in veritabani.Haber join kategori in veritabani.Kategori on
                                 haber.kategori_id equals kategori.id where kategori.kategori_ad.Contains("Gundem") select haber).ToList();                    
            return View(liste);
        }

        public ActionResult Spor()
        {
            List<Haber> liste = (from haber in veritabani.Haber
                                 join kategori in veritabani.Kategori on
                                    haber.kategori_id equals kategori.id
                                 where kategori.kategori_ad.Contains("Spor")
                                 select haber).ToList();
            return View(liste);
        }

        public ActionResult Dunya()
        {
            List<Haber> liste = (from haber in veritabani.Haber
                                 join kategori in veritabani.Kategori on
                                 haber.kategori_id equals kategori.id
                                 where kategori.kategori_ad.Contains("Dunya")
                                 select haber).ToList();
            return View(liste);
        }

        public ActionResult Ekonomi()
        {
            List<Haber> liste = (from haber in veritabani.Haber
                                 join kategori in veritabani.Kategori on
                                 haber.kategori_id equals kategori.id
                                 where kategori.kategori_ad.Contains("Ekonomi")
                                 select haber).ToList();
            return View(liste);
        }

        public ActionResult SonDakika()
        {
            List<Haber> liste = (from haber in veritabani.Haber select haber).OrderByDescending(h => h.tarih).Take(9).ToList();
            return View(liste); 
        }

        public ActionResult Magazin()
        {
            List<Haber> liste = (from h in veritabani.Haber
                                 join k in veritabani.Kategori
                                 on h.kategori_id equals k.id
                                 where k.kategori_ad.Contains("Magazin")                             
                                 select h).ToList();
            return View(liste);
        }

        public ActionResult SonDakikaBar()
        {
            List<Haber> haberler = veritabani.Haber.OrderByDescending(x => x.tarih).Take(5).ToList();
            return View(haberler);
           
        }


    }
}