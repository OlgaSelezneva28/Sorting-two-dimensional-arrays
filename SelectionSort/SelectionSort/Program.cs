using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
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
                    arr[i, j] = rnd.Next(0, 500);
                }
            }
            //Вывод исходного массива
            Console.WriteLine(" Исходный массив:  ");
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            //Сортировка выбором 

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int min_index1 = i;
                    int min_index2 = j;

                    if ((i == n - 1) && (j == m - 1))
                        break;

                    for (int k = i; k < n; k++)
                    {
                        for (int r = 0; r < m; r++)
                        {
                            if ((k == i) && (r <= j))
                                continue;

                            if (arr[k, r] < arr[min_index1, min_index2])
                            {
                                min_index1 = k;
                                min_index2 = r;
                            }
                        }
                    }

                    if ((min_index1 != i) || (min_index2 != j))
                    {
                        int tmp = arr[i, j];
                        arr[i, j] = arr[min_index1, min_index2];
                        arr[min_index1, min_index2] = tmp;
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
