using System.Web;
using System.Web.Http;

namespace AdvertisementManagement.Api.Controllers
{
    public class ErrorController : ApiController
    {
        [HttpGet, HttpPost, HttpDelete, HttpPut]
        public IHttpActionResult NotFound(string path)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new HttpException(404, "404 Not Found: /" + path));
            return NotFound();
        }
    }
}
