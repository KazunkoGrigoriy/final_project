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
            string token = "6027163971:AAFPLZy5XhNTwLNBVs-tJqCUW2j2jlZE6ak";

            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
            bot.StopReceiving();
        }

        private static IEnumerable<Request> GetRequests()
        {
            HttpClient httpClient = new HttpClient();
            string url = @"https://localhost:44373/webapi";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Request>>(json);
        }

        private static Request GetRequest(int id)
        {
            HttpClient httpClient = new HttpClient();
            string url = @"https://localhost:44373/webapi" + id;
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Request>(json);
        }

        private static void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            if (e.Message.Text == null) return;

            if (e.Message.Text == "/start") //начало работы
            {
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Приветствую! Мое имя Учебный бот\n" +
                "Вам доступна команда /getrequests для получения списка заявок");
            }

            if (e.Message.Text == "/getrequests")
            {
                IEnumerable<Request> requests = GetRequests();
                foreach(var item in requests)
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, $"{item.Id}, {item.Name}, {item.Status}, {item.Email}, {item.Message}");
                }
            }
        }
    }
}
