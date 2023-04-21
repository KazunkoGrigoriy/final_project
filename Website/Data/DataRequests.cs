using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Website.Interfaces;
using Website.Models;

namespace Website.Data
{
    public class DataRequests : IRequestsData
    {
        HttpClient httpClient = new HttpClient();

        public void AddRequest(Request request)
        {
            string url = @"https://localhost:44373/webapi";

            try
            {
                var p = httpClient.PostAsync(
                                    requestUri: url,
                                    content: new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                                    mediaType: "application/json")
                                    ).Result;
            } catch
            {

            }
        }
    }
}
