using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MontyHallProblem.Porta;

namespace MontyHallProblem
{
    internal class MontyHall
    {

        public static void MontyHallMain()
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

            Console.WriteLine("Finalizado.");
            // Thread.Sleep(2000);

            stopwatch.Stop();

            winrate = getWinrate(vitorias, derrotas, true, quantidade);
            loserate = getWinrate(vitorias, derrotas, false, quantidade);

            Console.WriteLine("Vitórias: " + vitorias);
            Console.WriteLine("Derrotas: " + derrotas);

            Console.WriteLine("\nWinrate esperado no problema: 66.666%");
            Console.WriteLine("Winrate obtido: " + winrate + "%");

            Console.WriteLine("\nLoserate esperado no problema: 33.333%");
            Console.WriteLine("Loserate obtido: " + loserate + "%");

            double tempoDecorrido = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nTempo de execução: " + tempoDecorrido + "." + stopwatch.ElapsedMilliseconds % 100 + "s");
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("|Informações utilizadas:                                                            |");
            Console.WriteLine("|-Você sempre escolhe a 1° porta                                                    |");
            Console.WriteLine("|-Você sempre troca quando o host abre uma porta                                    |");
            Console.WriteLine("|-Existe 33.33% de chance de cair em cada porta                                     |");
            Console.WriteLine("|-Você só perde se cair na 1° porta, leia mais sobre o problema caso tenha dúvidas  |");
            Console.WriteLine("|-Observação: A winrate está um pouco fora do esperado por erro no cálculo de vitória");
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
