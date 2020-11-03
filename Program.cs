﻿using System;
using System.Reflection.Emit;

class Program
{
    static void Main()
    {
        int maxValueAbs = 1000;
        int accuracy = 3;
        Console.Write("Введите коэффициенты\na: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        if (Math.Abs(a) > maxValueAbs || Math.Abs(b) > maxValueAbs || Math.Abs(c) > maxValueAbs)
        {
            Console.WriteLine("Уравнение имеет слишком большой по модулю коэффициент!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        a = Math.Round(a, accuracy);
        b = Math.Round(b, accuracy);
        c = Math.Round(c, accuracy);
        Solution(a, b, c, accuracy);
        Console.ReadKey();
    }
    static void Solution(double a, double b, double c, int accuracy)
    {
        double D = Math.Pow(b, 2) - 4 * a * c;
        if (D > 0) //b^2 > 4*a*c
        {
            if (a == 0 && c == 0)
            {
                double x = 0;
                Console.WriteLine($"Корень уравнения: {x}");
            }
            else if (a == 0)
            {
                double x = -c / b;
                Console.WriteLine($"Корень уравнения: {x}");
            }
            else if (c == 0)
            {
                double x1 = 0;
                double x2 = -b / a;
                Console.WriteLine($"Корни уравнения: {x1}, {x2}");
            }
            else
            {
                double x1 = Math.Round((-b + Math.Sqrt(D)) / 2 * a, accuracy);
                double x2 = Math.Round((-b - Math.Sqrt(D)) / 2 * a, accuracy);
                Console.WriteLine($"Корни уравнения: {x1}, {x2}");
            }
        }
        else if (D == 0) //b^2 = 4*a*c
        {
            if (b == 0 && a == 0)
            {
                Console.WriteLine("Это не уравнение!");
            }
            else if (b == 0 && c == 0)
            {
                double x = 0;
                Console.WriteLine($"Корень уравнения: {x}");
            }
            else
            {
                double x = Math.Round(-b / 2 * a, accuracy);
                Console.WriteLine($"Корень уравнения: {x}");
            }
        }
        else //b^2 < 4*a*c --> complex numbers
        {
            if (b == 0) //D = - 4*a*c
            {
                double x1 = -Math.Round(Math.Sqrt(-D) / 2 * a, accuracy);
                double x2 = Math.Round(Math.Sqrt(-D) / 2 * a, accuracy);
                Console.WriteLine($"Корни уравнения: {x1}i, {x2}i");
            }
            else
            {
                double x1 = -Math.Round(-b + Math.Sqrt(-D) / 2 * a, accuracy);
                double x2 = Math.Round(-b - Math.Sqrt(-D) / 2 * a, accuracy);
                Console.WriteLine($"Корни уравнения: {x1}i, {x2}i");
            }
        }
    }
}