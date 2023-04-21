using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using WpfApplication.Model;

namespace WpfApplication.Data
{
    class DataRequest
    {
        private string url = @"https://localhost:44373/webapi";
        public IEnumerable<Request> GetRequests()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var get = httpClient.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<IEnumerable<Request>>(get);
            } catch
            {
                return null;
            }
        }

        public void Update(Request request)
        {
            HttpClient httpClient = new HttpClient();
            var update = httpClient.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request))).Result;
        }
    }
}
