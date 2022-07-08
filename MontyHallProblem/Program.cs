using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MontyHallProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vitorias = 0;
            double derrotas = 0;
            double winrate;
            double loserate;
            Stopwatch stopwatch = new Stopwatch();
            Random r = new Random();
            bool sortear;
            Console.Write("Informe a quantidade desejada de simulações: ");
            int quantidade;
            String imput = Console.ReadLine();

            quantidade = Int32.Parse(imput);

            stopwatch.Start();

            Console.Write("\nRealizando simulações... ");
            
                for (int i = 0; i < quantidade; i++)
                {

                    sortear = Porta.Sortear(r);
                    if (sortear == true)
                    {
                        vitorias = vitorias + 1;
                    }
                    if (sortear == false)
                    {
                        derrotas = derrotas + 1;
                    }

                    
                }
            
            Console.WriteLine("Finalizado.");
            Thread.Sleep(2000);

            stopwatch.Stop();

            winrate = Porta.getWinrate(vitorias, derrotas, true, quantidade);
            loserate = Porta.getWinrate(vitorias, derrotas, false, quantidade);

            Console.WriteLine("Vitórias: " + vitorias);
            Console.WriteLine("Derrotas: " + derrotas);

            Console.WriteLine("\nWinrate esperado no problema: 66.666%");
            Console.WriteLine("Winrate obtido: " + winrate + "%");
            
            Console.WriteLine("\nLoserate esperado no problema: 33.333%");
            Console.WriteLine("Loserate obtido: " + loserate + "%");

            double tempoDecorrido = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nTempo de execução: " + tempoDecorrido + "." + stopwatch.ElapsedMilliseconds % 100 + "s");

            Console.ReadLine();

        }
    }
}
