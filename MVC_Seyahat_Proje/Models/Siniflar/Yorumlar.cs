using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Seyahat_Proje.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        //public int BlogID { get; set; }
        //ilişki kurmak için
        public int Blogid { get; set; }
        public virtual Blog Blog { get; set; }

    }
}