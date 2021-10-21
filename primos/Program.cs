using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace Balta_Desafios
{
    public class Numero
    {
        public int Value { get; set; }
        public string Tipo { get; set; }

        public Numero() { }
    }
    class Program
    {
        public static Dictionary<int, Numero> ListaNumeros = new Dictionary<int, Numero>();
        static void Main(string[] args)
        {

            string continuar = "S";
            while (continuar == "S")
            {
                try
                {
                    SetRodada(continuar);
                    continuar = Console.ReadLine().ToUpper();
                    continuar = VerificarContinnuar(continuar);
                }
                catch (System.Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("****** Alerta ******");
                    Console.WriteLine("Houve o seguinte erro:\n" + ex.Message + "\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Preessione qualquer teclar para refazer!");
                    Console.ReadKey();
                    continuar = "S";
                }
            }
            Console.WriteLine("\nObrigado e volte sempre!!!");
            Console.ReadKey();
        }
        public static string VerificarContinnuar(string entrada)
        {
            if (entrada == "NAO" || entrada == "N" || entrada == "NÃO")
            {
                return "N";
            }
            else
            {
                return "S";
            }
        }
        public static void SetRodada(string continuar)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("######################");
            Console.WriteLine("### Números Primos ###");
            Console.WriteLine("######################\n");
            Console.Write("Informe um numero: ");
            int input = int.Parse(Console.ReadLine());
            IsPrimeNumber(input);
            ShowTab();
            Console.WriteLine("Para continuar pressione qualquer tecla... ");
            Console.Write("\tou digite n ou nao para sair:  ");
        }
        public static void IsPrimeNumber(int number)
        {
            string tipo = "é PRIMO";
            try
            {
                if (number < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n****** Alerta ******");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Numero não pode negativo ou vazio!\n");
                }
                else
                {
                    int aux = 0;
                    for (var cont = 1; cont <= number; cont++)
                    {
                        if (number % cont == 0)
                            aux++;
                    }
                    if (aux == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        System.Console.WriteLine($"O numero {number} {tipo} \n");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        tipo = "NÃO é PRIMO";
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        System.Console.WriteLine($"O numero {number} {tipo}!!! \n");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    var numero = new Dictionary<int, Numero>();
                    numero.Add(number, new Numero
                    {
                        Tipo = tipo,
                        Value = 0
                    });
                    AddOrUpdate(numero);
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void AddOrUpdate(Dictionary<int, Numero> dic)
        {
            var obj = dic.FirstOrDefault();
            var val = GetValue(obj.Key);
            if (val == 0)
            {
                obj.Value.Value = val + 1;
                ListaNumeros.Add(obj.Key, obj.Value);
            }
            else
            {
                obj.Value.Value = val + 1;
                ListaNumeros[obj.Key] = obj.Value;
            }
        }
        public static int GetValue(int key)
        {
            foreach (var item in ListaNumeros)
            {
                if (item.Key == key)
                    return item.Value.Value;
            }
            return 0;
        }
        public static void ShowTab()
        {
            Console.WriteLine();
            var table = new ConsoleTable("NÚMERO", "QNT", "É PRIMO");
            foreach (var item in ListaNumeros.OrderBy(x => x.Key))
            {
                if (item.Value.Tipo == "é PRIMO")
                    table.AddRow(item.Key, item.Value.Value, " SIM ");
                else
                    table.AddRow(item.Key, item.Value.Value, " NÃO ");
            }
            table.Options.EnableCount = true;
            table.Write();
            Console.WriteLine();
        }
    }
}
