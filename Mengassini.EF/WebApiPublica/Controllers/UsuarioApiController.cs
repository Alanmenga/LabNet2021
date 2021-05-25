using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using WebApiPublica.Models;
using System.Net;
using System.IO;
using System.Web;

namespace WebApiPublica.Controllers
{
    public class UsuarioApiController : ApiController
    {
        // GET: api/Usuario
        public UsuarioView Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1l WOW64; rv:23.0) Gecjo/20100101 Firefox/23.0";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Proxy = null;
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string datos = HttpUtility.HtmlDecode(streamReader.ReadToEnd());

            UsuarioView data=JsonConvert.DeserializeObject<UsuarioView>(datos);

            return data;
        }
    }
}
