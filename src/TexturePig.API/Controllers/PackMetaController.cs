using Microsoft.AspNetCore.Mvc;
using Supabase.Realtime;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using static Supabase.Client;
using System.Net;

namespace TexturePig.API.Controllers
{
    public class PackMetaController : Controller
    {
        private const string URL = "https://sub.domain.com/objects.json";
        private string urlParameters = "?api_key=123";

        [Route("v1/pack/meta/{id}")]
        public IActionResult GetById(int id)
        {
            string html = string.Empty;
            string url = @"https://vneidrffkiqxdxwpwrzk.supabase.co/rest/v1/pack?select=id";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return Ok(new { html });
        }
    }
}
