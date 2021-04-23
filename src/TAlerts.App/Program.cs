using System;
using TAlerts.Core.Services.Teams;

namespace TAlerts.App
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastrarCliente();

            Console.ReadKey();
        }

        public static void CadastrarCliente()
        {
            try
            {
                //tenta cadastrar o cliente aqui
                throw new Exception("Erro ao cadastrar o cliente");
            }
            catch (Exception)
            {
                var teamsRequest = new Request
                {
                    Context = "https://schema.org/extensions",
                    Type = "MessageCard",
                    ThemeColor = "000",
                    Title = "Deu erro :(",
                    Text = "Erro ao cadastrar o cliente ABCD"
                };

                new TeamsService().Send(teamsRequest);
                Console.WriteLine("Deu erro...");
            }
        }
    }
}
