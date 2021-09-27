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
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Kategori.ToList();
            var degerler = db.Kategori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {

            return View();

        }

        [HttpPost]
        public ActionResult YeniKategori(Kategori P1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");

            }
            db.Kategori.Add(P1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SIL(int id)
        {
            var kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Kategori.Find(id);
            return View("KategoriGetir",ktgr);   


        }
        public ActionResult Guncelle(Kategori p1)
        {
            var ktg = db.Kategori.Find(p1.Kategoriid);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}