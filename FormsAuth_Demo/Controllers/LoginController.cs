using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuth_Demo.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string uname)
        {
            if (!string.IsNullOrWhiteSpace(uname))
            {
                //自动注册分发用户凭证
                FormsAuthentication.SetAuthCookie(uname, true);
                #region MyRegion
                //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                //            1,
                //            uname,
                //            DateTime.Now,
                //            DateTime.Now.AddMinutes(30),
                //            false,
                //            uname);

                //string encTicket = FormsAuthentication.Encrypt(authTicket);
                //HttpCookie cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                //if (cookie == null)
                //{
                //    cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                //}
                //cookie.Value = encTicket;
                //HttpContext.Response.AppendCookie(cookie); 
                #endregion
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}