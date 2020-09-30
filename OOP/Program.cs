using NUnit.Framework;
using NUnit.Framework.Constraints;
using OOP.EF_CodeFirst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            SchoolContextRun.Run();

            //OOPRun.Run();

            //DesignPattern.Run();

            Console.ReadLine();
        }

        public static (int _sum, int _subtract) Cal(int a, int b)
        {
            return (a + b, a - b);
        }

    }

    public class Step
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
