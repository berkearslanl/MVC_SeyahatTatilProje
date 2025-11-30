using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Seyahat_Proje.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlokImage { get; set; }
        //ilişkideki yorumları dahil etme
        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}