using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace denemenet.Models.Tables
{
    [Table("mesaj")]

    public class mesaj
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int urunID { get; set; }

      //  [Required]
        [StringLength(350)]
        public string text { get; set; }
      //  [Required]
        [StringLength(80)]
        public string name { get; set; }
       // [Required]
        [StringLength(60)]
        public string mail { get; set; }
        //   [Required]
        //  public DateTime time { get; set; }
        public DateTime Time { get; set; }
        public int? replyid { get; set; }

        [StringLength(350)]
        public string replytext { get; set; }

        public virtual urun urun { get; set; }

    }
}