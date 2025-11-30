using MVC_Seyahat_Proje.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Seyahat_Proje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        //mesaj gönderme
        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult MesajGonder(iletisim i)
        {
            c.iletisims.Add(i);
            c.SaveChanges();
            return PartialView();
        }
    }
}