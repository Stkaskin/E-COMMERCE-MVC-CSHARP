using denemenet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace denemenet.Controllers
{
    public class detaController : Controller
    {
        // GET: deta
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]
        public ActionResult LoginControl(admin GetAdmin)
        {
            if (GetAdmin.username == "admindeta" && GetAdmin.parola == "123")
            {
                FormsAuthentication.SetAuthCookie("admindeta", false);

                return RedirectToAction("ozet", "admin");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "deta");
        }
    }
}