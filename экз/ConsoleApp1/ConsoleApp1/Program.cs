using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                int i = 0;
                int j = 0;
                int n;

            s1: Console.Clear();
                Console.WriteLine("метод с/з");
                Console.WriteLine("Введите количество покупателей");
                n = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[n];

                Console.WriteLine("Введите количество продавцов");
                int m = Convert.ToInt32(Console.ReadLine());
                int[] b = new int[m];
                int suma = 0;
                int sumb = 0;
                Transport[,] C = new Transport[n, m];
                Console.WriteLine(" сколько имеется");
                for (i = 0; i < a.Length; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                    suma = suma + a[i];
                }
                Console.WriteLine("сколько необходимо");
                for (j = 0; j < b.Length; j++)
                {
                    b[j] = Convert.ToInt32(Console.ReadLine());
                    sumb = sumb + b[j];
                }
                if (suma != sumb)
                {
                    Console.WriteLine("Количество покупателей и продавцов не совпадает");
                    System.Threading.Thread.Sleep(1500);
                    goto s1;
                }

                Console.WriteLine(" цены");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        Console.Write("Цена [{0},{1}] = ", i + 1, j + 1);

                        C[i, j].znachenie = Convert.ToInt32(Console.ReadLine());

                    }
                }

                while (true)
                {
                s3: Console.WriteLine();
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            if (C[i, j].dostavka != 0)
                            {

                                Console.Write("{0}", C[i, j].znachenie);

                                Console.Write("({0})", C[i, j].dostavka);
                            }
                            else
                                Console.Write("{0}({1})", C[i, j].znachenie, C[i, j].dostavka);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("верно ввели значения? [0/1]");
                    int ans = Int32.Parse(Console.ReadLine());
                    if (ans == 1) break;
                    if (ans == 0)
                    {
                    s2: Console.WriteLine("Выберите что вы хотите заменить:");
                        Console.WriteLine("1.Количество имеющегося  " +
                            "\n2.Кол-во необходимого . " +
                            "\n3.Цены товаров.");

                        int vib = Int32.Parse(Console.ReadLine());
                        switch (vib)
                        {
                            case 1:
                                Console.WriteLine("Введите номер записи, которую хотите изменить:");
                                int c = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите новое значение:");
                                a[c] = Int32.Parse(Console.ReadLine());
                                if (suma != sumb)
                                {
                                    Console.WriteLine("Количество покупателей и продавцов не совпадает");
                                    System.Threading.Thread.Sleep(1500);
                                    goto s2;
                                }
                                goto s3;
                            case 2:
                                Console.WriteLine("Введите номер записи, которую хотите изменить:");
                                c = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите новое значение:");
                                b[c] = Int32.Parse(Console.ReadLine());
                                if (suma != sumb)
                                {
                                    Console.WriteLine("Количество покупателей и продавцов не совпадает");
                                    System.Threading.Thread.Sleep(1500);
                                    goto s2;
                                }
                                goto s3;
                            case 3:
                                Console.WriteLine("Введите номер записи, которую хотите изменить:");
                                Console.WriteLine("Строка:");
                                c = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Столбец:");
                                int s = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите новое значение:");
                                C[c - 1, s - 1].znachenie = Convert.ToInt32(Console.ReadLine());
                                goto s3;
                            default:
                                Console.WriteLine("Выбор некорректен, повторите попытку!"); System.Threading.Thread.Sleep(1500);
                                goto s2;
                        }
                    }

                }


                i = j = 0;
                while (i < n && j < m)
                {

                    try
                    {
                        if (a[i] == 0) { i++; }
                        if (b[j] == 0) { j++; }
                        if (a[i] == 0 && b[j] == 0) { i++; j++; }
                        C[i, j].dostavka = Transport.MinEl(a[i], b[j]);
                        a[i] -= C[i, j].dostavka;
                        b[j] -= C[i, j].dostavka;

                    }
                    catch { }

                }
                Console.Clear();
                Console.WriteLine();
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        if (C[i, j].dostavka != 0)
                        {

                            Console.Write("{0}", C[i, j].znachenie);

                            Console.Write("({0})", C[i, j].dostavka);
                        }
                        else
                            Console.Write("{0}({1})", C[i, j].znachenie, C[i, j].dostavka);
                    }
                    Console.WriteLine();
                }
                int ResultFunction = 0;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++) { ResultFunction += (C[i, j].znachenie * C[i, j].dostavka); }
                }
                Console.WriteLine();
                Console.WriteLine("Ответ = {0} у.д.е.", ResultFunction);
                Console.ReadKey();

            }

        }
    }

}

