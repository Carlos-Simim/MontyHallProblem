using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Random r = new Random();
            bool sortear;
            int quantidade = 10000000;

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

            winrate = Porta.getWinrate(vitorias, derrotas, true, quantidade);
            loserate = Porta.getWinrate(vitorias, derrotas, false, quantidade);

            Console.WriteLine("Vitórias: " + vitorias);
            Console.WriteLine("Derrotas: " + derrotas);

            Console.WriteLine("\nWinrate esperado no problema: 66.666%");
            Console.WriteLine("Winrate obtido: " + winrate + "%");
            
            Console.WriteLine("\nLoserate esperado no problema: 33.333%");
            Console.WriteLine("Loserate obtido: " + loserate + "%");

            Console.ReadLine();

        }
    }
}
