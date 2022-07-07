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
            int vitorias = 0;
            int derrotas = 0;
            
            Porta p1 = new Porta();
            Porta p2 = new Porta();
            Porta p3 = new Porta();
            Porta escolha;
            Random r = new Random();
            int sortearporta;

            for (int i = 0; i < 5; i++)
            {
                p1 = new Porta();
                p1.numero = 1;   
                p2 = new Porta();
                p2.numero = 2;
                p3 = new Porta();
                p3.numero = 3;
                escolha = p1;
                sortearporta = r.Next(1, 3); //Acho que ta com problema aqui
                if(sortearporta == 1)
                {
                    p1.carro = true;
                    p1.cabra = false;
                }
                if(sortearporta == 2)
                {
                    p2.carro = true;
                    p2.cabra = false;
                }
                if(sortearporta == 3)
                {
                    p3.carro = true;
                    p3.cabra = false;
                }
                


                if (escolha == p1)
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
                        sortearporta = r.Next(2, 3);
                        switch (sortearporta)
                        {
                            case 2:
                                p2.estado = true;
                                break;

                            case 3:
                                p3.estado = true;
                                break;
                        }
                    }
                }

                if (escolha == p1)
                {
                    if(p2.estado == true)
                    {
                        escolha = p3;
                    }
                    if(p3.estado == true)
                    {
                        escolha = p2;
                    }
                }


                Console.WriteLine("\ncarro de p1: " + p1.carro);
                Console.WriteLine("carro de p2: " + p2.carro);
                Console.WriteLine("carro de p3: " + p3.carro);

                Console.WriteLine("Escolha final: " + escolha.numero);


                
            }
            Console.ReadLine();




        }
    }
}
