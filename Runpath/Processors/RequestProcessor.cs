using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Runpath.Processors
{
    public class RequestProcessor : IRequestProcessor
    {
        public T Process<T>(string requestUrl)
        {
            T result = default;

            HttpClientHandler hch = new HttpClientHandler();
            hch.Proxy = null;
            hch.UseProxy = false;

            using (HttpClient client = new HttpClient(hch))
            {
                try
                {
                    var response = client.GetAsync(requestUrl).Result;
                    response.EnsureSuccessStatusCode();

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<T>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Exception:{0} ", e.Message);
                }
            }

            return result;
        }
    }
}
