using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public string Index()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null
                ? ""
                : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser:" + browser + "</p>"
            + "<p>User-Agent:" + user_agent + "</p>"
            + "<p>URL request:" + url + "</p>"
            + "<p>Referrer:" + referrer + "</p>"
            + "<p>IP-adress:" + ip + "</p>";
        }
    }
}