using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Seyahat_Proje.Models.Siniflar;

namespace MVC_Seyahat_Proje.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        public ActionResult About()
        {

            return View();
        }
        public PartialViewResult Partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.Where(x => x.ID==1).ToList();
            return PartialView(degerler);
        }
        //en popüler 10 blog
        public PartialViewResult Partial3()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }
        //en beğendiğim yerler sol 3
        public PartialViewResult Partial4()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
        //en beğendiğim yerler sağ 3
        public PartialViewResult Partial5()
        {
            var degerler = c.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }
    }
}