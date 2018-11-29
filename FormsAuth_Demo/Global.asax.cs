using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FormsAuth_Demo
{
    /// <summary>
    /// 使用 FormsAuthentication.SetAuthCookie 进行身份验证
    ///     1 在web.config文件中配置<system.web><authentication mode="Forms"></system.web>表单验证代码，指明验证登陆url
    ///     2 在想用的文件中实现 FormsAuthentication.SetAuthCookie(通过验证并发放登陆票据) 以及 FormsAuthentication.SignOut();(退出登录)
    ///     3 在所有的控制器里实现 验证过滤器(自定义)或重写 OnAuthorization(此方法是控制器基类继承而来) 方法；
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
