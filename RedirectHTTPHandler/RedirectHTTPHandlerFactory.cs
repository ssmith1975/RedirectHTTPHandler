using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RedirectHTTPHandler
{
    public class RedirectHTTPHandlerFactory : System.Web.UI.PageHandlerFactory
    {
        public override  IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            string localHost;
            string referrerHost;

            localHost = context.Request.Url.Host;
            referrerHost = (context.Request.UrlReferrer != null ? context.Request.UrlReferrer.Host : String.Empty);

            // Is request local?
            if (localHost == referrerHost)
            {
                // Business as usual
                return base.GetHandler(context, requestType, url, pathTranslated);//new DefaultHttpHandler();
            }
            else
            { 
                // Intercept invalid page request
                return new RedirectHTTPHandler();
                //context.Response.Write("Not a local request! Get outta here!!!<br/><br/>");

            }
           
        }

        //public void ReleaseHandler(IHttpHandler handler)
        //{
            //Do nothing
            //throw new NotImplementedException();
        //}
    }
}
