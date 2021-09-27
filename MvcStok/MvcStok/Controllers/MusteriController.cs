using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Müşteriler.ToList();
            var degerler = db.Müşteriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public  ActionResult YeniMusteri()
        {
            return View();


        }
        [HttpPost]
        public ActionResult YeniMusteri(Müşteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");

            }
            db.Müşteriler.Add(p1);
            db.SaveChanges();
            return View();
            

        }
        public ActionResult SIL(int id)
        {
            var musteri = db.Müşteriler.Find(id);
            db.Müşteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");




        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Müşteriler.Find(id);
            return View("MusteriGetir", mus);



        }
        public ActionResult Guncelle(Müşteriler p1)
        {
            var musteri = db.Müşteriler.Find(p1.Musteriid);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyAd = p1.MusteriSoyAd;
            db.SaveChanges();
            return RedirectToAction("Index");





        }
            
        
        
            


        
    }
}