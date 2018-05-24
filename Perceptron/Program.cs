using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static double taxaAprendizado = 0.2;
        static double[] pesos = new double[2] { 0.5,0.5 };
        static int somaErros;

        static void Main(string[] args)
        {
            int i = 0;

            do
            {
                somaErros = 0;

                Treinar(new int[] { 10, 21 }, 0);
                Treinar(new int[] { -10, -21 }, 1);
                Treinar(new int[] { 5, 11 }, 0);
                Treinar(new int[] { -5, -11 }, 1);
                Treinar(new int[] { 1, 1 }, 0);
                Treinar(new int[] { -1, 41 }, 1);
                Treinar(new int[] { -1, 1 }, 1);

                Console.WriteLine($"Ciclo: {++i}, erros: {somaErros}");

            } while (somaErros != 0);


            Console.WriteLine("{0} - 0", Testar(new int[] { 10, 21 }));
            Console.WriteLine("{0} - 1", Testar(new int[] { -10, -21 }));
            Console.WriteLine("{0} - 0", Testar(new int[] { 5, 11 }));
            Console.WriteLine("{0} - 1", Testar(new int[] { -11, -5 }));
            Console.WriteLine("{0} - 0", Testar(new int[] { 20, 0 }));
            Console.WriteLine("{0} - 1", Testar(new int[] { -20, 41 }));


            Console.ReadKey();
        }

        static void Treinar(int[] entrada, int saidaDesejada)
        {
            int erro;
            int saida = Testar(entrada);

            if (saida != saidaDesejada)
            {
                erro = saidaDesejada - saida;
                somaErros += Math.Abs(erro);
                AtualizarPesos(entrada, erro);
            }
        }

        private static void AtualizarPesos(int[] entrada, int erro)
        {
            for (int i = 0; i < entrada.Length; i++)
                pesos[i] = pesos[i] + taxaAprendizado * erro * entrada[i];
        }

        private static int Testar(int[] entrada)
        {
            double net = 0;

            for (int i = 0; i < entrada.Length; i++)
                net += entrada[i] * pesos[i];

            return Degrau(net);
        }

        private static int Degrau(double net)
        {
            return (net > 0) ? 1 : 0 ;
        }
    }
}
