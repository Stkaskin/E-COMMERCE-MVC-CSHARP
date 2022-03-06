using denemenet.Models;
using denemenet.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace denemenet.Controllers
{
    public class SharedController : Controller
    {
        // GET: shared
        ContextDb db = new ContextDb();

      
        public ActionResult Menu()
        {
            var ChargeTypes = db.KatagoriTablosu.ToList();
            return View(ChargeTypes);
        }
        [HttpPost]
        public ActionResult _MenuLayout(mail getMail)
        {
            return View();
        }
        [HttpPost]
        public  JsonResult  Postmail (mail mailGet){


            MailMessage mailim = new MailMessage();
            mailim.To.Add("nitroemax@gmail.com");
            mailim.From = new MailAddress(mailGet.mailadress);
            mailim.Subject = mailGet.sub;
            mailim.Body = "Sayın yetkili," + mailGet.name + " kişisinden gelen mesajın içeriği aşağıdaki gibidir. <br>" + mailGet.message + "<br>" + "Ad Soyad:"+ mailGet.name+"<br>" +"Mail Adresi:"+mailGet.mailadress; 
            mailim.IsBodyHtml = true;

        
        

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("nitroemax@gmail.com", "123456789.qQ");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            byte donus = 0;
            try
            {
                
                smtp.Send(mailim);
                ViewData["Message"] = "1";
                donus = 1;


            }
            catch (Exception ex)
            {

                ViewData["Message"] =  ex.Message;
                donus = 0;
            }

            return Json(donus.ToString());
        }

      

    }
}