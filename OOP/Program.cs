using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(10, 20);

            var hcn = new ChuNhat();
            hcn.SetWidth(7);
            hcn.SetHeight(3);
            var result1 = AreaCalculator.CalculateArea(hcn);

            var hv = new Vuong();
            hv.SetWidth(7);
            hv.SetHeight(3);
            var result2 = AreaCalculator.CalculateArea(hv);


            Console.ReadLine();



        }
    }

    class Shape
    {
        protected int width, height;

        public Shape(int a = 0, int b = 0)
        {
            width = a;
            height = b;
        }
        public virtual int area()
        {
            Console.WriteLine("Parent class area :");
            return 0;
        }
    }

    sealed class Rectangle : Shape
    {
        public Rectangle(int a = 0, int b = 0) : base(a, b)
        {
        }
        public override int area()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * height);
        }
    }

    abstract class ShapeAbstract
    {
        public abstract int NotImplementMethod();

        public int ImplementedMethod()
        {
            return 100;
        }
    }

    class AbstractInherit : ShapeAbstract
    {
        public override int NotImplementMethod()
        {
            return 200;
        }
    }

    public class Apple
    {
        public virtual string GetColor()
        {
            return "Red";
        }
    }
    
    public class Orange : Apple
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }

    public class ChuNhat
    {
        protected int _width;
        protected int _height;
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }

        public virtual void SetWidth(int width)
        {
            _width = width;
        }
        public virtual void SetHeight(int height)
        {
            _height = height;
        }
        public int getArea()
        {
            return _width * _height;
        }
    }

    public class Vuong : ChuNhat  
    {
        public override void SetWidth(int width)
        {
            _width = width;
            _height = width;
        }

        public override void SetHeight(int height)
        {
            _height = height;
            _width = height;
        }
    }

    public class AreaCalculator
    {
        public static int CalculateArea(ChuNhat r)
        {
            return r.Height * r.Width;
        }

        public static int CalculateArea(Vuong s)
        {
            return s.Height * s.Height;
        }
    }

    public class ParentClass 
    {
        public string Do()
        {
            return "Parent";
        }
    }

    public class ChildClass: ParentClass, ISomething
    {
        public new string Do()
        {
            return "Parent";
        }

        public string Child_Method()
        {
            return "Child";
        }
    }

    public interface ISomething
    {
        string Do();
    }
}
