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
    public class UrunController : Controller
    {
        // GET: Ürün
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Ürünler.ToList();
            var degerler = db.Ürünler.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
           
            return View();                    

        }
        [HttpPost]
        public ActionResult UrunEkle(Ürünler p1)
        {
            db.Ürünler.Add(p1);
            db.SaveChanges();
            return View();


        }
        public ActionResult SIL(int id)
        {
            var urun = db.Ürünler.Find(id);
            db.Ürünler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.Ürünler.Find(id);
            return View("UrunGetir", urn);



        }
        public ActionResult Guncelle(Ürünler p)
        {
            var urun = db.Ürünler.Find(p.Urunid);
            urun.UrunAd = p.UrunAd;
            urun.UrunKategori = p.UrunKategori;
            urun.UrunFiyat = p.UrunFiyat;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");




        }
    }
}