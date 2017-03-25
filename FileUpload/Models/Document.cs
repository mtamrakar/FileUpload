using System.Collections.Generic;
using System.Net.Http;

namespace FileUpload.Models
{
    public class Document
    {
        public string CreatedBy { get; set; }

        public string Company { get; set; }

        public IEnumerable<HttpContent> Content {get;set;}
    }
}