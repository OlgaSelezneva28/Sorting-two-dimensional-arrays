using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        //Сравнение покоординатно 
        static bool less(int i1, int j1, int i2, int j2)
        {

            if (i1 < i2)
            {
                return true;
            }
            if (i1 == i2)
            {
                if (j1 < j2)
                    return true;
                else 
                    return false;
            }
       

            return false;
        }

        //Меньше либо равно 
        static bool less_equal(int i1, int j1, int i2, int j2)
        {
            if (i1 < i2)
            {
                return true;
            }
            if (i1 == i2)
            {
                if (j1 <= j2)
                    return true;
            }

            return false;
        }

        //Находит координаты средних элементов 
        static int[] M1(int[][] A, int i1, int j1, int i2, int j2 )
        {
            int[] rez = new int[4];

            if (!less(i1, j1, i2, j2))
            {
                int t1 = i1;
                i1 = i2;
                i2 = t1;

                t1 = j1;
                j1 = j2;
                j2 = t1;
            }

            int i = i1;
            int j = j1;
            int mid = 1;
            while ((i != i2) || (j != j2))
            {
                mid++;
                //i jj
                if (j == A[i].Count() - 1)
                {
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }

            }
            mid /= 2;

            int otschet = 1;
            int ii = i1;
            int jj = j1;
            while ((ii != i2) || (jj != j2))
            {
                
                if (otschet == mid)
                {
                    rez[0] = ii;
                    rez[1] = jj;

                    if (jj == A[ii].Count() - 1)
                    {
                        ii++;
                        jj = 0;
                    }
                    else
                    {
                        jj++;
                    }
                    
                    rez[2] = ii;
                    rez[3] = jj;
                    return rez;
                }

                //ii jj
                if (jj == A[ii].Count() - 1)
                {
                    ii++;
                    jj = 0;
                }
                else
                {
                    jj++;
                }
                otschet++;
                
            }


                return rez;

        }

        //Функция, сливающая массивы
        static void Merge(int[][] A, int i1, int j1, int i2, int j2)
        {
            int[] middle = new int[4];
            middle = M1(A, i1, j1, i2, j2);

            int istart = i1;
            int jstart = j1;
            int ifinal = middle[2];
            int jfinal = middle[3];

            int[][] mas = new int[A.Count()][];
            for (int ii = 0; ii < A.Count(); ii++)
            {
                mas[ii] = new int[A[ii].Count()];
            }


            int i = i1;
            int j = j1;
            bool flag = true; 
            while(((i != i2) || (j != j2)) || flag)
            {
               
                    if (less_equal(istart, jstart, middle[0], middle[1]) && ( less(i2, j2, ifinal, jfinal) || (A[istart][jstart] < A[ifinal][jfinal])))
                    {
                        mas[i][j] = A[istart][jstart];

                        //Вычисляем слудующие стартовые i j 
                        if ((jstart == A[istart].Count() - 1) && (istart != A.Count() - 1))
                        {
                            istart ++;
                            jstart = 0;
                        }
                        else
                        {
                            jstart ++;
                        }
                    }
                    else {

                        
                        mas[i][j] = A[ifinal][jfinal];

                        //Вычисляем слудующие финальные i j
                        if ((jfinal == A[ifinal].Count() - 1) && (ifinal != A.Count() - 1))
                        {
                            ifinal ++;
                            jfinal = 0;
                        }
                        else
                        {
                            jfinal ++;
                        }
                    }

                    if ((i == i2) && (j == j2))
                    {
                        flag = false;
                        break;
                    }
                    //i j - обновляем 
                    if (j == A[i].Count() - 1)
                    {
                        i++;
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
            }



            //Возвращаем результат в исходный массив
            i = i1;
            j = j1;
            flag = true;
            while (((i != i2) || (j != j2)) || flag)
            {
                A[i][j] = mas[i][j];
                if ((i == i2) && (j == j2))
                {
                    flag = false;
                    break;
                }

                //i j - обновляем 
                if ((j == A[i].Count() - 1) && (i != A.Count() - 1))
                {
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }
            }


        }

        //Рекурсивная функция сортировки
        static void MergeSort(int[][] A, int i1, int j1, int i2, int j2)
        {
            if (less(i1, j1, i2, j2))
            {
                int []middle1 = new int[4];

                middle1 = M1(A, i1, j1, i2, j2); // координаты серединных аргументов 

                MergeSort(A, i1, j1, middle1[0], middle1[1]); //сортировка левой части
                MergeSort(A, middle1[2], middle1[3], i2, j2); //сортировка правой части
                Merge(A, i1, j1, i2, j2); //слияние двух частей
            }
        }


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


            //Сортировка слиянием 
            MergeSort(arr, 0, 0, n - 1, arr[n - 1].Count() - 1);
            
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
