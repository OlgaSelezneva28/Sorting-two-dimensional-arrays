using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Изрезанный (Зубчатый) массив 
            int n;
            Console.WriteLine("Введите число строк n");
            n = Convert.ToInt32(Console.ReadLine());
            
            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите количество элементов строки  ");
                Console.WriteLine( i );
                int m = Convert.ToInt32(Console.ReadLine());

                arr[i] = new int[m];
            }
                
            Console.WriteLine();

            

            //Заполнение массива
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < arr[i].Count(); j++)
                {
                    arr[i][j] = rnd.Next(0, 500);
                }
            }
            //Вывод исходного массива
            Console.WriteLine(" Исходный массив:  ");
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < arr[i].Count(); j++)
                {
                    Console.Write(arr[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            //Сортировка вставками 
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < arr[i].Count(); j++)
                {
                    if ((i == n - 1) && (j == arr[n - 1].Count() - 1))
                        break;


                    //Определим следующий элемент
                    int i1 = i;
                    int j1 = j;
                    int tmp = arr[i1][j1];

                    //Является ли элемент крайним правым
                    if (j == arr[i].Count() - 1)//yes
                    {
                        i1 = i + 1;
                        j1 = 0;
                        tmp = arr[i1][j1];
                    }
                    else // следующий элемент в строке
                    {
                        i1 = i;
                        j1 = j + 1;
                        tmp = arr[i1][j1];
                    }

                    int k = i1;
                    int r = j1;

                    while ((k > 0) || (r > 0))
                    {

                        //Вычислим предыдущий элемент 
                        int ipr = k;
                        int jpr = r;

                        if ((r == 0) && (k != 0))
                        {
                            ipr = k - 1;
                            jpr = arr[ipr].Count() - 1;
                        }
                        else
                        {
                            ipr = k;
                            jpr = r - 1;
                        }


                        if (tmp < arr[ipr][jpr])
                        {
                            arr[k][r] = arr[ipr][jpr];
                            i1 = ipr;
                            j1 = jpr;
                        }

                        k = ipr;
                        r = jpr;

                    }

                    arr[i1][j1] = tmp;
                }
            }
            Console.WriteLine();
            

            // Вывод отсортированного массива 
            Console.WriteLine(" Отсортированный массив");
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < arr[i].Count(); j++)
                {
                    Console.Write(arr[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            Console.ReadKey(true);
        }
    }
}
