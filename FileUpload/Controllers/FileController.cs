using FileUpload.Models;
using System.Web.Http;

namespace FileUpload.Controllers
{
    public class FileController : ApiController
    {
        [Route("upload")]
        public IHttpActionResult Upload(Document document)
        {
            
            return Created("", "");
        }

    }
}
