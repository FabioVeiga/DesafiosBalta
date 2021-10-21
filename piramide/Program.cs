using System;

namespace piramide
{
    class Program
    {
        const char SYMBOL = '#';
        const char SPACE = ' ';
        const int DEFAULT = 5;
        static void Main(string[] args)
        {
            string toContinue = "S";
            while (toContinue == "S")
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"***** PIRAMIDE *****");
                    Console.Write($" Digite o valor da piramide: ");
                    int size = int.Parse(Console.ReadLine());
                    GetSides(size);
                    Console.WriteLine("Para continuar pressione qualquer tecla... ");
                    Console.Write("\tou digite n ou nao para sair:  ");
                    toContinue = CheckContinue(Console.ReadLine().ToUpper());
                }
                catch (System.Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("****** Alerta ******");
                    Console.WriteLine("Houve o seguinte erro:\n" + ex.Message + "\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Preessione qualquer teclar para refazer!");
                    Console.ReadKey();
                    toContinue = "S";
                }
            }
            Console.WriteLine("\nObrigado e volte sempre!!!");
            Console.ReadKey();
        }

         public static string CheckContinue(string input)
        {
            if (input == "NAO" || input == "N" || input == "NÃO")
            {
                return "N";
            }
            else
            {
                return "S";
            }
        }

        private static void GetSides(int size)
        {
            if(size <= 0)
                size = DEFAULT;
            
            var leftSide = LeftSide(size);
            var rightSide = RightSide(size);
            BuildTriangle(leftSide, rightSide);
        }
        public static string[] LeftSide(int size)
        {
            Console.WriteLine($"Left side ---------->");
            string[] result = new string[size];
            string line = string.Empty;
            for (var i = 0; i < size; i++)
            {
                line += SYMBOL.ToString();
                result[i] = line;
                Console.WriteLine($"{line}");
            }
            Console.WriteLine($"");
            return result;
        }

        public static string[] RightSide(int size)
        {
            Console.WriteLine($"Right side <----------");
            string[] result = new string[size];
            string line = string.Empty;
            int spaces = size - 1;
            int qtSymbos = 1;
            for (var i = 0; i < size; i++)
            {
                line = string.Empty;
                for (var j = 0; j < spaces; j++)
                {
                    line += SPACE.ToString();
                }
                for (var j = 0; j < qtSymbos; j++)
                {
                    line += SYMBOL.ToString();   
                }
                result[i] = line;
                Console.WriteLine($"{line}");
                spaces--;
                qtSymbos++;
            }
            Console.WriteLine($"");
            return result;
        }

        private static void BuildTriangle(string[] left, string[] right)
        {
            Console.WriteLine($"<---------- Triangle ---------->");
            string[] mergedSides = new string[left.Length];
            for (var i = 0; i < right.Length; i++)
            {
                mergedSides[i] = right[i] + left[i];
            }
            foreach (var item in mergedSides)
            {
                Console.WriteLine($"{item}");
                
            }
        }
    }
}
