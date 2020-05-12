using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public static class OOPRun
    {
        public static void Run()
        {
            var cl = new PolyConcrete();

            var a = cl.AbstractMethodWithoutBody();

            var b = cl.VirtualFunction();

            var breakdebug = 0;
        }
    }

    public class Shape
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
        public abstract string NotImplementMethod();

        public string ImplementedMethod()
        {
            return "ImplementedMethod";
        }
    }

    class AbstractInherit : ShapeAbstract
    {
        public override string NotImplementMethod()
        {
            return "NotImplementMethod Is Overrided";
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

    public interface ISomething
    {
        string Do();

        int GetNumber();
    }

    public class ChildClass : ParentClass, ISomething
    {
        public new string Do()
        {
            return "Parent";
        }

        public string Child_Method()
        {
            return "Child";
        }

        public int GetNumber()
        {
            return 100;
        }
    }

    public class FlowInstanceId
    {
        public string Id { get; set; }
        public string FlowName { get; set; }


        public FlowInstanceId()
        {

        }

        public FlowInstanceId(string id, string flowName)
        {
            Id = id;
            FlowName = flowName;
        }

        //override method
        public override string ToString()
        {
            return $"FlowId: {Id} of Name: {FlowName}";
        }
    }

    public class ConstantVar
    {
        const string Co = "CONSTANT";
        public ConstantVar()
        {
            //ERROR: 
            //Co = "initValue";
        }
        public ConstantVar(string newValue)
        {
            //ERROR: 
            //Co = newValue;
        }
        public void ChangeValue()
        {
            //ERROR: 
            //Co = "changeValue"; 
        }
    }

    public class ReadonlyVar
    {
        readonly string Re; // ONLY CHANGE during run-time through NON-STATIC CONSTRUCTOR / INITIALIZER
        ReadonlyVar()
        {
            Re = "DefaultConstructValue";
        }
        ReadonlyVar(string newValue)
        {
            Re = newValue;
        }
        void ChangeValue()
        {
            // CAN NOT CHANGE BY METHOD
            // Re = "changeValue"; 
        }
    }

    public class StaticReadonlyVar
    {
        static readonly string SRVar; // ONLY CHANGE STATIC CONSTRUCTOR
        static readonly string SRVarValue = "INIT_VALUE";
        static StaticReadonlyVar()
        {
            SRVar = SRVarValue;
            SRVarValue = "UPDATE_VALUE";
            Console.ReadKey();
        }
    }

    public abstract class Polymorphism
    {
        //STATIC POLYMORPHISM - FUNCTION OVERLOADING
        public string Print(int i)
        {
            return $"Return INT value:" + i;
        }
        public string Print(double f)
        {
            return $"Return INT double:" + f;
        }

        //DYNAMIC POLYMORPHISM
        public abstract string AbstractMethodWithoutBody();

        public virtual string VirtualFunction()
        {
            return "RETURN FROM VIRTUALFUNCTION";
        }
    }

    public class PolyConcrete : Polymorphism
    {
        public override string AbstractMethodWithoutBody()
        {
            return "RETURN ABSTRACTMETHODWITHOUTBODY IN CONCRETE CLASS";
        }

        public override string VirtualFunction()
        {
            return "RETURN VIRTUALFUNCTION IN CONCRETE CLASS";
        }
    }

}
