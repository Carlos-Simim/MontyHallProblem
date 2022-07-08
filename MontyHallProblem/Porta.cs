using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem
{
    internal class Porta
    {
        public bool estado;
        public bool carro;
        public int numero;

        public Porta()
        {
            this.estado = false;
            this.carro = false;
           
        }

        public static bool Sortear(Random r)
        {
            
            Porta p1 = new Porta();
            p1.numero = 1;
            Porta p2 = new Porta();
            p2.numero = 2;
            Porta p3 = new Porta();
            p3.numero = 3;
            int escolha = 1;
            int sortearporta = r.Next(0, 100); //Acho que ta com problema aqui
            if (sortearporta <= 33)
            {
                p1.carro = true;

            }
            if (sortearporta > 33 && sortearporta <= 66)
            {
                p2.carro = true;

            }
            if (sortearporta > 66)
            {
                p3.carro = true;

            }



            if (escolha == 1)
            {
                if (p2.carro == true)
                {
                    p3.estado = true;
                }
                if (p3.carro == true)
                {
                    p2.estado = true;
                }

                if (p1.carro == true)
                {
                    sortearporta = r.Next(2);
                    switch (sortearporta)
                    {
                        case 0:
                            p2.estado = true;
                            break;

                        case 1:
                            p3.estado = true;
                            break;
                    }
                }
            }

            if (escolha == 1)
            {
                if (p2.estado == true)
                {
                    escolha = 3;
                }
                if (p3.estado == true)
                {
                    escolha = 2;
                }
            }

            if (escolha == 2)
            {
                if (p2.carro == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (escolha == 3)
            {
                if (p3.carro == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            Console.WriteLine("Bugou!");
            return false;
        }

        public static double getWinrate(double vitorias, double derrotas, bool escolha, double quantidade)
        {
            
            double toreturn = 0;

            if(escolha == true) toreturn = (100*vitorias)/ quantidade;

            if(escolha == false) toreturn = (100*derrotas)/ quantidade;


            return toreturn;
        }

        public static int coletarImput()
        {
            bool erro = true;
            int quantidade = 0;
            int contadorErros = 7;
            
            String imput = Console.ReadLine();

            while (erro == true)
            {
                erro = false;
                try
                {
                    quantidade = Int32.Parse(imput);
                }
                catch (System.FormatException)
                {
                    Console.Write("\nErro no input do usuário!");
                    if (contadorErros <= 10)
                    {
                        Console.Write("\nPor favor, responda apenas com números inteiros. \n");
                    }
                    if (contadorErros > 10)
                    {
                        Console.Write("\nPelo amor de deus, siga as instruções :(((. Exemplo de números inteiros: 1, 2, 3, 4... \n");
                    }
                    Console.Write("Informe a quantidade desejada de simulações: ");
                    imput = Console.ReadLine();
                    erro = true;
                    contadorErros++;
                }
                catch (System.OverflowException)
                {
                    Console.Write("\nInput do usuário é muito grande!");
                    if (contadorErros <= 10)
                    {
                        Console.Write("\nPor favor, insira um número menor. \n");
                    }
                    if (contadorErros > 10)
                    {
                        Console.Write("\nPelo amor de deus, siga as instruções :(((. Exemplo de números não muito grandes: 100, 2000, 3000, 4000... \n");
                    }
                    Console.Write("Informe a quantidade desejada de simulações: ");
                    imput = Console.ReadLine();
                    erro = true;
                    contadorErros++;
                }

                
            }
            return quantidade;
        }

     

    }
}
