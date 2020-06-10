using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public static class DesignPattern
    {
        public static void Run()
        {
            //var color = new Color(100, 200, 300);
            //var shallowColor = color.Clone();

            IShape circle = new DCircle();

            Console.WriteLine("Cricle with normal");
            circle.Draw();

            var redRectangle = new RedShapeDecorator(new DRectangle());

            Console.WriteLine("redRectangle");
            redRectangle.Draw();

            var _debug = 0;
        }
    }


    #region //PROTOTYPE - CREATE NEW OBJECTS BY COPYING PROTOTYPICAL INSTANCE
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", _red, _green, _blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }
    #endregion


    #region //DECORATOR
    //add new functionality to an existing object without altering its structure. 
    //This type of design pattern comes under structural pattern as this pattern acts as a wrapper to existing class.

    public interface IShape
    {
        void Draw();
    }

    public class DRectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }
    public class DCircle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }
    }
    public abstract class ShapeDecorator : IShape
    {
        protected IShape _decoratedShape;

        public ShapeDecorator(IShape decoratedShape)
        {
            _decoratedShape = decoratedShape;
        }
        public void Draw()
        {
            _decoratedShape.Draw();
        }
    }
    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape decoratedShape) : base(decoratedShape)
        {

        }
        public void Draw()
        {
            base.Draw();
            SetRedBorder(_decoratedShape);
        }
        private void SetRedBorder(IShape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    } 
    #endregion
}
