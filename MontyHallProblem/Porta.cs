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

     

    }
}
