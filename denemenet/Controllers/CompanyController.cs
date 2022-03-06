using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace denemenet.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult kurumsal() { ViewData["Baslik"] = "Kurumsal";  return View(); } 
        public ActionResult hakkimizda() { ViewData["Baslik"] = "CANLİ TAVUK AL Hakkında"; return View(); }
        public ActionResult Company() { ViewData["Baslik"] = "Şirket"; return View(); }     
        public ActionResult _MenuLayout() {
          
                return View(); }
        public ActionResult MarkaFelsefe() { return View(); }
        public ActionResult anasayfa() { return View(); }
    
    }
}