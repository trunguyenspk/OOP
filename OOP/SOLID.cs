using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public static class SOLID
    {
        public static void SolidRun()
        {
            Apple apple = new Orange();

            Console.WriteLine(apple.GetColor());
        }
    }

    #region OPEN_CLOSE_PRINCIPLE
    public class Customer_NOT_Follow_Open_Close_Principle
    {
        private int _CustType;
        public int CustType
        {
            get
            {
                return _CustType;
            }
            set
            {
                _CustType = value;
            }
        }
        public double getDiscount(double TotalSales)
        {
            if (_CustType == 1)
                return TotalSales - 100;
            else if (_CustType == 2)
                return TotalSales - 200;
            else
                return TotalSales - 50;
        }
    }

    //CUSTOMER CLASS FOLLOW OPEN_CLOSE_PRINCIPLE
    public class Customer
    {
        //Override this method when another CustomerType is added
        public virtual double getDiscount(double TotalSales)
        {
            return TotalSales;
        }

        public virtual void AddCustomer()
        {
            Console.WriteLine("ADDED");
        }
    }

    public class SilverCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 50;
        }
    }

    public class GoldCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 100;
        }
    } 
    #endregion

    #region liskov-substitution-principle
    // https://dotnettutorials.net/lesson/liskov-substitution-principle/
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
    public abstract class Fruit
    {
        public abstract string GetColor();
    }
    public class TraiTao : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }
    }
    public class TraiCam : Fruit
    {
        public override string GetColor()
        {
            return "Orange";
        }
    } 
    #endregion

}
