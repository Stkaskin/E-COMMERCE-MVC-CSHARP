using denemenet.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace denemenet.Models
{
    public class ContextDb : DbContext  
    {
       
        public virtual DbSet<katagori> KatagoriTablosu { get; set; }
        public virtual DbSet<resims> ResimTablosu { get; set; }

        public virtual DbSet<urun> UrunTablosu { get; set; }
        public virtual DbSet<mesaj> MesajTablosu { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<urun>()
                .HasMany(e => e.resim1)
                .WithRequired(e => e.urun)
                .WillCascadeOnDelete(false);
            //modelBuilder.Entity<urun>()
            //   .HasMany(e => e.mesajlar)
            //   .WithRequired(e => e.urun)
            //   .WillCascadeOnDelete(false);
        }
      
    }
}