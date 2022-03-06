using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace denemenet.Models.Tables
{
    [Table("urun")]
    public class urun
    {
        //public urun()
        //{
        //    resim1 = new HashSet<resim>();
        //}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }

        public int? Fiyat { get; set; }

        [StringLength(100)]
        public string Resim { get; set; }

        public int? katagoriID { get; set; }

        public virtual katagori katagori { get; set; }
        
        
        public virtual ICollection<resims> resim1 { get; set; }
        public virtual ICollection<mesaj> mesajs { get; set; }






    }
}