using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuth_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
//aaa
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string uname)
        {
            if (!string.IsNullOrWhiteSpace(uname))
            {
                FormsAuthentication.SetAuthCookie(uname, true);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //身份验证
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Write("通过验证");
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
                filterContext.HttpContext.Response.End();
            }
        }
    }
}