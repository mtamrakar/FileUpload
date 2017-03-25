using FileUpload.Models;
using System.Web.Http;

namespace FileUpload.Controllers
{
    public class FileController : ApiController
    {
        [Route("upload")]
        public IHttpActionResult Upload(Document document)
        {
            var files = document.Content;

            foreach(var file in files)
            {
                //This gives you file as byte[] 
                var bytes = file.ReadAsByteArrayAsync().Result;

                //This gives you file as byte[] 
                //var stream = file.ReadAsStreamAsync().Result;

                //This gives you file as byte[] 
                //var string = file.ReadAsStringAsync().Result;
            }
            return Created("", "");
        }

    }
}
