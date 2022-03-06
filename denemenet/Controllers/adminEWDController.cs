using denemenet.Models;
using denemenet.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace denemenet.Controllers
{

    public class adminEWDController : Controller
    {
        ContextDb db = new ContextDb();
        [Authorize]
        public ActionResult ewdLayout() { return View(); }
        // GET: adminEWD
        /*//////////////////////////////// yeni kayıtlar/////////////////////////////////// */
        [Authorize] public ActionResult newurun() { return View(); }
        [Authorize] public ActionResult newkatagori() {
            
            
            return View(); }

        [Authorize] public ActionResult newyorum() { return View(); }
        [Authorize] public ActionResult newresim() { return View(); }
        /*//////////////////////////////// kayıt silme/////////////////////////////////// */
        [Authorize]
        public ActionResult urundelete(int? id)
        {
            urun urun = new urun();
            urun = db.UrunTablosu.Where(x => x.id == id).FirstOrDefault();
            if (urun != null) { return View(urun); }
            else { return RedirectToAction("Urun", "admin"); }
        }


        [Authorize]
        public ActionResult katagoridelete(int? id)
        {
            katagori katagori = new katagori();
            katagori = db.KatagoriTablosu.Where(x => x.ID == id).FirstOrDefault();

            if (katagori != null) { return View(katagori); }
            else { return RedirectToAction("Katagori", "admin"); }
        }
        [Authorize]
        public ActionResult yorumdelete(int? id)
        {
            mesaj mesaj = new mesaj();
            mesaj = db.MesajTablosu.Where(x => x.ID == id).FirstOrDefault();
            if (mesaj != null) { return View(mesaj); }
            else { return RedirectToAction("yorum", "admin"); }

        }
        [Authorize]
        public ActionResult urunedit(int? id)
        {
            urun urun = new urun();
            urun = db.UrunTablosu.Where(x => x.id == id).FirstOrDefault();


            if (urun != null) { return View(urun); }
            else { return RedirectToAction("urun", "admin"); }
        }
        [Authorize]
        public ActionResult katagoriedit(int? id)
        {
            katagori katagori = new katagori();
            katagori = db.KatagoriTablosu.Where(x => x.ID == id).FirstOrDefault();

            if (katagori != null) { return View(katagori); }
            else { return RedirectToAction("Katagori", "admin"); }
        }
        [Authorize]
        public ActionResult yorumedit(int? id)
        {
            mesaj mesaj = new mesaj();
            mesaj = db.MesajTablosu.Where(x => x.ID == id).FirstOrDefault();

            if (mesaj != null) { return View(mesaj); }
            else { return RedirectToAction("yorum", "admin"); }
        }

        /*/////////////////////////////////////////////////////////////////////*/
        [HttpPost, ActionName("urundelete")]
        [Authorize]
        public ActionResult urundeleteactive(int? id)
        {

            urun urun = db.UrunTablosu.Where(x => x.id == id).FirstOrDefault();
         
            List<resims> resimsListesi = db.ResimTablosu.Where(y => y.urun.id == id).ToList();
            List<mesaj> mesajListesi = db.MesajTablosu.Where(y => y.urun.id == id).ToList();
            foreach (var item in resimsListesi)
            {
                db.ResimTablosu.Remove(item);
            }
            foreach (var msj in mesajListesi)
            {
                db.MesajTablosu.Remove(msj);
            }
            db.UrunTablosu.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Urun", "admin");
        }
        [Authorize]
        [HttpPost,ActionName("newkatagori")]
        public ActionResult newkatagoriactive(katagori katagori)
        {
            katagori.link = FakeData.NameData.GetFirstName();
            katagori.resim = "katagori"+FakeData.NumberData.GetNumber(0, 4)+ ".jpg"; 
            db.KatagoriTablosu.Add(katagori);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("katagori", "admin");
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        [HttpPost, ActionName("newurun")]
        public ActionResult newurunactive(urun urun)
        {
          
            
            urun.Fiyat = FakeData.NumberData.GetNumber(0, 50);

            urun.Resim = "urunresim" + FakeData.NumberData.GetNumber(0, 9) + ".jpg";
          

            db.UrunTablosu.Add(urun);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Urun", "admin");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpPost, ActionName("katagoridelete")]
        public ActionResult katagorideleteactive(int? id)
        {
            if (id != null)
            {
                katagori katagori = db.KatagoriTablosu.Where(x => x.ID == id).FirstOrDefault();
                // Kişi kaydını silmeden önce ilişkili tablolardaki kayıtları silmeliyiz
                List<urun> urunListesi = db.UrunTablosu.Where(y => y.katagori.ID == id).ToList();
                List<resims> resimsListesi = db.ResimTablosu.Where(y => y.urun.katagori.ID == id).ToList();
                List<mesaj> mesajListesi = db.MesajTablosu.Where(y => y.urun.katagori.ID == id).ToList();
                foreach (var item in resimsListesi)
                {
                    db.ResimTablosu.Remove(item);
                }
                foreach (var item in mesajListesi)
                {
                    db.MesajTablosu.Remove(item);
                }
                foreach (var item in urunListesi)
                {
                    db.UrunTablosu.Remove(item);
                }
                db.KatagoriTablosu.Remove(katagori);
                db.SaveChanges();
            }
            return RedirectToAction("katagori", "admin");
        }
        [Authorize]
        [HttpPost, ActionName("yorumdelete")]
        public ActionResult yorumdeleteactive(int? id)
        {

            mesaj mesaj = db.MesajTablosu.Where(x => x.ID == id).FirstOrDefault();
            // Kişi kaydını silmeden önce ilişkili tablolardaki kayıtları silmeliyiz

            db.MesajTablosu.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("yorum", "admin");
        }
        [Authorize]
        [HttpPost, ActionName("urunedit")]
        public ActionResult uruneditactive(int? id, urun urun)
        {
            int sonuc = 0;
            urun urunR = db.UrunTablosu.Where(x => x.id == id).FirstOrDefault();
            if (urunR != null)
            {
                urunR.Adi = urun.Adi;
                urunR.katagoriID = urun.katagoriID;

                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Urun", "admin");
            }
            else
            {
                return View();
            }

        }
        [Authorize]
        [HttpPost, ActionName("katagoriedit")]
        public ActionResult katagorieditactive(int? id, katagori katagori)
        {
            int sonuc = 0;
            katagori katagoriR = db.KatagoriTablosu.Where(x => x.ID == id).FirstOrDefault();
            if (katagoriR != null)
            {
                katagoriR.name = katagori.name;


                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Katagori", "admin");
            }
            else
            {
                return View();
            }

        }
        [Authorize]
        [HttpPost, ActionName("yorumedit")]
        public ActionResult yorumeditactive(int? id, mesaj mesaj)
        {
            int sonuc = 0;
            mesaj mesajR = db.MesajTablosu.Where(x => x.ID == id).FirstOrDefault();
            if (mesajR != null)
            {
                mesajR.name = mesaj.name;
                mesajR.text = mesaj.text;



                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("yorum", "admin");
            }
            else
            {
                return View();
            }

        }
    }



}