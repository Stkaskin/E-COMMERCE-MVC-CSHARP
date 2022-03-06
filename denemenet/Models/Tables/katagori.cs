using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace denemenet.Models.Tables
{
    [Table("Kategori")]
    public class katagori
    {
       public katagori()
        {
            urun = new HashSet<urun>();
       }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string link { get; set; }

        [Required]
        [StringLength(100)]
        public string resim { get; set; }


        public virtual ICollection<urun> urun { get; set; }






    }
}