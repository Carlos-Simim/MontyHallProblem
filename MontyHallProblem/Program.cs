using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net;

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
            String UserIP = GetIPAddress();
            var Ip_Api_Url = "http://ip-api.com/json/" + UserIP.ToString();

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
                                    //Console.Clear();
                                    Console.WriteLine("\nEu avisei!!!!!!??!");
                                    Thread.Sleep(2000);
                                    Console.Write("Carregando: ");
                                    for(int i = 0; i < 50; i++)
                                    {
                                        Console.Write("|");
                                        Thread.Sleep(100);
                                    }
                                    Console.WriteLine("\n\nSeu país: " + geolocationInfo.country);
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Seu estado: " + geolocationInfo.regionName);
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Sua cidade: " + geolocationInfo.city);
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Sua latitude: " + geolocationInfo.lat);
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Sua longitude: " + geolocationInfo.lon);
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Aqui pra vc _|_");
                                    Console.WriteLine("=======================================");
                                    Console.Write("\nPressione enter pra sair bobão");
                                    Console.ReadLine();
                                    fazerPalhacadinha();
                                    Environment.Exit(0);

                                }
                            }
                        }
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

        protected static string GetIPAddress()
        {
            String UserIP = new WebClient().DownloadString(@"http://icanhazip.com").Trim();
            

            return UserIP;
        }

        public static void fazerPalhacadinha()
        {
            System.Diagnostics.Process.Start("https://lista.mercadolivre.com.br/comprar-escravos");
            System.Diagnostics.Process.Start("https://clinicamauad.com.br/blog/cura-para-calvicie-existe-descubra/");
            System.Diagnostics.Process.Start("https://hypescience.com/maneiras-se-livrar-corpo/");
            System.Diagnostics.Process.Start("https://www.plural.jor.br/cronicas/sandoval/receita-para-uma-bomba-caseira/");
            System.Diagnostics.Process.Start("https://www.casadotiro.com.br/filtro-categoria/armas-de-fogo/16/"); 
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=B5PDj-vM7YA");
            System.Diagnostics.Process.Start("https://www.ojogodobicho.com/deu_no_poste.htm");
            System.Diagnostics.Process.Start("https://www.submarino.com.br/busca/comprar-drogas");
            System.Diagnostics.Process.Start("https://www.google.com/search?q=mulheres+sem+sem+roupa+bonitas+lindas+esbeltas&client=opera-gx&hs=A2f&ei=nrPIYq3_MfnR1sQPxK2q6Ak&ved=0ahUKEwitxqi2r-r4AhX5qJUCHcSWCp0Q4dUDCA0&uact=5&oq=teste+teste+teste+aaaaa&gs_lcp=Cgdnd3Mtd2l6EAMyBwghEAoQoAE6BwgAEEcQsAM6BwgAELADEEM6CggAEOQCELADGAE6FQguEMcBEKMCENQCEMgDELADEEMYAjoSCC4QxwEQ0QMQyAMQsAMQQxgCOgsIABCABBCxAxCDAToFCAAQgAQ6CAgAELEDEIMBOggIABCABBCxAzoHCAAQgAQQCjoGCAAQHhAWOgUILhCABDoICAAQHhAPEBY6CAgAEB4QFhAKOgUIIRCgAToICCEQHhAWEB1KBAhBGABKBAhGGAFQalidImCBJGgDcAF4AIABsAGIAc4UkgEEMC4yMJgBAKABAcgBEcABAdoBBggBEAEYCdoBBggCEAEYCA&sclient=gws-wiz");
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
