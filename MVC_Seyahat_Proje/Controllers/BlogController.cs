using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Seyahat_Proje.Models.Siniflar;
namespace MVC_Seyahat_Proje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.blg = c.Blogs.ToList();
            //by.blgsirala = c.Blogs.Take(4).ToList();
            by.blgsirala = c.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            by.yrm = c.Yorumlars.Take(3).OrderByDescending(x => x.ID).ToList();

            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {   
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.blg = c.Blogs.Where(x => x.ID == id).ToList();
            by.yrm = c.Yorumlars.Where(x=>x.Blogid == id).ToList();
            return View(by);
        }
        //yorum yapma
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}