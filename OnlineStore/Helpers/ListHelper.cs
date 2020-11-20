
using System.Web.Mvc;

namespace OnlineStore.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, string[] item)
        {
            TagBuilder ui = new TagBuilder("ui");
            foreach (var tt in item)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(tt);
                ui.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ui.ToString());
        }
    }
}