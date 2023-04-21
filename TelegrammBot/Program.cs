using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Telegram.Bot;

namespace TelegrammBot
{
    class Program
    {
        static TelegramBotClient bot;
        static void Main(string[] args)
        {
            string token = "*****";

            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
            bot.StopReceiving();

            //Console.WriteLine("Hello World!");
        }

        private static IEnumerable<Request> GetRequests()
        {
            HttpClient httpClient = new HttpClient();
            string url = @"https://localhost:48373/webapi";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Request>>(json);
        }

        private static Request GetRequest(int id)
        {
            HttpClient httpClient = new HttpClient();
            string url = @"https://localhost:48373/webapi/" + id;
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Request>(json);
        }

        private static void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            if (e.Message.Text == null) return;

            var MessageText = e.Message.Text;

            if(e.Message.Text == "/getrequests")
            {
                GetRequests();
            }

            int id = 0;
            try
            {
                id = int.Parse(e.Message.Text.Substring(12, e.Message.Text.Length - 12));
            } catch
            {
                Console.WriteLine("Необходимо ввести id");
            }
            
            if (e.Message.Text == $"/getrequest/{id}")
            {
                GetRequest(id);
            }
        }
    }
}
