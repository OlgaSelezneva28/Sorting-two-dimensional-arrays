using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Прямоугольный массив 
            int n, m; 
            Console.WriteLine("Введите размер n - строк, m - столбцов");
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[,] arr = new int[n, m];

            //Заполнение массива
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    arr[i , j] = rnd.Next(0, 500);
                }
            }
            //Вывод исходного массива
            Console.WriteLine(" Исходный массив:  ");
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Console.Write( arr[i , j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            //Сортировка пузырьком 

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        for (int r = 0; r < m; r++)
                        {
                            if (arr[i, j] < arr[k, r])
                            {

                                int tmp = arr[i, j];
                                arr[i, j] = arr[k, r];
                                arr[k, r] = tmp;
                            }
                        }
                    }
                }
            }
            Console.WriteLine();


            // Вывод отсортированного массива 
            Console.WriteLine(" Отсортированный массив");
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ReadKey(true);
        }
    }
}
