using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Text;

namespace System.Web.Mvc
{
    public static class MikePagerHtmlExtensions
    {

        #region MikePager 分页控件

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data)
        {
            string actioinName = html.ViewContext.RouteData.GetRequiredString("action");
            return MikePager<T>(html, data, actioinName);
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, object values)
        {
            string actioinName = html.ViewContext.RouteData.GetRequiredString("action");
            return MikePager<T>(html, data, actioinName, values);
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, string action)
        {
            return MikePager<T>(html, data, action, null);
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, string action, object values)
        {
            string controllerName = html.ViewContext.RouteData.GetRequiredString("controller");
            return MikePager<T>(html, data, action, controllerName, values);
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, string action, string controller, object values)
        {
            return MikePager<T>(html, data, action, controller, new RouteValueDictionary(values));
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, RouteValueDictionary values)
        {
            string actioinName = html.ViewContext.RouteData.GetRequiredString("action");
            return MikePager<T>(html, data, actioinName, values);
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, string action, RouteValueDictionary values)
        {
            string controllerName = html.ViewContext.RouteData.GetRequiredString("controller");
            return MikePager<T>(html, data, action, controllerName, values);
        }

        public static string MikePager<T>(this HtmlHelper html, PagedList<T> data, string action, string controller, RouteValueDictionary valuedic)
        {
            int start = (data.PageIndex - 2) >= 1 ? (data.PageIndex - 2) : 1;
            int end = (data.TotalPage - start) > 3 ? start + 3 : data.TotalPage;

            RouteValueDictionary vs = valuedic == null ? new RouteValueDictionary() : valuedic;

            var builder = new StringBuilder();
            if (data.IsPreviousPage)
            {
                vs["pageIndex"] = 1;
                vs["pageIndex"] = data.PageIndex - 1;
                builder.Append(Html.LinkExtensions.ActionLink(html, "&laquo;", action, controller, vs, null));
                builder.Append("&nbsp;");

            }

            for (int i = start; i <= end; i++) //前后各显示2个数字页码
            {
                vs["pageIndex"] = i;
                if (i == data.PageIndex)
                {
                    builder.Append(i.ToString ());
                }
                else
                {
                    builder.Append("&nbsp;");
                    builder.Append(Html.LinkExtensions.ActionLink(html, i.ToString(), action, controller, vs, null));
                }
            }

            if (data.IsNextPage)
            {
                builder.Append("&nbsp;");
                vs["pageIndex"] = data.PageIndex + 1;
                builder.Append(Html.LinkExtensions.ActionLink(html, "&raquo;", action, controller, vs, null));
                builder.Append("&nbsp;");

            }
            return builder.ToString();
        }
        #endregion

    }
}
