using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MontyHallProblem.Porta;

namespace MontyHallProblem
{
    internal class Roulette
    {

        public static void RouletteMain()
        {
            double vitorias = 0;
            double derrotas = 0;
            double winrate;
            double loserate;
            Stopwatch stopwatch = new Stopwatch();
            Random r = new Random();
            bool sortear;
            int quantidade = 0;

            Console.Write("Informe quantas vezes deseja realizar a simulação: ");
            quantidade = coletarImput();

            stopwatch.Start();
            Console.WriteLine("\n========================================");
            Console.Write("Realizando simulações... ");

            for (int i = 0; i < quantidade; i++)
            {
                sortear = Sortear(r);
                if (sortear == true)
                {
                    vitorias = vitorias + 1;
                }
                if (sortear == false)
                {
                    derrotas = derrotas + 1;
                }
            }
            stopwatch.Stop();

            winrate = getWinrate(vitorias, derrotas, true, quantidade);
            loserate = getWinrate(vitorias, derrotas, false, quantidade);

            Console.WriteLine("\nVitórias: " + vitorias);
            Console.WriteLine("Derrotas: " + derrotas);

            Console.WriteLine("\nWinrate esperado no problema: 46.5%");
            Console.WriteLine("Winrate obtido: " + winrate + "%");

            Console.WriteLine("\nLoserate esperado no problema: 53.50%");
            Console.WriteLine("Loserate obtido: " + loserate + "%");

            double tempoDecorrido = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nTempo de execução: " + tempoDecorrido + "." + stopwatch.ElapsedMilliseconds % 100 + "s");
            Console.WriteLine("==========================================");
            Console.WriteLine("|Informações utilizadas:                 |");
            Console.WriteLine("|-Você sempre aposta no vermelho         |");
            Console.WriteLine("|-Existe 46.5% de chance de cair vermelho|");
            Console.WriteLine("|-Existe 46.5% de chance de cair preto   |");
            Console.WriteLine("|-Existe 7% de chance de cair verde      |");
            Console.WriteLine("==========================================");

            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

        public static bool Sortear(Random r)
        {
            double Sortear = 0 + (100 - 0) * r.NextDouble();
            //double Sortear = r.NextDouble(0, 100);

            if (Sortear <= 46.5)
            {
                return true;
            }
            else
            {
                return false;
            }


            
        }

    }
}
