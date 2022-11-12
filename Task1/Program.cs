using System;
using System.Threading;

namespace Task1
{
    internal class Program
    {
        const int n = 10;
        const int m = 10;
        
        static int[,] path = new int[n, m]              // Двумерный массив. Сад
        {
            { 50, 1, 1, 1, 1, 1, 1, 1, 10, 2 },
            { 1, 1, 1, 1, 1, 1, 25, 1, 1, 11 },
            { 4, 1, 10, 6, 3, 9, 4, 5, 4, 2 },
            { 6, 5, 5, 8, 7, 9, 5, 16, 4, 2 },
            { 7, 6, 2, 6, 10, 7, 5, 7, 4, 9 },
            { 10, 10, 10, 6, 9, 15, 5, 16, 4, 2 },
            { 8, 6, 19, 6, 0, 9, 14, 5, 4, 15 },
            { 2, 5, 10, 15, 11, 6, 5, 16, 4, 2 },
            { 5, 4, 5, 17, 16, 8, 5, 7, 4, 112 },
            { 1, 5, 16, 6, 1, 19, 20, 16, 4, 2 }
        };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();
            Console.WriteLine("Поле: \n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($" {path[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n-1: - Садовник 1\n-2: - Садовник 2");
            Console.ReadKey();
        }
        static void Gardner1()                                                // Садовник 1
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }

        static void Gardner2()                                              // Садовник 2
        {
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (path[j, i] >= 0)
                    {
                        int delay = path[j, i];
                        path[j, i] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
