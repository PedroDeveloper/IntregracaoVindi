using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using IntegracaoVindi.API.Model;

namespace IntregracaoVindi.API.Helpers
{
    public class ApiHelper
    {
        public static string HttpPostJson(string url, string json)
        {
           string username = "VWzGJHLQbg_brFaqkrjnRH8Q6HNY-HgfxYjwValE3JQ";
           string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}"));
           var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
           httpWebRequest.ContentType = "application/json";
           httpWebRequest.Headers.Add("Authorization", $"Basic {encoded}");
           httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

         public static string HttpGet(string url)
        {

            string username = "VWzGJHLQbg_brFaqkrjnRH8Q6HNY-HgfxYjwValE3JQ";
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}"));

            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("Authorization", $"Basic {encoded}");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }

    }
}
