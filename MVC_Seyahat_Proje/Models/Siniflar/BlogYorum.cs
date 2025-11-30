using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Seyahat_Proje.Models.Siniflar
{
    public class BlogYorum
    {
        //1 index'e birden fazla tablodan veri çekebilmek için
        public IEnumerable<Blog> blg {  get; set; }
        public IEnumerable<Yorumlar> yrm { get; set; }
        public IEnumerable<Blog> blgsirala { get; set; }
    }
}