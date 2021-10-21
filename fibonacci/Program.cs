using System;

namespace fibonacci
{
    class Program
    {
        public static string continuos = "S";
        static void Main(string[] args)
        {
            while (continuos == "S")
            {
                try
                {
                    Console.Clear();
                    int sizeNumber = 0;
                    Console.Write("Digite o tamanho da sequencia: ");
                    sizeNumber = int.Parse(Console.ReadLine());
                    PrintSequence(sizeNumber);
                    Console.ReadKey();
                }
                catch (System.Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("****** Alerta ******");
                    Console.WriteLine("Houve o seguinte erro:\n" + ex.Message + "\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Pressione qualquer teclar para refazer!");
                    Console.ReadKey();
                    continuos = "S";
                }
            }
        }
        public static int FibonacciSequence(int value)
        {
            if (value == 0 || value == 1)
                return 1;
            else
                return FibonacciSequence(value - 1) + FibonacciSequence(value - 2);
        }
        public static void PrintSequence(int sizeNumber)
        {
            if(sizeNumber < 0)
            {
                Console.WriteLine("Número negativo, entrada invalida!");
                Console.WriteLine("Pressione qualquer teclar pra refazer!");
                continuos = "S";
                return;
            }

            Console.WriteLine("\nSequencia para o número: " + sizeNumber);
            for (int i = 0; i <= sizeNumber; i++)
            {
                Console.Write(" " + FibonacciSequence(i + 1));
            }
            Console.WriteLine("\nObrigado!!!!");
            continuos = "n";
        }
    }
}
