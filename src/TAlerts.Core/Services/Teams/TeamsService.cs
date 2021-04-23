using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TAlerts.Core.Services.Teams
{
    public class TeamsService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public void Send(Request request)
        {
            var url = "SUA URL DO TEAMS AQUI";

            var jsonRequest = JsonConvert.SerializeObject(request);

            var response = HttpClient.PostAsync(
                url,
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