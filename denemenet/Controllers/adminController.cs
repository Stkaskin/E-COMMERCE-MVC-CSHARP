using denemenet.Models;
using denemenet.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace denemenet.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        ContextDb db = new ContextDb();

        public ActionResult Login()
        {
            return View();
        }
        [Authorize]
        public ActionResult AdminLayout() { return View(); }
        [Authorize]
        public ActionResult ozet()
        {
            AllModelView model = new AllModelView();
            model.KatagoriListesi = db.KatagoriTablosu.ToList();
            model.MesajListesi = db.MesajTablosu.ToList();
            model.ResimListesi = db.ResimTablosu.ToList();
            model.UrunListesi = db.UrunTablosu.ToList();

            return View(model);
        }
        [Authorize]
        public ActionResult yorum()
        {
            detayViewModel model = new detayViewModel();
            model.MesajListesi = db.MesajTablosu.OrderByDescending(x => x.Time).ToList();
            model.UrunListesi = db.UrunTablosu.ToList();

            return View(model);
        }
        [Authorize]
        public ActionResult soru() { return View(); }//pasif
        [Authorize]
        public ActionResult Katagori()
        {
            UrunModelView model = new UrunModelView();
            model.KatagoriListesi = db.KatagoriTablosu.ToList();
            return View(model);
        }
        [Authorize]
        public ActionResult Urun()
        {
            UrunModelView model = new UrunModelView();
            model.UrunListesi = db.UrunTablosu.ToList();
            return View(model);
        }
        public ActionResult UrunDetay() { return View(); }
        [Authorize]
        public ActionResult kayitlariekle() {

            //10-25 kayıt kodu--hafta 12 dk24-35

            for (int i = 0; i < 10; i++)
            {
                int c = i % 4;
                katagori k = new katagori();
                k.name = "Katagori " + FakeData.NameData.GetFirstName();
                k.resim = "katagori" + c + ".jpg";
                k.link = FakeData.NameData.GetCompanyName();
                db.KatagoriTablosu.Add(k);
                db.SaveChanges();
            }

            List<katagori> kategorilist = db.KatagoriTablosu.ToList();
            List<resims> resimList = db.ResimTablosu.ToList();
            List<mesaj> mesajList = db.MesajTablosu.ToList();
            foreach (var id in kategorilist)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    urun a = new urun();
                    resims b = new resims();
                    mesaj m = new mesaj();
                    a.Adi = "urun" + FakeData.NameData.GetSurname();
                    a.Fiyat = FakeData.NumberData.GetNumber(0, 50);

                    a.Resim = "urunresim" + FakeData.NumberData.GetNumber(0, 9) + ".jpg";
                    
                    a.katagoriID = id.ID;
                    db.UrunTablosu.Add(a);
                    db.SaveChanges();
                    int sonid = a.id;

                    for (int x = 0; x < FakeData.NumberData.GetNumber(1, 5); x++)
                    {
                        b.urunID = sonid;

                        b.resimYolu = "urunresim" + FakeData.NumberData.GetNumber(0, 9) + ".jpg";

                        m.urunID = sonid;
                        m.name = FakeData.NameData.GetFirstName();
                        m.text = FakeData.TextData.GetSentences(3);
                        m.replyid = FakeData.NumberData.GetNumber(51, 99);
                        m.replytext = FakeData.TextData.GetSentences(2);
                        m.mail = FakeData.NetworkData.GetEmail();

                        m.Time = FakeData.DateTimeData.GetDatetime();

                        db.ResimTablosu.Add(b);
                        db.MesajTablosu.Add(m);
                        db.SaveChanges();
                    }


                }
            }

            return RedirectToAction("ozet","admin"); }

       



    }
}