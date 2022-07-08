using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace MontyHallProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolhaPrincipal;
            bool continuar = true;
            String input;
            int contagemErros = 0;
            var Ip_Api_Url = "http://ip-api.com/json/206.189.139.232";

            while (continuar == true)
            {
                
                
                Console.WriteLine("==========MENU==========");
                Console.WriteLine("|1 - Monty Hall Problem |");
                Console.WriteLine("|2 - Coin Flip          |");
                Console.WriteLine("|3 - Roulette           |");
                Console.WriteLine("|4 - Sair               |");
                Console.WriteLine("========================");
                Console.Write("\nEscolha uma opção da lista acima: ");
                input = Console.ReadLine();
                
                while(input != "1" && input != "2" && input != "3" && input != "4")
                {
                    Console.Clear();
                    Console.WriteLine("==========MENU==========");
                    Console.WriteLine("|1 - Monty Hall Problem |");
                    Console.WriteLine("|2 - Coin Flip          |");
                    Console.WriteLine("|3 - Roulette           |");
                    Console.WriteLine("|4 - Sair               |");
                    Console.WriteLine("========================");
                    if (contagemErros >= 3)
                    {
                        Console.WriteLine("Contagem de vidas: " + (10 - contagemErros));
                    }
                    if((10-contagemErros) <= 4 && (10 - contagemErros) > 0)
                    {
                        Console.Write("\nEita, suas vidas estão acabando :OOO - Melhor responder do jeito certo!! ");
                    }

                    if ((10 - contagemErros) > 0)
                    {
                        Console.Write("\nEscolha uma opção da lista acima (Responda apenas com 1, 2 3 ou 4 por favor): ");
                    }

                    if ((10 - contagemErros) <= 0)
                    {
                        TesteIp();
                        Console.ReadLine();
                    }
                    
                    
                    
                    input = Console.ReadLine();
                    contagemErros++;
                }

                escolhaPrincipal = Int32.Parse(input);
                

                if (escolhaPrincipal == 1)
                {
                    Console.Clear();
                    MontyHall.MontyHallMain();
                }
                if (escolhaPrincipal == 2)
                {
                    Console.Clear();
                    CoinFlip.CoinFlipMain();
                }
                if (escolhaPrincipal == 3)
                {
                    Console.Clear();
                    Roulette.RouletteMain();
                }
                if (escolhaPrincipal == 4)
                {
                    continuar = false;
                }
            }
            Console.WriteLine("\nPrograma finalizado! Obrigado por utilizá-lo ;)");
            Console.Write("\nAperte qualquer tecla para fechar a janela!");
            Console.ReadLine();
        }

        static void TesteIp()
        {
            var Ip_Api_Url = "http://ip-api.com/json/206.189.139.232";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Pass API address to get the Geolocation details 
                httpClient.BaseAddress = new Uri(Ip_Api_Url);
                HttpResponseMessage httpResponse = httpClient.GetAsync(Ip_Api_Url).GetAwaiter().GetResult();
                // If API is success and receive the response, then get the location details
                if (httpResponse.IsSuccessStatusCode)
                {
                    var geolocationInfo = httpResponse.Content.ReadAsAsync<LocationDetails_IpApi>().GetAwaiter().GetResult();
                    if (geolocationInfo != null)
                    {
                        Console.WriteLine("Country: " + geolocationInfo.country);
                        Console.WriteLine("Region: " + geolocationInfo.regionName);
                        Console.WriteLine("City: " + geolocationInfo.city);
                        Console.WriteLine("Zip: " + geolocationInfo.zip);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
    public class LocationDetails_IpApi
    {
        public string query { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string isp { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string org { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public string zip { get; set; }
    }
}
