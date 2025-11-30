using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Seyahat_Proje.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MVC_Seyahat_Proje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        //blogları listeleme
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = c.Blogs.ToList();
            var degerler = c.Blogs.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        //yeni blog ekleme
        [HttpGet]//butona basılmazsa sadece sayfayı geri döndürür
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]//sayfada bir şey gönderilirse yapılacak işlemler
        public ActionResult YeniBlog(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //blog silme
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //blog güncelleme için bloggetir sayfasına verileri çekme
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir",b);
        }
        //güncelleme
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Tarih=b.Tarih;
            blg.Baslik=b.Baslik;
            blg.BlokImage=b.BlokImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //yorumlar
        public ActionResult YorumListesi(int sayfa = 1)
        {
            //var yorumlar = c.Yorumlars.ToList();
            var yorumlar = c.Yorumlars.ToList().OrderByDescending(x=>x.ID).ToPagedList(sayfa, 5);
            return View(yorumlar);
        }
        //yorum silme
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        //yorum güncelleme
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yr = c.Yorumlars.Find(y.ID);
            yr.KullaniciAdi = y.KullaniciAdi;
            yr.Mail = y.Mail;
            yr.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult iletisim()
        {
            var iletisim = c.iletisims.OrderByDescending(x => x.ID).ToList();
            return View(iletisim);
        }

    }
}