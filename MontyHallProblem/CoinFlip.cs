using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MontyHallProblem.Porta;

namespace MontyHallProblem
{
    internal class CoinFlip
    {

        public static void CoinFlipMain()
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

            Console.WriteLine("\nWinrate esperado no problema: 50.00%");
            Console.WriteLine("Winrate obtido: " + winrate + "%");

            Console.WriteLine("\nLoserate esperado no problema: 50.00%");
            Console.WriteLine("Loserate obtido: " + loserate + "%");

            double tempoDecorrido = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nTempo de execução: " + tempoDecorrido + "." + stopwatch.ElapsedMilliseconds % 100 + "s");
            Console.WriteLine("==========================================");
            Console.WriteLine("|Informações utilizadas:                 |");
            Console.WriteLine("|-Você sempre aposta em coroa            |");
            Console.WriteLine("|-Existe 50% de chance de cair coroa     |");
            Console.WriteLine("|-Existe 50% de chance de cair cara      |");
            Console.WriteLine("==========================================");
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadLine();
            Console.Clear();

        }

        public static bool Sortear(Random r)
        {
            int Sortear = r.Next(0, 100);
            
            if(Sortear < 50)
            {
                return true;
            }
            if(Sortear >= 50)
            {
                return false;
            }

            
            return true;
        }


    }
}
