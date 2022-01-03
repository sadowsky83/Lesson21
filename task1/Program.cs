using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    class Program
    {
        // Многопоточность
        static int[,] garden;
        static int width;
        static int height;
        static object locker = new object();

        static void Main()
        {
            Console.WriteLine("Введите размеры сада.");
            Console.WriteLine("Введите размер сада по вертикали:");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите размер сада по горизонтали:");
            width = Convert.ToInt32(Console.ReadLine());

            garden = new int[height, width];

            ThreadStart threadStart = new ThreadStart(garden1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            garden2();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private static void garden1()
        {
            lock (locker)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (garden[i, j] == 0)
                            garden[i, j] = 1;
                        Thread.Sleep(1);
                    }
                }
            }
        }
        private static void garden2()
        {
            for (int i = width - 1; i >= 0; i--)
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}