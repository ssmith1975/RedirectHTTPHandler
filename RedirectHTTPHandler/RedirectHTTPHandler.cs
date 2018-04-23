using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Web;

namespace RedirectHTTPHandler
{
    public class RedirectHTTPHandler:IHttpHandler
    {

        public bool IsReusable {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // Should redirect to homepage
            context.Response.Redirect("~");
        }


    }
}
