using denemenet.Models;
using denemenet.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using denemenet.Models.Entity;
namespace denemenet.Controllers
{

    public class urunController : Controller
    {
        ContextDb db = new ContextDb();
        UrunModelView model = new UrunModelView();
        urun Tekurun = new urun();
        detayViewModel detayModel = new detayViewModel();
        public ActionResult urunler(int? id)
        {


            //  var deger = from d in db.UrunTablosu select d;
            //deger = deger.Where(m => m.katagoriID == id);

            model.UrunListesi = db.UrunTablosu.Where(m => m.katagoriID == id).ToList(); ;

            model.ResimListesi = db.ResimTablosu.Where(m => m.urun.katagoriID == id).ToList();
            if (model.UrunListesi.Count > 0) { ViewData["resim"] = "/image/urun_resim/" + model.UrunListesi.FirstOrDefault().Resim;
                ViewData["Baslik"] = model.UrunListesi.FirstOrDefault().katagori.name; }
            else {
                ViewData["resim"] = "/image/detakatagoriresim/" + db.KatagoriTablosu.Where(m => m.ID == id).FirstOrDefault().resim;
                ViewData["Baslik"] = db.KatagoriTablosu.Where(m => m.ID == id).FirstOrDefault().name; }

           

            foreach (var urn in model.UrunListesi)
            {

                ViewData["Baslik"] = urn.katagori.name;

                break;
            }

            return View(model);
        }
        public ActionResult katagori()
        {
            model.KatagoriListesi = db.KatagoriTablosu.ToList();
            model.ResimListesi = db.ResimTablosu.ToList();
            ViewData["Baslik"] = "TAVUK CİNSLERİ";
            ViewData["resim"] = "/image/detakatagoriresim/" + model.KatagoriListesi.FirstOrDefault().resim;
            return View(model);

        }
        public ActionResult detayurun(int? id)
        {


            //  var deger = from d in db.ResimTablosu select d;
            // deger = deger.Where(m => m.urunID == id);
            // detayModel.UrunListesi = db.ResimTablosu.ToList();
            detayModel.ResimListesi = db.ResimTablosu.Where(m => m.urunID == id).ToList();
            detayModel.MesajListesi = db.MesajTablosu.Where(m => m.urunID == id).ToList();

            Tekurun = db.UrunTablosu.Where(x => x.id == id).FirstOrDefault();
            ViewData["resim"] = "/image/urun_resim/" + Tekurun.Resim;
            ViewData["Baslik"] = Tekurun.katagori.name + "\n";
            ViewData["AltBaslik"] = Tekurun.Adi;
            TempData["id"] = id;
            ViewBag.urun = Tekurun;






            return View(detayModel);
        }
        class SendData
        {
            public string mail { get; set; }
            public string text { get; set; }
            public string name { get; set; }
        }

        [HttpPost]
        public JsonResult CommentsPost(mesaj MessageComments)
        {
            mesaj msg = new mesaj();
            //   Response.Redirect("GOOGLE.COM.TR");
            msg.urunID = (int)TempData["id"];
            msg.name = MessageComments.name;
            msg.text = MessageComments.text;
            msg.replyid = FakeData.NumberData.GetNumber(51, 99);
            msg.replytext = FakeData.TextData.GetSentences(2);
            msg.mail = MessageComments.mail;
            msg.Time = DateTime.Now.Date;
            string message = "";
            try
            {
                message = "Ekleme Başarılı En Kısa Zamanda Onaylanacaktır.";
                db.MesajTablosu.Add(msg);
                db.SaveChanges();
            }
            catch (Exception ex) { message = ex.ToString(); }

            TempData["id"] = msg.urunID;
            return Json(message);

        }


    }
}
