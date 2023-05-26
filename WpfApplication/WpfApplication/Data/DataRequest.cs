using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using WpfApplication.Model;

namespace WpfApplication.Data
{
    static class DataRequest
    {
        private static string url = @"https://localhost:44373/webapi";

        public static IEnumerable<Request> GetRequests()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var get = httpClient.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<IEnumerable<Request>>(get);
            };
        }

        public static string Update(Request request)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage update = httpClient.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request),
                        Encoding.UTF8, "application/json")).Result;
                return "Обновление успешно";
            };
        }
    }
}