using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using denemenet.Models;
using denemenet.Models.Tables;

namespace denemenet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            using (ContextDb db = new ContextDb())
            {

                db.Database.CreateIfNotExists();
          
                
/*
                //10-25 kayýt kodu--hafta 12 dk24-35
               
                for (int i = 0; i < 10; i++)
                {
                    int c = i % 4;
                    katagori k = new katagori();
                    k.name = "Katagori "+FakeData.NameData.GetFirstName();
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
                        a.Adi ="urun"+ FakeData.NameData.GetSurname();
                        a.Fiyat = FakeData.NumberData.GetNumber(0, 50);

                        a.Resim = "urunresim" + FakeData.NumberData.GetNumber(0, 9) + ".jpg";
                        a.katagoriID = FakeData.NumberData.GetNumber(1, 10);

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
                            m.replyid = FakeData.NumberData.GetNumber(51,99);
                            m.replytext = FakeData.TextData.GetSentences(2);
                            m.mail = FakeData.NetworkData.GetEmail();

                            m.Time = FakeData.DateTimeData.GetDatetime();
                            
                            db.ResimTablosu.Add(b);
                            db.MesajTablosu.Add(m);
                            db.SaveChanges();
                        }
                        

                    }
                }
              

                /*  Kisi k = new Kisi();
                  k.Ad = "Ahmet";
                  k.Soyad = "KEMAL";
                  k.Yas = 30;
                  db.KisiTablosu.Add(k);
                  db.SaveChanges();
                */

            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
