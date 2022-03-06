using denemenet.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace denemenet.Models
{
    public class UrunModelView
    {
        public List<katagori> KatagoriListesi { get; set; }
        public List<urun> UrunListesi { get; set; }
        public List<resims> ResimListesi { get; set; }
       
        //Sonradan eklencek icin ayrılmış simdilik tek kullanımlık model
    }
}