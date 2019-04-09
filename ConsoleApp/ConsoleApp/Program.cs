using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            double soma = 0;
            int cont = 0;
            int[] inteiros = { 3, 12, 7, 5, 9, 10, 23, 4, 34, 11 };

            
            Media(inteiros, soma, cont);
            Invertido(inteiros);
        }
        static void Media(int[] inteiros, double soma, int contador)
        {
            foreach (var item in inteiros)
                soma += item;

            //Encontrando o número de elementos maiores do que a média
            foreach (var i in inteiros)
            {
                if (i > soma / inteiros.Length)
                    contador++;
            }
            Console.Write("Metódo recursivo Média: ");
            Console.WriteLine(soma / inteiros.Length);
            Console.Write("Número de elementos maiores do que a média: ");
            Console.WriteLine(contador);
            

        }
        static void Invertido(int[] inteiros)
        {
            Array.Reverse(inteiros, 0, inteiros.Length);

            Console.Write("Lista invertida: ");
            Console.WriteLine("{0}", string.Join(", ", inteiros));
            Console.ReadLine();

        }
    }
}
