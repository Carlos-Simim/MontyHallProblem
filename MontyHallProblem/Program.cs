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
            int escolhaPrincipal;
            bool continuar = true;
            String input;
            int contagemErros = 0;

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
    }
}
