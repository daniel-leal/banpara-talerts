using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TAlerts.Core.Services.Teams
{
    public class TeamsService
    {
        private readonly string _url = string.Empty;

        private static readonly HttpClient HttpClient = new HttpClient();

        public TeamsService()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _url = root.GetSection("ApplicationSettings").GetSection("TeamsWebHook").Value;
        }

        public void Send(Request request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);

            var response = HttpClient.PostAsync(
                _url,
                new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            ).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mensagem enviada ao MS Teams");
            }
            else
            {
                Console.WriteLine("Erro ao enviar mensagem ao MS Teams");
            }
        }
    }

    public class Request
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("themeColor")]
        public string ThemeColor { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}