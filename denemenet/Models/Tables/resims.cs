using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace denemenet.Models.Tables
{
    [Table("resims")]
    public class resims
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int urunID { get; set; }

        [Required]
        [StringLength(100)]
        public string resimYolu { get; set; }

        public virtual urun urun { get; set; }
    }
}