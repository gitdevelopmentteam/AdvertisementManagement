using System;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using Elmah;

namespace AdvertisementManagement.Api.ElmahHandler
{
    public class ElmahHandleWebApiErrorAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            RaiseError(actionExecutedContext.Exception);
        }

        private static bool RaiseError(Exception e)
        {
            var context = HttpContext.Current;
            if (context == null)
                return false;
            var signal = ErrorSignal.FromContext(context);
            if (signal == null)
                return false;
            signal.Raise(e, context);
            return true;
        }
    }
}