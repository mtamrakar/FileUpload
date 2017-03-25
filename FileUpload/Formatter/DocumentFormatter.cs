using FileUpload.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FileUpload.Formatter
{
    public class DocumentFormatter:MediaTypeFormatter
    {
        public DocumentFormatter()
        {            
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            //Your custom model type
            return type == typeof(Document);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            if (!content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }           
            
            var response = await content.ReadAsMultipartAsync();

            var fileContent = response.Contents.Where(x => x.Headers.ContentDisposition.Name.Trim('"') == "document");
            var jsonContent = response.Contents.Where(x => x.Headers.ContentDisposition.Name.Trim('"') == "json").FirstOrDefault();
            var jsonData = await jsonContent.ReadAsStringAsync();

            var document = JsonConvert.DeserializeObject<Document>(jsonData);
            document.Content = fileContent;
            return document;
        }
    }
}