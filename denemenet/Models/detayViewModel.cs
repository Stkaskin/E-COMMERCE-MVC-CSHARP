using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using denemenet.Models.Tables;
namespace denemenet.Models
{
    public class detayViewModel
    {
        public List<mesaj> MesajListesi { get; set; }
        public List<urun> UrunListesi { get; set; }
        public List<resims> ResimListesi { get; set; }
     

    }
}