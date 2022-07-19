using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MontyHallProblem.Porta;

namespace MontyHallProblem
{
    internal class MegaSena
    {
        public int acertos;
        public int erros;
        public bool vitorioso;

        public static void MegaMain()
        {
            double vitorias = 0;
            double derrotas = 0;
            double acertos = 0;
            double erros = 0;
            double winrate;
            double loserate;
            Stopwatch stopwatch = new Stopwatch();
            Random r = new Random();            
            int quantidade = 0;
            List<int> escolha = new List<int>();
            escolha.Add(5); escolha.Add(10); escolha.Add(15);
            escolha.Add(20); escolha.Add(25); escolha.Add(30);
            MegaSena sortear = new MegaSena();

            List<int> sorteio = new List<int>();

            Console.Write("Informe quantas vezes deseja realizar a simulação: ");
            quantidade = coletarImput();

            stopwatch.Start();
            Console.WriteLine("\n========================================");
            Console.Write("Realizando simulações... ");

            for (int i = 0; i < quantidade; i++)
            {
                
                sortear = Sortear(r, escolha, sorteio);
                acertos = acertos + sortear.acertos;
                erros = erros + sortear.erros;
                if (sortear.vitorioso == true)
                {
                    vitorias = vitorias + 1;
                }
                if (sortear.vitorioso == false)
                {
                    derrotas = derrotas + 1;
                }
            }
            stopwatch.Stop();

            winrate = getWinrate(vitorias, derrotas, true, quantidade);
            loserate = getWinrate(vitorias, derrotas, false, quantidade);
            double total = acertos + erros;
            double porcentagemAcertos = 100 * acertos / total;
            double porcentagemErros = 100 * erros / total;

            Console.WriteLine("\nVitórias: " + vitorias);
            Console.WriteLine("Derrotas: " + derrotas);

            Console.WriteLine("\nAcertos: " + acertos);
            Console.WriteLine("Erros: " + erros) ;
            Console.WriteLine("Taxa de acertos: " + porcentagemAcertos);
            Console.WriteLine("Taxa de erros: " + porcentagemErros);

            Console.WriteLine("\nWinrate obtida: " + winrate + "%");
            Console.WriteLine("Loserate obtida: " + loserate + "%");

            double tempoDecorrido = stopwatch.ElapsedMilliseconds / 1000;
            Console.WriteLine("\nTempo de execução: " + tempoDecorrido + "." + stopwatch.ElapsedMilliseconds % 100 + "s");
            Console.WriteLine("=======================================================");
            Console.WriteLine("|Informações utilizadas:                              |");
            Console.WriteLine("|-Você sempre aposta nos números 5, 10, 15, 20, 25, 30|");
            Console.WriteLine("|-O computador escolhe 6 números aleatórios de 1 a 60 |");            
            Console.WriteLine("=======================================================");
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        public static MegaSena Sortear(Random r, List<int> escolha, List<int> sorteio)
        {
            MegaSena retorno = new MegaSena();
            sorteio.Clear();
            for (int i = 0; i < 6; i++)
            {
                sorteio.Add(r.Next(0, 61));
            }
            for (int i = 0; i < escolha.Count; i++)
            {
                if (sorteio.Contains(escolha.ElementAt(i)))
                {
                    retorno.acertos++;
                }
                else
                {
                    retorno.erros++;
                }
            }

            if (retorno.acertos == 6)
            {
                retorno.vitorioso = true;
                return retorno;
            }
            else
            {
                retorno.vitorioso = false;
                return retorno;
            }

        }

    }
}
