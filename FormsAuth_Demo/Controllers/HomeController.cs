using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuth_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //这里存储的是 FormsAuthentication.SetAuthCookie(uname, true); 里的uname，这个变量可以换成用户信息的json字符串，到时候转换一下，就能
            //获取更多的用户信息。
            var ss = HttpContext.User.Identity.Name;

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
                //在正常的登陆功能里，这里需要修改，通过sql查询得到用户信息，记录用户的 id，名称，等信息存到cookie里。

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